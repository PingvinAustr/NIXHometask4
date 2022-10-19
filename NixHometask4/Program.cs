using System;

public class Program
{
    public static void InitArray(ref int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = new Random().Next(1, 27);
        }
    }

    public static void ShowArray(ref string[] array)
    {
        foreach (string str in array)
        {
            Console.Write(str + " ");
        }
    }

    public static void DivideArray(ref int[] array)
    {
        string[] oddArray = new string[array.Length];
        string[] notOddArray = new string[array.Length];
        int oddNum = 0, notOddNum = 0;
        string letterString = "abcdefghijklmnopqrstuvwxyz";
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 0)
            {
                notOddArray[notOddNum] = array[i].ToString();
                notOddNum++;
            }
            else if (array[i] % 2 != 0)
            {
                oddArray[oddNum] = array[i].ToString();
                oddNum++;
            }
        }

        Console.WriteLine("\n\nEnglish alphabet:");
        for (int i = 0; i < letterString.Length; i++)
        {
            Console.WriteLine("[" + (i + 1) + "]---" + letterString[i]);
        }

        Console.WriteLine("\n\nOdd array:");
        ShowArray(ref oddArray);

        Console.WriteLine("\n\nNot odd array:");
        ShowArray(ref notOddArray);

        // Replacing numbers with corresponding letters. If current letter is [a, e, i, d, h, j] - show it uppercase, otherwise - lowercase
        string uniqueChars = "aeidhj";
        int uniqueOddCharsNum = 0, uniqueNotOddCharsNum = 0;
        for (int i = 0; i < oddNum; i++)
        {
            oddArray[i] = letterString[int.Parse(oddArray[i]) - 1].ToString();
            if (uniqueChars.IndexOf(oddArray[i]) != -1)
            {
                oddArray[i] = oddArray[i].ToUpper();
                uniqueOddCharsNum++;
            }
        }

        for (int i = 0; i < notOddNum; i++)
        {
            notOddArray[i] = letterString[int.Parse(notOddArray[i]) - 1].ToString();
            if (uniqueChars.IndexOf(notOddArray[i]) != -1)
            {
                notOddArray[i] = notOddArray[i].ToUpper();
                uniqueNotOddCharsNum++;
            }
        }

        if (uniqueOddCharsNum > uniqueNotOddCharsNum)
        {
            Console.WriteLine("\n\nOdd array has more uppercase chars! (" + uniqueOddCharsNum + ">" + uniqueNotOddCharsNum + ")");
        }
        else if (uniqueOddCharsNum < uniqueNotOddCharsNum)
        {
            Console.WriteLine("\n\nNot odd array has more uppercase chars! (" + uniqueNotOddCharsNum + ">" + uniqueOddCharsNum + ")");
        }
        else
        {
            Console.WriteLine("\n\nBoth arrays have the same number of uppercase chars! (" + uniqueOddCharsNum + "=" + uniqueNotOddCharsNum + ")");
        }

        Console.WriteLine("\nOdd array after changes:");
        ShowArray(ref oddArray);

        Console.WriteLine("\nNot odd array after changes:");
        ShowArray(ref notOddArray);
    }

    public static void Main(string[] args)
    {
        // n - number of elements in array
        int n = 0;
        while (true)
        {
            Console.WriteLine("NIX Hometask #4. Done by Chushenko Yaroslav\n\nPlease enter N (number of elements in array):");
            bool parseValidation = int.TryParse(Console.ReadLine(), out n);
            if (!parseValidation || n <= 0)
            {
                Console.Clear();
                Console.WriteLine("Invalid N! Please try again...");
                continue;
            }
            else
            {
                // Array to be filled with random numbers
                int[] array = new int[n];
                InitArray(ref array);
                Console.WriteLine("Your generated array:\n");
                foreach (int i in array)
                {
                    Console.Write(i + " ");
                }

                DivideArray(ref array);
                Console.WriteLine("\n\n");
                Console.Read();
            }
        }
    }
}