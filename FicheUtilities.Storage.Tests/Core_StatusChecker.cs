using System.Linq;
using FicheUtilities.Storage;
using FicheUtilities.Storage.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FicheUtilities.DiskStatus.Tests
{
    [TestClass]
    public class Core_StatusChecker
    {
        [TestMethod]
        public void ShouldHandle_InvalidPath()
        {
            // Arrange
            var fakeAPI = new FakeDiskAPI();
            var directoryMock = new Mock<IDirectoryWrapper>();
            directoryMock.Setup(dir => dir.Exists(It.IsAny<string>())).Returns(false);
            var checker = new StatusChecker(fakeAPI, directoryMock.Object);
            var opt = new StatusOptions(@"c:\temp", 50, 20);

            // Act
            var logs = checker.GetStatus(opt);

            // Assert
            Assert.AreEqual(1, logs.Count);
            var log = logs.First();
            Assert.AreEqual($@"ERROR - Verify that you have the correct path: c:\temp", log.Message);
            Assert.AreEqual(MessageType.Critical, log.MessageType);
        }

        [TestMethod]
        public void ShouldHandle_Exceptions()
        {
            // Arrange
            var fakeAPI = new FakeDiskAPI_ThrowsExceptions();
            var directoryMock = new Mock<IDirectoryWrapper>();
            directoryMock.Setup(dir => dir.Exists(It.IsAny<string>())).Returns(true);
            var checker = new StatusChecker(fakeAPI, directoryMock.Object);
            var opt = new StatusOptions(@"c:\temp", 50, 20);

            // Act
            var logs = checker.GetStatus(opt);

            // Assert
            Assert.AreEqual(1, logs.Count);
            var log = logs.First();
            Assert.AreEqual($"ERROR - Something went wrong!", log.Message);
            Assert.AreEqual(MessageType.Critical, log.MessageType);
        }

        [DataTestMethod]
        [DataRow(30, 20, "OK", MessageType.Ok)]
        [DataRow(50, 20, "Warning", MessageType.Warning)]
        [DataRow(100, 50, "Critical", MessageType.Critical)]
        public void ShouldReturn_ProperStatus(double warning, double critical, string message, MessageType messageType)
        {
            // Arrange
            var fakeAPI = new FakeDiskAPI();
            var directoryMock = new Mock<IDirectoryWrapper>();
            directoryMock.Setup(dir => dir.Exists(It.IsAny<string>())).Returns(true);
            var checker = new StatusChecker(fakeAPI, directoryMock.Object);
            var opt = new StatusOptions(@"c:\temp", warning, critical);

            // Act
            var logs = checker.GetStatus(opt);

            // Assert
            Assert.AreEqual(1, logs.Count);
            var log = logs.First();
            Assert.AreEqual(message, log.Message);
            Assert.AreEqual(messageType, log.MessageType);
        }

        [TestMethod]
        public void ShouldReturn_ProperStatusWithVerbose()
        {
            // Arrange
            var fakeAPI = new FakeDiskAPI();
            var directoryMock = new Mock<IDirectoryWrapper>();
            directoryMock.Setup(dir => dir.Exists(It.IsAny<string>())).Returns(true);
            var checker = new StatusChecker(fakeAPI, directoryMock.Object);
            var opt = new StatusOptions(@"c:\temp", 50, 20, true);

            // Act
            var logs = checker.GetStatus(opt);

            // Assert
            Assert.AreEqual(6, logs.Count);
            Assert.AreEqual(@"Disk at path: c:\temp", logs[2].Message);
            Assert.AreEqual(MessageType.Info, logs[2].MessageType);
            Assert.AreEqual("Total space: 111.79 GB", logs[3].Message);
            Assert.AreEqual(MessageType.Info, logs[3].MessageType);
            Assert.AreEqual("Used space: 67.59 GB", logs[4].Message);
            Assert.AreEqual(MessageType.Info, logs[4].MessageType);
            Assert.AreEqual("Available space: 44.2 GB", logs[5].Message);
            Assert.AreEqual(MessageType.Info, logs[5].MessageType);
        }
    }
}
