namespace Day2
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            var parser = new intCodeParser();
            parser.RunDay1("..\\..\\..\\..\\Day2\\input.txt");          
            parser.RunDay2("..\\..\\..\\..\\Day2\\input.txt");
        }
    }
}