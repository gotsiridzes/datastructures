namespace LinkedList;

/// <summary>
/// Singly linked list implementation, able to add, find, remove and enumerate
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkedList<T>
{
	/// <summary>
	/// First element of list, null if list is empty
	/// </summary>
	public LinkedListNode<T>? Head { get; private set; }

	/// <summary>
	/// Last node of singly linked list, null if list is empty
	/// </summary>
	public LinkedListNode<T>? Tail { get; private set; }

	/// <summary>
	/// Number of elements in list
	/// </summary>
	public int Count { get; private set; }

	public void AddFirst(T val) => AddFirst(new LinkedListNode<T>(val));

	/// <summary>
	/// Add node as start element of the list
	/// </summary>
	/// <param name="node"></param>
	public void AddFirst(LinkedListNode<T> node)
	{
		var tmp = Head; // save head pointer (i.e. rest of the list) in tmp variable
		Head = node; // node we are adding becomes new head of linked list
		Head.Next = tmp; // append rest of the list to new node

		Count++;

		if (Count == 1) // if list was empty, head and tail become new node
			Tail = Head;
	}

	public void AddLast(T val) => AddLast(new LinkedListNode<T>(val));

	public void AddLast(LinkedListNode<T> node)
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
				while (current?.Next != Tail)
					current = current?.Next;
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
			Head = Head?.Next;
			Count--;
			if (Count == 0) Tail = null;
		}
	}
}