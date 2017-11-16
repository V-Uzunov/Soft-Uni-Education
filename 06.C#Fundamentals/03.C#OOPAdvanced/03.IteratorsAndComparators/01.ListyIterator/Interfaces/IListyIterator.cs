namespace _01.ListyIterator.Interfaces
{
    public interface IListyIterator<T>
    {
        void Add(T elem);

        bool Move();

        T Print();

        bool HasNext();
        
    }
}
