using Ensek.Api.Interfaces;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Ensek.Tests
{
    [TestFixture]
    public class MeterReadingTests
    {
        private Mock<IMeterReadingService> mockIMeterReadingService;

        [Test]
        public void Check_Bad_Data_is_not_saved_to_the_Db()
        {
            mockIMeterReadingService = new Mock<IMeterReadingService>(MockBehavior.Strict);

            //mockIMeterReadingService.Setup(s => s.LoadReadings()).Returns()

        }
    }
}
