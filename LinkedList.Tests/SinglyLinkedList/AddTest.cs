namespace LinkedList.Tests.SinglyLinkedList;

public class AddTest
{
	[Theory]
	[InlineData(new int[] { 1 })]
	[InlineData(new int[] { 1, 2, 3 })]
	[InlineData(new int[] { 0, 1, 3 })]
	public static void Add_First_Values(int[] values)
	{
		var result = new LinkedList<int>();
		foreach (var item in values)
			result.AddFirst(item);

		Assert.Equal(values.Length, result.Count);

		Assert.Equal(values.Last(), result.Head?.Value);
		Assert.Equal(values.First(), result.Tail?.Value);
	}

	[Theory]
	[InlineData(new int[] { 1 })]
	[InlineData(new int[] { 1, 2, 3 })]
	[InlineData(new int[] { 0, 1, 3 })]
	[InlineData(new int[] { 0, 1, 3,1,2,3,4,5,6,7,87888,88,8,7,6,5,4,4444444,333333 })]
	public static void Add_First_Node_Values(int[] values)
	{
		var result = new LinkedList<int>();
		foreach (var item in values)
			result.AddFirst(new LinkedListNode<int>(item));

		Assert.Equal(values.Length, result.Count);

		Assert.Equal(values.Last(), result.Head?.Value);
		Assert.Equal(values.First(), result.Tail?.Value);
	}



	[Theory]
	[InlineData(new int[] { 1 })]
	[InlineData(new int[] { 1, 2, 3 })]
	[InlineData(new int[] { 0, 1, 3 })]
	[InlineData(new int[] { 0, 1, 3, 1, 2, 3, 4, 5, 6, 7, 87888, 88, 8, 7, 6, 5, 4, 4444444, 333333 })]
	public static void Add_Last_Node_Values(int[] values)
	{
		var result = new LinkedList<int>();
		foreach (var item in values)
			result.AddLast(new LinkedListNode<int>(item));

		Assert.Equal(values.Length, result.Count);

		Assert.Equal(values.Last(), result.Tail?.Value);
		Assert.Equal(values.First(), result.Head?.Value);
	}
}