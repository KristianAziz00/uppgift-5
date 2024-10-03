using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Kalkylator");

        bool keepGoing = true;

        while (keepGoing)
        {
            // Ber användaren att välja en operation
            Console.WriteLine("Välj en operation (+, -, *, /):");
            char operation = Console.ReadKey().KeyChar;
            Console.WriteLine();

            // Ber om det första talet
            Console.WriteLine("Ange första talet:");
            double num1;
            while (!double.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Ogiltig inmatning. Försök igen:");
            }

            // Ber om det andra talet
            Console.WriteLine("Ange andra talet:");
            double num2;
            while (!double.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Ogiltig inmatning. Försök igen:");
            }

            double result = 0;

            // Switch-sats för operation
            switch (operation)
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
                        Console.WriteLine("Fel: Division med noll är inte tillåten.");
                        continue;  // Återgå till början av loopen
                    }
                    break;
                default:
                    Console.WriteLine("Fel: Ogiltig operation.");
                    continue;  // Återgå till början av loopen
            }

            // Skriver ut resultatet
            Console.WriteLine($"Resultat: {result}");

            // Skapa en array för att lagra resultaten
            double[] resultsArray = new double[10]; // Skapa en array för upp till 10 resultat
            resultsArray[0] = result; // Spara resultatet på första indexet

            // Fråga användaren vilket resultat de vill se
            Console.WriteLine("Vilket resultat vill du se? (0-9, 0 för senaste resultatet)");
            int indexToAccess;
            while (!int.TryParse(Console.ReadLine(), out indexToAccess) || indexToAccess < 0 || indexToAccess >= resultsArray.Length)
            {
                Console.WriteLine("Fel: Ogiltigt index. Försök igen med ett index mellan 0 och 9.");
            }

            try
            {
                // Försök att skriva ut det valda resultatet
                Console.WriteLine($"Resultatet vid index {indexToAccess} är: {resultsArray[indexToAccess]}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Fel: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Något gick fel: " + e.Message);
            }

            // Fråga om ny beräkning
            Console.WriteLine("Vill du göra en ny beräkning? (j/n)");
            char response = Console.ReadKey().KeyChar;
            keepGoing = response == 'j' || response == 'J';
            Console.WriteLine();  // För att gå till ny rad
        }
    }
}

