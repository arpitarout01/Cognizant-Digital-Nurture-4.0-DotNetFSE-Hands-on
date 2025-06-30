namespace CalcLibrary.Tests
{
    public class Tests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        [TestCase(5, 3, 8)]
        [TestCase(0, 0, 0)]
        [TestCase(-2, 2, 0)]
        public void Add_WhenCalled_ReturnsSum(int a, int b, int expectedResult)
        {
            int result = _calculator.Add(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
