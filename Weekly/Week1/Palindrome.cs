namespace Narik.Code.Weekly;

public sealed class Palindrome
{
	public string Input { get; private set; }

	public Palindrome(System.IO.TextReader inputReader) {
		Input = inputReader.ReadToEnd();
	}
}