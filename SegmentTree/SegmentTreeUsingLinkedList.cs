using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentTree
{
    public class SegmentTreeUsingLinkedList
    {
        private readonly int start;
        private readonly int end;
        readonly Node root;

        public SegmentTreeUsingLinkedList(int[] nums)
        {
            start = 0;
            end = nums.Length - 1;
            root = new Node();
            BuildTree(nums, root, 0, nums.Length - 1);
        }

        private void BuildTree(int[] nums, Node root, int start, int end)
        {
            if(start == end)
            {
                root.val = nums[start];
                return;
            }

            int mid = start + (end - start) / 2;
            root.left = new Node();
            root.right = new Node();

            BuildTree(nums, root.left, start, mid);
            BuildTree(nums, root.right, mid + 1, end);

            root.val = root.left.val + root.right.val;
        }

        public void Update(int num, int idx)
        {
            if (idx < start || idx > end)
                return;

            UpdateUntil(root, start, end, num, idx);
        }

        public int Query(int l, int r)
        {
            if (r < start || l > end)
                return -1;

            return QueryUntil(root, start, end, l, r);
        }

        private int UpdateUntil(Node root, int start, int end, int num, int idx)
        {
            if(start == end)
            {
                int temp = root.val;
                root.val = num;
                return num - temp;
            }

            int res;
            int mid = start + (end - start) / 2;

            if (idx >= start && idx <= mid)
                res = UpdateUntil(root.left, start, mid, num, idx);
            else
                res = UpdateUntil(root.right, mid + 1, end, num, idx);

            root.val += res;
            return res;
        }

        private int QueryUntil(Node root, int start, int end, int l, int r)
        {
            if (r < start || l > end)
                return 0;

            if (l <= start && r >= end)
                return root.val;

            int mid = start + (end - start) / 2;
            return QueryUntil(root.left, start, mid, l, r) + QueryUntil(root.right, mid + 1, end, l, r);
        }
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node()
        {
            val = 0;
            left = null;
            right = null;
        }
    }
}
