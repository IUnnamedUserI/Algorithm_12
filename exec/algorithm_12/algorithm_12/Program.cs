using System;

class LevenshteinDistance
{
    static void Main()
    {
        Console.WriteLine("Введите первое слово:");
        Console.Write(">>> ");
        string str1 = Console.ReadLine();
        Console.WriteLine("Введите второе слово:");
        Console.Write(">>> ");
        string str2 = Console.ReadLine();

        int distance = CalculateLevenshteinDistance(str1, str2);

        Console.WriteLine($"Расстояние Левенштейна между '{str1}' и '{str2}' - {distance}");

        Console.WriteLine("\nДля завершения работы программы нажмите любую клавишу...");
        Console.ReadKey();
    }

    static int CalculateLevenshteinDistance(string str1, string str2)
    {
        int m = str1.Length;
        int n = str2.Length;

        int[,] dp = new int[m + 1, n + 1];

        for (int i = 0; i <= m; i++)
            for (int j = 0; j <= n; j++)
            {
                if (i == 0) dp[i, j] = j;
                else if (j == 0) dp[i, j] = i;
                else
                {
                    int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + cost);
                }
            }
        return dp[m, n];
    }
}