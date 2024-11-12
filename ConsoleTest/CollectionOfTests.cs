
namespace Tester
{
    class CollectionOfTests
    {
        private List<Test> tests = new List<Test>();
        public Test[] GetTests(int from, int to)
        {
            int fromClamp = Math.Clamp(from, 0, to);
            int toClamp = Math.Clamp(to, from, tests.Count);
            int testCount = toClamp - fromClamp;
            Test[] result = new Test[testCount];
            int iterationCount = 0;
            for(int i = fromClamp; i < toClamp; i++)
            {
                result[iterationCount] = tests[i];
                iterationCount++;
            }
            return result;
        }
        public Test GetTest(int questionIndex)
        {
            var test = tests[questionIndex];
            return test;
        }

        public void AddTest(Test test)
        {
            tests.Add(test);
        }
        public void DeleteTest(Test test)
        {

        }
    }
}
