using System;
using System.Collections.Generic;

namespace Day_One
{
    class Program
    {
        /*/// <summary>
        /// The seed the program uses to generate the cypher
        /// </summary>
        static int seed = 0;*/
        /// <summary>
        /// The cypher itself
        /// </summary>
        static Dictionary<char, char> cypher = new Dictionary<char, char>();
        /// <summary>
        /// The cypher used to translate from scrambled mode back to undersandable text
        /// </summary>
        static Dictionary<char, char> backCypher = new Dictionary<char, char>();
        /// <summary>
        /// All available characters to choose from to generate the cypher.
        /// <para>Yes, it took a long time to create.</para>
        /// </summary>
        static char[] availableCharacters = new char[] { '`', '~', '1', '!', '2', '@', '3', '#', '4', '$', '5', '%', '6', '^', '7', '&', '8', '*', '9', '(', '0', ')', '-', '_', '=', '+',
        'q', 'Q', 'w', 'W', 'e', 'E', 'r', 'R', 't', 'T', 'y', 'Y', 'u', 'U', 'i', 'I', 'o', 'O', 'p', 'P', '[', '{', ']', '}', '\\',
        'a', 'A', 's', 'S', 'd', 'D', 'f', 'F', 'g', 'G', 'h', 'H', 'j', 'J', 'k', 'K', 'l', 'L', ';', ':', '\'', '"',
        'z', 'Z', 'x', 'X', 'c', 'C', 'v', 'V', 'b', 'B', 'n', 'N', 'm', 'M', ',', '<', '.', '>', '/', '?', ' '};
        static void Main(string[] args)
        {
            //Tells the user the commands
            Console.WriteLine("\"/\" to tell the program to scramble the following text,");
            Console.WriteLine("\"\\\" to tell the program to unscramble the following text,");
            Console.WriteLine("\"~cc\" to change the cypher's seed, and");
            Console.WriteLine("\"~q\" to quit");
            //Gets the seed the user inputs
            Console.Write("Enter a seed: ");
            cypher = GenerateCypher(Convert.ToInt32(Console.ReadLine()));
            backCypher = GenerateBackCypher(cypher);

            //Wether or not the program should keep running at the end of the loop
            bool keepGoing = true;
            //Starts a loop that doesn't end untill the user wants it to
            while (keepGoing)
            {
                //Gets the users input
                Console.Write("Enter text: ");
                string input = Console.ReadLine();

                //Checks of the user input is either of the two commands, otherwise cyphers or decyphers the input, also makes sure something is actually being entered
                if (input == "~cc")
                {
                    //Gets the seed the user inputs
                    Console.Write("Enter a seed: ");
                    cypher = GenerateCypher(Convert.ToInt32(Console.ReadLine()));
                    backCypher = GenerateBackCypher(cypher);
                }
                else if (input == "~q")
                {
                    keepGoing = false;
                }
                else if (input.Length > 0)
                {
                    //The output (pretty self explanatory, but I thought I'd put this here anyway)
                    string output = "";
                    //Removes the first character
                    List<char> inputCL = new List<char>(); 
                    foreach (char c in input.ToCharArray())
                    {
                        inputCL.Add(c);
                    }
                    char input0 = inputCL[0];
                    inputCL.RemoveAt(0);
                    char[] inputCA = inputCL.ToArray();
                    //Checks wether the user wants the text cyphered or decyphered, then does what the user wants.
                    if (input0 == '/')
                    {
                        output = CypherString(inputCA);
                    }
                    else if (input0 == '\\')
                    {
                        output = UnCypherString(inputCA);
                    }
                    else
                    {
                        output = CypherString(input.ToCharArray());
                    }
                    //Writes the output
                    Console.WriteLine(output);
                }
            }
        }
        /// <summary>
        /// Used to generate the cypher
        /// </summary>
        /// <returns>The generated cypher</returns>
        public static Dictionary<char, char> GenerateCypher(int seed)
        {
            //The dictionary this method is creating
            Dictionary<char, char> cypher = new Dictionary<char, char>();
            //The list of characters that can be used
            List<char> usableCharaters = new List<char>();

            //Transcribes the available characters into the usable characters.
            foreach (char c in availableCharacters)
            {
                usableCharaters.Add(c);
            }
            //Now we loop through the available charaters again, so that we can add them to the dictionary
            foreach (char c in availableCharacters)
            {
                //Gets a random character to cypher to, then adds it to the dictionaty
                char cypherTo = usableCharaters[new Random(seed).Next(0, usableCharaters.Count)];
                cypher.Add(c, cypherTo);

                //Removes the character from the usable character array, so that no character is used twice 
                //(I don't know if this is the best method for making sure I don't use the same character twice, but it is the best way that I thought of)
                usableCharaters.Remove(cypherTo);
            }

            //returns the created dictionary
            return cypher;
        }
        /// <summary>
        /// Used to generate a back cypher for the given cypher
        /// </summary>
        /// <param name="cypher"></param>
        /// <returns></returns>
        public static Dictionary<char, char> GenerateBackCypher(Dictionary<char, char> cypher)
        {
            Dictionary<char, char> backCypher = new Dictionary<char, char>();
            //Loops through the available characters and puts them through the cypher to get the key, then uses the character as the value
            foreach (char c in availableCharacters)
            {
                backCypher.Add(cypher[c], c);
            }

            //Returns the created back cypher
            return backCypher;
        }

        public static string CypherString(char[] toCypher)
        {
            //Again, the output (and again, pretty self explanatory, but, again, I thought I'd put this here anyway)
            string output = "";

            //Cyphers toCypher and adds it to the output
            foreach (char c in toCypher)
            {
                output += cypher[c];
            }

            //returns the output
            return output;
        }

        public static string UnCypherString(char[] toUnCypher)
        {
            //Last time, I promise. The output (pretty self explanatory, but I thought I'd put this here anyway)
            string output = "";

            //Cyphers toUnCypher and adds it to the output
            foreach (char c in toUnCypher)
            {
                output += backCypher[c];
            }

            //returns the output
            return output;
        }
    }
}
