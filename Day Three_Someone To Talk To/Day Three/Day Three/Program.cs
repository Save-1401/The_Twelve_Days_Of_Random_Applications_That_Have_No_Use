using System;
using System.Collections.Generic;

namespace Day_Three
{
    class Program
    {
        /// <summary>
        /// All the things the program can say
        /// </summary>
        static ConversationPhrase[] thingsToSay = new ConversationPhrase[] { new ConversationPhrase("My name is Someone To Talk To", new string[] { "What", "Your", "Name"}), 
            new ConversationPhrase("That is insulting", new string[] { "You", "Stupid" }), new ConversationPhrase("Yes, user?", new string[] { "Someone To Talk To"}), 
            new ConversationPhrase("GOOD", new string[] { "Good" }), new ConversationPhrase("GOOD!", new string[] { "I hate you" }), new ConversationPhrase("Talk to you later", new string[] { "Goodbye", "Cya", "See you", "See you later" }, true),
            new ConversationPhrase("Goodbye", new string[] { "Goodbye", "Cya", "See you", "See you later" }, true), new ConversationPhrase("It was nice talking to you", new string[] { "Goodbye", "Cya", "See you", "See you later" }, true) };
        static void Main(string[] args)
        {
            Random rnd = new Random(1401);

            while (true)
            {
                string toSay = Speak(Console.ReadLine(), rnd);
                Console.WriteLine(toSay);

                if (toSay == "Talk to you later" || toSay == "Goodbye" || toSay == "It was nice talking to you")
                {
                    return;
                }
            }
        }
        /// <summary>
        /// Checks the user input and decides on something to say based off it
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>The thing decided to say</returns>
        static string Speak(string userInput, Random rnd)
        {
            //What to say
            string toSay = "";
            //List of conversation phrases that can be said
            List<ConversationPhrase> thingsThatCanBeSaid = new List<ConversationPhrase>();

            //Gets all the phrases that can be said
            foreach (ConversationPhrase cp in thingsToSay)
            {
                if (cp.CheckIfCanBeSaid(userInput))
                {
                    thingsThatCanBeSaid.Add(cp);
                }
            }

            //Chooses a random thing that can be said's phrase to say, if there are no things that can be said, tells the user that it does not understand what they said
            if (thingsThatCanBeSaid.Count > 0)
                toSay = thingsThatCanBeSaid[rnd.Next(0, thingsThatCanBeSaid.Count)].phrase;
            else
                toSay = "I'm sorry, I do not understand";

            //Returns what has been decided to say
            return toSay;
        }
        /// <summary>
        /// Checks if container contains word
        /// </summary>
        /// <param name="container"></param>
        /// <param name="word"></param>
        /// <returns>Whether or not container contains word</returns>
        public static bool Contains(string container, string word)
        {
            //If word is contained in container
            bool contains = false;
            //The letter of word currently being checked
            int letter = 0;

            //Iterates through container and checks if word is contained in it
            char[] containerCA = container.ToCharArray();
            for (int i = 0; i < containerCA.Length; i++)
            {
                if (containerCA[i] == word.ToCharArray()[letter])
                {
                    letter++;
                    if (letter >= word.Length)
                    {
                        contains = true;
                        letter = 0;
                    }
                }
                else
                {
                    letter = 0;
                }
            }

            //Returns the results
            return contains;
        }
    }
}
