using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Module
    {
        public int mass;
        public int pt2fuelcost;
        public int fuelcost;

        public Module(decimal inputmass)
        {
            mass = (int)inputmass;
            fuelcost = fuelCostEquation(inputmass);
            pt2fuelcost = fuelCostEquation2(inputmass,0);
        }

        private int fuelCostEquation(decimal inputmass)
        {
            return (int)Math.Floor(inputmass / 3) - 2;
        }

        private int fuelCostEquation2(decimal inputmass, decimal totalfuel)
        {
            var cost = fuelCostEquation(inputmass);

            if (cost <= 0)
            {
                return (int)totalfuel;
            }
            totalfuel += cost;
            return fuelCostEquation2(cost, totalfuel);
        }
    }

    internal class ModuleParser
    {
        public void RunDay1(string filename)
        {
            List<Module> modules = CreateModules(ReadFile(filename));
            int totalfuel = modules.Sum(i => i.fuelcost);
            Console.WriteLine($"Day 1 : {totalfuel} ");
        }

        public void RunDay2(string filename)
        {
            List<Module> modules = CreateModules(ReadFile(filename));
            int totalfuel = modules.Sum(i => i.pt2fuelcost);
            Console.WriteLine($"Day 2 : {totalfuel} ");
        }

        private List<string> ReadFile(string fileName)
        {
            return File.ReadLines(fileName).ToList<string>();
        }

        private List<Module> CreateModules(List<string> strings)
        {
            var modules = new List<Module>();
            foreach (string line in strings)
            {
                var dec = Convert.ToDecimal(line);
                modules.Add(new Module(dec));
            }
            return modules;
        }
    }
}
