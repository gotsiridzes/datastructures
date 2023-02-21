namespace LinkedList.DoublyLinkedList;

public class DoublyLinkedListNode<T>
{
	public T Value { get; set; }
	public DoublyLinkedList<T>? Next { get; set; }
	public DoublyLinkedList<T>? Previous { get; set; }
	
	public DoublyLinkedListNode(T val) => Value = val;
}