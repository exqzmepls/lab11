using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab11;
using States;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestCollections
    {
        [TestMethod]
        public void TestDesigner1()
        {
            TestCollections tc = new TestCollections(8);

            bool result = tc.Collection00First != null && tc.Collection01First != null && tc.Collection10Last.Value != null && tc.Collection11Last.Value != null;

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestDesigner2()
        {
            bool result;
            try
            {
                TestCollections tc = new TestCollections(2);
                result = true;
            }
            catch
            {
                result = false;
            }
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestCollection00Contains()
        {
            TestCollections tc = new TestCollections(8);
            long time;
            bool result = tc.Collection00Contains(tc.Collection00Middle, out time);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestCollection01Contains()
        {
            TestCollections tc = new TestCollections(8);
            long time;
            bool result = tc.Collection01Contains(tc.Collection01Middle, out time);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestCollection10ContainsKey()
        {
            TestCollections tc = new TestCollections(8);
            long time;
            bool result = tc.Collection10ContainsKey(tc.Collection10Middle.Key, out time);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestCollection10ContainsValue()
        {
            TestCollections tc = new TestCollections(8);
            long time;
            bool result = tc.Collection10ContainsValue(tc.Collection10First.Value, out time);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestCollection11ContainsKey()
        {
            TestCollections tc = new TestCollections(8);
            long time;
            bool result = tc.Collection11ContainsKey(tc.Collection11Middle.Key, out time);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestCollection00AddLast()
        {
            TestCollections tc = new TestCollections(8);
            State last = tc.Collection00Last;
            tc.Collection00AddLast(tc.NotIncluded);
            Assert.AreEqual(last.Equals(tc.Collection00Last), false);
        }

        [TestMethod]
        public void TestCollection00RemoveLast1()
        {
            TestCollections tc = new TestCollections(5);
            tc.Collection00RemoveLast();
            tc.Collection00RemoveLast();
            Assert.AreEqual(tc.Collection00RemoveLast(), true);
        }

        [TestMethod]
        public void TestCollection00RemoveLast2()
        {
            TestCollections tc = new TestCollections(5);
            tc.Collection00RemoveLast();
            tc.Collection00RemoveLast();
            tc.Collection00RemoveLast();
            tc.Collection00RemoveLast();
            tc.Collection00RemoveLast();
            Assert.AreEqual(tc.Collection00RemoveLast(), false);
        }

        [TestMethod]
        public void TestCollection01AddLast()
        {
            TestCollections tc = new TestCollections(8);
            string last = tc.Collection01Last;
            tc.Collection01AddLast(tc.NotIncluded.Title);
            Assert.AreEqual(last.Equals(tc.Collection01Last), false);
        }

        [TestMethod]
        public void TestCollection01RemoveLast1()
        {
            TestCollections tc = new TestCollections(5);
            tc.Collection01RemoveLast();
            tc.Collection01RemoveLast();
            Assert.AreEqual(tc.Collection01RemoveLast(), true);
        }

        [TestMethod]
        public void TestCollection01RemoveLast2()
        {
            TestCollections tc = new TestCollections(5);
            tc.Collection01RemoveLast();
            tc.Collection01RemoveLast();
            tc.Collection01RemoveLast();
            tc.Collection01RemoveLast();
            tc.Collection01RemoveLast();
            Assert.AreEqual(tc.Collection01RemoveLast(), false);
        }
        [TestMethod]
        public void TestCollection10Add1()
        {
            TestCollections tc = new TestCollections(8);
            Republic r = tc.NotIncluded;
            tc.Collection10Add(r);
            long time;
            Assert.AreEqual(tc.Collection10ContainsKey(r.BaseState(), out time), true);
        }

        [TestMethod]
        public void TestCollection10Add2()
        {
            TestCollections tc = new TestCollections(8);
            Assert.AreEqual(tc.Collection10Add(tc.Collection10First.Value), false);
        }

        [TestMethod]
        public void TestCollection10Remove1()
        {
            TestCollections tc = new TestCollections(5);
            tc.Collection10Remove(tc.Collection10First.Key);
            tc.Collection10Remove(tc.Collection10First.Key);
            Assert.AreEqual(tc.Collection10Remove(tc.Collection10First.Key), true);
        }

        [TestMethod]
        public void TestCollection10Remove2()
        {
            TestCollections tc = new TestCollections(5);
            tc.Collection10Remove(tc.Collection10First.Key);
            tc.Collection10Remove(tc.Collection10First.Key);
            tc.Collection10Remove(tc.Collection10First.Key);
            tc.Collection10Remove(tc.Collection10First.Key);
            tc.Collection10Remove(tc.Collection10First.Key);
            Assert.AreEqual(tc.Collection10Remove(tc.Collection10First.Key), false);
        }

        [TestMethod]
        public void TestCollection11Add1()
        {
            TestCollections tc = new TestCollections(8);
            Republic r = tc.NotIncluded;
            tc.Collection11Add(r);
            long time;
            Assert.AreEqual(tc.Collection11ContainsKey(r.Title, out time), true);
        }

        [TestMethod]
        public void TestCollection11Add2()
        {
            TestCollections tc = new TestCollections(8);
            Assert.AreEqual(tc.Collection11Add(tc.Collection11First.Value), false);
        }

        [TestMethod]
        public void TestCollection11Remove1()
        {
            TestCollections tc = new TestCollections(5);
            tc.Collection11Remove(tc.Collection11First.Key);
            tc.Collection11Remove(tc.Collection11First.Key);
            Assert.AreEqual(tc.Collection11Remove(tc.Collection11First.Key), true);
        }

        [TestMethod]
        public void TestCollection11Remove2()
        {
            TestCollections tc = new TestCollections(5);
            tc.Collection11Remove(tc.Collection11First.Key);
            tc.Collection11Remove(tc.Collection11First.Key);
            tc.Collection11Remove(tc.Collection11First.Key);
            tc.Collection11Remove(tc.Collection11First.Key);
            tc.Collection11Remove(tc.Collection11First.Key);
            Assert.AreEqual(tc.Collection11Remove(tc.Collection11First.Key), false);
        }
    }
}
