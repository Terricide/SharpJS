using System;
using JSIL.Meta;

namespace JSIL.Dom
{
    public class IntervalDispatcher
    {
        private object _handle = null;

        /// <summary>
        ///     Creates an IntervalDispatcher that dispatches an event after each elapse of <paramref name="interval" />.
        /// </summary>
        public IntervalDispatcher(TimeSpan timeSpan)
        {
            Interval = timeSpan;
        }

        public TimeSpan Interval { get; private set; }

        public event EventHandler Tick;

        private void OnNativeEvent()
        {
            if (Tick != null)
            {
                Tick(this, EventArgs.Empty);
            }
        }

        [JSReplacement(
            "$this._handle = setInterval(function () { $this.OnNativeEvent(); }, $this.Interval.TotalMilliseconds)")]
        public void Start()
        {
        }

        [JSReplacement("clearInterval($this._handle)")]
        public void Stop()
        {
        }
    }
}