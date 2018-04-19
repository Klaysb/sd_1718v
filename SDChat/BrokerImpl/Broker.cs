using GroupImpl;
using BrokerInterface;
using UserInterface;
using CentralManagerInterface;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace BrokerImpl
{
    public class Broker : MarshalByRefObject, IBroker
    {

        private ICentralManager manager;
        private readonly ConcurrentDictionary<int, IUser> users = new ConcurrentDictionary<int, IUser>();
        private readonly ConcurrentDictionary<string, Group> groupNames = new ConcurrentDictionary<string, Group>();

        public Broker(ICentralManager manager) => this.manager = manager;

        public void AddUserToGroup(int adderMember, int userNumber, string groupName)
        {
            if(groupNames.TryGetValue(groupName, out Group group))
            {
                if (group.UsersInSameRegion.ContainsKey(adderMember))
                {
                    if (users.ContainsKey(userNumber))
                    {
                        group.UsersInSameRegion.TryAdd(userNumber, userNumber);
                    }
                    else
                    {
                        try
                        {
                            manager.AddUserToGroup(adderMember, userNumber, groupName);
                            group.UsersInAnotherRegion.TryAdd(userNumber, userNumber);
                        } 
                        catch(ArgumentException)
                        {
                            throw; 
                        }
                        catch(Exception)
                        {
                            throw new Exception("Cannot connect to server.");
                        }
                    }
                }
                else throw new ArgumentException($"The user with the number {adderMember} is not part of the group");
            }
            else throw new ArgumentException($"The group {groupName} does not exist."); 
        }

        public void Register(IUser user)
        {
            try
            {
                manager.Register(user.GetUserNumber(), user, this);
                users.TryAdd(user.GetUserNumber(), user);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception("Cannot connect to server.");
            }
        }

        public void RegisterGroup(int userNumber, string groupName)
        {
            try
            {
                CheckIfRegistered(userNumber);
                manager.RegisterGroup(groupName, this);
                var group = new Group(userNumber, groupName);
                group.UsersInSameRegion.TryAdd(userNumber, userNumber);
                groupNames.TryAdd(groupName, group);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception("Cannot connect to server.");
            }
        }

        public void SendMessageToGroup(string groupName, string message, int srcUserNumber)
        {
            CheckIfRegistered(srcUserNumber);
            if (groupNames.TryGetValue(groupName, out Group group))
            {
                users.TryGetValue(srcUserNumber, out IUser srcUser);
                bool exceptionOccurred = false;
                group.UsersInSameRegion.Keys.ToList().ForEach(userNumber =>
                {
                    if (userNumber != srcUserNumber && users.TryGetValue(userNumber, out IUser user))
                    {
                        try
                        {
                            user.AcceptMessage(message, srcUser);
                        }
                        catch (Exception)
                        {
                            exceptionOccurred = true;
                        }
                    }
                });
                try
                {
                    manager.SendMessageToUsers(message, srcUserNumber, group.UsersInAnotherRegion.Keys.ToArray());
                }
                catch (Exception)
                {
                    throw new Exception("Could not send message to users outside of your region.");
                }

                if (exceptionOccurred) throw new Exception("Could not send message to all users.");
            }
            else throw new ArgumentException($"The group {groupName} does not exist.");
        }

        public void SendMessageToUser(int destUserNumber, string message, int srcUserNumber)
        {
            users.TryGetValue(srcUserNumber, out IUser srcUser);
            try
            {
                if (users.TryGetValue(destUserNumber, out IUser user))
                {
                    user.AcceptMessage(message, srcUser);
                }
                else
                {
                    manager.SendMessageToUsers(message, srcUserNumber, destUserNumber);
                }
            }
            catch (Exception) { throw new Exception("Could not send message to user."); }
        }

        public void Unregister(int userNumber)
        {
            CheckIfRegistered(userNumber);
            try
            {
                manager.Unregister(userNumber);
                users.TryRemove(userNumber, out IUser user);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch(Exception)
            {
                throw new Exception("Cannot connect to server.");
            }
        }

        public void UnregisterGroup(string groupName, int userNumber)
        {
            CheckIfRegistered(userNumber);
            if(!groupNames.TryGetValue(groupName, out Group group))
            {
                throw new ArgumentException($"Group with name {groupName} does not exist.");
            }

            if(group.Owner != userNumber)
            {
                throw new ArgumentException("You do not have permission to delete this group.");
            }
            
            try
            {
                manager.UnregisterGroup(groupName);
                groupNames.TryRemove(groupName, out Group g);
            }
            catch(ArgumentException)
            {
                throw;
            }
            catch(Exception)
            {
                throw new Exception("Cannot connect to server.");
            }
        }

        private void CheckIfRegistered(int userNumber)
        {
            if (!users.ContainsKey(userNumber))
                throw new ArgumentException($"User with number {userNumber} is not registered.");
        }

        public void SendMessageToUser(int destUserNumber, string message, IUser srcUser)
        {
            try
            {
                if (users.TryGetValue(destUserNumber, out IUser user))
                {
                    user.AcceptMessage(message, srcUser);
                }
                else
                {
                    throw new Exception("The user is not available.");
                }
            }
            catch (Exception) { throw new Exception("Could not send message to user."); }
        }
    }
}
