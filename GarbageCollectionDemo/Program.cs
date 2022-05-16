using System;
namespace GarbageCollectionDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            long mem1 = GC.GetTotalMemory(false);
            {
                // Allocate an array and make it reachable
                int[] values = new int[50000];
                values = null;
            }
            long mem2 = GC.GetTotalMemory(false);
            {
                // Collect Garbage
                GC.Collect();
            }
            long mem3 = GC.GetTotalMemory(false);
            {
                Console.WriteLine(mem1);
                Console.WriteLine(mem2);
                Console.WriteLine(mem3);
            }
            Console.WriteLine("##########");

            long bytes1 = GC.GetTotalMemory(false); //Get memory in bytes

            byte[] memory = new byte[1000 * 1000 * 10]; //Ten million bytes
            memory[0] = 1; //Set memory (prevent allocation from being optimized out)

            long bytes2 = GC.GetTotalMemory(false); //Get Memory
            long bytes3 = GC.GetTotalMemory(false); //Get Memory

            Console.WriteLine(bytes1);
            Console.WriteLine(bytes2);
            Console.WriteLine(bytes2-bytes1); //Write Difference
            Console.WriteLine(bytes3);
            Console.WriteLine(bytes3-bytes2); //Write Difference
            Console.ReadLine();
        }
    }
}