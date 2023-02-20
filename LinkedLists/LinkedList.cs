namespace LinkedList;

public class LinkedList<T>
{
	public LinkedListNode<T>? Head { get; private set; }
	public LinkedListNode<T>? Tail { get; private set; }
	public int Count { get; private set; }

	public void AddFirst(LinkedListNode<T> node)
	{
		var tmp = Head;
		Head = node;
		Head.Next = tmp;

		Count++;

		if (Count == 1)
			Tail = Head;
	}

	public void AddLast(LinkedListNode<T> node)
	{
		if (Count == 0)
			Head = node;
		else if (Tail != null) Tail.Next = node;

		Count++;
		Tail = node;
	}
}