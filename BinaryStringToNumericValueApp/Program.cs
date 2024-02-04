namespace BinaryStringToNumericValueApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] _tests = new string[]
			{
				"1101",
				"1011",
				"101111011011",
				"45",
				"0110",
				"",
				"rstgg",
				"1111111111111111111111111111111111111111111111111111111111111111",
				"11111111111111111111111111111111111111111111111111111111111111111",
				"111111111111111111111111111111111111111111111111111111111111111111"
			};
			for (int i = 0; i < _tests.Length; i++)
			{
				dynamic _value = BinaryToNumericValue(_tests[i]);
				Type _type = _value.GetType();

				Console.ForegroundColor = ConsoleColor.DarkMagenta;
				Console.Write(_tests[i]);
				Console.ResetColor();
				Console.Write(" is equivalent to: ");
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.Write(_value);
				Console.ResetColor();
				Console.Write(", and has the type of: ");
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.Write(_type + "\n\n");
				Console.ResetColor();
			}
			Console.WriteLine();
		}

		private static dynamic BinaryToNumericValue(string _binaryInput)
		{
			var _length = _binaryInput.Length;
			if (_length < 1 || string.IsNullOrEmpty(_binaryInput) || string.IsNullOrWhiteSpace(_binaryInput))
			{
				return (short)-1;
			}

			ulong _currentValue = 0;
			ulong _max = 1;
			for (var _index = _length - 1; _index >= 0; _index--)
			{
				char _char = _binaryInput[_index];
				ulong _cache = _currentValue;
				switch (_char)
				{
					case '0':
						break;
					case '1':
						_currentValue += _max == 0 ? 1 : _max;
						break;
					default:
						return (short)-1;
				}

				if (_currentValue < _cache)
				{
					return (short)-1;
				}

				_max *= 2;
			}

			return _currentValue switch
			{
				0 => -1,
				<= byte.MaxValue => (byte)_currentValue,
				<= ushort.MaxValue => (ushort)_currentValue,
				<= uint.MaxValue => (uint)_currentValue,
				_ => _currentValue
			};
		}
	}
}