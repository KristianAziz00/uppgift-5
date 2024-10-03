using System;
using System.Collections.Generic; // För att använda List<T>

class Program
{
    static void Main()
    {
        Console.WriteLine("Kalkylator");
        bool keepGoing = true;
        List<double> resultsList = new List<double>(); // Lista för att lagra resultaten

        while (keepGoing)
        {
            // Ber användaren att välja en operation med validering
            char operation;
            while (true)
            {
                Console.WriteLine("Välj en operation (+, -, *, /, r för kvadratrot):");
                operation = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (operation == '+' || operation == '-' || operation == '*' || operation == '/' || operation == 'r')
                {
                    break; // Giltig operation, bryt loopen
                }
                else
                {
                    Console.WriteLine("Fel: Ogiltig operation. Försök igen.");
                }
            }

            double num1 = 0;
            double num2 = 0; // Skapa variabel för num2, även om den kanske inte används

            // Ber om det första talet
            if (operation == 'r')
            {
                // För kvadratroten behövs endast ett tal
                Console.WriteLine("Ange talet för kvadratrot:");
                while (!double.TryParse(Console.ReadLine(), out num1) || num1 < 0)
                {
                    Console.WriteLine("Ogiltig inmatning. Försök igen (ange ett icke-negativt tal):");
                }
            }
            else
            {
                // Ber om det första talet
                Console.WriteLine("Ange första talet:");
                while (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Ogiltig inmatning. Försök igen:");
                }

                // Ber om det andra talet
                Console.WriteLine("Ange andra talet:");
                while (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Ogiltig inmatning. Försök igen:");
                }
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
                case 'r':
                    result = Math.Sqrt(num1); // Beräkna kvadratroten
                    break;
                default:
                    Console.WriteLine("Fel: Ogiltig operation.");
                    continue;  // Återgå till början av loopen
            }

            // Lägg till resultatet i listan
            resultsList.Add(result);
            Console.WriteLine($"Resultat: {result}");

            // Fråga användaren vilket resultat de vill se
            Console.WriteLine("Vilket resultat vill du se? (0 för senaste resultatet, 1 för föregående, osv.)");
            int indexToAccess;
            while (!int.TryParse(Console.ReadLine(), out indexToAccess) || indexToAccess < 0 || indexToAccess >= resultsList.Count)
            {
                Console.WriteLine($"Fel: Ogiltigt index. Försök igen med ett index mellan 0 och {resultsList.Count - 1}.");
            }

            try
            {
                // Försök att skriva ut det valda resultatet
                Console.WriteLine($"Resultatet vid index {indexToAccess} är: {resultsList[indexToAccess]}");
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
