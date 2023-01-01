using System;
using System.Diagnostics.CodeAnalysis;

namespace Narik.Code.Weekly.Week1;

public sealed class Palindrome
{
	private readonly bool _caseMatters;

	public string Input { get; private set; }

	private string? _palindrome;
	public string Output {
		get {
			if (_palindrome is null) {
				CalculatePalindrome();
			}

			return _palindrome;
		}
	}


	public Palindrome(System.IO.TextReader inputReader, bool caseMatters = false) {
		Input = inputReader.ReadLine() ?? String.Empty;

		_caseMatters = caseMatters;
	}

	[MemberNotNull(nameof(_palindrome))]
	private void CalculatePalindrome() {
		_palindrome = String.Empty;

		int newLength = 1;
		do {
			for (int i = 0; i < Input.Length - newLength; i++) {
				string testCase = Input[i..(i + newLength)];
				string reverseCase = Reverse(testCase);

				if (_caseMatters && testCase == reverseCase) {
					_palindrome = testCase;
					break;
				} else if (!_caseMatters && testCase.ToLowerInvariant() == reverseCase.ToLowerInvariant()) {
					_palindrome = testCase;
					break;
				}
			}
		} while (++newLength <= Input.Length);
	}

	/// <summary>
	/// Reverses a string on a char basis.
	/// Only works in Unicode BMP due to char being UTF-16.
	/// </summary>
	/// <param name="input">The string to be reversed</param>
	/// <returns>The reverse string of the input</returns>
	private static string Reverse(string input) {
		char[] temp = input.ToCharArray();
		Array.Reverse(temp);
		return new(temp);
	}
}