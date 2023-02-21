namespace LinkedList.Tests.SinglyLinkedList;

public class RemoveTest
{
	[Fact]
	public void RemoveLast_Ten_Nodes()
	{
		LinkedList<int> list = new LinkedList<int>();
		for (int i = 0; i < 10; i++)
		{
			list.AddFirst(i);
		}

		for (int i = 10; i > 0; i--)
		{
			Assert.Equal(i, list.Count);
			list.RemoveLast();
		}

		Assert.Equal(0, list.Count);
		Assert.Null(list.Tail);
		Assert.Null(list.Head);
	}

	[Fact]
	public void RemoveFirstLast_Empty_Lists()
	{
		LinkedList<int> list = new LinkedList<int>();
		Assert.Equal(0, list.Count);
		Assert.Null(list.Head);
		Assert.Null(list.Tail);

		list.RemoveFirst();
		Assert.Equal(0, list.Count);
		Assert.Null(list.Head);
		Assert.Null(list.Tail);

		list.RemoveLast();
		Assert.Equal(0, list.Count);
		Assert.Null(list.Head);
		Assert.Null(list.Tail);
	}

	[Fact]
	public void RemoveFirstLast_One_Node()
	{
		LinkedList<int> list = new LinkedList<int>();

		list.AddFirst(10);
		list.RemoveFirst();
		Assert.Equal(0, list.Count);
		Assert.Null(list.Head);
		Assert.Null(list.Tail);

		list.AddFirst(10);
		list.RemoveLast();
		Assert.Equal(0, list.Count);
		Assert.Null(list.Head);
		Assert.Null(list.Tail);
	}
}