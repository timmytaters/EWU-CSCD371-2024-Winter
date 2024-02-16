namespace GenericsHomework;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T data)
    {
        Data = data;
        //Set to this so not nullable
        Next = this;
    }

    public void Append(T value)
    {
        if (Exists(value))
        {
            throw new ArgumentException("Value already exists");
        }

        Node<T> newNode = new(value);
        newNode.Next = this.Next;
        this.Next = newNode;
    }
    public bool Exists(T value)
    {
        Node<T> current = this;
        T startValue = this.Data;

        do
        {
            if (current.Data!=null&&current.Data.Equals(value))
            {
                return true;

            }
            current = current.Next;

        } while (current.Data!=null && !current.Data.Equals(startValue));
        return false;

    }

    public void Clear()
    {
        // it is sufficient to only set Next to itself, we need to unlink the current node from the list
        // garbage collector built into C# will automaticaly collect the rest of the other nodes once there is no available reference to them
        this.Next = this;
    }

    public override string ToString()
    {
        if(this == null || this.Data == null || Data.ToString() == null)
        {
            return "Null";
        }
#pragma warning disable CS8603 // Possible null reference return. Can suppress since null checked abov
        return Data.ToString();
#pragma warning restore CS8603 // Possible null reference return.
    }
}
