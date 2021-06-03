using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentTree
{
    class SegmentTree
    {
        int[] st;

        public SegmentTree(int[] arr, int n)
        {
            int x = (int)Math.Ceiling(Math.Log(n, 2));
            int max_size = 2 * (int)Math.Pow(2, x) - 1;
            st = new int[max_size];

            ConstructSTUtil(arr, 0, n - 1, 0);
        }

        private int ConstructSTUtil(int[] arr, int low, int high, int pos)
        {
            if (low == high)
            {
                st[pos] = arr[low];
                return arr[low];
            }

            int mid = GetMid(low, high);
            st[pos] = ConstructSTUtil(arr, low, mid, pos * 2 + 1) + ConstructSTUtil(arr, mid + 1, high, pos * 2 + 2);

            return st[pos];
        }

        internal int GetSum(int n, int qStart, int qEnd)
        {
            if (qStart < 0 || qEnd > n - 1 || qStart > qEnd)
            {
                Console.WriteLine("Invalid Input");
                return -1;
            }
            return GetSumUtil(0, n - 1, qStart, qEnd, 0);
        }

        private int GetSumUtil(int segStart, int segEnd, int qStart, int qEnd, int pos)
        {
            if (qStart <= segStart && qEnd >= segEnd)
                return st[pos];

            if (segEnd < qStart || segStart > qEnd)
                return 0;

            int mid = GetMid(segStart, segEnd);
            return GetSumUtil(segStart, mid, qStart, qEnd, 2 * pos + 1) +
                    GetSumUtil(mid + 1, segEnd, qStart, qEnd, 2 * pos + 2);
        }

        internal void UpdateValue(int[] arr, int n, int i, int new_val)
        {
            if (i < 0 || i > n - 1)
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            int diff = new_val - arr[i];

            arr[i] = new_val;

            UpdateValueUtil(0, n - 1, i, diff, 0);
        }

        private void UpdateValueUtil(int segStart, int segEnd, int i, int diff, int pos)
        {
            if (i < segStart || i > segEnd)
                return;

            st[pos] = st[pos] + diff;
            if (segEnd != segStart)
            {
                int mid = GetMid(segStart, segEnd);
                UpdateValueUtil(segStart, mid, i, diff, 2 * pos + 1);
                UpdateValueUtil(mid + 1, segEnd, i, diff, 2 * pos + 2);
            }
        }

        private int GetMid(int s, int e)
        {
            return s + (e - s) / 2;
        }
    }
}
