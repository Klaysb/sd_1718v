using System;

namespace MessageImpl
{
    /// <summary>
    /// The object to send between broker and central manager.
    /// </summary>
    [Serializable]
    public class Message
    {
        /// <summary>
        /// The message to be sent.
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// The identifier of the sender.
        /// </summary>
        public int SenderNumber { get; set; }

        /// <summary>
        /// The name of the sender.
        /// </summary>
        public string SenderName { get; set; }
    }
}
