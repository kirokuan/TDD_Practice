using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TDD;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    public class UnitTest1
    {
        private static readonly List<Revenue> RevenuList=new List<Revenue>()
        {
            new Revenue(){Cost = 1,Revenu = 11,SellPrice = 21},
            new Revenue(){Cost = 2,Revenu = 12,SellPrice = 22},
            new Revenue(){Cost = 3,Revenu = 13,SellPrice = 23},
            new Revenue(){Cost = 4,Revenu = 14,SellPrice = 24},
            new Revenue(){Cost = 5,Revenu = 15,SellPrice = 25},
            new Revenue(){Cost = 6,Revenu = 16,SellPrice = 26},
            new Revenue(){Cost = 7,Revenu = 17,SellPrice = 27},
            new Revenue(){Cost = 8,Revenu = 18,SellPrice = 28},
            new Revenue(){Cost = 9,Revenu = 19,SellPrice = 29},
            new Revenue(){Cost = 10,Revenu = 20,SellPrice = 30},
            new Revenue(){Cost = 11,Revenu = 21,SellPrice = 31},
        };

        public readonly List<TestObj> _EmptyList = new List<TestObj>();
        private readonly List<TestObj> _TestObjList = new List<TestObj>()
        {
            new TestObj(){prop=1},
            new TestObj(){prop=2},
            new TestObj(){prop=3}
        }; 

        private readonly int[] _CostGroupBy3 = { 6, 15, 24, 21 };
        private readonly int[] _RevenuGroupBy4 = {50,66,60};
        private int[] _sumOfTestObj = new[] { 6 };

        [Test]
        public void RevenuGroupBy3()
        {
            var group=RevenuList.SumByGroup(i => i.Cost, 3);
            Assert.AreEqual(_CostGroupBy3,group);
        }

        [Test]
        public void RevenuGroupBy4()
        {
            var group = RevenuList.SumByGroup(i => i.Revenu, 4);
            Assert.AreEqual(_RevenuGroupBy4, group);
        }

        [Test]
        public void EmptyList()
        {
            var group=_EmptyList.SumByGroup(t => t.prop, 1);
            Assert.AreEqual(new int[]{}, group);
        }

        [Test]
        public void GroupBy1()
        {
            var result = _TestObjList.SumByGroup(t => t.prop, 1);
            Assert.AreEqual(new[] { 1, 2, 3 }, result);
        }
        [Test]
        public void DividCompletely()
        {
            var countOfList = 3;
            var group = _TestObjList.SumByGroup(t => t.prop, countOfList);
            Assert.AreEqual(_sumOfTestObj, group);
        }
        [TestCase(4)]
        [TestCase(int.MaxValue)]
        public void DividByLargeNum(int devident)
        {
            var group = _TestObjList.SumByGroup(t => t.prop, devident);
            Assert.AreEqual(_sumOfTestObj, group);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void InvalidGroupCountThrowException(int count)
        {
            var ex=Assert.Catch<ArithmeticException>(() =>
            {
                RevenuList.SumByGroup(t => t.Revenu, count);
            });
            Assert.AreEqual("Can't devid by 0", ex.Message);
        }

      

    }

    public class TestObj
    {
        public int prop { get; set; }
    }
}
