using System;
using System.Diagnostics;
using System.Threading;

namespace Test
{
	class Program
	{
		private string Current { get; set; } = "1234567890";

		static void Main(string[] args)
		{
			ConsoleKeyInfo cki;

			var program = new Program();
			var watch = new Stopwatch();

			Console.WriteLine("Press the Escape (Esc) key to quit: \n");
			Console.WriteLine("Current string: {0}", program.Current);

			Console.Write("Set a delay (milliseconds) —> ");
			var delay = int.Parse(Console.ReadLine() ?? string.Empty);

			do
			{
				cki = Console.ReadKey();
				Console.Write(" —> ");


				var t = new Thread(() =>
				{
					watch.Start();
					program.Current = NumberKeysOperations(cki, program);
					Thread.Sleep(delay);
					watch.Stop();
				}) {Name = "Numbers"};
				t.Start();
				DisplayThreadInformation(t, program.Current, cki, watch);
				t.Join();

				var tr = new Thread(() => program.Current = BackSpaceOperation(cki, program)
				) {Name = "Backspace"};
				watch.Start();

				tr.Start();
				DisplayThreadInformation(tr, program.Current, cki, watch);
				Thread.Sleep(delay);

				watch.Stop();
			} while (cki.Key != ConsoleKey.Escape);
		}

		private void ShowString()
		{
			Console.WriteLine($"Current string: {Current}");
		}

		private static void DisplayThreadInformation(Thread thread, string currentString, ConsoleKeyInfo cki,
						Stopwatch watch)
		{
			Console.WriteLine($"Name: {thread.Name}/" +
			                  $"Priority: {thread.Priority}/" +
			                  $"State: {thread.ThreadState}/" +
			                  $"Id: {thread.ManagedThreadId}/" +
			                  $"Key code: {cki.Key}/" +
			                  $"Execution time (milliseconds): {watch.Elapsed.Milliseconds}");
		}

		private static string NumberKeysOperations(ConsoleKeyInfo currentKey, Program program)
		{
			switch (currentKey.Key)
			{
				case ConsoleKey.D0:
					program.Current += "0";
					program.ShowString();
					return program.Current;
				case ConsoleKey.D1:
					program.Current += "1";
					program.ShowString();
					return program.Current;
				case ConsoleKey.D2:
					program.Current += "2";
					program.ShowString();
					return program.Current;
				case ConsoleKey.D3:
					program.Current += "3";
					program.ShowString();
					return program.Current;
				case ConsoleKey.D4:
					program.Current += "4";
					program.ShowString();
					return program.Current;
				case ConsoleKey.D5:
					program.Current += "5";
					program.ShowString();
					return program.Current;
				case ConsoleKey.D6:
					program.Current += "6";
					program.ShowString();
					return program.Current;
				case ConsoleKey.D7:
					program.Current += "7";
					program.ShowString();
					return program.Current;
				case ConsoleKey.D8:
					program.Current += "8";
					program.ShowString();
					return program.Current;
				case ConsoleKey.D9:
					program.Current += "9";
					program.ShowString();
					return program.Current;
				default:
					return program.Current;
			}
		}


		private static string BackSpaceOperation(ConsoleKeyInfo currentKey, Program program)
		{
			if (currentKey.Key != ConsoleKey.Backspace) return program.Current;

			if (string.IsNullOrEmpty(program.Current))
			{
				Console.WriteLine("string is empty! Add symbols");
				return program.Current;
			}

			if (program.Current.Length < 5)
			{
				var warning = "\nWARNING! Please, add Symbols!\n" +
				              "Current string: " + program.Current + "\n" +
				              "Amount of symbols: " + program.Current.Length;
				Console.WriteLine(warning);
				return program.Current;
			}

			program.Current = program.Current.Remove(program.Current.Length - 5);
			program.ShowString();

			return program.Current;
		}
	}
}