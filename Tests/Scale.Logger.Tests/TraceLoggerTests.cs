using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scale.Logger.Tests
{
    [TestClass]
    public class TraceLoggerTests
    {
        [TestMethod]
        [TestCategory("integration")]
        public void MessageTest()
        {
            // Arrange
            var logger = new TraceLogger("abc123");
            
            // Act
            logger.Message("This is a message");
            logger.Message("MessageTest is running on TraceLogger #{0}.", new object[] {logger.Key});            
        }
	
        [TestMethod]
        [TestCategory("integration")]
        public void InfoTest()
        {
            // Arrange
            var logger = new TraceLogger("abc123");
            
            // Act
            logger.Info("This is a Info message");
            logger.Info("InfoTest is running on TraceLogger #{0}.", new object[] {logger.Key});            
        }
	
        [TestMethod]
        [TestCategory("integration")]
        public void ErrorTest()
        {
            // Arrange
            var logger = new TraceLogger("abc123");
            
            // Act
            logger.Error("This is a Error message");
            logger.Error("ErrroTest is running on TraceLogger #{0}.", new object[] {logger.Key});            
        }
	
        [TestMethod]
        [TestCategory("integration")]
        public void ErrorTestWithExceptionAndMessage()
        {
            // Arrange
            var logger = new TraceLogger("abc123");
            
            // Act
            logger.Error(new Exception("this is an exception's message"), "ErrorTest is running on TraceLogger #{0}.",
                new object[] {logger.Key});
        }
	
        [TestMethod]
        [TestCategory("integration")]
        public void ErrorTestThrowExceptionWithMessage()
        {
            // Arrange
            var logger = new TraceLogger("abc123");

            try
            {
                throw new Exception("This is a thrown exception's message.");
            }
            catch(Exception exception)
            {
                // Act
                logger.Error(exception, "ErrorTest is running on TraceLogger #{0}.",
                    new object[] { logger.Key });
            }
        }
	
        [TestMethod]
        [TestCategory("integration")]
        public void ErrorTestThrowException()
        {
            // Arrange
            var logger = new TraceLogger("abc123");

            try
            {
                throw new Exception("This is a thrown exception's message.");
            }
            catch(Exception exception)
            {
                // Act
                logger.Error(exception);
            }
        }
	
        [TestMethod]
        [TestCategory("integration")]
        public void ErrorTestWithException()
        {
            // Arrange
            var logger = new TraceLogger("abc123");
            
            // Act
            logger.Error(new Exception("this is an exception's message"));
        }
	

    }
}
