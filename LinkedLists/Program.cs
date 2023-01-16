
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// 1 -> 9 -> 48

var first = new LinkedLists.LinkedListNode<int> { Value = 1 };
var middle = new LinkedLists.LinkedListNode<int> { Value = 9 };
var last = new LinkedLists.LinkedListNode<int>{Value = 48};

first.Next = middle;
middle.Next = last;

PrintList(first);

void PrintList(LinkedLists.LinkedListNode<int> node){
	while (node != null)
	{
		Console.WriteLine(node.Value);
		node = node.Next;
	}
}


