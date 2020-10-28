using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_game
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words =
            {
                "manchester",
                "london",
                "newcastle",
                "glasgow",
                "liverpool",
                "birmingham",
                "leeds"
            };

            Random random = new Random();
            string wordToFind = words[random.Next(0, words.Length)];
            bool wordFound = false;
            int incorrect = 0;
            char guess;
            string progress;

            Console.WriteLine("Please try to guess the secret word");

            List<char> guesses = new List<char>();

            while (!wordFound)
            {
                Console.Write("Please enter a letter to guess: ");
                Console.Out.Flush();
                guess = Convert.ToChar(Console.ReadLine().ToLower());
                if (guesses.Contains(guess))
                {
                    Console.WriteLine("You have already guessed this letter");
                    continue;
                }
                else
                    guesses.Add(guess);

                if (wordToFind.Contains(guess))
                {
                    Console.WriteLine("Correct, the letter " + guess + " is contained within the word.");
                }
                else
                {
                    Console.WriteLine("Nope, the letter " + guess + " is not contained within the word.");
                    incorrect++;
                    printHangman(incorrect);
                    Console.WriteLine("You have " + (6 - incorrect) + " lives left.");
                }
                progress = printProgress(wordToFind, guesses);

                if (progress == wordToFind)
                {
                    wordFound = true;
                    Console.WriteLine("Well done! You have correctly guessed the word.");
                    Console.ReadKey();
                }

                if (incorrect == 6)
                {
                    Console.WriteLine("You have ran out of guesses, the word was: " + wordToFind);
                    Console.ReadKey(true);
                    break;
                }
            }
        }

        static string printProgress(string word, List<char> guesses)
        {
            //method to print progress through guessing word
            string progress = word;
            foreach (char letter in progress)
            {
                if (!guesses.Contains(letter))
                {
                    progress = progress.Replace(letter, '_');
                }
            }
            Console.WriteLine(progress);
            return progress;
        }

        static void printHangman(int incorrect)
        {
            if (incorrect > 0)
                Console.WriteLine(" O");


            if (incorrect == 3)
                Console.WriteLine("/|");
            else if (incorrect == 2)
                Console.WriteLine(" |");
            else if (incorrect >= 4)
                Console.WriteLine(@"/|\");

            if (incorrect == 5)
                Console.WriteLine("/");
            else if (incorrect == 6)
                Console.WriteLine(@"/ \");
        }
    }
}
