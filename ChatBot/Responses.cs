using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    static class Responses
    {
        static public List<string> defaultResponse = new List<string>() { "I can't understand your question, could you clarify?", "Can you rephrase that please?", "I'm sorry i dont understand" };

        static public List<string> goodbye = new List<string>() { "See you next time!", "Hope to see you again!", "Message me again when I'm needed :)" };
        static public List<string> weather = new List<string>() { "You can check current weather at https://www.accuweather.com/" };
        static public List<string> joke = new List<string>() { "What do you call it when a snowman has a temper tantrum? A meltdown.", "Why are elevator jokes so good? Because they work on so many levels.", "What do you call advice from a cow? Beef Tips.", "Why are pediatricians always so grumpy? They have little patients. (Patience haha)", "Why did the scarecrow win an award? Because he was outstanding in his field.", "Why did the melon jump into the lake? It wanted to be a water-melon.", "What did the duck say when it bought lipstick? “Put it on my bill.”" };
        static public List<string> greetings = new List<string>() { "Hello!", "Welcome to my kitchen!", "Nice to see you!","Hi!","Greetings!" };

        static public List<string> bPNone = new List<string>() { };


        static public List<string> bPType = new List<string>() { };

        static public List<string> bPPeripherals = new List<string>() { };

        static public List<string> bPBudget = new List<string>() { };

        static public List<string> bPReview = new List<string>() { };
    }



    static class Keywords
    {
        static public List<string> weather = new List<string>() { "weather", "rain", "snowy", "rainy", "rain", "windy", "cold", "warm" };
        static public List<string> goodbye = new List<string>() { "bye", "quit", "exit" };
        static public List<string> joke = new List<string>() { "joke", "prank", "laugh", "entertain" };
        static public List<string> greetings = new List<string>() { "hi", "hello", "hey", "helloo", "hellooo", "g morining", "gmorning", "good morning", "morning",
            "good day", "good afternoon", "good evening", "greetings", "greeting", "good to see you", "its good seeing you", 
            "how are you", "how're you", "how are you doing", "how ya doin'", "how ya doin", "how is everything", 
            "how is everything going", "how's everything going", "how is you", "how's you", "how are things", "how're things", 
            "how is it going", "how's it going", "how's it goin'", "how's it goin", "how is life been treating you", 
            "how's life been treating you", "how have you been", "how've you been", "what is up", "what's up", "what is cracking", 
            "what's cracking", "what is good", "what's good", "what is happening", "what's happening", "what is new", "what's new", 
            "what is neww", "g’day", "howdy" };

        static public List<string> bPNone = new List<string>() { };

        static public List<string> bPType = new List<string>() { };

        static public List<string> bPPeripherals = new List<string>() { };

        static public List<string> bPBudget = new List<string>() { };

        static public List<string> bPReview = new List<string>() { };


    }

    public class KR //keyword-response
    {
        public KR(List<string> keyword, List<string> response)
        {
            this.keywords = keyword;
            this.response = response;
        }
        public List<string> response;
        public List<string> keywords;
    }

}
