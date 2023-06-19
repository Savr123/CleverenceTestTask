using System.Text;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Compressor.Compress("ab"));
            Console.WriteLine(Compressor.Decompress("a3b3cde"));
            Console.WriteLine("ab");
            Console.WriteLine("ab");
        }
    }

    public interface ICompressor
    {
        public static string Compress(string text)
        {
            return text;
        }
        public static string Decompress(string text)
        {
            return text;
        }
    }

    public class Compressor : ICompressor
    {
        public static string Compress(string text)
        {
            if (text.Length < 2) return text;

            StringBuilder result = new StringBuilder();

            for (int i = 0; i <= text.Length - 1; i++)
            {
                if (i == text.Length - 1)
                {
                    result.Append(text[i].ToString());
                    return result.ToString();
                }
                if (text[i] == text[i + 1])
                {
                    int count = 1;
                    if (i + count == text.Length)
                        break;
                    while (i + count + 1 != text.Length && text[i + count] == text[i + count + 1])
                    {
                        count++;
                    }
                    result.Append(text[i].ToString() + (count + 1));
                    i += count;
                }
                else
                {
                    result.Append(text[i].ToString());
                }
            }
            return result.ToString();
        }
        public static string Decompress(string text)
        {

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                    result.Append(new String(text[i - 1], (int)(text[i]-'0')-1));
                else
                    result.Append(text[i].ToString());
            }
            return result.ToString();
        }
    }
}