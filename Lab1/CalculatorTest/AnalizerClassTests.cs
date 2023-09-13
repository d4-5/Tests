using AnalaizerClassLibrary;
using ErrorLibrary;

namespace AnalaizerClassTests
{
    [TestClass]
    public class AnalaizerClassTests
    {
        [TestMethod]
        public void Format_ValidExpression_NoError()
        {
            // Arrange
            AnalaizerClass.expression = "2 + 3 * (4 - 1)";

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("2+3*(4-1)", result);
        }

        [TestMethod]
        public void Format_EmptyExpression_NoError()
        {
            // Arrange
            AnalaizerClass.expression = "";

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void Format_ExpressionTooLong_ERROR07()
        {
            // Arrange
            AnalaizerClass.expression = new string('1', 65537);

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("&" + ErrorsExpression.ERROR_07, result);
        }

        [TestMethod]
        public void Format_UnknownCharacter_ERROR02()
        {
            // Arrange
            AnalaizerClass.expression = "2+3+a";

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("&" + ErrorsExpression.GetFullStringError(ErrorsExpression.ERROR_02, 4), result);
        }

        [DataTestMethod]
        [DataRow("(2+3-4-1)", "(2+3-4-1)")]
        [DataRow("m2+3-(4-1)", "m2+3-(4-1)")]
        [DataRow("p2+3-(4-1)", "p2+3-(4-1)")]
        public void Format_ValidStartSymbol_NoError(string inputExpression, string expectedResult)
        {
            // Arrange
            AnalaizerClass.expression = inputExpression;

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Format_InvalidStartSymbol_ERROR03()
        {
            // Arrange
            AnalaizerClass.expression = "/2+3";

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("&" + ErrorsExpression.ERROR_03, result);
        }

        [DataTestMethod]
        [DataRow("2(+2", 1)]
        [DataRow("2+2m+2", 3)]
        [DataRow("2+2p+2", 3)]
        public void Format_InvalidSymbolAfterDigit_ERROR01(string inputExpression, int position)
        {
            // Arrange
            AnalaizerClass.expression = inputExpression;

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("&" + ErrorsExpression.GetFullStringError(ErrorsExpression.ERROR_01, position), result);
        }

        [TestMethod]
        public void Format_DobleOperator_ERROR04()
        {
            // Arrange
            AnalaizerClass.expression = "2++3";

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("&" + ErrorsExpression.GetFullStringError(ErrorsExpression.ERROR_04, 2), result);
        }

        [TestMethod]
        public void Format_InvalidSymbolAfterOperator_ERROR03()
        {
            // Arrange
            AnalaizerClass.expression = "2+)3";

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("&" + ErrorsExpression.ERROR_03, result);
        }

        [DataTestMethod]
        [DataRow("2+(+2")]
        [DataRow("2+(-2")]
        [DataRow("2+(*2")]
        [DataRow("2+(/2")]
        [DataRow("2+(%2")]
        [DataRow("2+()2")]
        public void Format_InvalidSymbolAfterOpenBracket_ERROR03(string expression)
        {
            // Arrange
            AnalaizerClass.expression = expression;

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("&" + ErrorsExpression.ERROR_03, result);
        }

        [DataTestMethod]
        [DataRow("2+(2+2)(+2")]
        [DataRow("2+(2+2)m+2")]
        [DataRow("2+(2+2)p+2")]
        [DataRow("2+(2+2)2+2")]
        public void Format_InvalidSymbolAfterCloseBracket_ERROR03(string expression)
        {
            // Arrange
            AnalaizerClass.expression = expression;

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("&" + ErrorsExpression.ERROR_03, result);
        }

        [DataTestMethod]
        [DataRow("m)2")]
        [DataRow("mm2")]
        [DataRow("mp2")]
        [DataRow("m+2")]
        [DataRow("m-2")]
        [DataRow("m/2")]
        [DataRow("m*2")]
        [DataRow("m%2")]
        public void Format_InvalidSymbolAfterUnaryOperator_ERROR03(string expression)
        {
            // Arrange
            AnalaizerClass.expression = expression;

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("&" + ErrorsExpression.ERROR_03, result);
        }

        [TestMethod]
        public void Format_UnaryOperatorAtTheEndOfExpression_ERROR05()
        {
            // Arrange
            AnalaizerClass.expression = "2+3m";

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("&" + ErrorsExpression.ERROR_05, result);
        }
    }
}

/*
using AnalaizerClassLibrary;
using ErrorLibrary;

namespace AnalaizerClassTests
{
    [TestClass]
    public class AnalaizerClassTests
    {
        [DataTestMethod]
        [DataRow("2+3+a", ErrorsExpression.ERROR_02,4)]
        [DataRow("/2+3", ErrorsExpression.ERROR_03, -1)]
        [DataRow("2(+2", ErrorsExpression.ERROR_01, 1)]
        [DataRow("2+2m+2", ErrorsExpression.ERROR_01, 3)]
        [DataRow("2+2p+2", ErrorsExpression.ERROR_01, 3)]
        [DataRow("2++3", ErrorsExpression.ERROR_04, 2)]
        [DataRow("2+)3", ErrorsExpression.ERROR_03, -1)]
        [DataRow("2+(+2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("2+(-2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("2+(*2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("2+(/2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("2+(%2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("2+()2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("2+(2+2)(+2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("2+(2+2)m+2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("2+(2+2)p+2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("2+(2+2)2+2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("m)2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("mm2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("mp2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("m+2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("m-2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("m/2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("m*2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("m%2", ErrorsExpression.ERROR_03, -1)]
        [DataRow("2+3m", ErrorsExpression.ERROR_05, -1)]
        public void Format_InvalidExpression_Error(string inputExpression, string expectedError, int position)
        {
            // Arrange
            AnalaizerClass.expression = inputExpression;

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            if(position == -1)
            {
                Assert.AreEqual("&" + expectedError, result);
            }
            else
            {
                Assert.AreEqual("&" + ErrorsExpression.GetFullStringError(expectedError, position), result); 
            }
        }
        [TestMethod]
        public void Format_ValidExpression_NoError()
        {
            // Arrange
            AnalaizerClass.expression = "2 + 3 * (4 - 1)";

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("2+3*(4-1)", result);
        }

        [TestMethod]
        public void Format_EmptyExpression_NoError()
        {
            // Arrange
            AnalaizerClass.expression = "";

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void Format_ExpressionTooLong_ERROR07()
        {
            // Arrange
            AnalaizerClass.expression = new string('1', 65537);

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual("&" + ErrorsExpression.ERROR_07, result);
        }
        
        [DataTestMethod]
        [DataRow("(2+3-4-1)", "(2+3-4-1)")]
        [DataRow("m2+3-(4-1)", "m2+3-(4-1)")]
        [DataRow("p2+3-(4-1)", "p2+3-(4-1)")]
        public void Format_ValidStartSymbol_NoError(string inputExpression, string expectedResult)
        {
            // Arrange
            AnalaizerClass.expression = inputExpression;

            // Act
            string result = AnalaizerClass.Format();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
*/