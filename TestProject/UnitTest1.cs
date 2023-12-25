using Calc.Model;

namespace TestProject
{
    public class Tests
    {
        CalcModel model;
        //�����, ������������� �� ������ ����� ������ ����� ����������� ������ �����
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Console.WriteLine("After all test exec");
        }

        // �����, ������������� ����� ������ ������
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("First exec");
            model = new CalcModel();

        }

        // �����, ������������� ����� ������� �����
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