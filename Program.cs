// Skriver ut rubriken för kalkylatorn
Console.WriteLine("Kalkylator");

// Ber användaren att välja en operation och väntar på inmatning av ett tecken (+, -, *, /)
Console.WriteLine("Välj en operation (+, -, *, /):");
char operation = Console.ReadKey().KeyChar;

// Hoppar till en ny rad och ber om det första talet
Console.WriteLine("\nAnge första talet:");
double num1 = Convert.ToDouble(Console.ReadLine());  // Läser in första talet

// Ber om det andra talet
Console.WriteLine("Ange andra talet:");
double num2 = Convert.ToDouble(Console.ReadLine());  // Läser in andra talet

double result = 0;  // Deklarerar variabeln som ska lagra resultatet

// Switch-sats som kollar vilken operation användaren har valt
switch (operation)
{
    case '+':
        result = num1 + num2;  // Om användaren valde '+', addera de två talen
        break;
    case '-':
        result = num1 - num2;  // Om användaren valde '-', subtrahera andra talet från första
        break;
    case '*':
        result = num1 * num2;  // Om användaren valde '*', multiplicera de två talen
        break;
    case '/':
        if (num2 != 0)
        {
            result = num1 / num2;  // Om användaren valde '/', dividera första talet med andra
        }
        else
        {
            Console.WriteLine("Fel: Division med noll är inte tillåten.");
            return;  // Avbryt om det sker division med noll
        }
        break;
    default:
        // Om inget av ovanstående tecken valdes, skrivs ett felmeddelande ut
        Console.WriteLine("Fel: Ogiltig operation.");
        return;  // Avbryter programmet om en ogiltig operation har valts
}

// Skriver ut resultatet av beräkningen
Console.WriteLine($"Resultat: {result}");

// Väntar på att användaren ska trycka på en tangent innan programmet stängs
Console.ReadKey();
