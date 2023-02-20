// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// 1 -> 9 -> 48

var first = new LinkedList.LinkedListNode<int>(1);
var middle = new LinkedList.LinkedListNode<int>(9);
var last = new LinkedList.LinkedListNode<int>(48);

first.Next = middle;
middle.Next = last;


var list = new LinkedList.LinkedList<int>();
list.AddFirst(first);
list.AddLast(middle);

PrintList(first);

void PrintList(LinkedList.LinkedListNode<int>? node){
	while (node != null)
	{
		Console.WriteLine(node.Value);
		node = node.Next;
	}
}


