namespace Tools
{
    public static class LineHelper
    {
        public const string SPLITTER = "---------------------------------------------------";
        public static int TryReadLineParseToInt(string input)
        {
            if (int.TryParse(input, out int result) == false)
            {
                throw new Exception("Ошибка, некорректный ввод");
            }
            return result;
        }

        public static string TryReadLine()
        {
            string input = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Ошибка, введена пустая строка");
            }
            return input;
        }
        public static string ReadArray(string[] array)
        {
            string resoult = "";
            foreach (string line in array)
            {
                resoult += line + ", ";
            }
            return resoult;
        }
        public static void ClassicWriteLine(string text, bool upperSplitter = false, bool bottomSplitter = false)
        {
            if (upperSplitter == true) Console.WriteLine(SPLITTER);
            Console.WriteLine(text);
            if (bottomSplitter == true) Console.WriteLine(SPLITTER);
        }
    }
}
