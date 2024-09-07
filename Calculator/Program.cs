/*
 * برنامه ای بنویسید که عملیات جمع ، تفریق ، ضرب و تقسیم را انجام دهد.
 * از کاربر دوعدد و نوع عملیات را دریافت کرده و نتیجه را نمایش دهد.
 */

namespace Calculator;

using System;

internal enum Operation
{
    Add, // +
    Subtract, // -
    Multiply, // *
    Divide // /
}

internal abstract class Program
{
    private static void Main()
    {
        SetColorConsoleMessage("Welcome to Console calculator \n", ConsoleColor.DarkMagenta);
        SetColorConsoleMessage("Enter a number 1:", ConsoleColor.White);
        var numberOne = Console.ReadLine();
        SetColorConsoleMessage("Enter a number 2:", ConsoleColor.White);
        var numberTwo = Console.ReadLine();
        SetColorConsoleMessage("Type + (Add), - (subtract), / (divide) or * (multiply):",
            ConsoleColor.White);
        var typeOperation = Console.ReadLine();
        try
        {
            var type = typeOperation switch
            {
                "+" => "Add",
                "-" => "Subtract",
                "*" => "Multiply",
                "/" => "Divide",
                _ => ""
            };
            if (double.TryParse(numberOne, out var num1)
                && double.TryParse(numberTwo, out var num2)
                && Enum.TryParse(type, out Operation operation))
            {
                var result = ComputeMath(num1, num2, operation);
                SetColorConsoleMessage("Result of your operation:", ConsoleColor.DarkCyan);
                var mathOp = operation switch
                {
                    Operation.Add => "plus",
                    Operation.Divide => "divided by",
                    Operation.Multiply => "times",
                    Operation.Subtract => "minus",
                    _ => ""
                };
                SetColorConsoleMessage($"{num1} {mathOp} {num2} is {result}", ConsoleColor.DarkGreen);
            }
            else
            {
                throw new FormatException();
            }
        }
        catch (FormatException)
        {
            SetColorConsoleMessage("Oh! Please enter valid numbers and valid type of operation.",
                ConsoleColor.DarkRed);
        }
        catch (Exception e)
        {
            SetColorConsoleMessage($"Error: {e.Message}", ConsoleColor.DarkRed);
        }
        finally
        {
            SetColorConsoleMessage("End! Good luck", ConsoleColor.DarkBlue);
        }
    }

    private static double ComputeMath(double num1, double num2, Operation operation)
    {
        return operation switch
        {
            Operation.Add => num1 + num2,
            Operation.Subtract => num1 - num2,
            Operation.Multiply => num1 * num2,
            Operation.Divide when num2 != 0 => num1 / num2,
            Operation.Divide => throw new Exception("Division by 0 isn't allowed!"),
            _ => throw new FormatException()
        };
    }

    private static void SetColorConsoleMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}