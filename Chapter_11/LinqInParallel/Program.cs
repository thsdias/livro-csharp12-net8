﻿using System.Diagnostics; // To use Stopwatch.

Write("Press ENTER to start");
ReadLine();
Stopwatch watch = Stopwatch.StartNew();

watch.Start();

int max = 45;
IEnumerable<int> numbers = Enumerable.Range(start: 1, count: max);

WriteLine($"Calculating Fibonacci sequence up to term {max}. Please wait...");

int[] fibonacciNumbers = numbers.AsParallel()
    .Select(number => Fibonacci(number))
    .ToArray();

watch.Stop();

WriteLine("{0:#,##0} elapsed milliseconds.", arg0: watch.ElapsedMilliseconds);

Write("Results: ");

foreach (int number in fibonacciNumbers)
{
    Write($"    {number:N0}");
}

static int Fibonacci(int term) =>
    term switch
    {
        1 => 0,
        2 => 1,
        _ => Fibonacci(term - 1) + Fibonacci(term - 2)
    };
