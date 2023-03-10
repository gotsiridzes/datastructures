using System.Collections;

namespace LinkedList.SinglyLinkedList;

/// <summary>
/// Singly linked list implementation, able to add, find, remove and enumerate
/// </summary>
/// <typeparam name="T"></typeparam>
public class SinglyLinkedList<T> : IEnumerable<T>
{
    /// <summary>
    /// First element of list, null if list is empty
    /// </summary>
    public SinglyLinkedListNode<T>? Head { get; private set; }

    /// <summary>
    /// Last node of singly linked list, null if list is empty
    /// </summary>
    public SinglyLinkedListNode<T>? Tail { get; private set; }

    /// <summary>
    /// Number of elements in list
    /// </summary>
    public int Count { get; private set; }

    public void AddFirst(T val) => AddFirst(new SinglyLinkedListNode<T>(val));

    /// <summary>
    /// Add node as start element of the list
    /// </summary>
    /// <param name="node"></param>
    public void AddFirst(SinglyLinkedListNode<T> node)
    {
        var tmp = Head; // save head pointer (i.e. rest of the list) in tmp variable
        Head = node; // node we are adding becomes new head of linked list
        Head.Next = tmp; // append rest of the list to new node

        Count++;

        if (Count == 1) // if list was empty, head and tail become new node
            Tail = Head;
    }

    public void AddLast(T val) => AddLast(new SinglyLinkedListNode<T>(val));

    public void AddLast(SinglyLinkedListNode<T> node)
    {
        if (Count == 0)
            Head = node;
        else if (Tail != null) Tail.Next = node;

        Count++;
        Tail = node;
    }

    public void RemoveLast()
    {
        if (Count != 0)
        {
            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                var current = Head;
                while (current!.Next != Tail)
                    current = current.Next;
                current.Next = null;
                Tail = current;
            }

            Count--;
        }
    }

    public void RemoveFirst()
    {
        if (Count != 0)
        {
            Head = Head!.Next;
            Count--;
            if (Count == 0) Tail = null;
        }
    }

    public bool Contains(T val)
    {
        var current = Head;
        while (current != null)
        {
            if (current.Value!.Equals(val)) return true;
            current = current.Next;
        }

        return false;
    }

    public bool Remove(T item)
    {
        // 1. empty list - do nothing
        // 2. single node - 
        // 3. many nodes
        //   1 - node to remove is the first element
        //   2 - node to remove is middle or last

        SinglyLinkedListNode<T>? previous = null;
        var current = Head;

        while (current != null)
        {
            if (current.Value!.Equals(item))
            {
                if (previous == null) RemoveFirst(); // 2. single node case or 3.1 - node to remove is the first one
                else
                {
                    // 3.2 middle or last
                    previous.Next = current.Next;
                    if (current.Next == null) Tail = previous;
                    Count--;
                }

                return true;
            }

            previous = current;
            current = current.Next;
        }

        return false; // 1. empty list
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (Count != 0)
        {
            var current = Head;
            while (current!.Next != null)
            {
                yield return current.Value!;
                current = current.Next;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}