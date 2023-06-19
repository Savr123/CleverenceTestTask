namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[,] a = { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 } };
            var testVar = SpiralCounterclockwise(a);
            foreach (var v in testVar)
            {
                Console.Write(v + " ");
            }
        }
        public static int[] SpiralCounterclockwise(int[,] arr)
        {
            int[] result = new int[arr.Length];
            int index = 0;
            int x1 = 0, x2 = arr.GetLength(1)-1,
                y1 = 0, y2 = arr.GetLength(0)-1;
            while(x1<=x2 && y1<=y2)
            {
                //go down
                for(int i=y1; i<=y2; i++)
                {
                    result[index] = arr[i, x1];
                    index++;
                }
                x1++;
                //go right
                for(int i = x1; i <= x2; i++)
                {
                    result[index] = arr[y2, i];
                    index++;
                }
                y2--;
                //go top
                for(int i = y2; i>=y1; i--)
                {
                    result[index] = arr[i, x2];
                    index++;
                }
                x2--;
                //go left
                if (index == arr.Length)
                    break;
                for(int i = x2; i >= x1; i--)
                {
                    result[index] = arr[y1, i];
                    index++;
                }
                y1++;

            }


            return result;
        }
    }
}