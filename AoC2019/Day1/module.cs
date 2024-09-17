using AdventOfCode;

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

    internal class ModuleParser : ICommonProjectPart
    {
        public override void RunDay1(string filename)
        {
            List<Module> modules = CreateModules(ReadFile(filename));
            int totalfuel = modules.Sum(i => i.fuelcost);
            Console.WriteLine($"Day 1 : {totalfuel} ");
        }

        public override void RunDay2(string filename)
        {
            List<Module> modules = CreateModules(ReadFile(filename));
            int totalfuel = modules.Sum(i => i.pt2fuelcost);
            Console.WriteLine($"Day 2 : {totalfuel} ");
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
