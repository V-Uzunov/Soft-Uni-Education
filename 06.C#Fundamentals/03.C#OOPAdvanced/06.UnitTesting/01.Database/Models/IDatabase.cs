namespace _01.Database.Models
{
    public interface IDatabase
    {
        void Add(int element);

        void Remove();

        int[] Fetch();
    }
}
