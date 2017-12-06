namespace _03.Stack.Interfaces
{
    public interface IStackable<T>
    {
        void Push(params T[] items);

        T Pop();
    }
}
