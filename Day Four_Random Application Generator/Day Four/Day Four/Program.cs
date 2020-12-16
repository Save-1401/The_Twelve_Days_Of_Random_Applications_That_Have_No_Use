using System;
using System.Collections.Generic;
using System.Numerics;

namespace Day_Four
{
    class Program
    {
        /// <summary>
        /// All of the words
        /// </summary>
        static string[] words = new string[] { 
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
            //Sets up the lists of words
            List<string> nouns = ReadStringList(words[0] + " " + words[1] + " " + words[2] + " " + words[3] + " " + words[4] + " " + words[5] + " " + words[6]);
            List<string> verbs = ReadStringList(words[7] + " " + words [8] + " " + words [9]);
            List<string> adjectives = ReadStringList(words[10] + " " + words[11] + " " + words[12] + " " + words[13] + " " + words[14] + " " + words[15] + " " + words[16] + " " + words[17]
                + " " + words[18] + " " + words[19]);
            List<string> adverbs = ReadStringList(words[20] + " " + words[21] + " " + words[22] + " " + words[23] + " " + words[24]);
            //The random used for random generation
            Random rnd;
            Console.Write("Enter a seed: ");
            try
            {
                rnd = new Random(Convert.ToInt32(Console.ReadLine()));
            }
            catch
            {
                rnd = new Random(1401);
            }
            //Endlessly generates an idea after enter is pressed
            while (true)
            {
                Console.ReadLine();
                Console.WriteLine(GenerateIdea(rnd, nouns, verbs, adjectives, adverbs));
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

            foreach(char c in toList.ToCharArray())
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
        /// Generates a random idea
        /// </summary>
        /// <returns>A randomly generated idea</returns>
        static string GenerateIdea(Random rnd, List<string> nouns, List<string> verbs, List<string> adjectives, List<string> adverbs)
        {
            //The idea
            string idea = "An application that";

            //Rolls to see if it should say is
            if (RollChance(rnd))
            {
                idea += " is";

                idea += " " + GetRandom(adjectives, rnd);
                for (int i = 0; i < rnd.Next(0, 10); i++)
                {
                    idea += " and";
                    idea += " " + GetRandom(adjectives, rnd);
                }
            }
            else
            {
                for (int i = 0; i < rnd.Next(0, 4); i++)
                {
                    idea += " " + GetRandom(adverbs, rnd);
                }
                idea += " " + GetRandom(verbs, rnd);
                idea += "s";
                if (RollChance(rnd))
                {
                    idea += " a";
                    for (int i = 0; i < rnd.Next(0, 4); i++)
                    {
                        idea += " " + GetRandom(adjectives, rnd);
                    }
                    idea += " " + GetRandom(nouns, rnd);
                }
                else
                {
                    for (int i = 0; i < rnd.Next(0, 4); i++)
                    {
                        idea += " " + GetRandom(adjectives, rnd);
                    }
                    idea += " " + GetRandom(nouns, rnd);
                    idea += "s";
                }
            }
            idea += ".";

            //Returns the generated idea
            return idea;
        }
        /// <summary>
        /// Rolls based on the chance
        /// </summary>
        /// <param name="chance"></param>
        /// <param name="rnd"></param>
        /// <returns></returns>
        static bool RollChance(Random rnd)
        {
            return rnd.Next(0, 2) == 0;
        }
        /// <summary>
        /// Get a random string from to choose from
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        static string GetRandom(List<string> toChooseFrom, Random rnd)
        {
            return toChooseFrom[rnd.Next(0, toChooseFrom.Count)].ToLower();
        }
    }
}
