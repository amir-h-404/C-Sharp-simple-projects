/*
 * برنامه ای بنویسید که عملیات جمع ، تفریق ، ضرب و تقسیم را انجام دهد.
 * از کاربر دوعدد و نوع عملیات را دریافت کرده و نتیجه را نمایش دهد.
 */

Console.WriteLine("*_* Welcome to Console calculator *_*" + "\n");
Console.WriteLine("Enter a number 1: ");
var numberOne = Console.ReadLine();
Console.WriteLine("Enter a number 2: ");
var numberTwo = Console.ReadLine();
Console.WriteLine("Select the type of math operation: ");
Console.WriteLine("(Type '+', '*', '/' or '-')");
var typeOperation = Console.ReadLine();
try
{
    if (double.TryParse(numberOne, out var num1)
        && double.TryParse(numberTwo, out var num2)
        && char.TryParse(typeOperation, out var type))
    {
        double result;
        switch (type)
        {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                else
                {
                    throw new Exception("Division by 0 isn't allowed!");
                }

                break;
            default:
                throw new FormatException();
        }

        Console.WriteLine("**_** Result of your operation **_**");
        Console.WriteLine("{0} {1} {2} = {3}", num1, type, num2, result);
    }
    else
    {
        throw new FormatException();
    }
}
catch (FormatException)
{
    Console.WriteLine("Oh! Please enter valid numbers and valid type of operation.");
}
catch (Exception e)
{
    Console.WriteLine("Error: {0}", e.Message);
}
finally
{
    Console.WriteLine("End! Good luck");
}