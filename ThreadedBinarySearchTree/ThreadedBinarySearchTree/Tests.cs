using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    private static void startAdd(ThreadedBinarySearchTree bst, int x)
    {
        bst.add(x);
    }
    private static void startRemove(ThreadedBinarySearchTree bst, int x)
    {
        bst.remove(x);
    }
    private static void startSearch(ThreadedBinarySearchTree bst, int x)
    {
        bst.search(x);
    }
    private static void startClear(ThreadedBinarySearchTree bst)
    {
        bst.clear();
    }
    private static void startPrint(ThreadedBinarySearchTree bst)
    {
        bst.print();
    }
    public void add(ThreadedBinarySearchTree bst, int x)
    {
        Thread thread = new Thread(() => startAdd(bst, x));
        thread.Start();
    }
    public void remove(ThreadedBinarySearchTree bst, int x)
    {
        Thread thread = new Thread(() => startRemove(bst, x));
        thread.Start();
    }
    public void search(ThreadedBinarySearchTree bst, int x)
    {
        Thread thread = new Thread(() => startSearch(bst, x));
        thread.Start();
    }
    public void clear(ThreadedBinarySearchTree bst)
    {
        Thread thread = new Thread(() => startClear(bst));
        thread.Start();
    }
    public void print(ThreadedBinarySearchTree bst)
    {
        Thread thread = new Thread(() => startPrint(bst));
        thread.Start();
    }
    static public void Main()
    {
        ThreadedBinarySearchTree bst = new ThreadedBinarySearchTree();
        Test test = new Test();
        test.add(bst, 5);
        test.add(bst, 7);
        test.add(bst, 3);
        test.add(bst, 9);
        test.add(bst, 8);
        test.search(bst, 2);
        test.search(bst, 9);
        test.add(bst, 9);
        test.add(bst, 1);
        test.add(bst, 2);
        test.remove(bst, 8);
        test.search(bst, 9);
        test.print(bst);
        test.add(bst, 6);
        test.clear(bst);
        test.add(bst, 4);
        test.add(bst, 2);
        test.add(bst, 5);
        test.add(bst, 5);
        test.add(bst, 7);
        test.add(bst, 3);
        test.add(bst, 9);
        test.add(bst, 8);
        test.search(bst, 2);
        test.search(bst, 9);
        test.add(bst, 9);
        test.add(bst, 1);
        test.add(bst, 2);
        test.remove(bst, 8);
        test.search(bst, 9);
        test.print(bst);
        test.add(bst, 6);
        test.clear(bst);
        test.add(bst, 4);
        test.add(bst, 2);
        test.add(bst, 5);
        test.add(bst, 5);
        test.add(bst, 7);
        test.add(bst, 3);
        test.add(bst, 9);
        test.add(bst, 8);
        test.search(bst, 2);
        test.search(bst, 9);
        test.add(bst, 9);
        test.add(bst, 1);
        test.add(bst, 2);
        test.remove(bst, 8);
        test.search(bst, 9);
        test.print(bst);
        test.add(bst, 6);
        test.clear(bst);
        test.add(bst, 4);
        test.add(bst, 2);
        test.add(bst, 5);
        test.add(bst, 5);
        test.add(bst, 7);
        test.add(bst, 3);
        test.add(bst, 9);
        test.add(bst, 8);
        test.search(bst, 2);
        test.search(bst, 9);
        test.add(bst, 9);
        test.add(bst, 1);
        test.add(bst, 2);
        test.remove(bst, 8);
        test.search(bst, 9);
        test.print(bst);
        test.add(bst, 6);
        test.clear(bst);
        test.add(bst, 4);
        test.add(bst, 2);
        test.add(bst, 5);
    }
}
