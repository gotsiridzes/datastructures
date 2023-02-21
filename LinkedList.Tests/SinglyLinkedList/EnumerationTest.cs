namespace LinkedList.Tests.SinglyLinkedList;

public class EnumerationTest
{
	[Fact]
	public void Enumerate_Empty_List()
	{
		var lst = new LinkedList<int>();
		foreach (var i in lst) Assert.Fail("Enumeration contains no elements");
	}

	[Theory]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
	public void Enumerate_Various(int[] testCase)
	{
		var list = new LinkedList<int>();
		foreach (var value in testCase) list.AddLast(new LinkedListNode<int>(value));

		// repeat enumeration multiple times
		for (var i = 0; i < 3; i++)
		{
			Assert.Equal(testCase.Length, list.Count);

			var expectedIndex = 0;
			foreach (var value in list)
			{
				Assert.Equal(testCase[expectedIndex], value);

				expectedIndex++;
			}
		}
	}
}