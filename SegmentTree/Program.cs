using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 9, 5, 7, 3 };
            int n = arr.Length;

            SegmentTree tree = new SegmentTree(arr, n);
            SegmentTreeUsingLinkedList segmentTreeUsingLinkedList = new SegmentTreeUsingLinkedList(arr);

            Console.WriteLine("Sum of values in given range = " + tree.GetSum(n, 0, 4));
            Console.WriteLine("Sum of values in given range = " + segmentTreeUsingLinkedList.Query(0, 4));

            segmentTreeUsingLinkedList.Update(1, 0);
            segmentTreeUsingLinkedList.Update(10, 2);
            Console.WriteLine("Sum of values in given range after update = " + segmentTreeUsingLinkedList.Query(0, 4));

            Console.ReadKey();
        }
    }
}
