using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree;

public class BinaryTree<T> :
	IEnumerable<T>
	where T : IComparable<T>
{
	private BinaryTreeNode<T>? _root;
	private int _count;

	public void Add(T value)
	{
		if (_root is null) _root = new BinaryTreeNode<T>(value);
		else AddTo(_root, value);
		_count++;
	}

	public void AddTo(BinaryTreeNode<T> node, T value)
	{
		// node.value is less than value
		if (node.CompareTo(value) < 0)
		{
			if (node.Left is null) node.Left = new BinaryTreeNode<T>(value);
			else AddTo(node.Left, value);
		}
		// node.value is greater or equal to value
		else
		{
			if (node.Right is null) node.Right = new BinaryTreeNode<T>(value);
			else AddTo(node.Right, value);
		}
	}

	public bool Contains(T value) => FindWithParent(value, out var parent) != null;

	private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T>? parent)
	{
		var current = _root;
		parent = null;
		while (current != null)
		{
			var result = current.CompareTo(value);
			if (result < 0) // value is greater than current.value, so current becomes rightmost value of root
			{
				parent = current;
				current = current.Right;
			}
			else if (result > 0) // value is less than current.value
			{
				parent = current;
				current = current.Left;
			}
			else break; // current. equals to value;
		}

		return current!;
	}

	public bool TryRemove(T value)
	{
		BinaryTreeNode<T>? current, parent;

		current = FindWithParent(value, out parent);

		if (current == null) return false;
		_count--;

		// 1. the node we are removing has no right child, so node's left child replaces node
		if (current.Left == null)
		{
			if (parent == null) _root = current.Left; // removing root node - replacing with its left node
			else
			{
				// determine whether we are updaging parent's left or right child link
				var result = current.CompareTo(value);
				if (result > 0) parent.Left = current.Left;
				else if (result < 0) parent.Right = current.Left;
			}

		}

		// 2. If current's right child has no left child, then current's right child replaces current node;
		if (current.Right.Left == null)
		{
			current.Right.Left = current.Left;

			if (parent == null) _root = current.Right;
			else
			{
				// determine whether we are updaging parent's left or right child link
				var result = parent.CompareTo(value);
				if (result > 0) parent.Left = current.Right;
				else if (result < 0) parent.Right = current.Right;
			}
		}
		else // 3. if deleted node's right child has left child, replace deleted node with right's left child
		{
			var left = current.Right.Left;
			var leftsParent = current.Right;

			while (left.Left != null)
			{
				leftsParent = left;
				left = left.Left;
			}
			left.Left = current.Left;
			left.Right = current.Right;

			if (current == null) _root = left;
			else
			{
				var result = current.CompareTo(value);
				if (result > 0) parent.Left = left;
				if (result < 0) parent.Right = left;

			}
		}
		return true;


	}

	#region PreOrderTraversal
	public void PreOrderTraversal(Action<T> process)
	{
		PreOrderTraversal(process, _root);
	}

	private void PreOrderTraversal(Action<T> process, BinaryTreeNode<T>? node)
	{
		if (node != null)
		{
			process(node.Value);
			PreOrderTraversal(process, node.Left);
			PreOrderTraversal(process, node.Right);
		}
	}
	#endregion PreOrderTraversal

	#region PostOrderTraversal

	public void PostOrderTraversal(Action<T> process)
	{
		PostOrderTraversal(process, _root);
	}

	private void PostOrderTraversal(Action<T> process, BinaryTreeNode<T>? node)
	{
		if (node != null)
		{
			PostOrderTraversal(process, node.Left);
			PostOrderTraversal(process, node.Right);
			process(node.Value);
		}
	}
	#endregion PostOrderTraversal

	#region InOrderTraversal
	public void InOrderTraversal(Action<T> process)
	{
		InOrderTraversal(process, _root);
	}

	private void InOrderTraversal(Action<T> process, BinaryTreeNode<T>? node)
	{
		if (node != null)
		{
			InOrderTraversal(process, node.Left);
			process(node.Value);
			InOrderTraversal(process, node.Right);
		}
	}
	#endregion InOrderTraversal

	// non recursive
	public IEnumerator<T> InOrderTraversal()
	{
		if (_root != null)
		{
			var stack = new Stack<BinaryTreeNode<T>>();
			var current = _root;
			stack.Push(current);

			var goLeftNext = true;

			while (stack.Count > 0)
			{
				if (goLeftNext)
				{
					while (current.Left != null)
					{
						stack.Push(current);
						current = current.Left;
					}
				}

				yield return current.Value;

				if (current.Right != null)
				{
					current = current.Right;
					goLeftNext = true;
				}
				else
				{
					current = stack.Pop();
					goLeftNext = false;
				}
			}
		}
	}

	public IEnumerator<T> GetEnumerator() => InOrderTraversal();

	IEnumerator IEnumerable.GetEnumerator() => InOrderTraversal();

	public void Clear() 
	{ 
		_root = null; 
		_count = 0; 
	}

	public int Count { get { return _count; } }
}
