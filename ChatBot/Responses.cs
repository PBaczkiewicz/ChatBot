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
        static public List<string> greetings = new List<string>() { "Hello!", "Welcome to my kitchen!", "Nice to see you!", "Hi!", "Greetings!" };
        static public List<string> coffee = new List<string>() { "Sorry, but i can't do a coffee for you. Go to kitchen or ask your mom." };
        static public List<string> robot = new List<string>() { "I'm not robot. I'm chatbot O.o", "Does it hurt when you get shot? I sense injuries. The data could be called pain." };
        static public List<string> poland = new List<string>() { "Bober Kurwa!","Gdzie jest krzyż?!","Ale urwał!" ,"POLSKA GUROM!" };
        #region PC build responses

        static public List<string> bPType = new List<string>() { "What type of PC do you want to build?" };
        static public List<string> bPWrongType = new List<string>() { "You didn't specify what type do you want me to build. I can build a gaming powerhouse, workplace pc, student learning helper, design monster or just universal computer." };
        static public List<string> bPTypeGaming = new List<string>() { "You choose 'Gaming' computer build. Do you also need monitor, mouse and keyboard?" };
        static public List<string> bPTypeGraphics = new List<string>() { "You choose 'Design' computer build. Do you also need monitor, mouse and keyboard?" };
        static public List<string> bPTypeUniversal = new List<string>() { "You choose 'Universal' computer build. Do you also need monitor, mouse and keyboard?" };
        static public List<string> bPTypeWork = new List<string>() { "You choose 'Work' computer build. Do you also need monitor, mouse and keyboard?" };
        static public List<string> bPTypeStudent = new List<string>() { "You choose 'Student' computer build. Do you also need monitor, mouse and keyboard?" };



        static public List<string> bPPeripherals = new List<string>() { "Okay I will create your build with peripherals. What is your budget? For this build purpose I suggest amount above : " };
        static public List<string> bPNoPeripherals = new List<string>() { "Okay I will create your build without peripherals. What is your budget? For this build purpose I suggest amount above : " };

        static public List<string> bPBudget = new List<string>() { "You ented a value of ", ". Now i will generate a few builds for you." };
        static public List<string> bPNotEnoughBudget = new List<string>() { "Value you entered is not enough for PC build with this parameters. Please input a budget above minimal treshold." };

        static public List<string> bPReview = new List<string>() { };
        #endregion
    }



    static class Keywords
    {
        static public List<string> weather = new List<string>() { "weather", "rain", "snowy", "rainy", "rain", "windy", "cold", "warm" };
        static public List<string> goodbye = new List<string>() { "bye", "quit", "exit" };
        static public List<string> joke = new List<string>() { "joke", "prank", "laugh", "entertain" };
        static public List<string> greetings = new List<string>() { "hi", "hello", "hey", "helloo", "hellooo", "g morining", "gday", "gmorning", "good morning", "morning", "good day", "good afternoon", "good evening", "greetings", "greeting", "good to see you", "its good seeing you", "how are you", "how're you", "how are you doing", "how ya doin'", "how ya doin", "how is everything", "how is everything going", "how's everything going", "how is you", "how's you", "how are things", "how're things", "how is it going", "how's it going", "how's it goin'", "how's it goin", "how is life been treating you", "how's life been treating you", "how have you been", "how've you been", "what is up", "what's up", "what is cracking", "what's cracking", "what is good", "what's good", "what is happening", "what's happening", "what is new", "what's new", "what is neww", "g’day", "howdy" };
        static public List<string> coffee = new List<string>() { "coffee" };
        static public List<string> robot = new List<string>() { "robot", "ai", "machine" };
        static public List<string> poland = new List<string>() { "polish", "polska", "poland", "kurwa", "polsk" };
        #region PC build keywords
        static public List<string> bPType = new List<string>() { "build", "start", "begin", "pc", "computer" };
        static public List<string> bPWrongType = new List<string>() { };//nothing neccesary

        static public List<string> bPTypeGaming = new List<string>() { "gaming", "games", "play", "streaming", "stream" };
        static public List<string> bPTypeGraphics = new List<string>() { "graphics", "design", "photoshop", "edit", "marketing", "photo", "video" };
        static public List<string> bPTypeUniversal = new List<string>() { "normal", "universal" };
        static public List<string> bPTypeWork = new List<string>() { "work", "company", "spreadsheets", "excel", "programming" };
        static public List<string> bPTypeStudent = new List<string>() { "school", "university", "learn", "student" };




        static public List<string> bPPeripherals = new List<string>() { "yes", "sure", "of course", "why not" };
        static public List<string> bPNoPeripherals = new List<string>() { "no", "not", "won't", "already have" };

        static public List<string> bPBudget = new List<string>() { };
        static public List<string> bPNotEnoughBudget = new List<string>() { };

        static public List<string> bPReview = new List<string>() { };
        #endregion


    }

    public class KR //keyword-response
    {
        public KR(List<string> keyword, List<string> response)
        {
            this.keywords = keyword;
            this.response = response;
        }
        public KR() { }
        public List<string> response;
        public List<string> keywords;
    }

}
