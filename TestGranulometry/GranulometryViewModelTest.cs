
//using Granulometry.Models;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace TestGranulometry
//{
//    [TestClass]
//    public class GranulometryTest
//    {
//        [TestMethod]
//        public void TestCalculateX50()
//        {
//            // Arrange
//            GranulometryModel model = new GranulometryModel()
//            {
//                A = 2,
//                K = 0.5,
//                Q = 100,
//                RWS = 150
//            };
//            double expectedX50 = 4.49864630041377;

//            // Act
//            double actualX50 = model.CalculateX50();

//            // Assert
//            Assert.AreEqual(expectedX50, actualX50, 0.0001);
//        }

//        [TestMethod]
//        public void TestCalculateXmax()
//        {
//            // Arrange
//            GranulometryModel model = new GranulometryModel()
//            {
//                B = 20,
//                S = 10
//            };
//            double expectedXmax = 15;

//            // Act
//            double actualXmax = model.CalculateXmax();

//            // Assert
//            Assert.AreEqual(expectedXmax, actualXmax);
//        }
//    }
//}