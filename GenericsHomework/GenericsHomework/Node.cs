﻿namespace GenericsHomework
{
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
                throw new InvalidOperationException("value already exists");
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
            // it is not sufficient to only set Next to itself, we need to unlink the current node from the list
            // garbage collector built into C# will automaticaly collect the rest of the other nodes 
            Node<T> current = this;
            current.Next = this;

        }

        public override string ToString()
        {
            Node<T> current = this;

            string result = "LinkedList: ";
            while (current.Next != this)
            {
                result += current.Data + " - ";
                current = current.Next;
            }
            result += current.Data;

            return result;

        }

    }
}
