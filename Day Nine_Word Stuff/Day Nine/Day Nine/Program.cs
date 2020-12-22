using System;
using System.Collections.Generic;

namespace Day_Nine
{
    class Program
    {
        /// <summary>
        /// All of the words
        /// </summary>
        static string[] allOfTheWords = new string[] { 
            //Nouns
            /*0*/"Actor Gold Painting Advertisement Grass Parrot Afternoon Greece Pencil Airport Guitar Piano Ambulance Hair Pillow Animal Hamburger Pizza Answer Helicopter Planet Apple",
            /*1*/"Helmet Plastic Army Holiday Portugal Australia Honey Potato Balloon Horse Queen Banana Hospital Quill Battery House Rain Beach Hydrogen Rainbow Beard Ice Raincoat Bed Insect Refrigerator Belgium",
            /*2*/"Insurance Restaurant Boy Iron River Branch Island Rocket Breakfast Jackal Room Brother Jelly Rose Camera Jewellery Russia Candle Jordan Sandwich Car Juice School Caravan Kangaroo Scooter Carpet King", 
            /*3*/"Shampoo Cartoon Kitchen Shoe China Kite Soccer Church Knife Spoon Crayon Lamp Stone Crowd Lawyer Sugar Daughter Leather Sweden Death Library Teacher Denmark Lighter Telephone Diamond Lion Television", 
            /*4*/"Dinner Lizard Tent Disease Lock Thailand Doctor London Tomato Dog Lunch Toothbrush Dream Machine Traffic Dress Magazine Train Easter Magician Truck Egg Manchester Uganda Eggplant Market Umbrella", 
            /*5*/"Egypt Match Van Elephant Microphone Vase Energy Monkey Vegetable Engine Morning Vulture England Motorcycle Wall Evening Nail Whale Eye Napkin Window Family Needle Wire Finland Nest Xylophone Fish", 
            /*6*/"Nigeria Yacht Flag Night Yak Flower Notebook Zebra Football Ocean Zoo Forest Oil Garden Fountain Orange Gas France Oxygen Girl Furniture Oyster Glass Garage Ghost",
            //Verbs
            /*7*/"Act Answer Approve Arrange Break Build Buy Coach Color Cough Create Complete Cry Dance Describe Draw Drink Eat Edit Enter Exit Imitate Invent Jump Laugh Lie Listen Paint Plan Play Read Replace Run",
            /*8*/"Scream See Shop Shout Sing Skip Sleep Sneeze Solve Study Teach Touch Turn Walk Win Write Whistle Yank Zip Concern Decide Dislike Doubt Feel Forget Hate Hear Hope Impress Know Learn Like Look Love", 
            /*9*/"Mind Notice Own Perceive Realize Recognize Remember See Smell Surprise Please Prefer Promise Think Understand",
            //Adjectives
            /*10*/"attractive bald beautiful chubby clean dazzling drab elegant fancy fit flabby glamorous gorgeous handsome long magnificent muscular plain plump quaint scruffy shapely short skinny stocky ugly unkempt", 
            /*11*/"unsightly ash black blue gray green icy lemon mango orange purple red salmon white yellow alive better careful clever dead easy famous gifted hallowed helpful important inexpensive mealy mushy odd",
            /*12*/"poor powerful rich shy tender unimportant uninterested vast wrong aggressive agreeable ambitious brave calm delightful eager faithful gentle happy jolly kind lively nice obedient polite proud silly",
            /*13*/"thankful victorious witty wonderful zealous angry bewildered clumsy defeated embarrassed fierce grumpy helpless itchy jealous lazy mysterious nervous obnoxious panicky pitiful repulsive scary", 
            /*14*/"thoughtless uptight worried broad chubby crooked curved deep flat high hollow low narrow refined round shallow skinny square steep straight wide big colossal fat gigantic great huge immense large",
            /*15*/"little mammoth massive microscopic miniature petite puny scrawny short small tall teeny tiny crashing deafening echoing faint harsh hissing howling loud melodic noisy purring quiet rapping raspy",
            /*16*/"rhythmic screeching shrilling squeaking thundering tinkling wailing whining whispering ancient brief early fast future late long modern old old-fashioned prehistoric quick rapid short slow swift", 
            /*17*/"young acidic bitter cool creamy delicious disgusting fresh greasy juicy hot moldy nutritious nutty putrid rancid ripe rotten salty savory sour spicy spoiled stale sweet tangy tart tasteless tasty",  
            /*18*/"yummy breezy bumpy chilly cold cool cuddly damaged damp dirty dry flaky fluffy freezing greasy hot icy loose melted prickly rough shaggy sharp slimy sticky strong tight uneven warm weak wet wooden",
            /*19*/"abundant billions enough few full hundreds incalculable limited little many most millions numerous scarce some sparse substantial thousands",
            //Adverbs
            /*20*/"Randomly boldly bravely brightly cheerfully deftly devotedly eagerly elegantly faithfully fortunately gleefully gracefully happily honestly innocently justly kindly merrily obediently perfectly",
            /*21*/"politely powerfully safely victoriously warmly vivaciously angrily anxiously badly boastfully foolishly hopelessly irritably jealously lazily obnoxiously poorly rudely selfishly wearily always eventually",
            /*22*/"finally frequently hourly never occasionally often rarely regularly seldom sometimes usually weekly yearly promptly quickly rapidly slowly speedily tediously accidentally awkwardly blindly coyly crazily",
            /*23*/"defiantly deliberately doubtfully dramatically dutifully enormously evenly exactly hastily hungrily inquisitively loosely madly mortally mysteriously nervously only seriously shakily sharply silently",
            /*24*/"solemnly sternly technically unexpectedly wildly" };
        static void Main(string[] args)
        {
            //List of all of the words separated
            List<string> words = ReadStringList(allOfTheWords[0] + " " + allOfTheWords[1] + " " + allOfTheWords[2] + " " + allOfTheWords[3] + " " + allOfTheWords[4] + " " + allOfTheWords[5]
                + " " + allOfTheWords[6]+ " " + allOfTheWords[7]+ " " + allOfTheWords[8]+ " " + allOfTheWords[9]+ " " + allOfTheWords[10]+ " " + allOfTheWords[11]+ " " + allOfTheWords[12]
                + " " + allOfTheWords[13]+ " " + allOfTheWords[14]+ " " + allOfTheWords[15]+ " " + allOfTheWords[16]+ " " + allOfTheWords[17]+ " " + allOfTheWords[18]+ " " + allOfTheWords[19]
                + " " + allOfTheWords[20]+ " " + allOfTheWords[21]+ " " + allOfTheWords[22]+ " " + allOfTheWords[23]+ " " + allOfTheWords[24]);

            //Loops infinitely
            while (true)
            {
                //The word the user inputs
                string word = "";
                //The amount of letters that must match
                int letters = 0;

                //Gets the users input
                Console.Write("Enter a word: "); word = Console.ReadLine();
                Console.Write("Enter an amount of letters that must match: "); try { letters = Convert.ToInt32(Console.ReadLine()); } catch { letters = 1; }

                //Makes sure letters isn't longer than word
                if (letters > word.Length)
                {
                    letters = word.Length;
                }

                //Gets the matching words
                List<string> wordsWithMatchingLetters = GetWordsWithMatchingLetters(word, letters, words);

                //Prints the matching words
                foreach (string s in wordsWithMatchingLetters)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("");
            }
        }
        /// <summary>
        /// Reads a string and turns it into a list of strings
        /// </summary>
        /// <returns></returns>
        static List<string> ReadStringList(string toList)
        {
            //List of strings
            List<string> stringList = new List<string>();
            //The current word being read
            string currentWord = "";

            foreach (char c in toList.ToCharArray())
            {
                if (c == ' ')
                {
                    if (currentWord != "")
                    {
                        stringList.Add(currentWord);
                        currentWord = "";
                    }
                }
                else
                {
                    currentWord += c;
                }
            }
            if (currentWord != "")
            {
                stringList.Add(currentWord);
                currentWord = "";
            }

            //Returns the created list of strings
            return stringList;
        }
        /// <summary>
        /// Gets words with <paramref name="letters"/> matching letters with <paramref name="word"/>
        /// </summary>
        /// <param name="word"></param>
        /// <param name="letters"></param>
        /// <returns></returns>
        static List<string> GetWordsWithMatchingLetters(string word, int letters, List<string> words)
        {
            //The words with matching letters
            List<string> wordsWithMatchingLetters = new List<string>();

            //Iterates through every word and sees if it has enough matching letters, and if so adds it to the words with matching letters array, but doesn't add it if the words are the same
            foreach (string matchesWith in words)
            {
                if (HasMatchingLetters(word.ToLower(), matchesWith.ToLower(), letters) && word.ToLower() != matchesWith.ToLower())
                    wordsWithMatchingLetters.Add(matchesWith.ToLower());
            }

            //Returns the words with matching letters
            return wordsWithMatchingLetters;
        }
        /// <summary>
        /// Checks if <paramref name="word"/> has <paramref name="letters"/> matching letters with <paramref name="matchesWith"/>
        /// </summary>
        /// <param name="word"></param>
        /// <param name="matchesWith"></param>
        /// <param name="letters"></param>
        /// <returns></returns>
        static bool HasMatchingLetters(string word, string matchesWith, int letters)
        {
            //Converts the two inputed string to char arrays
            char[] wordCA = word.ToCharArray();
            char[] matchesWithCA = matchesWith.ToCharArray();

            //Converts the wordCA the a list
            List<char> wordCL = new List<char>();
            foreach (char c in wordCA)
            {
                wordCL.Add(c);
            }

            //The number of letters that match
            int lettersThatMatch = 0;

            //Check through each letter in mathcesWith to see if it has a matching letter in word 
            foreach (char c in matchesWithCA)
            {
                foreach (char h in wordCL)
                {
                    //If the letters match, adds to letters that match, removes the matching letter from the word, and stops checking for letters that match c
                    if (h == c)
                    {
                        lettersThatMatch++;
                        wordCL.Remove(h);
                        break;
                    }
                }
            }

            //returns if the letters that match are greater than or equal to letters
            return lettersThatMatch >= letters;
        }
    }
}
