using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scale.Logger.Tests
{
    [TestClass]
    public class LoggerRegistryTests
    {
        [TestMethod]
        public void Logger_GetsSecondLoggerWithDifferentKey_IsNotTheSameLogger()
        {
            // Arrange
            var registry = new LoggerRegistry();
            var logger1 = registry.Logger("abc.123");

            // Act
            var logger2 = registry.Logger("xyz.789");

            // Assert
            Assert.AreNotSame(logger1, logger2);
        }

        [TestMethod]
        public void Logger_GetsSecondLoggerWithSameKey_IsTheSameLogger()
        {
            // Arrange
            const string key = "abc123";
            var registry = new LoggerRegistry();
            var logger1 = registry.Logger(key);

            // Act
            var logger2 = registry.Logger(key);

            // Assert
            Assert.AreSame(logger1, logger2);
        }

        [TestMethod]
        public void MakeKey_SameInput_SameOutput()
        {
            // Arrange
            var registry = new LoggerRegistry();
            string key1 = registry.MakeKey("abc", "123", "456");

            // Act
            string key2 = registry.MakeKey("abc", "123", "456");

            // Assert
            Assert.AreEqual(key1, key2);
        }
	
        [TestMethod]
        public void MakeKey_DifferentInput_DifferentOutput()
        {
            // Arrange
            var registry = new LoggerRegistry();
            string key1 = registry.MakeKey("abc", "123", "456");

            // Act
            string key2 = registry.MakeKey("xyz", "456", "789");

            // Assert
            Assert.AreNotEqual(key1, key2);
        }
	

    }
}
