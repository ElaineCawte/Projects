using AdventOfCode;
using System.Collections.Generic;

namespace Day2
{
    internal class intCodeParser : ICommonProjectPart
    {

        public override void RunDay1(string filename)
        {
            List<int> list = SplitString<int>(ReadFile(filename).First(), int.Parse);
            var computer = new intCodeComputer();
            computer.loadMemory(list);
            computer.processValues();
            Console.WriteLine("The Answer is " + computer.GetCode());

        }

        public override void RunDay2(string filename)
        {
            List<int> list = SplitString<int>(ReadFile(filename).First(), int.Parse);
            createScenarios(list);
        }

        public void createScenarios(List<int> list)
        {
            for (int i = 1; i <= 99; i++)
            {
                list[1] = i;
                for (int x = 1; x <= 99; x++)
                {
                    list[2] = x;
                    runScenario(list, i, x);
                }

            }    
        }

        private void runScenario(List<int> list, int x, int y)
        {
            var computer = new intCodeComputer();
        //    Console.WriteLine($"noun = {x} verb = {y}");
            computer.loadMemory(list);
            computer.processValues();

            //Console.WriteLine(computer.GetCode());

            if (computer.GetCode() == 19690720)
            {
                Console.WriteLine($"noun = {x} verb = {y}");
                Console.WriteLine(100 * x + y);
                return;
            }
        }
    }
}
