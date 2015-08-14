using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Toci.Utilities.Test.Developers.Warrior.Poc.MultiThreading
{
    [TestClass]
    public class TestMultiThreadStacking
    {
        Dictionary<int, List<string>> resultsListDictionary = new Dictionary<int, List<string>>();
        private static object lockObject = new object();

        [TestMethod]
        public void DoesMultiThreadStackingFillDictTest()
        {
            var list = GetRandomList();

            list.AsParallel().WithDegreeOfParallelism(16).ForAll(RunThread);

            Debug.WriteLine("Ilosc procow: {0}", Environment.ProcessorCount);

            var test = resultsListDictionary.Select(item => item.Value);

            var resultTest = resultsListDictionary.Select(item => item.Value).Aggregate((x, y) =>
            {
                x.AddRange(y);
                return x;
            });
        }

        private void RunThread(string str)
        {
            lock (lockObject)
            {
                if (resultsListDictionary.ContainsKey(Thread.CurrentThread.ManagedThreadId))
                {
                    resultsListDictionary[Thread.CurrentThread.ManagedThreadId].Add(str.Substring(2));
                }
                else
                {
                    resultsListDictionary.Add(Thread.CurrentThread.ManagedThreadId, new List<string> {str.Substring(2)});
                }
            }
        }

        private List<string> GetRandomList()
        {
            var list = new List<string>()
            {
                "dfsafsd",
                "tyrjhgsdf",
                "tyerhgbsdfgbfsd",
                "fwergrehet",
                "ergsdgsfhfsd",
                "rwegsdfgdsdfhfs",
                "rtweyhffgfsd",
                "rgdsghejhgsdda",
                "jytjegsfgvwewe",
            };

            //for (int j = 0; j < 3; j++)
            for (int i = 0; i < 15000; i++)
            {
                list.Add(list[i]);
            }

            return list;
        }
    }
}
