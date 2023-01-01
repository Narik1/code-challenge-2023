using System;
using System.IO;

namespace Narik.Code.Weekly.Week1;

internal class Program
{
	public static void Main(string[] args) {
		Palindrome palindrome;

		if (args.Length > 0) {
			string input = String.Empty;
			for (int i = 0; i < args.Length; i++) {
				input += args[i];
			}

			StringReader reader = new(input);
			palindrome = new(reader);
		} else {
			Console.WriteLine("Provide string to find palindrome within:");
			palindrome = new(Console.In);
		}

		Console.WriteLine($"Input: {palindrome.Input}");
		Console.WriteLine($"Output: {palindrome.Output}");
	}
}