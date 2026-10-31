namespace MemorySpel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            while (true)
            {
                string[] kort = { "A", "A", "B", "B", "C", "C", "D", "D" };
                bool[] found = new bool[kort.Length];

                // Blanda korten
                for (int i = 0; i < kort.Length; i++)
                {
                    int j = rnd.Next(kort.Length);
                    string temp = kort[i];
                    kort[i] = kort[j];
                    kort[j] = temp;
                }

                int attempts = 0;

                while (true)
                {
                    Console.Clear();

                    // Visa korten
                    for (int i = 0; i < found.Length; i++)
                    {
                        if (found[i])
                            Console.Write(kort[i] + " ");
                        else
                            Console.Write(i + " ");
                    }

                    Console.WriteLine();

                    // Kontrollera om alla kort är hittade
                    bool done = true;

                    for (int i = 0; i < found.Length; i++)
                    {
                        if (found[i] == false)
                            done = false;
                    }

                    if (done)
                    {
                        Console.WriteLine("Grattis! Du vann!");
                        Console.WriteLine("Antal försök: " + attempts);
                        break;
                    }

                    // Första kortet
                    Console.Write("Vänligen välj ditt första kort: ");

                    int i1;

                    while (!int.TryParse(Console.ReadLine(), out i1))
                    {
                        Console.Write("Fel! Du ska skriva en siffra: ");
                    }

                    if (i1 < 0 || i1 >= kort.Length)
                    {
                        Console.WriteLine("Fel! Det kortet finns ej.");
                        Console.ReadLine();
                        continue;
                    }

                    if (found[i1])
                    {
                        Console.WriteLine("Det kortet är redan hittat!");
                        Console.ReadLine();
                        continue;
                    }

                    // Visa första kortet
                    Console.Clear();

                    for (int i = 0; i < kort.Length; i++)
                    {
                        if (i == i1 || found[i])
                            Console.Write(kort[i] + " ");
                        else
                            Console.Write("* ");
                    }

                    Console.WriteLine();

                    // Andra kortet
                    Console.Write("Vänligen välj ditt andra kort: ");

                    int i2;

                    while (!int.TryParse(Console.ReadLine(), out i2))
                    {
                        Console.Write("Fel! Du ska skriva en siffra: ");
                    }

                    if (i2 < 0 || i2 >= kort.Length)
                    {
                        Console.WriteLine("Fel! Det kortet finns ej.");
                        Console.ReadLine();
                        continue;
                    }

                    if (i1 == i2)
                    {
                        Console.WriteLine("Du får inte välja samma kort två gånger!");
                        Console.ReadLine();
                        continue;
                    }

                    if (found[i2])
                    {
                        Console.WriteLine("Du har redan hittat detta kort!");
                        Console.ReadLine();
                        continue;
                    }

                    // Visa båda korten
                    Console.Clear();

                    for (int i = 0; i < kort.Length; i++)
                    {
                        if (i == i1 || i == i2 || found[i])
                            Console.Write(kort[i] + " ");
                        else
                            Console.Write("* ");
                    }

                    Console.WriteLine();

                    // Kontrollera om det är ett par
                    if (kort[i1] == kort[i2])
                    {
                        Console.WriteLine("Par!");

                        found[i1] = true;
                        found[i2] = true;
                    }
                    else
                    {
                        Console.WriteLine("Inte par!");
                    }

                    attempts++;

                    Console.ReadLine();
                }

                // Spela igen?
                Console.WriteLine(
                    "Tryck C om du vill spela igen, annars tryck på något annat för att avsluta."
                );

                string svar = Console.ReadLine();

                if (svar.ToUpper() != "C")
                    break;
            }
        }
    }
}
