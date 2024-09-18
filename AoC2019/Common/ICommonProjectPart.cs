namespace AdventOfCode
{
    public abstract class ICommonProjectPart()
    {
        public abstract void RunDay1(string filename);

        public abstract void RunDay2(string filename);

        public List<string> ReadFile(string fileName)
        {
            return File.ReadLines(fileName).ToList<string>();
        }

        public List<T> SplitString<T>(string input, Func<string, T> converter)
        {
            return input.Split(',')
                        .Select(converter)
                        .ToList();
        }
    }
}