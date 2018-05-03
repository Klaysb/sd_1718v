using CentralManagerInterface;
using System;
using System.Collections.Concurrent;
using MessageImpl;
using GroupImpl;
using System.Collections.Generic;
using BrokerClientInterface;

namespace CentralManagerImpl
{
    public class CentralManager : MarshalByRefObject, ICentralManager
    {
        
        private readonly ConcurrentBag<IBrokerClient> brokers = new ConcurrentBag<IBrokerClient>();

        public CentralManager(IEnumerable<IBrokerClient> brokers)
        {
            this.brokers = new ConcurrentBag<IBrokerClient>(brokers);
        }

        public void RegisterGroup(Group group, IBrokerClient callerBroker)
        {
            foreach (IBrokerClient broker in brokers)
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

        public void AddUserToGroup(string groupName, int destNumber, IBrokerClient callerBroker)
        {
            foreach (IBrokerClient broker in brokers)
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

        public void SendMessageToBrokers(int receiver, Message message, IBrokerClient callerBroker)
        {
            foreach (IBrokerClient broker in brokers)
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

        public void SendMessageToGroup(string groupName, Message message, IBrokerClient callerBroker)
        {
            foreach (IBrokerClient broker in brokers)
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

        public void UnregisterGroup(string groupName, IBrokerClient callerBroker)
        {
            foreach (IBrokerClient broker in brokers)
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
