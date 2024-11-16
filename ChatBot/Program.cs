using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;

namespace ChatBot
{
    internal class Program
    {
        static string input = "";
        static readonly Random rng = new Random();

        #region Lists of components
        static List<CPU> processorList = new List<CPU>();
        static List<GPU> gpuList = new List<GPU>();
        static List<CPUCooler> cpuCoolerList = new List<CPUCooler>();
        static List<Disc> discList = new List<Disc>();
        static List<Keyboard> keyboardList = new List<Keyboard>();
        static List<Monitor> monitorList = new List<Monitor>();
        static List<Motherboard> motherboardList = new List<Motherboard>();
        static List<PSU> psuList = new List<PSU>();
        static List<RAM> ramList = new List<RAM>();
        static List<Mouse> mouseList = new List<Mouse>();
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

        //Default responses
        static public List<KR> kr = new List<KR>();

        #region PC building responses
        static BuildPhase bP = BuildPhase.None;
        static public List<KR> bPNone = new List<KR>();
        static public List<KR> bPType = new List<KR>();
        static public List<KR> bPPeripherals = new List<KR>();
        static public List<KR> bPBudget = new List<KR>();
        static public List<KR> bPReview = new List<KR>();

        #endregion
        static void Main(string[] args)
        {
            LoadDataBase();
            ChatManager();

        }

        static void ChatManager()
        {
            GenerateKeywordResponse();

            Console.WriteLine("Amiga : Welcome to Amiga! How can i help you?");

            while (!Keywords.goodbye.Contains(input))
            {
                Console.Write("\nUser : ");
                input = Console.ReadLine();
                Console.Write("\nAmiga : " + ManageResponse(input)+"\n");
            }
            Thread.Sleep(1500);
        }

        static string ManageResponse(string input)
        {
            string response = "";
            switch (bP)
            {
                //
                //0. Nic
                //1. Typ builda
                //2. Peryferia
                //3. Ile kasy

                case BuildPhase.None:
                    response = BuildPhaseNoneKR();
                    if (response != "") return response;
                    break;
                case BuildPhase.Type:
                    response = BuildPhaseTypeKR();
                    if (response != "") return response;
                    break;
                case BuildPhase.Peripherals:
                    response = BuildPhasePeripheralsKR();
                    if (response != "") return response;
                    break;
                case BuildPhase.Budget:
                    response = BuildPhaseBudgetKR();
                    if (response != "") return response;
                    break;
                case BuildPhase.Review:
                    response = BuildPhaseReviewKR();
                    if (response != "") return response;
                    break;

            }

            foreach (KR item in kr)
            {
                foreach (string keyword in item.keywords)
                {
                    if (input.Contains(keyword))
                    {
                        response = item.response[rng.Next(0, item.response.Count - 1)];
                        return response;
                    }
                }
            }

            return Responses.defaultResponse[rng.Next(0, Responses.defaultResponse.Count - 1)];
        }


        #region Applying keyword-response data
        static void GenerateKeywordResponse()
        {
            kr.Add(new KR(Keywords.greetings, Responses.greetings));
            kr.Add(new KR(Keywords.weather, Responses.weather));
            kr.Add(new KR(Keywords.joke, Responses.joke));
            kr.Add(new KR(Keywords.goodbye, Responses.goodbye));


            #region PC building KR
            bPNone.Add(new KR(Keywords.bPNone, Responses.bPNone));
            bPBudget.Add(new KR(Keywords.bPBudget, Responses.bPBudget));
            bPPeripherals.Add(new KR(Keywords.bPPeripherals, Responses.bPPeripherals));
            bPType.Add(new KR(Keywords.bPType, Responses.bPType));
            bPReview.Add(new KR(Keywords.bPReview, Responses.bPReview));
            #endregion
        }
        static string BuildPhaseNoneKR()
        {
            foreach (KR item in bPNone)
            {
                foreach (string keyword in item.keywords)
                {
                    if (input.Contains(keyword))
                    {
                        return item.response[rng.Next(0, item.response.Count - 1)];

                    }
                }
            }
            return "";
        }
        static string BuildPhaseTypeKR()
        {
            foreach (KR item in bPNone)
            {
                foreach (string keyword in item.keywords)
                {
                    if (input.Contains(keyword))
                    {
                        return item.response[rng.Next(0, item.response.Count - 1)];

                    }
                }
            }
            return "";
        }
        static string BuildPhasePeripheralsKR()
        {
            foreach (KR item in bPNone)
            {
                foreach (string keyword in item.keywords)
                {
                    if (input.Contains(keyword))
                    {
                        return item.response[rng.Next(0, item.response.Count - 1)];

                    }
                }
            }
            return "";
        }
        static string BuildPhaseBudgetKR()
        {
            foreach (KR item in bPNone)
            {
                foreach (string keyword in item.keywords)
                {
                    if (input.Contains(keyword))
                    {
                        return item.response[rng.Next(0, item.response.Count - 1)];

                    }
                }
            }
            return "";
        }
        static string BuildPhaseReviewKR()
        {
            foreach (KR item in bPNone)
            {
                foreach (string keyword in item.keywords)
                {
                    if (input.Contains(keyword))
                    {
                        return item.response[rng.Next(0, item.response.Count - 1)];
                    }
                }
            }
            return "";
        }


        #endregion
        #region Saving and loading data from component's JSON
        static void LoadDataBase()
        {
            int pause = 100;
            //try
            //{
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include // Uwzględnij wartości null
            };
            int loadingDataBaseProgress = 0; int totalDataBaseProgress = 10;

            Console.WriteLine("Loading database "+loadingDataBaseProgress+"/"+totalDataBaseProgress);
            Thread.Sleep(pause);
            
            

            string jsonString = File.ReadAllText(processorPath);
            processorList = JsonConvert.DeserializeObject<List<CPU>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database " + loadingDataBaseProgress + "/" + totalDataBaseProgress);
            Thread.Sleep(pause);
            


            jsonString = File.ReadAllText(gpuPath);
            gpuList = JsonConvert.DeserializeObject<List<GPU>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database "+loadingDataBaseProgress+"/"+totalDataBaseProgress);
            Thread.Sleep(pause);
            


            jsonString = File.ReadAllText(cpuCoolerPath);
            cpuCoolerList = JsonConvert.DeserializeObject<List<CPUCooler>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database "+loadingDataBaseProgress+"/"+totalDataBaseProgress);
            Thread.Sleep(pause);
            


            jsonString = File.ReadAllText(discPath);
            discList = JsonConvert.DeserializeObject<List<Disc>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database "+loadingDataBaseProgress+"/"+totalDataBaseProgress);
            Thread.Sleep(pause);
            


            jsonString = File.ReadAllText(keyboardPath);
            keyboardList = JsonConvert.DeserializeObject<List<Keyboard>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database "+loadingDataBaseProgress+"/"+totalDataBaseProgress);
            Thread.Sleep(pause);
            


            jsonString = File.ReadAllText(monitorPath);
            monitorList = JsonConvert.DeserializeObject<List<Monitor>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database "+loadingDataBaseProgress+"/"+totalDataBaseProgress);
            Thread.Sleep(pause);
            


            jsonString = File.ReadAllText(motherboardPath);
            motherboardList = JsonConvert.DeserializeObject<List<Motherboard>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database "+loadingDataBaseProgress+"/"+totalDataBaseProgress);
            Thread.Sleep(pause);
            


            jsonString = File.ReadAllText(psuPath);
            psuList = JsonConvert.DeserializeObject<List<PSU>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database "+loadingDataBaseProgress+"/"+totalDataBaseProgress);
            Thread.Sleep(pause);
            


            jsonString = File.ReadAllText(ramPath);
            ramList = JsonConvert.DeserializeObject<List<RAM>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Loading database "+loadingDataBaseProgress+"/"+totalDataBaseProgress);
            Thread.Sleep(pause);
            


            jsonString = File.ReadAllText(mousePath);
            mouseList = JsonConvert.DeserializeObject<List<Mouse>>(jsonString, settings);

            loadingDataBaseProgress++;
            Console.Clear();
            Console.WriteLine("Database loaded "+loadingDataBaseProgress+"/"+totalDataBaseProgress+"\n\n");
            Thread.Sleep(pause*5);
            Console.Clear();
            //}
            //catch
            //{

            //}
        }
        static void SaveJson(string path)
        {
            string jsonString = JsonConvert.SerializeObject(processorList);

            File.WriteAllText(processorPath, jsonString);
        }
        #endregion
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
