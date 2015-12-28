
namespace UnitTests {
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TupleTests {
        [TestMethod]
        public void Should_TupleHoldStringAndInteger_ReturnTrue() {
            // Arrange
            var t = new Tuple<int, string>(123, "test");
            
            // Act
            
            // Assert
            Assert.IsInstanceOfType(t.Item1, typeof(Int32));
            Assert.IsInstanceOfType(t.Item2, typeof(string));
        }

        [TestMethod]
        public void Should_CompareTupleByValue_ReturnFalse() {
            // Arrange
            var t = Tuple.Create<int, string>(123, "abc");
            var t2 = Tuple.Create<int, string>(123, "abc");

            // Act
            bool result = t == t2;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Should_CompareTupleByReference_ReturnTrue() {
            // Arrange
            var t = Tuple.Create<int, string>(123, "abc");
            var t2 = Tuple.Create<int, string>(123, "abc");

            // Act
            bool result = t.Equals(t2);

            // Assert
            Assert.IsTrue(result);
        }
         
    }
}
