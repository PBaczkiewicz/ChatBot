using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;

namespace ChatBot
{
    internal class Program
    {
        static string input = "";
        static readonly Random rng = new Random();

        #region Lists of components
        static public List<CPU> cpuList = new List<CPU>();
        static public List<GPU> gpuList = new List<GPU>();
        static public List<CPUCooler> cpuCoolerList = new List<CPUCooler>();
        static public List<Disc> discList = new List<Disc>();
        static public List<Keyboard> keyboardList = new List<Keyboard>();
        static public List<Monitor> monitorList = new List<Monitor>();
        static public List<Motherboard> motherboardList = new List<Motherboard>();
        static public List<PSU> psuList = new List<PSU>();
        static public List<RAM> ramList = new List<RAM>();
        static public List<Mouse> mouseList = new List<Mouse>();
        #endregion

        #region PC components paths
        static readonly string processorPath = "data/cpu.json";
        static readonly string gpuPath = "data/gpu.json";
        static readonly string cpuCoolerPath = "data/cpu-cooler.json";
        static readonly string discPath = "data/disc.json";
        static readonly string keyboardPath = "data/keyboard.json";
        static readonly string monitorPath = "data/monitor.json";
        static readonly string motherboardPath = "data/motherboard.json";
        static readonly string psuPath = "data/psu.json";
        static readonly string ramPath = "data/ram.json";
        static readonly string mousePath = "data/mouse.json";

        #endregion


        static void Main(string[] args)
        {
            LoadDataBase();
            ChatManager();

        }

        //Manages "chat"
        static void ChatManager()
        {
            GenerateKeywordResponse();

            Console.WriteLine("Amiga : Welcome to Amiga, PC build advisor! How can i help you?");

            while (!Keywords.goodbye.Contains(input))
            {
                Console.Write("\nUser : ");
                input = Console.ReadLine().ToLower();
                Console.Write("\nAmiga : " + ManageResponse(input) + "\n");
            }
            Thread.Sleep(1500);
        }

        //Manages input and gives response
        static string ManageResponse(string input)
        {
            string response = "";
            //Checks if input is tied to pc building keywords
            switch (bP)
            {
                //Phase 1 Starts building pc
                case BuildPhase.None:
                    response = BuildPhaseNoneKR();
                    if (response != "")
                    {
                        //Starts pc building
                        bP = BuildPhase.Type;
                        return response;
                    }
                    break;
                //Phase 2 user chooses which computer he wants
                case BuildPhase.Type:
                    response = BuildPhaseTypeKR();
                    if (response != "")
                    {
                        return response;
                    }
                    break;
                //Phase 3 user chooses if he want a peripherals or not (keyboard, mouse, monitor)
                case BuildPhase.Peripherals:
                    response = BuildPhasePeripheralsKR();
                    if (response != "") return response;
                    break;
                //Phase 4 users inputs his budget and if it is above minimal treshold, chatbot generates 4 pc builds
                case BuildPhase.Budget:
                    response = BuildPhaseBudgetKR();
                    if (response == bPNotEnoughBudget.response[0]) return response;
                    response += "\nBuild No.1 Intel CPU\n";
                    response += pc.BuildPC(true);
                    response += "\n\nBuild No.2 AMD CPU\n";
                    response += pc.BuildPC(false);
                    float higherBudget=(float)Math.Round((double)pc.budget*1.2,2);
                    pc.budget = higherBudget;
                    response += "\n\nBuild No.3 Intel CPU with increased budget to " + higherBudget+"\n";
                    response += pc.BuildPC(true);
                    response += "\n\nBuild No.4 AMD CPU with increased budget to " + higherBudget+"\n";
                    response += pc.BuildPC(false);
                    response += "\n\nHere are 4 builds for you. If you want another just start again :)";
                    bP = BuildPhase.None;
                    if (response != "") return response;
                    break;

            }

            //Other responses
            foreach (KR item in kr)
            {
                foreach (string keyword in item.keywords)
                {
                    if (input.Contains(keyword))
                    {
                        response = item.response[rng.Next(0, item.response.Count)];
                        return response;
                    }
                }
            }

            //If input does not match any keyword, returns default responses
            return Responses.defaultResponse[rng.Next(0, Responses.defaultResponse.Count)];
        }


        #region Applying keyword-response data

        //Applies keyword-responses to lists
        static void GenerateKeywordResponse()
        {
            kr.Add(new KR(Keywords.help, Responses.help));
            kr.Add(new KR(Keywords.greetings, Responses.greetings));
            kr.Add(new KR(Keywords.weather, Responses.weather));
            kr.Add(new KR(Keywords.joke, Responses.joke));
            kr.Add(new KR(Keywords.coffee, Responses.coffee));
            kr.Add(new KR(Keywords.robot, Responses.robot));
            kr.Add(new KR(Keywords.goodbye, Responses.goodbye));
            kr.Add(new KR(Keywords.poland, Responses.poland));
            kr.Add(new KR(Keywords.howAreYou, Responses.howAreYou));
            kr.Add(new KR(Keywords.wasaaap, Responses.wasaaap));
            kr.Add(new KR(Keywords.porn, Responses.porn));
            kr.Add(new KR(Keywords.love, Responses.love));
            kr.Add(new KR(Keywords.money, Responses.money));
            kr.Add(new KR(Keywords.music, Responses.music));
            kr.Add(new KR(Keywords.movie, Responses.movie));
            kr.Add(new KR(Keywords.cook, Responses.cook));
            kr.Add(new KR(Keywords.sport, Responses.sport));
            kr.Add(new KR(Keywords.news, Responses.news));
            kr.Add(new KR(Keywords.thanks, Responses.thanks));



            #region PC building keywords-responses
            bPType = (new KR(Keywords.bPType, Responses.bPType));
            bPWrongType = (new KR(Keywords.bPWrongType, Responses.bPWrongType));
            bPTypeGaming = (new KR(Keywords.bPTypeGaming, Responses.bPTypeGaming));
            bPTypeGraphics = (new KR(Keywords.bPTypeGraphics, Responses.bPTypeGraphics));
            bPTypeUniversal = (new KR(Keywords.bPTypeUniversal, Responses.bPTypeUniversal));
            bPTypeWork = (new KR(Keywords.bPTypeWork, Responses.bPTypeWork));
            bPTypeStudent = (new KR(Keywords.bPTypeStudent, Responses.bPTypeStudent));
            bPBudget = (new KR(Keywords.bPBudget, Responses.bPBudget));
            bPNotEnoughBudget = (new KR(Keywords.bPNotEnoughBudget, Responses.bPNotEnoughBudget));
            bPPeripherals = (new KR(Keywords.bPPeripherals, Responses.bPPeripherals));
            bPNoPeripherals = (new KR(Keywords.bPNoPeripherals, Responses.bPNoPeripherals));
            bPType = (new KR(Keywords.bPType, Responses.bPType));
            bPReview = (new KR(Keywords.bPReview, Responses.bPReview));
            #endregion
        }
        //Default responses
        static public List<KR> kr = new List<KR>();

        #region PC building responses
        static BuildPhase bP = BuildPhase.None;
        static public KR bPNone = new KR();

        static public KR bPType = new KR();//done
        static public KR bPWrongType = new KR();//done
        static public KR bPTypeGaming = new KR();//done
        static public KR bPTypeGraphics = new KR();//done
        static public KR bPTypeUniversal = new KR();//done
        static public KR bPTypeWork = new KR();//done
        static public KR bPTypeStudent = new KR();//done

        static public KR bPPeripherals = new KR();//done
        static public KR bPNoPeripherals = new KR();//done

        static public KR bPBudget = new KR();//done
        static public KR bPNotEnoughBudget = new KR();

        static public KR bPReview = new KR();//done

        static public PCBuild pc = new PCBuild();
        #endregion

        #region Budget
        public const int minimalBudgetWOP = 750;//without peripherals
        public const int minimalBudgetWP = 900;//with peripherals

        public const int minimalBudgetWOPgr = 1500;//without peripherals
        public const int minimalBudgetWPgr = 1650;//with peripherals

        #endregion


        //Starts a build
        static string BuildPhaseNoneKR()
        {
            foreach (string keyword in bPType.keywords)
            {
                if (input.Contains(keyword))
                {
                    pc = new PCBuild();
                    return bPType.response[rng.Next(0, bPType.response.Count)];

                }
            }

            return "";
        }

        //Returns type of PC build
        static string BuildPhaseTypeKR()
        {
            bP = BuildPhase.Peripherals;

            foreach (string keyword in bPTypeGaming.keywords)
            {
                if (input.Contains(keyword))
                {
                    pc.buildType = BuildType.Gaming;
                    return bPTypeGaming.response[rng.Next(0, bPTypeGaming.response.Count)];

                }
            }


            foreach (string keyword in bPTypeGraphics.keywords)
            {
                if (input.Contains(keyword))
                {
                    pc.buildType = BuildType.Graphics;
                    return bPTypeGraphics.response[rng.Next(0, bPTypeGraphics.response.Count)];

                }
            }

            foreach (string keyword in bPTypeWork.keywords)
            {
                if (input.Contains(keyword))
                {
                    pc.buildType = BuildType.Work;
                    return bPTypeWork.response[rng.Next(0, bPTypeWork.response.Count)];

                }
            }


            foreach (string keyword in bPTypeStudent.keywords)
            {
                if (input.Contains(keyword))
                {
                    pc.buildType = BuildType.Student;
                    return bPTypeStudent.response[rng.Next(0, bPTypeStudent.response.Count)];

                }
            }

            foreach (string keyword in bPTypeUniversal.keywords)
            {
                if (input.Contains(keyword))
                {
                    pc.buildType = BuildType.Universal;
                    return bPTypeUniversal.response[rng.Next(0, bPTypeUniversal.response.Count)];

                }

            }
            bP = BuildPhase.Type;
            return Responses.bPWrongType[0];
        }

        //Returns information about peripherals (yes or no)
        static string BuildPhasePeripheralsKR()
        {
            int budget = 0;
            foreach (string keyword in bPPeripherals.keywords)
            {
                if (input.Contains(keyword))
                {
                    bP=BuildPhase.Budget;
                    if (pc.buildType == BuildType.Graphics) budget = minimalBudgetWPgr;
                    else budget = minimalBudgetWP;
                    pc.minimalBudget=budget;
                    pc.peripherals = true;
                    return bPPeripherals.response[rng.Next(0, bPPeripherals.response.Count)] + budget;

                }
            }

            foreach (string keyword in bPNoPeripherals.keywords)
            {
                if (input.Contains(keyword))
                {
                    bP=BuildPhase.Budget;
                    if (pc.buildType == BuildType.Graphics) budget = minimalBudgetWOPgr;
                    else budget = minimalBudgetWOP;
                    pc.minimalBudget = budget;
                    pc.peripherals = false;
                    return bPNoPeripherals.response[rng.Next(0, bPNoPeripherals.response.Count)] + budget;

                }
            }

            return "";
        }

        //Checks input for a value
        static string BuildPhaseBudgetKR()
        {
            pc.budget = ExtractBudget(input);
            if (pc.budget > pc.minimalBudget) return bPBudget.response[0] + pc.budget.ToString() + bPBudget.response[1];
            else if (pc.budget < pc.minimalBudget) return bPNotEnoughBudget.response[0];

            return "";
        }
        #endregion
        #region Saving and loading data from component's JSON
        static void LoadDataBase()
        {
            int pause = 10;
            //try
            //{
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include
            };

            int loadingDataBaseProgress = 0; int totalDataBaseProgress = 10;

            Console.WriteLine("Loading database " + loadingDataBaseProgress + "/" + totalDataBaseProgress);
            Thread.Sleep(pause);



            string jsonString = File.ReadAllText(processorPath);
            cpuList = JsonConvert.DeserializeObject<List<CPU>>(jsonString, settings);

            //Fixing socket name
            //foreach(CPU cpu in processorList)
            //{
            //    if(cpu.socket=="1700"|| cpu.socket=="1200" || cpu.socket =="1151" || cpu.socket =="2066" || cpu.socket =="1150" || cpu.socket =="1155")
            //    {
            //        cpu.socket = "LGA" + cpu.socket;
            //    }
            //}
            //SaveJson();

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database " + loadingDataBaseProgress + "/" + totalDataBaseProgress);
            Thread.Sleep(pause);



            jsonString = File.ReadAllText(gpuPath);
            gpuList = JsonConvert.DeserializeObject<List<GPU>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database " + loadingDataBaseProgress + "/" + totalDataBaseProgress);
            Thread.Sleep(pause);



            jsonString = File.ReadAllText(cpuCoolerPath);
            cpuCoolerList = JsonConvert.DeserializeObject<List<CPUCooler>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database " + loadingDataBaseProgress + "/" + totalDataBaseProgress);
            Thread.Sleep(pause);



            jsonString = File.ReadAllText(discPath);
            discList = JsonConvert.DeserializeObject<List<Disc>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database " + loadingDataBaseProgress + "/" + totalDataBaseProgress);
            Thread.Sleep(pause);



            jsonString = File.ReadAllText(keyboardPath);
            keyboardList = JsonConvert.DeserializeObject<List<Keyboard>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database " + loadingDataBaseProgress + "/" + totalDataBaseProgress);
            Thread.Sleep(pause);



            jsonString = File.ReadAllText(monitorPath);
            monitorList = JsonConvert.DeserializeObject<List<Monitor>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database " + loadingDataBaseProgress + "/" + totalDataBaseProgress);
            Thread.Sleep(pause);



            jsonString = File.ReadAllText(motherboardPath);
            motherboardList = JsonConvert.DeserializeObject<List<Motherboard>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database " + loadingDataBaseProgress + "/" + totalDataBaseProgress);
            Thread.Sleep(pause);



            jsonString = File.ReadAllText(psuPath);
            psuList = JsonConvert.DeserializeObject<List<PSU>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database " + loadingDataBaseProgress + "/" + totalDataBaseProgress);
            Thread.Sleep(pause);



            jsonString = File.ReadAllText(ramPath);
            ramList = JsonConvert.DeserializeObject<List<RAM>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database " + loadingDataBaseProgress + "/" + totalDataBaseProgress);
            Thread.Sleep(pause);



            jsonString = File.ReadAllText(mousePath);
            mouseList = JsonConvert.DeserializeObject<List<Mouse>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Database loaded " + loadingDataBaseProgress + "/" + totalDataBaseProgress + "\n\n");
            Thread.Sleep(pause * 5);
            Console.Clear();
            //}
            //catch
            //{

            //}
        }
        static void SaveJson()
        {
            string jsonString = JsonConvert.SerializeObject(cpuList);

            File.WriteAllText(processorPath, jsonString);
        }
        #endregion

        //Using regex checks input for any int value
        static int? ExtractBudget(string input)
        {
            // Regex, which searches for a number in input
            Regex regex = new Regex(@"\b\d+\b");

            Match match = regex.Match(input);
            if (match.Success)
            {
                // Parses a number to int
                if (int.TryParse(match.Value, out int budget))
                {
                    return budget;
                }
            }
            return 0;
        }
    }

    enum BuildPhase
    {
        None,
        Type,
        Peripherals,
        Budget,
        Review


    }
}
