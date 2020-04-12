using System;

namespace States
{
    public class Republic: State
    {
        int parlamentSize;
        public Republic() : base()
        {
            President = "";
            ParlamentSize = 0;
        }
        public Republic(string title, string capital, string continent, double area, int population, string president, int parlamentSize) : base(title, capital, continent, area, population)
        {
            President = president;
            ParlamentSize = parlamentSize;
        }
        public string President { get; set; }
        public int ParlamentSize
        {
            get { return parlamentSize; }
            set { parlamentSize = (value < 0) ? 0 : value; }
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("President - " + President);
            Console.WriteLine("Size of parlament = " + ParlamentSize + " members");
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Republic r = obj as Republic;
                if (r == null) return false;
                return r.ParlamentSize == ParlamentSize && r.President == President;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() + ParlamentSize.GetHashCode() + President.GetHashCode();
        }
        static public Republic[] PopulationMoreThan(State[] states, int population)
        {
            Republic[] result = new Republic[0];
            foreach (State s in states) if (s is Republic && s.Population > population)
                {
                    Republic r = s as Republic;
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = (Republic)r.Clone();
                }
            return result;
        }
        public override object Clone()
        {
            return new Republic(Title, Capital, Continent, Area, Population, President, ParlamentSize);
        }

        public State BaseState()
        {
            return new State(Title, Capital, Continent, Area, Population);
        }
    }
}
