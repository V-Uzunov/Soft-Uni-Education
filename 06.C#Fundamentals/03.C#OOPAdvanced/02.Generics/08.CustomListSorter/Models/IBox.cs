namespace _08.CustomListSorter.Models
{
    public interface IBox<T>
    {
        void Add(T element);
        void Remove(int index);
        bool Contains(T element);
        void Swap(int index1, int index2);
        int Greater(T element);
        T Max();
        T Min();
    }
}
