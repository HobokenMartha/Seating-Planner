using System;
using System.Collections.Generic;

namespace Seating_Planner.Common
{
    /// <summary>
    /// Loosely-coupled messaging class for communicating between ViewModels
    /// </summary>
    public static class Mediator
    {
        static IDictionary<string, List<Action<object>>> dict = new Dictionary<string, List<Action<object>>>();

        public static void Register(string token, Action<object> callback)
        {
            if (!dict.ContainsKey(token))
            {
                var list = new List<Action<object>>();
                list.Add(callback);
                dict.Add(token, list);
            }
            else
            {
                bool found = false;
                foreach (var item in dict[token])
                {
                    if (item.Method.ToString() == callback.Method.ToString())
                        found = true;

                    if (!found)
                        dict[token].Add(callback);
                }
            }
        }

        public static void Unregister(string token, Action<object> callback)
        {
            if (dict.ContainsKey(token))
                dict[token].Remove(callback);
        }

        public static void NotifyColleagues(string token, object args)
        {
            if (dict.ContainsKey(token))
                foreach (var callback in dict[token])
                    callback(args);
        }
    }
}
