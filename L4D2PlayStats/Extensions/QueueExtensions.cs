using System.Globalization;

namespace L4D2PlayStats.Extensions;

public static class QueueExtensions
{
    private static readonly CultureInfo CultureInfo = new("en-us");

    extension(Queue<string> queue)
    {
        public char DequeueAsChar()
        {
            return queue.Dequeue().First();
        }

        public int DequeueAsInt()
        {
            return int.Parse(queue.Dequeue());
        }

        public decimal DequeueAsDecimal()
        {
            return decimal.Parse(queue.Dequeue(), CultureInfo);
        }

        public DateTime? DequeueAsDateTime()
        {
            return queue.DequeueAsLong().ToDateTime();
        }

        private long DequeueAsLong()
        {
            return long.Parse(queue.Dequeue());
        }
    }
}