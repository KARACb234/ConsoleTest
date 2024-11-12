

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialization();
        }
        public static void Initialization()
        {
            Quiz quiz = new Quiz();
            quiz.ShowTests().Wait();
        }
    }
}
