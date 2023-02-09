/*
 * DAY 4  •  Neural Intercourse 
 * Today's challenge is to write an interpreter for the brainfuck esoteric language.
 *
 * Research how this language works and what each instruction does (>,<,[,],+,-,.). Then use this information to make an interpreter that reads a brainfuck program from standard input and displays the result.
 *
 * Goblin mode:
 * Use the brainfuck interpreter you wrote to write a brainfuck interpreter.
 */

using System;
using System.IO;

using Narik.CodeChallenge.Day4;

var codeStream = File.OpenRead("./code.bf");

Interpreter bfInterpreter = new(codeStream, Console.In, Console.Out);
bfInterpreter.Interpret();