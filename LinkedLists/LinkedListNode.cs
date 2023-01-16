namespace LinkedLists;

public class LinkedListNode<T>
{
	public LinkedListNode(T? value)
	{
		Value = value;
	}

	public T? Value { get; init; }

	public LinkedListNode<T>? Next { get; set; }
}