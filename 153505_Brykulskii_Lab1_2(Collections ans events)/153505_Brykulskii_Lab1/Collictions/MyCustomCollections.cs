using System.Collections;

class MyCustomCollections<T> : ICustomCollection<T>, IEnumerable<T>
{
    private Node<T>? head;
    private Node<T>? current;
    private Node<T>? tail;
    public int Count { get; private set; }



    public MyCustomCollections()
    {
        head = null;
        current = null;
        Count = 0;
    }
    public T this[int index]
    {
        get
        {
            Node<T>? node = head;
            if (index < 0 || index >= Count || node == null)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = 0; i < index; i++)
            {
                if (node.Next == null)
                    throw new IndexOutOfRangeException();
                node = node.Next;
            }
            return node.Data;
        }
        set
        {
            Node<T>? node = head;

            if (index < 0 || index >= Count || node == null)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = 0; i < index; i++)
            {
                if (node.Next == null)
                    throw new IndexOutOfRangeException();
                node = node.Next;
            }
            node.Data = value;
        }
    }
    public void Reset()
    {
        current = head;
    }
    public void Next()
    {
        if (current == null)
            throw new InvalidOperationException();
        current = current.Next;
    }
    public T Current()
    {
        if (current == null)
            throw new InvalidOperationException();
        return current.Data;
    }

    public void Add(T item)
    {
        Node<T> node = new(item);
        if (head == null)
        {
            current = node;
            head = node;
            tail = node;
        }
        else
        {
            tail.Next = node;
            node.Prev = tail;
            tail = node;
        }
        Count++;
    }

    public void Remove(T item)
    {
        Node<T>? node = head;
        if (!this.Contains(item))
        {
            throw new RemoveException("Item not found", item.GetHashCode());
        }
        while (node != null)
        {
            if (node.Data.Equals(item))
            {
                Count--;
                if (node.Prev != null)
                {
                    node.Prev.Next = node.Next;

                    if (node.Next == null)
                    {
                        tail = node.Prev;
                    }
                    else
                    {
                        node.Next.Prev = node.Prev;
                    }
                }
                else
                {
                    if (node.Next != null)
                    {
                        node.Next.Prev = null;
                        head = node.Next;
                    }
                    else
                    {
                        head = null;
                        return;
                    }
                }
            }
            node = node.Next;
        }
        this.Reset();
    }
    public T RemoveCurrent()
    {
        if (current == null)
            throw new InvalidOperationException();
        T result = current.Data;

        if (current.Prev != null)
        {
            current.Prev.Next = current.Next;
            if (current.Next == null)
            {
                tail = current.Prev;
            }
            else
            {
                current.Next.Prev = current.Prev;
            }
        }
        else
        {
            if (current.Next != null)
            {
                current.Next.Prev = null;
                head = current.Next;
            }
            else
            {
                head = null;
                current = null;
            }
        }
        current = head;
        Count--;
        return result;
    }

    public bool Contains(T item)
    {
        Node<T>? node = head;
        while (node != null)
        {
            if (node.Data.Equals(item))
            {
                return true;
            }
            node = node.Next;
        }
        return false;
    }
    new public string GetType()
    {
        return typeof(T).ToString();
    }
    public IEnumerator<T> GetEnumerator()
    {
         Node<T>? current = head;
         while (current != null)
         {
             yield return current.Data;
             current = current.Next;
         }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
