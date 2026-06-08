namespace ApplicationAPI.Infrastructure
{
    public class RandomExceptionGenerator
    {
        private static readonly Random _random = new();

        // نمونه هایی از استثنا
        private static readonly List<Exception> _exceptions =
        [
            new ArgumentException(),
            new ArgumentNullException(),
            new InvalidOperationException(),
            new NotImplementedException(),
            new NotSupportedException(),
            new FormatException(),
            new OverflowException(),
            new DivideByZeroException(),
            new IndexOutOfRangeException(),
            new NullReferenceException(),
            new KeyNotFoundException(),
            new TimeoutException(),
            new UnauthorizedAccessException(),
            new AccessViolationException(),
            new ObjectDisposedException("Object"),
            new ArithmeticException(),
            new ArrayTypeMismatchException(),
            new InvalidCastException(),
            new OutOfMemoryException(),
            new RankException(),
            new StackOverflowException(),
            new TypeLoadException(),
            new UriFormatException(),
            new PathTooLongException(),
            new FileNotFoundException(),
            new DirectoryNotFoundException(),
            new EndOfStreamException(),
            new IOException(),
            new OperationCanceledException(),
            new ApplicationException()
        ];
        /// <summary>
        /// به صورت رندوم یک استثنا پرت می کند
        /// </summary>
        public static void ThrowRandom()
        {
            int index = _random.Next(_exceptions.Count);
            throw _exceptions[index];
        }
    }
}
