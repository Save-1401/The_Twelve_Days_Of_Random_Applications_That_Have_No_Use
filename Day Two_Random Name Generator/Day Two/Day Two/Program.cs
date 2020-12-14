using System;
using System.Numerics;
using System.Collections.Generic;

namespace Day_Two
{
    class Program
    {
        /// <summary>
        /// All consonants the program can choose from
        /// </summary>
        public static List<WeightedChar> weightedConsonants = new List<WeightedChar>() { new WeightedChar('b', 5), new WeightedChar('c', 3), new WeightedChar('d', 5), new WeightedChar('f', 4), new WeightedChar('g', 3), 
            new WeightedChar('h', 4), new WeightedChar('j', 1), new WeightedChar('k', 2), new WeightedChar('l', 4), new WeightedChar('m', 4), new WeightedChar('n', 4), new WeightedChar('p', 3), 
            new WeightedChar('q', 1), new WeightedChar('r', 3), new WeightedChar('s', 4), new WeightedChar('t', 4), new WeightedChar('v', 1), new WeightedChar('w', 1), new WeightedChar('x', 1), 
            new WeightedChar('z', 1) };
        /// <summary>
        /// All consonants
        /// </summary>
        public static List<char> consonants = new List<char>() { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
        /// <summary>
        /// All vowels the program can choose from
        /// </summary>
        public static List<WeightedChar> weightedVowels = new List<WeightedChar>() { new WeightedChar('a', 3), new WeightedChar('e', 3), new WeightedChar('i', 3), new WeightedChar('o', 2), new WeightedChar('u', 1), 
            new WeightedChar('y', 1) };
        /// <summary>
        /// All vowels
        /// </summary>
        public static List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u', 'y' };
        /// <summary>
        /// All consonants that can be doubled up
        /// </summary>
        public static List<char> doubleableConsonants = new List<char>() { 'b', 'c', 'd', 'f', 'g', 'l', 'm', 'n', 'p', 'r', 's', 't', 'w' };
        /// <summary>
        /// All vowels that can be doubled up
        /// </summary>
        public static List<char> doubleableVowels = new List<char>() { 'a', 'e', 'o' };
        /// <summary>
        /// All symbols the program can choose from
        /// </summary>
        public static List<char> symbols = new List<char> { '-', '\'', ' ' };
        static void Main(string[] args)
        {
            //The random used to generate names
            Random rnd = new Random(1401);
            //If the player wants too keep going, continue to loop
            bool keepGoing = true;
            while(keepGoing)
            {
                Console.Write("Enter name length: ");
                try
                {
                    Console.WriteLine(GenerateName(rnd, Convert.ToInt32(Console.ReadLine()), 25, 10, 1, new Vector2(5, 7), new Vector2(2, 15), new Vector2(2, 5), new Vector2(3, 4)));
                }
                catch
                {
                    Console.WriteLine("Invalid Length");
                }
            }
        }
        /// <summary>
        /// Generates a random name
        /// </summary>
        /// <param name="length"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        static string GenerateName(Random rnd, int length, int consonantChance, int vowelChance, int symbolChance, Vector2 doublesChanceConsonants, Vector2 doublesChanceVowels, Vector2 vowelAfterConsonantChance,
            Vector2 qAfterUChance)
        {
            //The name being generated
            string name = "";
            //The last characters used
            char lastChar = ' ';
            char lastChar2 = ' ';
            char lastChar3 = ' ';
            char lastChar4 = ' ';
            char lastChar5 = ' ';

            //Generated the name from random letters
            for (int i = 0; i < length; i++)
            {
                //The character to add
                char toAdd = ' ';
                //Capitalizes the character if it is the first one
                if (i == 0)
                {
                    int characterType = rnd.Next(0, consonantChance + vowelChance);
                    string ta = "";
                    if (characterType < consonantChance)
                    {
                        ta = GetConsonant(rnd).ToString().ToUpper();
                    }
                    else
                    {
                        ta = GetVowel(rnd).ToString().ToUpper();
                    }
                    toAdd = ta.ToCharArray()[0];
                }
                else
                {
                    //Cycles while it should still be cycling
                    bool keepCycling = true;
                    while (keepCycling)
                    {
                        //Chooses a random character type and then sets a character of that type as toAdd
                        int characterType = rnd.Next(0, consonantChance + vowelChance + symbolChance);
                        //Checks if the last letter was a q, and rolls to see if it should put a u
                        if (lastChar.ToString().ToLower().ToCharArray()[0] == 'q' && RollChance(qAfterUChance, rnd))
                        {
                            toAdd = 'u';
                            keepCycling = false;
                        }
                        //Checks if the last two characters were q and u, and if so adds a vowel
                        else if (lastChar.ToString().ToLower().ToCharArray()[0] == 'u' && lastChar2.ToString().ToLower().ToCharArray()[0] == 'q')
                        {
                            toAdd = GetVowel(rnd);
                            //Makes sure it is not adding a letter that doesn't make sense after the u
                            while (toAdd == 'u' || toAdd == 'y')
                            {
                                toAdd = GetVowel(rnd);
                            }
                            keepCycling = false;
                        }
                        //Checks if the last character was a consonant, than rolls to see if there should be a vowel after it
                        else if (consonants.Contains(lastChar.ToString().ToLower().ToCharArray()[0]) && RollChance(vowelAfterConsonantChance, rnd))
                        {
                            toAdd = GetVowel(rnd);
                            keepCycling = false;
                        }
                        else if (consonants.Contains(lastChar.ToString().ToLower().ToCharArray()[0]) && consonants.Contains(lastChar2.ToString().ToLower().ToCharArray()[0])
                            && consonants.Contains(lastChar3.ToString().ToLower().ToCharArray()[0]))
                        {
                            toAdd = GetVowel(rnd);
                            keepCycling = false;
                        }
                        else if (vowels.Contains(lastChar.ToString().ToLower().ToCharArray()[0]) && vowels.Contains(lastChar2.ToString().ToLower().ToCharArray()[0])
                            && vowels.Contains(lastChar3.ToString().ToLower().ToCharArray()[0]))
                        {
                            toAdd = GetConsonant(rnd);
                            keepCycling = false;
                        }
                        else if (characterType < consonantChance)
                        {
                            toAdd = consonants.Contains(lastChar) && lastChar != lastChar2 && RollChance(doublesChanceConsonants, rnd) ? lastChar : GetConsonant(rnd);
                            while (toAdd == lastChar && lastChar == lastChar2)
                            {
                                toAdd = GetConsonant(rnd);
                            }
                            while (toAdd == lastChar && !doubleableConsonants.Contains(lastChar))
                            {
                                toAdd = GetConsonant(rnd);
                            }
                            keepCycling = false;
                        }
                        else if (characterType < consonantChance + vowelChance)
                        {
                            toAdd = vowels.Contains(lastChar) && lastChar != lastChar2 && RollChance(doublesChanceVowels, rnd) ? lastChar : GetVowel(rnd);
                            while (toAdd == lastChar && lastChar == lastChar2)
                            {
                                toAdd = GetVowel(rnd);
                            }
                            while (toAdd == lastChar && !doubleableVowels.Contains(lastChar))
                            {
                                toAdd = GetVowel(rnd);
                            }
                            keepCycling = false;
                        }
                        else
                        {
                            //Makes sure there is only ever one symbol in a row
                            if (!symbols.Contains(lastChar))
                            {
                                toAdd = GetSymbol(rnd);
                                keepCycling = false;
                            }
                        }
                    }
                    //Capitalizes toAdd if the last character was a symbol
                    if (symbols.Contains(lastChar))
                    {
                        toAdd = toAdd.ToString().ToUpper().ToCharArray()[0];
                    }
                }
                //Adds toAdd to the name
                name += toAdd;
                lastChar5 = lastChar4;
                lastChar4 = lastChar3;
                lastChar3 = lastChar2;
                lastChar2 = lastChar;
                lastChar = toAdd.ToString().ToLower().ToCharArray()[0];
            }

            //Returns the name generated
            return name;
        }
        /// <summary>
        /// Gets a random consonant
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        static char GetConsonant(Random rnd)
        {
            //Creates a list of characters to choose from
            List<char> charsToChoose = new List<char>();

            //Iterates through the weighted characters and adds them to the list of characters to choose from weight times
            foreach (WeightedChar wc in weightedConsonants)
            {
                for (int i = 0; i < wc.weight; i++)
                {
                    charsToChoose.Add(wc.c);
                }
            }

            //Returns a random character from the list of character to choose from
            return charsToChoose[rnd.Next(0, charsToChoose.Count)];
        }
        /// <summary>
        /// Gets a random vowel
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        static char GetVowel(Random rnd)
        {
            //Creates a list of characters to choose from
            List<char> charsToChoose = new List<char>();

            //Iterates through the weighted characters and adds them to the list of characters to choose from weight times
            foreach (WeightedChar wc in weightedVowels)
            {
                for (int i = 0; i < wc.weight; i++)
                {
                    charsToChoose.Add(wc.c);
                }
            }


            //Returns a random character from the list of character to choose from
            return charsToChoose[rnd.Next(0, charsToChoose.Count)];
        }
        /// <summary>
        /// Gets a random symbol
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        static char GetSymbol(Random rnd)
        {
            return symbols[rnd.Next(0, symbols.Count)];
        }
        /// <summary>
        /// Rolls a chance using the Vector2 provided
        /// </summary>
        /// <param name="chance"></param>
        /// <returns></returns>
        static bool RollChance(Vector2 chance, Random rnd)
        {
            return rnd.Next(0, (int)chance.X) < chance.Y;
        }
    }
}
