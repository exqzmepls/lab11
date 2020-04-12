namespace States
{
    public interface IExecutable
    {
        string Title { get; set; }
        string Capital { get; set; }
        string Continent { get; set; }
        double Area { get; set; }
        int Population { get; set; }
        void Print();
        double Density();
    }
}
