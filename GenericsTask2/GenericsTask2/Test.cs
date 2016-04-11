using System;
using System.Linq;
using NUnit.Framework;

namespace GenericsTask2
{
    [TestFixture]
    class Test
    {
        [Test]
        public void IfTypeAddedOnlyOnceNumberThisInObject1EqualOne()
        {
            var worker = new Worker();
            worker.Add<Random>();

            var res = worker.GetTuplesByType<Random>();
            Assert.That(res.Count() == 1);
        }

        [Test]
        public void IfTwoTypesAddedOnlyOnceNumberEachInObject1EqualOne()
        {
            var worker = new Worker();
            worker.Add<Random>();
            worker.Add<List>();

            var randomTyples = worker.GetTuplesByType<Random>();
            var listTyples = worker.GetTuplesByType<Random>();

            Assert.That(randomTyples.Count() == 1 && listTyples.Count() == 1);
        }

        //[Test]
        //public void Test2()
        //{
        //    var worker = new Worker();

        //    worker.Add<Random>();
        //    var tuples = worker.GetTuplesByType<Random>().ToList();
        //    var id = tuples.First().Item1;
        //    var @object = tuples.First().Item2;
        //    var randomObject = worker.GetObjectById<Random>(id);

        //    Assert.That(randomObject != null && tuples.Count() == 1 && @object == randomObject);
        //}
    }
}
