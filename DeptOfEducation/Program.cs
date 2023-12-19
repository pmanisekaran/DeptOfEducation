using System;
using System.Collections.Generic;

public class Program
{
	// Define the keypad matrix as a dictionary

	public static void Main(string[] args)
	{
		string[] instructions;
		if (args == null || args.Length == 0)
			instructions = new string[] { "LRULL", "RRDDDUD", "ULRDL", "UUUD" };
		else
			instructions = args;
		string code = CalculatePin.CalculateCode(instructions);
		Console.WriteLine($"The building code is: {code}");
	}
}
