
namespace Tester
{
    class Question
    {
        private string question;
        public string GetQuestion => question;
        private string[] answers;
        public string[] GetAnswers => answers;
        private string[] trueAnswers;
        public string[] TrueAnswers => trueAnswers;
        private int score;
        public int GetScore => score;
        

        public Question(string question, string[] answers, string[] trueAnswers, int score)
        {
            this.question = question;
            this.answers = answers;
            this.trueAnswers = trueAnswers;
            this.score = score;
        }

    }
}
