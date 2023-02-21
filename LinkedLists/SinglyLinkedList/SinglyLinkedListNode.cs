namespace LinkedList.SinglyLinkedList;

public class SinglyLinkedListNode<T>
{
    public SinglyLinkedListNode(T? value) => Value = value;

    public T? Value { get; private set; }

    public SinglyLinkedListNode<T>? Next { get; set; }
}