using System;
using System.Threading;

namespace Timer
{
    /// <summary>
    /// class that contains message for broadcasting
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class TimerEventArgs : EventArgs
    {
        /// <summary>
        /// The message
        /// </summary>
        private readonly string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        public TimerEventArgs(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            this.message = message;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get => this.message;
        }
    }

    /// <summary>
    /// Timer manager that notify observers
    /// </summary>
    public class TimerManager
    {
        /// <summary>
        /// Event that add and remove event handlers
        /// </summary>
        public event EventHandler<TimerEventArgs> Timer = delegate { };

        /// <summary>
        /// Raises the <see cref="E:Timer" /> event.
        /// </summary>
        /// <param name="e">The <see cref="TimerEventArgs"/> instance containing the event data.</param>
        protected virtual void OnTimer(TimerEventArgs e)
        {
            var temp = this.Timer;
            temp?.Invoke(this, e);
        }

        /// <summary>
        /// Notifies observers with the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <exception cref="ArgumentOutOfRangeException">milliseconds are below zero</exception>
        public void Notify(string message, int milliseconds = 0)
        {
            if (milliseconds < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(milliseconds));
            }

            Thread.Sleep(milliseconds);
            this.OnTimer(new TimerEventArgs(message));
        }
    }
}
