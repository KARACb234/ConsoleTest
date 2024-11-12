using ConsoleTest;
using Tools;
using Newtonsoft.Json;
using ConsoleTest.JsonData;

namespace Tester
{
    class Quiz
    {
        private CollectionOfTests collectionOfTests;
        private GenerateTests generateTests;
        private AnswerChecker answerChecker;
        private int curentQuestionIndex;


        public Quiz()
        {
            answerChecker = new AnswerChecker();
            collectionOfTests = new CollectionOfTests();
            generateTests = new GenerateTests(collectionOfTests);
        }
        public async Task ShowTests()
        {
            await generateTests.LoadTests();
            LineHelper.ClassicWriteLine("Введите номера тестов с какого по какой хотите увидеть", true, true);
            string fromInput = LineHelper.TryReadLine();
            int from = LineHelper.TryReadLineParseToInt(fromInput);
            string toInput = LineHelper.TryReadLine();
            int to = LineHelper.TryReadLineParseToInt(toInput);
            from--;
            if (from > to)
            {
                LineHelper.ClassicWriteLine("Ошибка, некорректный ввод");
                return;
            }
            LineHelper.ClassicWriteLine("Список доступных тестов: ", true);
            Test[] tests = collectionOfTests.GetTests(from, to);
            for (int i = 0; i < tests.Length; i++)
            {
                LineHelper.ClassicWriteLine($"{i + 1}. {tests[i].GetTitle}");
            }
            LineHelper.ClassicWriteLine("Введите тест который хотите пройти: ", true);
            int selectedId = LineHelper.TryReadLineParseToInt(LineHelper.TryReadLine());
            ShowSelectedTest(selectedId - 1);
        }
        public void ShowNextQuestion(Question question)
        {
            LineHelper.ClassicWriteLine(question.GetQuestion, true);
            string[] answers = question.GetAnswers;
            Random random = new Random();
            for (int i = answers.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                string temp = answers[i];
                answers[i] = answers[j];
                answers[j] = temp;
            }
            for (int i = 0; i < answers.Length; i++)
            {
                LineHelper.ClassicWriteLine($"{i + 1}. {answers[i]}");
            }
            LineHelper.ClassicWriteLine("Введите ответ: ");


        }
        public void ShowResult(Question[] questions)
        {
            int result = answerChecker.GetResult();
            int summaryScore = 0;
            foreach (Question question in questions)
            {
                summaryScore += question.GetScore;
            }
            LineHelper.ClassicWriteLine($"Вы набрали {result} из {summaryScore}",bottomSplitter:true);
            
            
        }
        public void ShowSelectedTest(int testId)
        {
            Console.Clear();
            Test curentTest = collectionOfTests.GetTest(testId);

            for (int i = 0; i < curentTest.GetQuestions.Length; i++)
            {
                ShowNextQuestion(curentTest.GetQuestions[i]);
                WaitUserAnswer(curentTest.GetQuestions[i]);
            }
            ShowResult(curentTest.GetQuestions);
        }
        public void WaitUserAnswer(Question question)
        {

            string userInput = LineHelper.TryReadLine(); ;
            string[] userAnswerID = userInput.Split(',');
            answerChecker.Check(userAnswerID, question);
        }
    }
}
