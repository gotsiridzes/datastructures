using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Undo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private Stack<UndoAction> undoOps = new();
	private Random _rng = new();

	public MainWindow()
	{
		InitializeComponent();
	}

	private Brush GetRandomBrush()
	{
		var rgb = new byte[3];
		_rng.NextBytes(rgb);

		return new SolidColorBrush(Color.FromRgb(rgb[0], rgb[1], rgb[2]));
	}

	private void button4_Click(object sender, RoutedEventArgs e)
	{
		if (undoOps.Count > 0)
		{
			undoOps.Pop().Execute();
			UpdateList();
		}
	}

	private void btn1_Click(object sender, RoutedEventArgs e)
	{
		undoOps.Push(new UndoAction(btn1));
		btn1.Background = GetRandomBrush();
		UpdateList();
	}

	private void btn2_Click(object sender, RoutedEventArgs e)
	{
		undoOps.Push(new UndoAction(btn2));
		btn2.Background = GetRandomBrush();
		UpdateList();
	}

	private void btn3_Click(object sender, RoutedEventArgs e)
	{
		undoOps.Push(new UndoAction(btn3));
		btn3.Background = GetRandomBrush();
		UpdateList();
	}

	private void btn4_Click(object sender, RoutedEventArgs e)
	{
		undoOps.Push(new UndoAction(btn4));
		btn4.Background = GetRandomBrush();
		UpdateList();
	}

	private void UpdateList()
	{
		lstBox.Items.Clear();

		foreach (var action in undoOps)
			lstBox.Items.Add(action.ToString());
	}
}