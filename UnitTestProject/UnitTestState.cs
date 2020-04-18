using Microsoft.VisualStudio.TestTools.UnitTesting;
using States;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestState
    {
        [TestMethod]
        public void TestTitle()
        {
            State s = new Monarchy();
            s.Title = "title";
            string title = "title";
            Assert.AreEqual(s.Title, title);
        }
        [TestMethod]
        public void TestCapital()
        {
            State s = new Monarchy();
            s.Capital = "capital";
            string capital = "capital";
            Assert.AreEqual(s.Capital, capital);
        }
        [TestMethod]
        public void TestContinent()
        {
            State s = new Monarchy();
            s.Continent = "continent";
            string continent = "continent";
            Assert.AreEqual(s.Continent, continent);
        }
        [TestMethod]
        public void TestAreaBellowZero()
        {
            State s = new Monarchy();
            s.Area = -100.7;
            double area = 0;
            Assert.AreEqual(s.Area, area);
        }
        [TestMethod]
        public void TestArea()
        {
            State s = new Monarchy();
            s.Area = 100.7;
            double area = 100.7;
            Assert.AreEqual(s.Area, area);
        }
        [TestMethod]
        public void TestPopulationBellowZero()
        {
            State s = new Monarchy();
            s.Population = -100;
            double population = 0;
            Assert.AreEqual(s.Population, population);
        }
        [TestMethod]
        public void TestPopulation()
        {
            State s = new Monarchy();
            s.Population = 100;
            double population = 100;
            Assert.AreEqual(s.Population, population);
        }
        [TestMethod]
        public void TestDensity()
        {
            State s = new Monarchy();
            s.Population = 100;
            s.Area = 1;
            double density = 100;
            Assert.AreEqual(s.Density(), density);
        }
        [TestMethod]
        public void TestDensityZeroArea()
        {
            State s = new Monarchy();
            s.Population = 100;
            double density = 0;
            Assert.AreEqual(s.Density(), density);
        }
        [TestMethod]
        public void TestCompareTo()
        {
            State s1 = new Monarchy();
            s1.Title = "a";
            State s2 = new Monarchy();
            s2.Title = "b";
            int result = -1;
            Assert.AreEqual(s1.CompareTo(s2), result);
        }
        [TestMethod]
        public void TestEquals()
        {
            State s = new Monarchy();
            object o = new object();
            Assert.AreEqual(s.Equals(o), false);
        }
        [TestMethod]
        public void TestClone()
        {
            State s = new State("s", "c", "c", 1.1, 1);
            State sClone = (State)s.Clone();
            Assert.AreEqual(s.Equals(sClone), true);
        }
    }
}
