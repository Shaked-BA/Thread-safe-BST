using System;
using System.Threading;

class ThreadedBinarySearchTree
{
    private class TreeNode
    {
        public int key { get; set; }
        public TreeNode? left { get; set; } = null;
        public TreeNode? right { get; set; } = null;

        public TreeNode(int key)
        {
            this.key = key;
        }

        public void add(int num)
        {
            if (key == num)
            {
                return;
            }
            if (num < key)
            {
                if (left == null)
                {
                    left = new TreeNode(num);
                }
                else
                {
                    left.add(num);
                }
            }
            else
            {
                if (right == null)
                {
                    right = new TreeNode(num);
                }
                else
                {
                    right.add(num);
                }
                
            }
        }

        private TreeNode findSuccessor(TreeNode node)
        {
            while (node.left != null)
                node = node.left;
            return node;
        }

        public TreeNode? remove(int num)
        {
            if (key == num)
            {
                if (left == null)
                {
                    return right;
                }
                if (right == null)
                {
                    return left;
                }
                TreeNode successor = findSuccessor(right);
                key = successor.key;
                right = right.remove(successor.key);
            }
            else if (key > num)
            {
                if (left == null)
                {
                    return this;
                }
                left = left.remove(num);
            }
            else
            {
                if (right == null)
                {
                    return this;
                }
                right = right.remove(num);
            }
            return this;
        }

        public bool search(int num)
        {
            if (key == num)
            {
                return true;
            }
            if (key > num)
            {
                if (left == null)
                {
                    return false;
                }
                return left.search(num);
            }
            else
            {
                if (right == null)
                {
                    return false;
                }
                return right.search(num);
            }
        }

        public List<string> inorder()
        {
            lock (this)
            {
                List<string> ordered = new List<string>();
                if (left != null)
                    ordered.AddRange(left.inorder());
                ordered.Add(key.ToString());
                if (right != null)
                    ordered.AddRange(right.inorder());
                return ordered;
            }
        }
    }

    private TreeNode? root = null;

    private static long readers;

    private Semaphore? readWriteSemaphore = new Semaphore(1,1);
    private Semaphore? reads = new Semaphore(1,1);

    // add num to the tree, if it already exists, do nothing
    public void add(int num)
    {
        enterWriteSection();
        if (root == null)
        {
            root = new TreeNode(num);
        }
        else
        {
            root.add(num);
        }
        exitWriteSection();
    }

    // remove num from the tree, if it doesn't exists, do nothing
    public void remove(int num)
    {
        enterWriteSection();
        if (root == null)
            return;
        root = root.remove(num);
        exitWriteSection();
    }

    // search num in the tree and return true/false accordingly
    public bool search(int num)
    {
        enterReadSection();
        if (root == null)
        {
            exitReadSection();
            return false;
        }
        bool res;
        res = root.search(num);
        exitReadSection();
        return res;
    }

    // remove all items from tree
    public void clear()
    {
        enterWriteSection();
        root = null;
        exitWriteSection();
    }

    // print the values of three from the smallest to largest in comma delimited form.
    // For example; -15,0,1,3,5,23,40,89,201. If the tree is empty do nothing.
    public void print()
    {
        if (root != null)
        {
            enterReadSection();
            Console.WriteLine(String.Join(',', root.inorder()));
            exitReadSection();
        }
    }

    public void enterReadSection()
    {
        reads.WaitOne();
        if (Interlocked.Increment(ref readers) == 1)
            readWriteSemaphore.WaitOne();
        reads.Release();
    }

    public void exitReadSection()
    {
        reads.WaitOne();
        if (Interlocked.Decrement(ref readers) == 0)
            readWriteSemaphore.Release();
        reads.Release();
    }

    public void enterWriteSection()
    {
        readWriteSemaphore.WaitOne();
    }

    public void exitWriteSection()
    {
        readWriteSemaphore.Release();
    }
}