using System;
using Appccelerate.EventBroker;
using Intel.Unite.Common.Command;
using UniteEmote.Interfaces;
using UniteEmote.Model.EventArguments;
using UniteEmote.Utility;

namespace UniteEmote.Static
{
    public static class MessagingEventBroker
    {
        public static IEventBroker GlobalEventBroker { get; } = new EventBroker();

        /// <summary>
        /// Method entry point that sends Messages to subscribers
        /// </summary>
        /// <param name="message">Message to be sent</param>
        public static void Process(Message message)
        {
            GetMessenger((EventArgumentTypes)message.DataType).InvokeSubscriptions(message);
        }

        /// <summary>
        /// Helper method that generates a Messsenger object
        /// </summary>
        /// <param name="eventArgumentTypes">The EventArg types</param>
        /// <returns>the Messenger object</returns>
        private static IMessenger GetMessenger(EventArgumentTypes eventArgumentTypes)
        {
            Type genericType = typeof(Messenger<>);
            Type[] genericTypeArgs = { System.Type.GetType("UniteEmote.Model.EventArguments." + eventArgumentTypes) };
            var argMessenger = genericType.MakeGenericType(genericTypeArgs);
            if (argMessenger == null) throw new Exception("Valid Messenger not created.");

            return (IMessenger)Activator.CreateInstance( argMessenger);
        }
    }
}
