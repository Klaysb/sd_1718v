using GroupImpl;
using Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BrokerImpl
{
    public class Broker : MarshalByRefObject, IBroker
    {
        private readonly ICentralManager manager;
        private readonly ConcurrentDictionary<int, IUser> users = new ConcurrentDictionary<int, IUser>();
        private readonly ConcurrentDictionary<string, Group> groupNames = new ConcurrentDictionary<string, Group>();

        public Broker(ICentralManager manager) => this.manager = manager; 

        public void AddUserToGroup(int adderMember, int userNumber, string groupName)
        {
            if(groupNames.TryGetValue(groupName, out Group group))
            {
                if (group.UsersInSameRegion.Exists(u => u == adderMember))
                {
                    if (users.ContainsKey(userNumber))
                    {
                        group.UsersInSameRegion.Add(userNumber);
                    }
                    else
                    {
                        try
                        {
                            manager.AddUserToGroup(adderMember, userNumber, groupName);
                            group.UsersInAnotherRegion.Add(userNumber);
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
                manager.Register(user.UserNumber, this);
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
                manager.RegisterGroup(groupName, this);
                var group = new Group
                {
                    Name = groupName,
                    Owner = userNumber,
                    UsersInSameRegion = new List<int> { userNumber },
                    UsersInAnotherRegion = new List<int>()
                };
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
                group.UsersInSameRegion.ForEach(userNumber =>
                {
                    if (users.TryGetValue(userNumber, out IUser user))
                    {
                        // TODO exception
                        user.AcceptMessage(message, srcUser);
                    }
                });
                // TODO exception
                manager.SendMessageToUsers(message, srcUserNumber, group.UsersInAnotherRegion.ToArray());
            }
            else throw new ArgumentException($"The group {groupName} does not exist.");
        }

        public void SendMessageToUser(int destUserNumber, string message, int srcUserNumber)
        {
            try
            {
                users.TryGetValue(srcUserNumber, out IUser srcUser);
                if (users.TryGetValue(destUserNumber, out IUser user))
                {
                    user.AcceptMessage(message, srcUser);
                }
                else
                {
                    manager.SendMessageToUsers(message, srcUserNumber, destUserNumber);
                }
            }
            catch(Exception ex)
            {
                // TODO
            }
        }

        public void Unregister(int userNumber)
        {
            try
            {
                manager.Unregister(userNumber);
                users.TryRemove(userNumber, out IUser user);
            }
            catch(Exception ex)
            {
                users.TryGetValue(userNumber, out IUser user);
                user.AcceptMessage("Cannot unregister user.", null);
            }
        }

        public void UnregisterGroup(string groupName, int userNumber)
        {
            try
            {
                //manager.UnregisterGroup()
            }
            catch(Exception ex)
            {

            }
        }

        private void CheckIfRegistered(int userNumber)
        {
            if (!users.ContainsKey(userNumber))
                throw new ArgumentException($"User with number {userNumber} is not registered");
        }
    }
}
