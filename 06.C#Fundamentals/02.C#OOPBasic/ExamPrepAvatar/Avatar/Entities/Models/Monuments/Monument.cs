public abstract class Monument : IMonument
{
    private string name;

    public Monument(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }
    public abstract double GetMonumentBonus();

    public override string ToString()
    {
        var name = this.GetType().Name;
        var index = name.IndexOf("Monument");
        name = name.Insert(index, " ");

        return $"###{name}: {this.Name},";
    }
}