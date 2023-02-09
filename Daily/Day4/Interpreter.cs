using System;
using System.Collections.Generic;
using System.IO;

namespace Narik.CodeChallenge.Day4;

public class Interpreter
{
	public readonly List<byte> memory = new(new byte[64_000]);
	public int instructionPointer = 0;

	private readonly Stack<long> _bracketPositions = new();

	private readonly Dictionary<char, Action> _commands = new();

	private readonly Stream _code;
	private readonly long _initialCodePosition;
	private readonly TextReader _in;
	private readonly TextWriter _out;

	/// <summary>
	/// Arguments will not be Disposed/Closed
	/// </summary>
	/// <param name="codeStream">The stream from which code will be read</param>
	/// <param name="inStream">The stream from which input will be read</param>
	/// <param name="outStream">The stream for which output will be written</param>
	public Interpreter(Stream codeStream, TextReader inStream, TextWriter outStream) {
		_code = codeStream;
		_in = inStream;
		_out = outStream;

		_initialCodePosition = _code.Position;

		_commands['+'] = Increment;
		_commands['-'] = Decrement;
		_commands['>'] = PointerIncrement;
		_commands['<'] = PointerDecrement;
		_commands[','] = ReadInput;
		_commands['.'] = PrintOutput;
		_commands['['] = StartLoop;
		_commands[']'] = BreakLoop;
	}

	/// <summary>
	/// Reads and interprets the code stream until end of stream is reached
	/// </summary>
	/// <param name="qQuits">When true, a 'q' character in the code stream will stop the interpreter by
	/// setting the code stream's position to the end of the stream</param>
	public void Interpret(bool qQuits = true) {
		if (qQuits) {
			_commands['q'] = Quit;
		} else if (_commands.ContainsKey('q')) {
			_commands.Remove('q');
		}

		int nextChar = _code.ReadByte();
		while (nextChar != -1) {
			// Any characters not found in the list of commands will be ignored
			if (_commands.TryGetValue((char)nextChar, out var command)) {
				command();
			}

			nextChar = _code.ReadByte();
		}
	}

	/// <summary>
	/// Resets the intepreter back to the start of the code and resets memory
	/// </summary>
	public void Reset() {
		_code.Position = _initialCodePosition;
		_out.Flush();

		memory.Clear();
		instructionPointer = 0;

		_bracketPositions.Clear();
	}


	private void Increment() {
		memory[instructionPointer]++;
	}

	private void Decrement() {
		memory[instructionPointer]--;
	}

	private void PointerIncrement() {
		// If out of memory, add more
		if (memory.Count == ++instructionPointer) {
			memory.Add(0);
		}
	}

	private void PointerDecrement() {
		if (instructionPointer > 0) {
			instructionPointer--;
		}
	}

	private void ReadInput() {
		int input = _in.Read();

		// If the input is invalid, set memory cell to 0
		memory[instructionPointer] = input == -1 || input > 255 ? (byte)0 : (byte)input;
	}

	private void PrintOutput() {
		_out.Write((char)memory[instructionPointer]);
	}

	private void StartLoop() {
		if (memory[instructionPointer] > 0) {
			_bracketPositions.Push(_code.Position);
		} else { // If we aren't entering the "loop", skip until the end of the "loop"
			int depth = 1;
			int nextChar;
			do {
				nextChar = _code.ReadByte();
				if (nextChar == ']') {
					depth--;
				} else if (nextChar == '[') {
					depth++;
				}
			} while (nextChar != -1 && depth > 0);
		}
	}

	private void BreakLoop() {
		if (memory[instructionPointer] is 0) {
			_bracketPositions.Pop();
		} else {
			_code.Position = _bracketPositions.Peek();
		}
	}

	private void Quit() {
		_code.Position = _code.Length;
	}
}