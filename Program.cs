using System.Runtime.InteropServices;
namespace CPPInteropDemo
{
    class Program
    {
        [DllImport("AgxCpp.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int a, int b);
        
        [DllImport("AgxCpp.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Multiply(int a, int b);
        
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            
            int addResult = Add(a, b);
            Console.WriteLine($"The result of adding {a} and {b} is: {addResult}");
            
            int multiplyResult = Multiply(a, b);
            Console.WriteLine($"The result of multiplying {a} and {b} is: {multiplyResult}");
        }
    }
}