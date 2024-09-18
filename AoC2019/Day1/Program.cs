namespace Day1
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            var parser = new ModuleParser();
            parser.RunDay1("..\\..\\..\\..\\Day1\\input.txt");
            parser.RunDay2("..\\..\\..\\..\\Day1\\input.txt");
        }
    }
}