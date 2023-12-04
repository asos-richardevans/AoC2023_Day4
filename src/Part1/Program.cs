var input = File.ReadAllLines("./input.txt");

var winningTotal = new List<double>();
foreach (var line in input)
{
    var cards = line.Split(":");
    var numbers = cards[1].Split("|");
    var winningNumbers = numbers[0].Replace("  ", " ").Trim().Split(" ").Select(int.Parse).ToList();
    var myNumbers = numbers[1].Replace("  ", " ").Trim().Split(" ").Select(int.Parse).ToList();
    double winningCount = myNumbers.Intersect(winningNumbers).Count();
    if (winningCount > 0)
    {
        winningCount = Math.Pow(2, winningCount-1);
    }
    winningTotal.Add(winningCount);
}

Console.WriteLine(winningTotal.Sum());
