using CentralManagerInterface;
using System;
using System.Collections.Concurrent;
using BrokerInterface;
using MessageImpl;
using GroupImpl;
using System.Collections.Generic;

namespace CentralManagerImpl
{
    public class CentralManager : MarshalByRefObject, ICentralManager
    {
        
        private readonly ConcurrentBag<IBroker> brokers = new ConcurrentBag<IBroker>();

        public CentralManager(IEnumerable<IBroker> brokers)
        {
            this.brokers = new ConcurrentBag<IBroker>(brokers);
        }

        public void RegisterGroup(Group group, IBroker callerBroker)
        {
            foreach (IBroker broker in brokers)
            {
                try
                {
                    if (!broker.Equals(callerBroker))
                        broker.RegisterGroup(group);
                }
                catch (Exception)
                {
                    // Não é necessário tratar a excecao, porque quem chama 
                    // o metodo nao tem de ter conhecimento se houve falhas ao conectar com outro broker.
                }
            }
        }

        public void AddUserToGroup(string groupName, int destNumber, IBroker callerBroker)
        {
            foreach (IBroker broker in brokers)
            {
                try
                {
                    if (!broker.Equals(callerBroker))
                        broker.AddUserToGroup(groupName, destNumber);
                }
                catch (Exception)
                {
                    // Não é necessário tratar a excecao, porque quem chama 
                    // o metodo nao tem de ter conhecimento se houve falhas ao conectar com outro broker.
                }
            }
        }

        public void SendMessageToBrokers(int receiver, Message message, IBroker callerBroker)
        {
            foreach (IBroker broker in brokers)
            {
                try
                {
                    if (!broker.Equals(callerBroker))
                        broker.SendMessageToUser(receiver, message);
                }
                catch (Exception)
                {
                    // Não é necessário tratar a excecao, porque quem chama 
                    // o metodo nao tem de ter conhecimento se houve falhas ao conectar com outro broker.
                }
            }
        }

        public void SendMessageToGroup(string groupName, Message message, IBroker callerBroker)
        {
            foreach (IBroker broker in brokers)
            {
                try
                {
                    if (!broker.Equals(callerBroker))
                        broker.SendMessageToGroup(groupName, message);
                }
                catch (Exception)
                {
                    // Não é necessário tratar a excecao, porque quem chama 
                    // o metodo nao tem de ter conhecimento se houve falhas ao conectar com outro broker.
                }
            }
        }

        public void UnregisterGroup(string groupName, IBroker callerBroker)
        {
            foreach (IBroker broker in brokers)
            {
                try
                {
                    if (!broker.Equals(callerBroker))
                        broker.UnregisterGroup(groupName);
                }
                catch (Exception)
                {
                    // Não é necessário tratar a excecao, porque quem chama 
                    // o metodo nao tem de ter conhecimento se houve falhas ao conectar com outro broker.
                }
            }
        }
    }
}
