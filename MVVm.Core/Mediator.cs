﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVm.Core
{
    /// <summary>
    /// Available cross ViewModel messages
    /// </summary>
   
    /// <summary>
    /// Mediator Pattern for better MVVM
    /// visit: http://sachabarber.net/?p=477
    /// and http://marlongrech.wordpress.com/2008/03/20/more-than-just-mvc-for-wpf/
    /// </summary>
    public sealed class Mediator<T>
    {
        #region Static
        static readonly Mediator<T> instance = new Mediator<T>();
        #endregion

        #region Properties
        private volatile object locker = new object();

        MultiDictionary<T, Action<Object>> internalList
            = new MultiDictionary<T, Action<Object>>();
        #endregion

        #region Ctor
        /// <summary>
        /// Private instance so that no one is allowed to create an instance of the Mediator.
        /// </summary>
        private Mediator() { }
        #endregion

        #region Public Properties


        public static Mediator<T> Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Registers a Colleague to a specific message
        /// </summary>
        /// <param name="callback">The callback to use 
        /// when the message it seen</param>
        /// <param name="message">The message to 
        /// register to</param>
        public void Register(T message,Action<Object> callback)
        {
            internalList.AddValue(message, callback);
        }

        /// <summary>
        /// Notify all colleagues that are registed to the 
        /// specific message
        /// </summary>
        /// <param name="message">The message for the notify by</param>
        /// <param name="args">The arguments for the message</param>
        public void NotifyColleagues(T message,
            object args)
        {
            if (internalList.ContainsKey(message))
            {
                //forward the message to all listeners
                foreach (Action<object> callback in
                    internalList[message])
                    callback(args);
            }
        }
        #endregion

    }
}
