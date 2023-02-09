using System;
using System.IO;

using Narik.CodeChallenge.Day4;

var codeStream = File.OpenRead("./code.bf");

Interpreter bfInterpreter = new(codeStream, Console.In, Console.Out);
bfInterpreter.Interpret();