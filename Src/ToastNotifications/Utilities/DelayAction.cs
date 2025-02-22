﻿using System;
using System.Threading;
using System.Windows.Threading;

namespace ToastNotifications.Utilities
{
    public static class DelayAction 
    {
        public static void Execute(TimeSpan delay, Action action, Dispatcher dispatcher = null)
        {
            dispatcher ??= Dispatcher.CurrentDispatcher;

            Timer[] timer = {null};
            timer[0] = new Timer(obj =>
            {
                dispatcher.Invoke(action);

                timer[0]?.Dispose();
                timer[0] = null;
            }, null, delay, TimeSpan.FromMinutes(1));
        }
    }
}