using GroupImpl;
using BrokerInterface;
using UserInterface;
using CentralManagerInterface;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.Remoting;

namespace BrokerImpl
{
    public class Broker : MarshalByRefObject, IBroker
    {

        public ICentralManager Manager { get; set; }
        private readonly ConcurrentDictionary<int, IUser> users = new ConcurrentDictionary<int, IUser>();
        private readonly ConcurrentDictionary<string, Group> groupNames = new ConcurrentDictionary<string, Group>(); 

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
                            Manager.AddUserToGroup(adderMember, userNumber, groupName);
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
                Manager.Register(user.UserNumber, this);
                users.TryAdd(user.UserNumber, user);
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
                Manager.RegisterGroup(groupName, this);
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
                    if (users.TryGetValue(userNumber, out IUser user))
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
                    Manager.SendMessageToUsers(message, srcUserNumber, group.UsersInAnotherRegion.Keys.ToArray());
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
            CheckIfRegistered(srcUserNumber);
            users.TryGetValue(srcUserNumber, out IUser srcUser);
            try
            {
                if (users.TryGetValue(destUserNumber, out IUser user))
                {
                    user.AcceptMessage(message, srcUser);
                }
                else
                {
                    Manager.SendMessageToUsers(message, srcUserNumber, destUserNumber);
                }
            }
            catch (Exception) { throw new Exception("Could not send message to user"); }
        }

        public void Unregister(int userNumber)
        {
            CheckIfRegistered(userNumber);
            try
            {
                Manager.Unregister(userNumber);
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
                Manager.UnregisterGroup(groupName);
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
                throw new ArgumentException($"User with number {userNumber} is not registered");
        }
    }
}
