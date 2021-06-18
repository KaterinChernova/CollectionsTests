using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    public class SelectTests
    {
        private List<Model> _list = new List<Model>(6000000);

        public SelectTests()
        {
            for (int i = 0; i < 6000000; i++)
            {
                _list.Add(new Model { Id = i + 3425, Name = $"Test{i}" });
            }
        }

        [Benchmark]
        public void TestAnonimObjSelect()
        {
            // Stopwatch watch = Stopwatch.StartNew();
            var anonimList = _list
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    FullName = x.Name + "_Anonim"
                })
                .ToList();
            // watch.Stop();
            // Console.WriteLine("List/AnonimModel/Select: {0}ms ({1})", watch.ElapsedMilliseconds, anonimList.Count);
        }

        [Benchmark]
        public void TestDtoObjCtrSelect()
        {
            // watch = Stopwatch.StartNew();
            var list = _list
                .Select(x => new NewModel(x.Id, x.Name, x.Name + "_Anonim"))
                .ToList();
            //watch.Stop();
            //Console.WriteLine("List/NewModel/Select: {0}ms ({1})", watch.ElapsedMilliseconds, list.Count);
        }

        [Benchmark]
        public void TestDtoObjPropSelect()
        {
            //watch = Stopwatch.StartNew();
            var proplist = _list
                .Select(x => new NewPropModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    FullName = x.Name + "_Anonim"
                })
                .ToList();
            //watch.Stop();
            //Console.WriteLine("List/NewPropModel/Select: {0}ms ({1})", watch.ElapsedMilliseconds, proplist.Count);
        }
    }
}
