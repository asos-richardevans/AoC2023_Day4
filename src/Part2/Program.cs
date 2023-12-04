var input = File.ReadAllLines("./input.txt");

var winningTotal = new List<(int, double)>();
var cardNumber = 1;
foreach (var line in input)
{
    var cards = line.Split(":");
    var numbers = cards[1].Split("|");
    var winningNumbers = numbers[0].Replace("  ", " ").Trim().Split(" ").Select(int.Parse).ToList();
    var myNumbers = numbers[1].Replace("  ", " ").Trim().Split(" ").Select(int.Parse).ToList();
    double winningCount = myNumbers.Intersect(winningNumbers).Count();
    winningTotal.Add((cardNumber, winningCount));
    cardNumber++;
}

var totalCardsCount = 0;
foreach (var item in winningTotal)
{
    GetCards(item.Item1);
}

Console.WriteLine($"Total cards: {totalCardsCount}");

void GetCards(int cardNumber)
{
    Console.WriteLine(cardNumber);
    totalCardsCount++;
    for (int i = 1; i <= winningTotal.First(x => x.Item1 == cardNumber).Item2; i++)
    {
        GetCards(cardNumber + i);
    }
}


