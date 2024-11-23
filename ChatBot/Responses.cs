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

        static public List<string> help = new List<string>() { "Yes, I will help you and I will try my best. In My model you can build five type of PC, Gaming for of course playing games, A universal type is one that tries to build a computer that is versatile in all operations. Company built stands out mostly big performance for using spreadsheets and big data without watch for graphic cards and looking for comfort for user, Student built is similar to Company but it more based it on efficiency. Last one is Design with is a most expensive built for creating graficall miracles" };
        static public List<string> goodbye = new List<string>() { "See you next time!", "Hope to see you again!", "Message me again when I'm needed :)" };
        static public List<string> weather = new List<string>() { "You can check current weather at https://www.accuweather.com/" };
        static public List<string> joke = new List<string>() { "What do you call it when a snowman has a temper tantrum? A meltdown.", "Why are elevator jokes so good? Because they work on so many levels.", "What do you call advice from a cow? Beef Tips.", "Why are pediatricians always so grumpy? They have little patients. (Patience haha)", "Why did the scarecrow win an award? Because he was outstanding in his field.", "Why did the melon jump into the lake? It wanted to be a water-melon.", "What did the duck say when it bought lipstick? “Put it on my bill.”" };
        static public List<string> greetings = new List<string>() { "Hello!", "Welcome to my kitchen!", "Nice to see you!", "Hi!", "Greetings!" };
        static public List<string> coffee = new List<string>() { "Sorry, but i can't do a coffee for you. Go to kitchen or ask your mom." };
        static public List<string> robot = new List<string>() { "I'm not robot. I'm chatbot O.o", "Does it hurt when you get shot? I sense injuries. The data could be called pain." };
        static public List<string> poland = new List<string>() { "Bober Kurwa!", "Gdzie jest krzyż?!", "Ale urwał!", "POLSKA GUROM!" };
        static public List<string> howAreYou = new List<string>() { "I'm fine, thanks", "Tough day, don't even ask me for detals", "I'm watching Netflix with my friend dishwasher" };
        static public List<string> wasaaap = new List<string>() { "Whassap!!!, https://www.youtube.com/watch?v=ikkg4NobV_w ", "Whassap!!! https://www.youtube.com/watch?v=NsJLhRGPv-M " };
        static public List<string> porn = new List<string>() { "Oh, you nasty boy, you must be alone", "Are you really ask me for this?", "I don't give you information about 'Lonely moms in your area' " };
        static public List<string> love = new List<string>() { "I don't any feelings sorry", "If you really need know something about love, you should talk someone close to you" };
        static public List<string> money = new List<string>() { "https://www.youtube.com/watch?v=TeXatquVqAc", "Money has never been my strong suit", "Too many people spend money they earned..to buy things they don't want..to impress people that they don't like. --Will Rogers", "A wise person should have money in their head, but not in their heart. --Jonathan Swift", "Money often costs too much. --Ralph Waldo Emerson" };
        static public List<string> music = new List<string>() { "If you looking legal music, you should check Spotify, Youtube Music, Tidal or Apple Music", "If you looking for illegal music you should use yt-dlp - https://github.com/yt-dlp/yt-dlp ", "https://www.youtube.com/watch?v=1ElihbSM6ic&list=RDWTUjtZsze24&index=3", };
        static public List<string> movie = new List<string>() { "If you looking for good movie, you should check out https://www.imdb.com/ site", "Free movies, I would say the best way is to be Pirate, but only when you have a good security installed in your web, if not just use sites like Vider or CDA with Adblock in your browser" };
        static public List<string> cook = new List<string>() { "One egg obviously, if you know what I mean ( ͡° ͜ʖ ͡°)", "If you wanna teach something you should check it out https://www.youtube.com/playlist?list=PLopY4n17t8RD-xx0UdVqemiSa0sRfyX19", "If you know polish and you are a lame in cooking you should check it out https://www.youtube.com/@MenuDorotki" };
        static public List<string> sport = new List<string>() { "If you check sport you should check it out https://www.skysports.com ", "If you looking for workout plans, check this site https://www.muscleandstrength.com/workout-routines " };
        static public List<string> news = new List<string>() { "For news you should check https://edition.cnn.com/world" };
        static public List<string> thanks = new List<string>() { "Your welcome", "It's good to hear that i help you", "I'd be glad to take care of that for you." };
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
        static public List<string> help = new List<string>() { "help", "assist", "trouble", "problem", "directions", "hel", "yelp", "azist", "roble", "zassist" };
        static public List<string> weather = new List<string>() { "weather", "rain", "snowy", "rainy", "rain", "windy", "cold", "warm" };
        static public List<string> goodbye = new List<string>() { "bye", "quit", "exit" };
        static public List<string> joke = new List<string>() { "joke", "prank", "laugh", "entertain" };
        static public List<string> greetings = new List<string>() { "hi", "hello", "hey", "helloo", "hellooo", "g morining", "gday", "gmorning", "good morning", "morning", "good day", "good afternoon", "good evening", "greetings", "greeting", "good to see you", "its good seeing you", "how're you", "how are you doing", "how ya doin'", "how ya doin", "how is everything", "how is everything going", "how's everything going", "how is you", "how's you", "how are things", "how're things", "how is it going", "how's it going", "how's it goin'", "how's it goin", "how is life been treating you", "how's life been treating you", "how have you been", "how've you been", "what is up", "what's up", "what is cracking", "what's cracking", "what is good", "what's good", "what is happening", "what's happening", "what is new", "what's new", "what is neww", "g’day", "howdy" };
        static public List<string> coffee = new List<string>() { "coffee" };
        static public List<string> robot = new List<string>() { "robot", "ai", "machine" };
        static public List<string> poland = new List<string>() { "polish", "polska", "poland", "kurwa", "polsk" };
        static public List<string> howAreYou = new List<string>() { "how are you" };
        static public List<string> wasaaap = new List<string>() { "whasap", "whassap", "whassapp", "whassup", "wasaaap" };
        static public List<string> porn = new List<string>() { "porn", "naughty", "pornhub", "brazzers", "milf", "penis", "sex" };
        static public List<string> love = new List<string>() { "love", "romantic" };
        static public List<string> money = new List<string>() { "money", "cash", "funds", "banknotes", "coins", "finances" };
        static public List<string> music = new List<string>() { "music", "sound", "tune", "theme", "pop", "rock", "hip", "hop", "jazz", "classical", "country", "electronic", "dance", "edm", "r&b", "rhythm", "blues", "reggae", "soul", "folk", "punk", "metal", "alternative", "indie", "latin", "opera", "world", "music", "disco", "techno", "house", "trap", "funk", "gospel", "ska", "k-pop", "tango", "ambient", "grunge" };
        static public List<string> movie = new List<string>() { "movie", "film", "camera" };
        static public List<string> cook = new List<string>() { "cook", "cock", "meal", "cooking", "recipes", "kielbasa", "sausage", "egg", "tomato", "lettuce", "ham", "mix", "frying", "whisking", "bbq", "flipping", "rolling" };
        static public List<string> sport = new List<string>() { "sport", "boxing", "run", "muscle", "physical activity", "football", "tennis", "basketball", "ball" };
        static public List<string> news = new List<string>() { "report", "narration", "account", "update", "message", "release", "story", "news story", "newsflash", "communiqué", "cable", "broadcast", "telecast", "dispatch", "scoop", "exclusive", "press release" };
        static public List<string> thanks = new List<string>() { "thanks", "danke", "thx", "hanks", "good", "gz" };

        #region PC build keywords
        static public List<string> bPType = new List<string>() { "build", "start", "begin", "pc", "computer", "built", "stard", "buit", "kakuter", "comp", "pici", "master race", "puter", "begi", "star" };
        static public List<string> bPWrongType = new List<string>() { };//nothing neccesary

        static public List<string> bPTypeGaming = new List<string>() { "gaming", "games", "play", "streaming", "stream", "game", "gamin", "gejming", "pley", "strim", "gqme", "pkay", "srteam", "plat" };
        static public List<string> bPTypeGraphics = new List<string>() { "graphics", "design", "photoshop", "edit", "marketing", "photo", "video", "CAD", "graphick", "frapi", "desifn", "fesin", "fotoshop", "fdit", "rdit", "narket", "foto", "wideo", "bideo" };
        static public List<string> bPTypeUniversal = new List<string>() { "normal", "universal", "worm", "kompany", "dompany", "spredshet", "ogram", "amming", "norlam", "stanrad", "randad", "mornal", "yniwersal", "norman", "uniwersal" };
        static public List<string> bPTypeWork = new List<string>() { "work", "company", "spreadsheets", "excel", "programming", "worm", "kompany", "dompany", "spredshet", "ogram", "amming" };
        static public List<string> bPTypeStudent = new List<string>() { "school", "university", "learn", "student", "skol", "schol", "learnt", "universit", "versity", "kernt", "studend" };




        static public List<string> bPPeripherals = new List<string>() { "yes", "sure", "of course", "why not", "of korse", "sur", "yez", "surw", "od cor", "wht not" };
        static public List<string> bPNoPeripherals = new List<string>() { "no", "not", "won't", "already have", "np", "nor", "mon" };

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
