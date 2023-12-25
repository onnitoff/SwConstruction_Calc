using Calc.Model;

namespace TestProject
{
    public class Tests
    {
        CalcModel model;
        //ћетод, выполн€ющийс€ на уровне всего класса перед выполнением любого теста
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Console.WriteLine("After all test exec");
        }

        // ћетод, выполн€ющийс€ перед каждым тестом
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("First exec");
            model = new CalcModel();

        }

        // ћетод, выполн€ющийс€ после каждого теста
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Last exec");
        }

        

        [Test]
        public void Send_10and10andMultiply_100returned()
        {
            //arrange
            double x = 10;
            double y = 10;
            string str = "*";
            double expected = 100;

            //act
            
            double actual = model.PerformOperation(x, y, str);
            //assert
            Console.WriteLine("Some test");
            Assert.AreEqual(expected, actual);
        }
    }
}