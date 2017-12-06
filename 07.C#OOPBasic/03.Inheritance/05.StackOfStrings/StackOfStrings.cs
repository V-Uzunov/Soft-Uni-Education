using System.Collections.Generic;

public class StackOfStrings : Stack<string>
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data=new List<string>();
    }

    public void Push(string item)
    {
        base.Push(item);
    }

    public string Pop()
    {
        return base.Pop();
    }

    public string Peek()
    {
        return base.Peek();
    }

    public bool IsEmpty()
    {
        return true;
    }
}

