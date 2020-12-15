using System;
using System.Collections.Generic;
using System.Text;

namespace Day_Three
{
    class ConversationPhrase
    {
        /// <summary>
        /// The phrase that is said if this conversation phrase can be said
        /// </summary>
        public string phrase;
        public string[] wordsThatMustBeSaid;
        public bool or;

        public ConversationPhrase(string phrase, string[] wordsThatMustBeSaid)
        {
            this.phrase = phrase;
            this.wordsThatMustBeSaid = wordsThatMustBeSaid;
            or = false;
        }
        public ConversationPhrase(string phrase, string[] wordsThatMustBeSaid, bool or)
        {
            this.phrase = phrase;
            this.wordsThatMustBeSaid = wordsThatMustBeSaid;
            this.or = or;
        }
        /// <summary>
        /// Checks if the conversation phrase can be said
        /// </summary>
        /// <returns>If the conversation phrase can be said</returns>
        public bool CheckIfCanBeSaid(string userInput)
        {
            //If the phrase can be said
            bool canBeSaid = true;
            //Checks each word that must be said to see if it is in the player input
            foreach (string word in wordsThatMustBeSaid)
            {
                if (or)
                    canBeSaid = canBeSaid || Program.Contains(userInput.ToLower(), word.ToLower());
                else
                    canBeSaid = canBeSaid && Program.Contains(userInput.ToLower(), word.ToLower());
            }

            //Returns if the phrase can be said
            return canBeSaid;
        }
    }
}
