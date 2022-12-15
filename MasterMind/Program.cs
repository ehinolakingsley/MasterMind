

Console.WriteLine("Welcome to the Master Mind Game");

Random rand = new Random();

int[] answer = new int[4];

for (int i = 0; i < answer.Length; i++)
    answer[i] = rand.Next(1, 6);


int attempt = 10;
int position = 0;
string[] words = new[] { "first", "second", "third", "forth" };

Console.WriteLine("You will be expected to enter 4 digits\nwith each digits between 1 and 6\n");


while (attempt > 0)
{

    if (position == answer.Length)
    {
        Console.WriteLine($"Hurray!!! You guessed by thought right. {string.Join("", answer)}");
        return;
    }


retry:
    Console.WriteLine($"Enter your {words[position]} digit");

    var input = Console.ReadLine();

    if (!int.TryParse(input, out int input_))
    {
        Console.WriteLine("Invalid input! You are expected to enter a digit only");
        goto retry;
    }

    if (input_ < 1 || input_ > 6)
    {
        Console.WriteLine("Invalid input! You are expected to enter a digit between 1 - 6");
        goto retry;
    }

    if (answer[position] == input_)
    {
        Console.WriteLine("+");
        position++;
        continue;
    }

    if (answer.Contains(input_))
    {
        Console.WriteLine("-");
        attempt--;
        continue;
    }

    attempt--;
}

if (attempt == 0)
    Console.WriteLine("Oops! Sorry you lost after 10 failed attempt");
