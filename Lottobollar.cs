using System;

namespace Lottobollar
{
    class Lottobollar
    {
        static void Main(string[] args)
        {
            // Variabeldeklaration
            int userInput;
            int[] lottoBollar = new int[10];
            Random rngGenerator = new Random();
            int[] bingoBollar = new int[10];
            int winCondition;
            bool playerWin = false;

            // Start
            Console.WriteLine("Välkommen till Lottobollar!\nSkriv in 10 heltal och se om du kan gissa rätt på dom slumpade talen!");

            // Iterera över spelet tills spelaren vinner
            while (!playerWin)
            {
                winCondition = 0;
                
                // Användar inmatning för 10 tal
                for (int i = 0; i < lottoBollar.Length; i++)
                {
                    try
                    {
                        userInput = int.Parse(Console.ReadLine());
                        if (userInput < 1 || userInput > 25)
                        {
                            Console.WriteLine("Du kan bara skriva heltalen 1 till 25");
                            i--; // Gå tillbaka en position i vektorn
                            // Går även att skriva som i = i - 1;
                        }
                        else
                        {
                            lottoBollar[i] = userInput;
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("ERROR: " + e.Message + " | Du kan bara skriva heltalen 1 till 25, börjar om från början");
                        i = -1; // Starta om från början, vi sätter platsen på -1 för att hamna på vektor position 0 när vi börjar om
                    }
                    
                }

                // Iterera över vektorn bingoBollar tills vi har ett slumpat tal i varje position
                for (int i = 0; i < bingoBollar.Length; i++)
                {
                    // Slumpa fram ett heltal, kan vara 1 till 25
                    bingoBollar[i] = rngGenerator.Next(1, 26);
                }

                Console.WriteLine("Nu ska vi jämföra dina tal med de slumpade talen . . .");

                // Kolla ifall inmatning matchar med slumpade tall
                for (int i = 0; i < lottoBollar.Length; i++)
                {
                    if (lottoBollar[i] == bingoBollar[i])
                    {
                        winCondition++;
                    }
                }

                // Kolla om spelaren har vunnit baserad på mängden rätt gissningar
                if(winCondition >= 5)
                {
                    Console.WriteLine("\nDu har klarat spelet, tryck på en knapp för att avsluta . . .");
                    Console.ReadKey();
                    // Avsluta programmet
                    playerWin = true;
                }
                else
                {
                    // Ifall vi har förlorat spelet så kommer while-loopen att börja om på nytt
                    Console.WriteLine("Du hade " + winCondition + " rätt men du behöver ha minst 5 rätt för att vinna spelet. Försök igen");
                }
            }

        }
    }
}
