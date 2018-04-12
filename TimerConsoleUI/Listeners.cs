using System;
using Timer;

namespace TimerConsoleUI
{
    public sealed class Listeners
    {
        public sealed class FirstListener
        {
            public void Register(TimerManager mail)
            {
                if (mail == null)
                {
                    throw new ArgumentNullException(nameof(mail));
                }

                mail.Timer += FirstListenerMessage;
            }

            public void Unregister(TimerManager mail)
            {
                if (mail == null)
                {
                    throw new ArgumentNullException(nameof(mail));
                }

                mail.Timer -= FirstListenerMessage;
            }

            public void FirstListenerMessage(object sender, TimerEventArgs eventArgs)
            {
                if (sender == null)
                {
                    throw new ArgumentNullException(nameof(sender));
                }

                if (eventArgs == null)
                {
                    throw new ArgumentNullException(nameof(EventArgs));
                }

                Console.WriteLine("FirstListener: {0}", eventArgs.Message);
            }
        }

        public sealed class SecondListener
        {
            public void Register(TimerManager mail)
            {
                if (mail == null)
                {
                    throw new ArgumentNullException(nameof(mail));
                }

                mail.Timer += SecondListenerMessage;
            }

            public void Unregister(TimerManager mail)
            {
                if (mail == null)
                {
                    throw new ArgumentNullException(nameof(mail));
                }

                mail.Timer -= SecondListenerMessage;
            }

            public void SecondListenerMessage(object sender, TimerEventArgs eventArgs)
            {
                if (sender == null)
                {
                    throw new ArgumentNullException(nameof(sender));
                }

                if (eventArgs == null)
                {
                    throw new ArgumentNullException(nameof(EventArgs));
                }

                Console.WriteLine("SecondListener: {0}", eventArgs.Message);
            }
        }

        public sealed class ThirdListener
        {
            public void Register(TimerManager mail)
            {
                if (mail == null)
                {
                    throw new ArgumentNullException(nameof(mail));
                }

                mail.Timer += ThirdListenerMessage;
            }

            public void Unregister(TimerManager mail)
            {
                if (mail == null)
                {
                    throw new ArgumentNullException(nameof(mail));
                }

                mail.Timer -= ThirdListenerMessage;
            }

            public void ThirdListenerMessage(object sender, TimerEventArgs eventArgs)
            {
                if (sender == null)
                {
                    throw new ArgumentNullException(nameof(sender));
                }

                if (eventArgs == null)
                {
                    throw new ArgumentNullException(nameof(EventArgs));
                }

                Console.WriteLine("ThirdListener: {0}", eventArgs.Message);
            }
        }
    }
}
