public class CalculatePin
{
	private static Dictionary<char, (int col, int row)> _keypad = new Dictionary<char, (int col, int row)>
		{
			{ '1', (-1, -1) }, { '2', (0, -1) }, { '3', (1, -1) },
			{ '4', (-1, 0) }, { '5', (0, 0) }, { '6', (1, 0) },
			{ '7', (-1, 1) }, { '8', (0, 1) }, { '9', (1, 1) }
		};

	/// <summary>
	/// return the code given list of istructions such as { "LRULL", "RRDDDUD", "ULRDL", "UUUD" };
	/// Initial position is 5.
	/// </summary>
	/// <param name="instructions"> Instructions as to how to move</param>
	/// <param name="startFromLastPosition"> if not passed, startFromLastPosition is true. If true, betweend each instruction 
	/// the starting postion is where the previous instruction left off. If false starting position is always 5 between each instruction.
	/// </param>
	/// <returns>return a string consisting the code</returns>
	public static string CalculateCode(string[] instructions, bool startFromLastPosition = true)
	{

		if (instructions == null || instructions.Length == 0)
			throw new ArgumentException("Instructions not valid");

		char currentButton = '5'; // Starting from the "5" button
		string code = "";

		foreach (string instruction in instructions)
		{
			if (!startFromLastPosition)
				currentButton = '5'; // for each instruction always start from 5

			foreach (char move in instruction)
			{
				// Calculate the new position based on the current move
				int col = _keypad[currentButton].col;
				int row = _keypad[currentButton].row;
				int newX = Math.Clamp(col + MoveLocationLeftOrRIght(move), -1, 1);
				int newY = Math.Clamp(row + MoveLocationUpOrDown(move), -1, 1);

				// Check if the new position is valid on the keypad
				char newButton = _keypad.FirstOrDefault(x => x.Value == (newX, newY)).Key;
				if (newButton != '\0')
					currentButton = newButton; // Update the current button if it's a valid move
			}

			code += currentButton; // Add the button to the code
		}

		return code;
	}

	private static int MoveLocationLeftOrRIght(char move)
	{
		return (move == 'L' ? -1 : (move == 'R' ? 1 : 0));
	}

	private static int MoveLocationUpOrDown(char move)
	{
		return (move == 'U' ? -1 : (move == 'D' ? 1 : 0));
	}
}