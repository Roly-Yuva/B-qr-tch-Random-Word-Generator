using System;

namespace Böqrîtch_Random_Word_Generator
{
    class Program
    {
        static void Main()
        {
            Generator generator = new Generator();

            bool isContinuing = true;

            Console.WriteLine("Note: The console may randomly stop responding. If this happens but you still want to keep generating words, restart the console and run the program again.");
            Console.Write("\n\n");

            do {
                int oddCharacters = 3;
                int evenCharacters = 4;

                for (int i = 0; i < 5; i++) {
                    string word = generator.Generate(oddCharacters);

                    oddCharacters += 2;

                    Console.WriteLine(word);
                }

                Console.Write("\n");

                for (int i = 0; i < 5; i++) {
                    string word = generator.Generate(evenCharacters);

                    evenCharacters += 2;

                    Console.WriteLine(word);
                }

                Console.Write("\n\n");

                Console.WriteLine("Press <ENTER> to continue generating words. Type 'quit' or 'q' and press <ENTER> to terminate the program.");
                string continueCommand = Console.ReadLine();

                if (continueCommand == "quit" || continueCommand == "q") {
                    isContinuing = false;
                    break;
                } else {
                    isContinuing = true;
                    Console.Write("\n\n");
                    continue;
                }
            } while (isContinuing);
        }
    }
}