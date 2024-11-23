using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class PCBuild
    {

        #region Components
        public CPU cpu;
        public CPUCooler cpuCooler;
        public GPU gpu;
        public Motherboard motherboard;
        public Disc disc;
        public RAM ram;
        public PSU psu;

        public Keyboard keyboard;
        public Monitor monitor;
        public Mouse mouse;

        //Clears every component (probably not neccessary but i am scared to delete this)
        void ClearComponents()
        {
            cpu = null;
            cpuCooler = null;
            gpu = null;
            motherboard = null;
            disc = null;
            ram = null;
            psu = null;
            keyboard = null;
            monitor = null;
            mouse = null;
            notCompatibleMb = new List<Motherboard>();
        }

        #endregion
        List<Motherboard> notCompatibleMb = new List<Motherboard>();

        public bool intelCpu;
        public bool peripherals;
        public float? minimalBudget;
        public float? budget;
        public BuildType buildType;

        public double? budgetCpu;
        public double? budgetCpuCooler;
        public double? budgetGpu;
        public double? budgetMotherboard;
        public double? budgetDisc;
        public double? budgetRam;
        public double? budgetPsu;

        public double? budgetKeyboard;
        public double? budgetMonitor;
        public double? budgetMouse;

        #region PC Building variables



        #endregion



        public PCBuild() { }


        //Generates a PC build
        public string BuildPC(bool intel = true)
        {

            string response = "";
            ClearComponents();
            switch (buildType)
            {
                case BuildType.Universal:
                    UniversalBudget();
                    break;
                case BuildType.Graphics:
                    GraphicsBudget();
                    break;
                case BuildType.Gaming:
                    GamingBudget();
                    break;
                case BuildType.Work:
                    WorkBudget();
                    break;
                case BuildType.Student:
                    StudentBudget();
                    break;
            }

            if (budgetMotherboard > 0 && budgetMotherboard != null) SelectMotherboard(intel);

            if (budgetCpu > 0 && budgetCpu != null) SelectCPU();


            //Safeguard if app cannot find compatible motherboard with cpu
            if (motherboard == null || cpu == null) return "I cannot create a build from this parameters. :( Try again with different ones.";

            response += "\nMotherboard : " + motherboard.name + " Price :" + motherboard.price + "$";
            response += "\nCPU : " + cpu.name + " Price :" + cpu.price + "$";
            response += "\n\tCores :" + cpu.core_count + "  Core clock :" + cpu.core_clock + " GHz";
            if (cpu.boost_clock != null) response += "  Boost clock :" + cpu.boost_clock + " GHz";

            if (budgetCpuCooler > 0) SelectCPUCooler();
            if (cpuCooler != null) response += "\nCpu Cooler : " + cpuCooler.name + " Price :" + cpuCooler.price + "$";

            if (budgetGpu > 0) SelectGPU();
            if (gpu != null)
            {
                response += "\nGPU : " + gpu.chipset + " Price :" + gpu.price + "$";
                response += "\n\tMemory : " + gpu.memory + " GB";
                if (gpu.core_clock != null) response += "  Core clock :" + gpu.core_clock;
                if (gpu.boost_clock != null) response += "  Boost clock :" + gpu.boost_clock;
                if (gpu.length != null) response += "  Length :" + gpu.length + " cm";
            }
            else if(cpu.graphics!=null)
            {
                response += "\nGPU : (Integrated) " + cpu.graphics;
            }

            if (budgetRam > 0) SelectRAM();
            if (ram != null) response += "\nRAM : " + ram.name + " Price :" + ram.price + "$";

            if (budgetDisc > 0) SelectDisc();
            if (disc != null)
            {
                response += "\nDisc : " + disc.name + " Price :" + disc.price + "$";
                if (disc.capacity != null) response += "\n\tCapacity :" + disc.capacity + " GB";
            }

            if (budgetPsu > 0) SelectPSU();
            if (psu != null) response += "\nPSU : " + psu.name + " Price :" + psu.price + "$";

            if (budgetMonitor > 0) SelectMonitor();
            if (monitor != null)
            {
                response += "\nMonitor : " + monitor.name + " Price :" + monitor.price + "$";
                if (monitor.resolution != null) response += "\n\t Resolution :" + monitor.resolution[0] + "x" + monitor.resolution[1];
                if (monitor.refresh_rate != null) response += "  Refresh rate :" + monitor.refresh_rate+" hz";
            }
            if (budgetMouse > 0) SelectMouse();
            if (mouse != null) response += "\nMouse : " + mouse.name + " Price :" + mouse.price + "$";

            if (budgetKeyboard > 0) SelectKeyboard();
            if (keyboard != null) response += "\nKeyboard : " + keyboard.name + " Price :" + keyboard.price + "$";

            response += "\nTOTAL : " + TotalPrice() + "$";


            return response;
        }

        //Sums up a price
        double? TotalPrice()
        {
            float? value = 0;
            if (cpu != null) value += cpu.price;
            if (motherboard != null) value += motherboard.price;
            if (cpuCooler != null) value += cpuCooler.price;
            if (gpu != null) value += gpu.price;
            if (ram != null) value += ram.price;
            if (disc != null) value += disc.price;
            if (psu != null) value += psu.price;
            if (monitor != null) value += monitor.price;
            if (mouse != null) value += mouse.price;
            if (keyboard != null) value += keyboard.price;
            return Math.Round((double)value, 2);
        }

        
        bool SelectMotherboard(bool intel = true)
        {
            List<Motherboard> mBList = Program.motherboardList
                    .Where(mb => mb.price <= budgetMotherboard)
                    .OrderByDescending(mb => mb.price)
                    .ToList();

            //Safeguard if motherboard cannot find compatible cpu (example: CPU without integrated graphics for work/school pc's)
            if (notCompatibleMb.Count > 0)
            {
                foreach (Motherboard mb in notCompatibleMb)
                {
                    mBList.Remove(mb);
                }
            }
            if (mBList.Count == 0) return false;


            foreach (Motherboard mb in mBList)
            {
                if (intel)
                {
                    if (mb.socket.ToUpper().Contains("LGA"))//tu coś nie działa -> sprawdzić jak najszybciej
                    {
                        this.motherboard = mb;
                        return true;
                    }
                }
                else
                {
                    if (!mb.socket.Contains("LGA"))
                    {
                        this.motherboard = mb;
                        return true;
                    }
                }
            }
            return true;
        }
        void SelectCPU()
        {
            List<CPU> cpuList = Program.cpuList
                    .Where(cpu => cpu.price <= budgetCpu)
                    .OrderByDescending(cpu => cpu.price)
                    .ToList();
            while (cpu == null)
            {
                foreach (CPU cpu in cpuList)
                {
                    if (motherboard.socket == cpu.socket)
                    {
                        if ((buildType == BuildType.Work || buildType == BuildType.Student) && cpu.graphics != null)
                        {
                            this.cpu = cpu;
                            return;
                        }
                        else
                        {
                            this.cpu = cpu;
                            return;
                        }
                    }
                }
                if (cpu == null)
                {
                    notCompatibleMb.Add(motherboard);
                    if (!SelectMotherboard())
                    {
                        return;
                    }
                    SelectCPU();
                }
            }
        }
        void SelectGPU()
        {
            List<GPU> gpuList = Program.gpuList
                    .Where(gpu => gpu.price <= budgetGpu)
                    .OrderByDescending(gpu => gpu.price)
                    .ToList();

            gpuList.OrderByDescending(gpu => gpu.core_clock);
            List<GPU> gpuAbove8 = new List<GPU>();
            foreach (GPU gpu in gpuList)
            {
                if (gpu.memory > 8)
                {
                    gpuAbove8.Add(gpu);
                }
            }


            foreach (GPU gpu in gpuAbove8)
            {
                this.gpu = gpu;
                return;
            }

            foreach (GPU gpu in gpuList)
            {
                this.gpu = gpu;
                return;
            }

        }
        void SelectRAM()
        {
            //TO DO
            //FIX RAM SELECTING AS PER MODULE[0] (its ram amount)
            List<RAM> ramList = Program.ramList
                                .Where(ram => ram.price <= budgetRam)
                                .OrderByDescending(ram => ram.price)
                                .ToList();
            List<RAM> rejectedRAM = new List<RAM>();
            foreach (RAM ram in ramList)
            {
                if (ram.GetModulesAsList().FirstOrDefault() > motherboard.memory_slots)
                {
                    rejectedRAM.Add(ram);
                }
            }
            foreach (RAM ram in rejectedRAM)
            {
                ramList.Remove(ram);
            }

            ramList = ramList
                .OrderByDescending(ram => (int)ram.GetSpeedAsList().LastOrDefault()).ToList()
                .Take(10)
                .OrderByDescending(ram => (int)ram.GetModulesAsList().LastOrDefault())
                .ToList();



            foreach (RAM ram in ramList)
            {
                if (ram.GetModulesAsList().LastOrDefault() <= motherboard.max_memory)
                {
                    this.ram = ram;
                    return;
                }
            }
        }
        void SelectDisc()
        {
            List<Disc> discList = Program.discList
                                            .Where(disc => disc.price <= budgetDisc)
                                            .OrderByDescending(disc => disc.price)
                                            .ToList();

            discList.OrderByDescending(disc => disc.capacity);

            foreach (Disc disc in discList)
            {
                if (disc.type.Contains("SSD"))
                {
                    this.disc = disc;
                    return;
                }

            }
            if (disc == null)
            {
                foreach (Disc disc in discList)
                {
                    this.disc = disc;
                    return;
                }
            }
        }
        void SelectCPUCooler()
        {
            List<CPUCooler> cpuCList = Program.cpuCoolerList
                .Where(cpuC => cpuC.price <= budgetCpuCooler)
                .OrderByDescending(cpuC => cpuC.price)
                .ToList();

            cpuCList.OrderByDescending(cpuC => cpuC.price)
                .Take(10)
                .OrderByDescending(cpuC => cpuC.GetNoiseLevelAsList().LastOrDefault())
                .ToList();
            foreach (CPUCooler cpuC in cpuCList)
            {
                this.cpuCooler = cpuC;
                return;
            }

        }
        void SelectPSU()
        {
            List<PSU> psuList = Program.psuList
                                .Where(psu => psu.price <= budgetPsu)
                                .OrderByDescending(psu => psu.price)
                                .ToList();
            //TO DO
            //LICZYĆ 140 BAZOWO + 270 JEŚLI JEST GPU + WARTOŚĆ CPU I POMNOŻYĆ RAZY 1.3  
            int gpuWattage = 0;
            if (gpu != null) gpuWattage = 270;

            foreach (PSU psu in psuList)
            {
                if (psu.wattage >= (float)((140 + gpuWattage + cpu.tdp)) * 1.3)
                {
                    this.psu = psu;
                    return;
                }
            }
        }
        void SelectMonitor()
        {
            List<Monitor> monitorList = Program.monitorList
                .Where(monitor => monitor.price <= budgetMonitor)
                .OrderByDescending(monitor => monitor.price)
                .ToList();
            foreach (Monitor monitor in monitorList)
            {
                this.monitor = monitor;
                return;
            }
        }
        void SelectMouse()
        {
            List<Mouse> mouseList = Program.mouseList
                            .Where(mouse => mouse.price <= budgetMouse)
                            .OrderByDescending(mouse => mouse.price)
                            .ToList();
            foreach (Mouse mouse in mouseList)
            {
                this.mouse = mouse;
                return;
            }
        }
        void SelectKeyboard()
        {
            List<Keyboard> keyboardList = Program.keyboardList
                .Where(keyboard => keyboard.price <= budgetKeyboard)
                .OrderByDescending(keyboard => keyboard.price)
                .ToList();
            foreach (Keyboard keyboard in keyboardList)
            {
                this.keyboard = keyboard;
                return;
            }
        }
        #region Budget settings
        void UniversalBudget()
        {
            if (peripherals)
            {
                budgetMotherboard = this.budget * 0.09;
                budgetCpu = this.budget * 0.2;
                budgetGpu = this.budget * 0.22;
                budgetRam = this.budget * 0.08;
                budgetDisc = this.budget * 0.08;
                budgetCpuCooler = this.budget * 0.07;
                budgetPsu = this.budget * 0.1;
                budgetMonitor = this.budget * 0.13;
                budgetMouse = this.budget * 0.01;
                budgetKeyboard = this.budget * 0.02;
            }
            else
            {
                budgetMotherboard = this.budget * 0.09;
                budgetCpu = this.budget * 0.3;
                budgetGpu = this.budget * 0.28;
                budgetRam = this.budget * 0.08;
                budgetDisc = this.budget * 0.08;
                budgetCpuCooler = this.budget * 0.07;
                budgetPsu = this.budget * 0.1;
            }
        }
        void GraphicsBudget()
        {
            if (peripherals)
            {
                budgetMotherboard = this.budget * 0.08;
                budgetCpu = this.budget * 0.18;
                budgetGpu = this.budget * 0.24;
                budgetRam = this.budget * 0.10;
                budgetDisc = this.budget * 0.08;
                budgetCpuCooler = this.budget * 0.05;
                budgetPsu = this.budget * 0.8;
                budgetMonitor = this.budget * 0.16;
                budgetMouse = this.budget * 0.01;
                budgetKeyboard = this.budget * 0.02;
            }
            else
            {
                budgetMotherboard = this.budget * 0.10;
                budgetCpu = this.budget * 0.28;
                budgetGpu = this.budget * 0.31;
                budgetRam = this.budget * 0.10;
                budgetDisc = this.budget * 0.08;
                budgetCpuCooler = this.budget * 0.05;
                budgetPsu = this.budget * 0.8;
            }
        }
        void GamingBudget()
        {
            if (peripherals)
            {
                budgetMotherboard = this.budget * 0.10;
                budgetCpu = this.budget * 0.18;
                budgetGpu = this.budget * 0.27;
                budgetRam = this.budget * 0.08;
                budgetDisc = this.budget * 0.06;
                budgetCpuCooler = this.budget * 0.05;
                budgetPsu = this.budget * 0.1;
                budgetMonitor = this.budget * 0.13;
                budgetMouse = this.budget * 0.01;
                budgetKeyboard = this.budget * 0.02;
            }
            else
            {
                budgetMotherboard = this.budget * 0.1;
                budgetCpu = this.budget * 0.23;
                budgetGpu = this.budget * 0.38;
                budgetRam = this.budget * 0.08;
                budgetDisc = this.budget * 0.06;
                budgetCpuCooler = this.budget * 0.05;
                budgetPsu = this.budget * 0.1;
            }
        }
        void WorkBudget()
        {
            if (peripherals)
            {
                budgetMotherboard = this.budget * 0.12;
                budgetCpu = this.budget * 0.3;
                budgetGpu = 0;
                budgetRam = this.budget * 0.10;
                budgetDisc = this.budget * 0.10;
                budgetCpuCooler = this.budget * 0.07;
                budgetPsu = this.budget * 0.08;
                budgetMonitor = this.budget * 0.17;
                budgetMouse = this.budget * 0.02;
                budgetKeyboard = this.budget * 0.04;
            }
            else
            {
                budgetMotherboard = this.budget * 0.11;
                budgetCpu = this.budget * 0.45;
                budgetGpu = 0;
                budgetRam = this.budget * 0.12;
                budgetDisc = this.budget * 0.12;
                budgetCpuCooler = this.budget * 0.10;
                budgetPsu = this.budget * 0.1;
            }
        }
        void StudentBudget()
        {
            if (peripherals)
            {
                budgetMotherboard = this.budget * 0.13;
                budgetCpu = this.budget * 0.35;
                budgetGpu = 0;
                budgetRam = this.budget * 0.10;
                budgetDisc = this.budget * 0.12;
                budgetCpuCooler = this.budget * 0.07;
                budgetPsu = this.budget * 0.08;
                budgetMonitor = this.budget * 0.12;
                budgetMouse = this.budget * 0.01;
                budgetKeyboard = this.budget * 0.02;
            }
            else
            {
                budgetMotherboard = this.budget * 0.14;
                budgetCpu = this.budget * 0.49;
                budgetGpu = 0;
                budgetRam = this.budget * 0.1;
                budgetDisc = this.budget * 0.12;
                budgetCpuCooler = this.budget * 0.07;
                budgetPsu = this.budget * 0.08;
            }
        }

        #endregion
    }

    public enum BuildType
    {
        Gaming,
        Graphics,
        Universal,
        Work,
        Student
    }

}
