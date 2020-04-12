using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace States
{
    public class SortByArea: IComparer<State>
    {
        int IComparer<State>.Compare(State s1, State s2)
        {
            return s1.Area.CompareTo(s2.Area);
        }
    }
}
