using System;
using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;

namespace Unshift
{
	internal sealed class UnshiftKeyProcessor : KeyProcessor
	{
		private readonly Dictionary<Key, Tuple<char, char>> _keyChars =
			new Dictionary<Key, Tuple<char, char>>
			{
				{ Key.D1, new Tuple<char, char>('!', '1') },
				{ Key.D2, new Tuple<char, char>('@', '2') },
				{ Key.D3, new Tuple<char, char>('#', '3') },
				{ Key.D4, new Tuple<char, char>('$', '4') },
				{ Key.D5, new Tuple<char, char>('%', '5') },
				{ Key.D6, new Tuple<char, char>('^', '6') },
				{ Key.D7, new Tuple<char, char>('&', '7') },
				{ Key.D8, new Tuple<char, char>('*', '8') },
				{ Key.D9, new Tuple<char, char>('(', '9') },
				{ Key.D0, new Tuple<char, char>(')', '0') },
			};


		private readonly IEditorOperations _operations;

		public UnshiftKeyProcessor(IEditorOperations operations)
		{
			_operations = operations;
		}

		public override void KeyDown(KeyEventArgs args)
		{
			Tuple<char, char> tuple;
			if (!_keyChars.TryGetValue(args.Key, out tuple))
			{
				return;
			}
			bool shiftIsDown = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
			var charToInsert = shiftIsDown ? tuple.Item2 : tuple.Item1;
			_operations.InsertText(charToInsert.ToString());
			args.Handled = true;
		}
	}
}