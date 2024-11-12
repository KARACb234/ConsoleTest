using Newtonsoft.Json;
using ConsoleTest.JsonData;

namespace Tester
{
    class Test
    {
        private string title;
        public  string GetTitle => title;
        private string description;
        public string GetDescription => description;
        private Question[] questions;
        public Question[] GetQuestions => questions;

        public Test(string title, string description, Question[] questions)
        {
            this.title = title;
            this.description = description;
            this.questions = questions;
        }
    }
}
