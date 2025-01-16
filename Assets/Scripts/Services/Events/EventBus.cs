using System;
using System.Collections.Generic;

namespace Playground.Services.Events
{
    public class EventBus
    {
        #region Variables

        private readonly Dictionary<Type, List<object>> _listenersByTypes = new();

        #endregion

        #region Public methods

        public void Publish<T>() where T : new()
        {
            Publish(new T());
        }

        public void Publish<T>(T value)
        {
            List<object> listeners = GetListeners<T>();

            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                object listener = listeners[i];
                if (listener is Action<T> concreteAction)
                {
                    concreteAction(value);
                }
                else if (listener is Action action)
                {
                    action.Invoke();
                }
            }
        }

        public void Subscribe<T>(Action callback)
        {
            List<object> listeners = GetListeners<T>();
            listeners.Add(callback);
        }

        public void Subscribe<T>(Action<T> callback)
        {
            List<object> listeners = GetListeners<T>();
            listeners.Add(callback);
        }

        public void Unsubscribe<T>(Action callback)
        {
            List<object> listeners = GetListeners<T>();
            listeners.Remove(callback);
        }

        public void Unsubscribe<T>(Action<T> callback)
        {
            List<object> listeners = GetListeners<T>();
            listeners.Remove(callback);
        }

        #endregion

        #region Private methods

        private List<object> GetListeners<T>()
        {
            Type type = typeof(T);
            if (!_listenersByTypes.TryGetValue(type, out List<object> listeners))
            {
                listeners = new List<object>();
                _listenersByTypes.Add(type, listeners);
            }

            return listeners;
        }

        #endregion
    }
}