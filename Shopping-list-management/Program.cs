/*
 * برنامه‌ای بنویسید که بتواند کالاهای خرید را اضافه ، حذف و نمایش دهد.
 * از لیست برای ذخیره اقلام استفاده کنید و عملیات مختلف را روی آن پیاده‌سازی کنید.
 */

namespace Shopping_list_management;

internal abstract class Program
{
    private static void Main()
    {
        SetMessageWithColor("Welcome to Consular Store!\n", ConsoleColor.Magenta);
        var inputOfUser = "";
        const string separator = "- - - - - - - - - - - - - -";
        List<string> shoppingList = [];
        while (inputOfUser != "0")
        {
            SetMessageWithColor("Choose one of the options below:", ConsoleColor.Cyan);
            SetMessageWithColor("0. Exit the program", ConsoleColor.White);
            SetMessageWithColor("1. Add product to shopping list", ConsoleColor.White);
            SetMessageWithColor("2. Remove the product from the shopping list", ConsoleColor.White);
            SetMessageWithColor("3. View the shopping list", ConsoleColor.White);
            inputOfUser = Console.ReadLine();
            switch (inputOfUser)
            {
                case "0":
                    SetMessageWithColor("You're logged out! Goodbye.", ConsoleColor.Blue);
                    inputOfUser = "0";
                    break;
                case "1":
                    AddProduct(shoppingList, separator);
                    break;
                case "2":
                    RemoveProduct(shoppingList, separator);
                    break;
                case "3":
                    ShowProducts(shoppingList, separator);
                    break;
                default:
                    SetMessageWithColor("Invalid option! Please try again.",
                        ConsoleColor.DarkRed);
                    SetMessageWithColor(separator, ConsoleColor.Yellow);
                    break;
            }
        }
    }

    private static void SetMessageWithColor(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static void AddProduct(List<string> shoppingList, string separator)
    {
        SetMessageWithColor("Please enter the product name to add to the shopping list:",
            ConsoleColor.White);
        var productUser1 = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(productUser1) && !shoppingList.Contains(productUser1))
        {
            shoppingList.Add(productUser1);
            SetMessageWithColor("The imported product has been successfully added to the shopping list.",
                ConsoleColor.DarkGreen);
        }
        else if (string.IsNullOrEmpty(productUser1))
            SetMessageWithColor("The input is empty! Please enter the product name.",
                ConsoleColor.Red);
        else
            SetMessageWithColor("The imported product is in the shopping list!",
                ConsoleColor.Red);

        SetMessageWithColor(separator, ConsoleColor.Yellow);
    }

    private static void RemoveProduct(List<string> shoppingList, string separator)
    {
        SetMessageWithColor("Please enter the product name to remove from the shopping list:",
            ConsoleColor.White);
        var productUser2 = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(productUser2) && shoppingList.Contains(productUser2))
        {
            shoppingList.Remove(productUser2);
            SetMessageWithColor(
                "The imported product has been successfully removed from the shopping list.",
                ConsoleColor.DarkGreen);
        }
        else if (string.IsNullOrEmpty(productUser2))
            SetMessageWithColor("The input is empty! Please enter the product name.",
                ConsoleColor.Red);
        else
            SetMessageWithColor("The imported product doesn't exist in the shopping list!",
                ConsoleColor.Red);

        SetMessageWithColor(separator, ConsoleColor.Yellow);
    }
    
    private static void ShowProducts(List<string> shoppingList, string separator)
    {
        if (shoppingList.Count > 0)
        {
            SetMessageWithColor("Your shopping list:", ConsoleColor.Cyan);
            shoppingList.ForEach(item => SetMessageWithColor($"- {item}",
                ConsoleColor.Green));
        }
        else
            SetMessageWithColor("Your shopping list is empty! Please import goods into it first.",
                ConsoleColor.Red);

        SetMessageWithColor(separator, ConsoleColor.Yellow);
    }
}