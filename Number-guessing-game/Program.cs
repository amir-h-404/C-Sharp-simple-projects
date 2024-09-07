/*
 * برنامه‌ای بنویسید که کاربر یک عدد تصادفی بین 1 تا 100 انتخاب کند.
 * کاربر باید عدد را حدس بزند و برنامه به او بگوید که عدد بزرگتر یا کوچکتر است ، تا زمانی که عدد درست را حدس بزند.
 */

namespace Number_guessing_game;

using System;

internal abstract class Program
{
    private static void Main()
    {
        var random = new Random();
        var numberForGuessing = random.Next(1, 101);
        var tryNumber = 1;
        SetColorForConsoleMessages("Welcome to the number guessing game! Let's have some fun!",
            ConsoleColor.Magenta);
        while (true)
        {
            SetColorForConsoleMessages($"Try to guess the number between 1 and 100 (Attempt #{tryNumber++}):",
                ConsoleColor.White);
            var numberOfUser = Console.ReadLine();
            try
            {
                if (int.TryParse(numberOfUser, out var numUser) && numUser is >= 1 and <= 100)
                {
                    if (numUser > numberForGuessing)
                        SetColorForConsoleMessages("The number you guessed is greater than the game number!",
                            ConsoleColor.Red);
                    else if (numUser < numberForGuessing)
                        SetColorForConsoleMessages("The number you guessed is less than the game number!",
                            ConsoleColor.Red);
                    else
                    {
                        SetColorForConsoleMessages($"Congratulations! You guessed right after {tryNumber} attempts.",
                            ConsoleColor.DarkGreen);
                        var message = tryNumber switch
                        {
                            1 => "You're a skilled magician!!",
                            2 => "Excellent! You will become a good magician in the future.",
                            3 => "Very good! Your guess is admirable.",
                            4 => "Good! You were able to guess correctly with less effort than most people.",
                            5 => "Well done! Your effort was good, but try to improve your record next time.",
                            _ => "Not bad! Next time, try to improve the current record, my friend."
                        };
                        SetColorForConsoleMessages(message, ConsoleColor.DarkBlue);
                        break;
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                SetColorForConsoleMessages("Error: Please enter a valid number between 1 and 100!",
                    ConsoleColor.DarkRed);
            }
            catch (Exception e)
            {
                SetColorForConsoleMessages($"Error: {e.Message}", ConsoleColor.DarkRed);
            }
        }
    }

    private static void SetColorForConsoleMessages(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}