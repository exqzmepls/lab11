using System;

namespace States
{
    public class Monarchy: State
    {
        public Monarchy() : base()
        {
            Monarch = "";
            MainReligion = "";
        }
        public Monarchy(string title, string capital, string continent, double area, int population, string monarch, string mainReligion) : base(title, capital, continent, area, population)
        {
            Monarch = monarch;
            MainReligion = mainReligion;
        }
        public string Monarch { get; set; }
        public string MainReligion { get; set; }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Monarch - " + Monarch);
            Console.WriteLine("Main Religion - " + MainReligion);
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Monarchy m = obj as Monarchy;
                if (m == null) return false;
                return m.Monarch == Monarch && m.MainReligion == MainReligion;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() + Monarch.GetHashCode() + MainReligion.GetHashCode();
        }
        static public Monarchy[] AreaLessThan(State[] states, double area)
        {
            Monarchy[] result = new Monarchy[0];
            foreach (State s in states) if (s is Monarchy && s.Area < area)
                {
                    Monarchy m = s as Monarchy;
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = (Monarchy)m.Clone();
                }
            return result;
        }
        public override object Clone()
        {
            return new Monarchy(Title, Capital, Continent, Area, Population, Monarch, MainReligion);
        }

        public State BaseState()
        {
            return new State(Title, Capital, Continent, Area, Population);
        }
    }
}
