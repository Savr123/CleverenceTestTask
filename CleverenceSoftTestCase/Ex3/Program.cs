namespace Task3
{
    public class Program
    {
        public static void Main()
        {
            Parallel.For(0, 500, i =>
            {
                if (i % 2 == 0)
                    Server.AddToCount(1, 1000);
                Console.WriteLine(" iteration {1}: server respond - {0}", Server.GetCount(1000), i);
            });
            Console.WriteLine("final result: {0} ", Server.GetCount(1000));
            Server.TimeoutsReport(new Logger());
        }
    }
    public interface ILogger
    {
        void Log(string message);
        void LogLine(string message);
        void LogError(string message);
        void LogLineError(string message);
    }

    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.Write(message);
        }
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void LogLine(string message)
        {
            Console.WriteLine(message);
        }
        public void LogLineError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public static class Server
    {
        private static int count = 0;
        private static int reads = 0;
        private static int writes = 0;
        private static int readerTimeouts = 0;
        private static int writerTimeouts = 0;
        private static readonly ReaderWriterLock rwl = new ReaderWriterLock();
        public static int GetCount(int timeout)
        {
            try
            {
                rwl.AcquireReaderLock(timeout);
                try
                {
                    Interlocked.Increment(ref reads);
                    return count;
                }
                finally
                {
                    rwl.ReleaseReaderLock();
                }
            }
            catch (ApplicationException exception)
            {
                Interlocked.Increment(ref readerTimeouts);
                throw new ApplicationException(exception.Message);
            }
        }
        public static void AddToCount(int value, int timeout)
        {
            try
            {
                rwl.AcquireWriterLock(timeout);
                try
                {
                    Interlocked.Increment(ref count);
                    Interlocked.Increment(ref writes);
                }
                finally
                {
                    rwl.ReleaseWriterLock();
                }
            }
            catch(ApplicationException exception)
            {
                Interlocked.Increment(ref writerTimeouts);
                throw new ApplicationException(exception.Message);
            }
        }
        public static void TimeoutsReport(ILogger logger)
        {
            logger.LogLineError($"number of writerTimeouts: {writerTimeouts}");
            logger.LogLineError($"number of readerTimeouts: {readerTimeouts}");
        }
    }
}