// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

try
{
    using (StreamReader file = new StreamReader("C:\\Users\\kaue\\Documents\\Projetos\\day2AdventOfCode\\day2\\day2\\input.txt"))
    {
        int sum = 0;
        string line;

        Dictionary<string, string> gameAndBalls = new();
        while ((line = file.ReadLine()) != null)
        {
            var (colorCounts, gameNumber) = SepareteGameAndBalls(line);
            if (VerifyBallsQuantity(colorCounts)) sum += gameNumber;
        }
        Console.WriteLine($"Sum: {sum}");
    }
}
catch (Exception e)
{
    // Let the user know what went wrong.
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}

static bool VerifyBallsQuantity(List<(string, int)> colorCounts)
{
    foreach(var color in colorCounts)
    {
        if(color.Item1 == "blue")
        {
            if (color.Item2 > 14) return false;
        }
        if (color.Item1 == "red")
        {
            if (color.Item2 > 12) return false;
        }
        if (color.Item1 == "green")
        {
            if (color.Item2 > 13) return false;
        }
    }
    return true;
}

static (List<(string, int)>, int) SepareteGameAndBalls(string line)
{
    string[] parts = line.Split(new[] { ": " }, StringSplitOptions.None);
    string gameName = parts[0];
    string colorInfo = parts[1];

    List<(string, int)> colorCounts = new List<(string, int)>();
    string[] games = colorInfo.Split(new[] { "; " }, StringSplitOptions.None);

    int gameNumber = int.Parse(gameName.Split(' ')[1]);

    foreach (var game in games)
    {
        string[] colors = game.Split(new[] { ", " }, StringSplitOptions.None);

        foreach (string color in colors)
        {
            // Split the color into count and color name
            string[] partsColor = color.Split(' ');
            int count = int.Parse(partsColor[0]);
            string colorName = partsColor[1];

            colorCounts.Add(new (colorName, count));
        }
    }

    return (colorCounts, gameNumber);
}