using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestStructCollections();

            // TestObjCollections();

            BenchmarkRunner.Run<SelectTests>();

            Console.ReadLine();
        }

        private static void TestStructCollections()
        {
            List<int> list = new List<int>(6000000);
            Random rand = new Random(12345);
            for (int i = 0; i < 6000000; i++)
            {
                list.Add(rand.Next(5000));
            }
            int[] arr = list.ToArray();
            HashSet<int> set = new HashSet<int>(arr);

            ArrayFor(arr);
            ArrayForeach(arr);
            ArrayLinqForeach(arr);
            Console.WriteLine("-------------------------------------------------");

            ListFor(list);
            ListForeach(list);
            ListLinqForeach(list);
            Console.WriteLine("-------------------------------------------------");

            ListCount(list);
            ListAny(list);
            Console.WriteLine("-------------------------------------------------");

            ListContains(list);
            HashSetContains(set);
            Console.WriteLine("-------------------------------------------------");

            ListLinqSearch(list);
            ListFindSearch(list);
            HashSetSearch(set);
            Console.WriteLine("-------------------------------------------------");
        }

        private static void TestObjCollections()
        {
            List<Model> list = new List<Model>(6000000);
            Random rand = new Random(123455521);
            for (int i = 0; i < 6000000; i++)
            {
                list.Add(new Model { Id = i + 3425, Name = $"Test{i}" });
            }
            Model[] arr = list.ToArray();
            HashSet<Model> set = new HashSet<Model>(arr);

            ListLinqSearch(list);
            ListFindSearch(list);
            HashSetSearch(set);
            Console.WriteLine("-------------------------------------------------");
        }

        private static void ListLinqSearch(List<Model> list)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Model res = list.FirstOrDefault(x => x.Id == 5555555);
            watch.Stop();
            Console.WriteLine("List/Model/FirstOrDefault: {0}ms ({1})", watch.ElapsedMilliseconds, res);
        }

        private static void ListFindSearch(List<Model> list)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Model res = list.Find(x => x.Id == 5555555);
            watch.Stop();
            Console.WriteLine("List/Model/Find: {0}ms ({1})", watch.ElapsedMilliseconds, res);
        }

        private static void HashSetSearch(HashSet<Model> set)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Model res = null;
            set.TryGetValue(new Model { Id = 5555555 }, out res);
            watch.Stop();
            Console.WriteLine("HashSet/Model/TryGetValue: {0}ms ({1})", watch.ElapsedMilliseconds, res);
        }

        private static void ListLinqSearch(List<int> list)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int res = list.FirstOrDefault(x => x == 5555);
            watch.Stop();
            Console.WriteLine("List/FirstOrDefault: {0}ms ({1})", watch.ElapsedMilliseconds, res);
        }

        private static void ListFindSearch(List<int> list)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int res = list.Find(x => x == 5555);
            watch.Stop();
            Console.WriteLine("List/Find: {0}ms ({1})", watch.ElapsedMilliseconds, res);
        }

        private static void HashSetSearch(HashSet<int> set)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int res = 0;
            set.TryGetValue(5555, out res);
            watch.Stop();
            Console.WriteLine("HashSet/TryGetValue: {0}ms ({1})", watch.ElapsedMilliseconds, res);
        }

        private static void ListCount(List<int> list)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int cnt = 0;
            for (int i = 0; i < 1000000; i++)
            {
                 cnt = list.Count;
            }
            watch.Stop();
            Console.WriteLine("List/Count: {0}ms ({1})", watch.ElapsedMilliseconds, cnt);
        }

        private static void ListAny(List<int> list)
        {
            Stopwatch watch = Stopwatch.StartNew();
            bool any = false;
            for (int i = 0; i < 1000000; i++)
            {
                any = list.Any();
            }
            watch.Stop();
            Console.WriteLine("List/Any: {0}ms ({1})", watch.ElapsedMilliseconds, any);
        }

        private static void ListContains(List<int> list)
        {
            Stopwatch watch = Stopwatch.StartNew();
            bool contains = false;
            for (int i = 0; i < 1000000; i++)
            {
                contains = list.Contains(556);
            }
            watch.Stop();
            Console.WriteLine("List/Contains: {0}ms ({1})", watch.ElapsedMilliseconds, contains);
        }

        private static void HashSetContains(HashSet<int> set)
        {
            Stopwatch watch = Stopwatch.StartNew();
            bool contains = false;
            for (int i = 0; i < 1000000; i++)
            {
                contains = set.Contains(556);
            }
            watch.Stop();
            Console.WriteLine("Hashset/Contains: {0}ms ({1})", watch.ElapsedMilliseconds, contains);
        }

        private static void ArrayFor(int[] arr)
        {
            int chk = 0;
            Stopwatch watch = Stopwatch.StartNew();
            for (int rpt = 0; rpt < 100; rpt++)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    chk += arr[i];
                }
            }
            watch.Stop();
            Console.WriteLine("Array/for: {0}ms ({1})", watch.ElapsedMilliseconds, chk);
        }

        private static void ArrayForeach(int[] arr)
        {
            int chk = 0;
            Stopwatch watch = Stopwatch.StartNew();
            for (int rpt = 0; rpt < 100; rpt++)
            {
                foreach (int i in arr)
                {
                    chk += i;
                }
            }
            watch.Stop();
            Console.WriteLine("Array/foreach: {0}ms ({1})", watch.ElapsedMilliseconds, chk);
        }

        private static void ArrayLinqForeach(int[] arr)
        {
            int chk = 0;
            Stopwatch watch = Stopwatch.StartNew();
            for (int rpt = 0; rpt < 100; rpt++)
            {
                Array.ForEach(arr, i => chk += i);
            }
            watch.Stop();
            Console.WriteLine("Array/ForEach: {0}ms ({1})", watch.ElapsedMilliseconds, chk);
        }

        private static void ListFor(List<int> list)
        {
            int chk = 0;
            Stopwatch watch = Stopwatch.StartNew();
            for (int rpt = 0; rpt < 100; rpt++)
            {
                int len = list.Count;
                for (int i = 0; i < len; i++)
                {
                    chk += list[i];
                }
            }
            watch.Stop();
            Console.WriteLine("List/for: {0}ms ({1})", watch.ElapsedMilliseconds, chk);
        }

        private static void ListForeach(List<int> list)
        {
            int chk = 0;
            Stopwatch watch = Stopwatch.StartNew();
            for (int rpt = 0; rpt < 100; rpt++)
            {
                foreach (int i in list)
                {
                    chk += i;
                }
            }
            watch.Stop();
            Console.WriteLine("List/foreach: {0}ms ({1})", watch.ElapsedMilliseconds, chk);
        }

        private static void ListLinqForeach(List<int> list)
        {
            int chk = 0;
            Stopwatch watch = Stopwatch.StartNew();
            for (int rpt = 0; rpt < 100; rpt++)
            {
                list.ForEach(i => chk += i);
            }
            watch.Stop();
            Console.WriteLine("List/ForEach: {0}ms ({1})", watch.ElapsedMilliseconds, chk);
        }
    }
}
