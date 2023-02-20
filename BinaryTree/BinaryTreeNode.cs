﻿namespace BinaryTree;

public class BinaryTreeNode<TNode>
	: IComparable<TNode>
	where TNode : IComparable<TNode>
{
	public TNode Value { get; init; }
	public BinaryTreeNode<TNode>? Left { get; set; }
	public BinaryTreeNode<TNode>? Right { get; set; }

	public BinaryTreeNode(TNode value) => Value = value;

	public int CompareTo(TNode? other) => Value.CompareTo(other);
}
