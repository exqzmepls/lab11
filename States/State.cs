using System;

namespace States
{
    public class State: IExecutable, ICloneable, IComparable
    {
        double area;
        int population;

        public State()
        {
            Title = "";
            Capital = "";
            Continent = "";
            Population = 0;
            Area = 0;
        }
        public State(string title, string capital, string continent, double area, int population)
        {
            Title = title;
            Capital = capital;
            Continent = continent;
            Population = population;
            Area = area;
        }
        public string Continent { get; set; }
        public string Title { get; set; }
        public string Capital { get; set; }
        public double Area
        {
            get { return area; }
            set { area = (value < 0) ? 0 : value; }
        }
        public int Population
        {
            get { return population; }
            set { population = (value < 0) ? 0 : value; }
        }
        public double Density()
        {
            if (Area == 0) return 0;
            return Math.Round(Population / Area, 2);
        }
        public override bool Equals(object obj)
        {
            State s = obj as State;
            if (s == null) return false;
            return Title == s.Title && Capital == s.Capital && Continent == s.Continent && Area == s.Area && Population == s.Population;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode() + Capital.GetHashCode() + Continent.GetHashCode() + Area.GetHashCode() + Population.GetHashCode();
        }

        public virtual void Print()
        {
            Console.WriteLine($"{Title} (capital - {Capital})");
            Console.WriteLine("Continent - " + Continent);
            Console.WriteLine("Area = " + Area + " million km2");
            Console.WriteLine("Population = " + Population + " million people");
        }
        public virtual int CompareTo(object obj)
        {
            return String.Compare(this.Title, ((State)obj).Title);
        }
        public virtual object Clone()
        {
            return new State(Title, Capital, Continent, Area, Population);
        }
    }
}
