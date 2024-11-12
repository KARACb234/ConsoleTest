using ConsoleTest.JsonData;
using ConsoleTest;
using Newtonsoft.Json;

namespace Tester
{
    class GenerateTests
    {
        private readonly TestLoader _testLoader;
        private readonly CollectionOfTests _collectionOfTests;
        public GenerateTests(CollectionOfTests collectionOfTests)
        {
            
            _testLoader = new TestLoader();
            _collectionOfTests = collectionOfTests;
        }
        public async Task LoadTests()
        {
            string testJson = await _testLoader.LoadTestFromServer();
            var testData = JsonConvert.DeserializeObject<QuizData>(testJson);
            foreach (var item in testData.tests)
            {
                Question[] questions = new Question[item.questions.Length];
                for(int i = 0; i < item.questions.Length; i++)
                {
                    string questionText = item.questions[i].question;
                    string[] correctAnswers = item.questions[i].correct_answers;
                    string[] options = item.questions[i].options;
                    int points = item.questions[i].points;
                    Question question = new Question(questionText, options, correctAnswers, points);
                    questions[i] = question;
                }
                Test newTest = new Test(item.theme, item.description, questions);
                _collectionOfTests.AddTest(newTest);

            }

        }

        public void GetGenersteCollction()
        {

        }
    }
}
