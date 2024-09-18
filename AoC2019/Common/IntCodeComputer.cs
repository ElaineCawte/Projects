using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace AdventOfCode
{
    public class intCodeComputer
    {
        private List<int> memory;
        private int instructionPointer;

        public intCodeComputer()
        {
            memory = new List<int>();
        }

        public int GetCode()
        {
            return memory[0];
        }

        private bool isHalt()
        {
            if (memory[instructionPointer] == 99) { return true; }
            else { return false; }
        }

        public void loadMemory(List<int> values)
        {
            memory.Clear();

            foreach (var item in values)
            {
                memory.Add(item);
            }

            instructionPointer = 0;
        }

        public void processValues()
        {
            //if no halt, process the instruction
            while (isHalt() != true)
            { 
                ProcessInstructions();
            }
        }
        private void ProcessInstructions()
        {
            var opcode = memory[instructionPointer];
            var noun = memory[memory[instructionPointer + 1]];
            var verb = memory[memory[instructionPointer + 2]];
            var location = memory[instructionPointer + 3];

            if (opcode == 1)
            {
              //  Console.WriteLine($"changed location {location} to {noun + verb}");
                memory[location] = noun + verb;
            }

            if (opcode == 2)
            {
               // Console.WriteLine($"changed location {location} to {noun * verb}");
                memory[location] = noun * verb;
            }
            instructionPointer = instructionPointer + 4;
        }
    }
}
