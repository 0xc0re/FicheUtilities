using System;
using FicheUtilities.Storage.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FicheUtilities.DiskStatus.Tests
{
    [TestClass]
    public class Core_StatusData
    {
        private const ulong TOTAL_DISK_BYTES = 120031539200;
        private const ulong AVAILABLE_DISK_BYTES = 47461699584;
        private const double EXPECTED_AVAILABLE_GIGABYTES = 44.2D;
        private const double EXPECTED_USED_GIGABYTES = 67.59D;
        private const double EXPECTED_TOTAL_GIGABYTES = 111.79D;

        [TestMethod]
        public void ShouldCalculateAvailableGigabytes()
        {
            // Arrange
            var stat = new StatusData(TOTAL_DISK_BYTES, AVAILABLE_DISK_BYTES);
            // Act
            var available = stat.AvailableGigabytes;
            // Assert
            Assert.AreEqual(EXPECTED_AVAILABLE_GIGABYTES, available);
        }

        [TestMethod]
        public void ShouldCalculateUsedGigabytes()
        {
            // Arrange
            var stat = new StatusData(TOTAL_DISK_BYTES, AVAILABLE_DISK_BYTES);
            // Act
            var used = stat.UsedGigabytes;
            // Assert
            Assert.AreEqual(EXPECTED_USED_GIGABYTES, used);
        }

        [TestMethod]
        public void ShouldCalculateTotalGigabytes()
        {
            // Arrange
            var stat = new StatusData(TOTAL_DISK_BYTES, AVAILABLE_DISK_BYTES);
            // Act
            var total = stat.TotalGigabytes;
            // Assert
            Assert.AreEqual(EXPECTED_TOTAL_GIGABYTES, total);
        }
    }
}
