using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreams Streams;

        // If we want to stream a music file, we can't but after my fix - can :-)
        public StreamProgressInfo(IStreams streams)
        {
            this.Streams = streams;
        }

        public int CalculateCurrentPercent()
        {
            return (this.Streams.BytesSent * 100) / this.Streams.Length;
        }
    }
}
