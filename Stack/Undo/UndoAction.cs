using System.Windows.Controls;
using System.Windows.Media;

namespace Undo;

public class UndoAction
{
	private readonly Button _button;
	private readonly Brush _brush;

	public UndoAction(Button button)
	{
		_button = button;
		_brush = button.Background.CloneCurrentValue();
	}

	public void Execute() => _button.Background = _brush;

	public override string ToString() => $"{_button.Content}: {_brush.ToString()}";
}