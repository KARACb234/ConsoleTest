using Tools;

namespace Tester
{
    class AnswerChecker
    {
        private int count;

        public bool Check(string[] userAnswerID, Question question)
        {
            int trueCount = 0;
            for (int i = 0; i < userAnswerID.Length; i++)
            {
                int userAnsver = LineHelper.TryReadLineParseToInt(userAnswerID[i]) - 1;
                foreach (string trueAnswer in question.TrueAnswers)
                {
                    if (trueAnswer == question.GetAnswers[userAnsver])
                    {
                        trueCount++;
                    }
                }
            }
            if (trueCount > 0)
            {
                int summaryCount = question.GetScore;
                if (trueCount != question.TrueAnswers.Length)
                {
                    summaryCount /= 2;
                    Console.WriteLine($"Некоторые ответы неверны. Вот правильные ответы: {LineHelper.ReadArray(question.TrueAnswers)}");
                }
                else
                {
                    Console.WriteLine("Ответ верный.");
                    AddCount(summaryCount);
                }
                return true;
            }
            Console.WriteLine($"Все ответы неверны. Вот правильные ответы: {LineHelper.ReadArray(question.TrueAnswers)}");
            return false;

        }

        private void AddCount(int score)
        {
            count += score;
        }

        public int GetResult()
        {
            return count;
        }
    }
}
