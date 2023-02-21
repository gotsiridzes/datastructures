using System.Collections;

namespace LinkedList.DoublyLinkedList;

public class DoublyLinkedList<T> : IEnumerable<T>
{
	/// <summary>
	/// First element of list, null if list is empty
	/// </summary>
	public DoublyLinkedListNode<T>? Head { get; private set; }

	/// <summary>
	/// Last node of singly linked list, null if list is empty
	/// </summary>
	public DoublyLinkedListNode<T>? Tail { get; private set; }

	public IEnumerator<T> GetEnumerator() => throw new NotImplementedException();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}