using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Integration.DanceCore.Test
{
    [TestFixture()]
    [Category("Unit")]
    public class TestDanceCoreReader
    {
        private readonly string excel_EmptyWorkbook = "TestData/Test_EmptyWorkbook.xlsx";
        private readonly string excel_HeaderOnlyWorkbook = "TestData/Test_HeaderOnly.xlsx";
        private readonly string excel_ValidCouplesWorkbook = "TestData/Test_ValidCouples.xlsx";
        private readonly string excel_CouplesWorkbook = "TestData/Test_Couples.xlsx";

        [SetUp]
        public void SetUp()
        {
            
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void ReadEmptyFile()
        {
            // --- Arrange ----------------------------------------------------

            string sheet1Name = "Taul1";
            var logInformation_1 = new LogEntry(LoggingEventType.Information, $"Reading sheet {sheet1Name} from file");
            var logInformation_2 = new LogEntry(LoggingEventType.Information, $"Read 0 rows from sheet {sheet1Name}.");

            var logger = new TestLoggingAdapter();
            var reader = new VakLatIlmoittautumisetReader(logger);

            // --- Act --------------------------------------------------------

            reader.ReadRegisteredCouples(excel_EmptyWorkbook);

            // --- Assert -----------------------------------------------------

            Assert.That(logger.LogEntries.Count, Is.EqualTo(2));
            Assert.That(logger.LogEntries[0].Severity, Is.EqualTo(logInformation_1.Severity));
            Assert.That(logger.LogEntries[0].Message, Is.EqualTo(logInformation_1.Message));
            Assert.That(logger.LogEntries[1].Severity, Is.EqualTo(logInformation_2.Severity));
            Assert.That(logger.LogEntries[1].Message, Is.EqualTo(logInformation_2.Message));

            Assert.That(reader.DanceCoreIlmoittautumiset.Count, Is.EqualTo(0));
        }

        [Test]
        public void ReadHeaderOnlyFile()
        {
            // --- Arrange ----------------------------------------------------

            string sheet1Name = "Sheet1";
            var logInformation_1 = new LogEntry(LoggingEventType.Information, $"Reading sheet {sheet1Name} from file");
            var logInformation_2 = new LogEntry(LoggingEventType.Information, $"Read 1 rows from sheet {sheet1Name}.");

            var logger = new TestLoggingAdapter();
            var reader = new VakLatIlmoittautumisetReader(logger);

            // --- Act --------------------------------------------------------

            reader.ReadRegisteredCouples(excel_HeaderOnlyWorkbook);

            // --- Assert -----------------------------------------------------

            Assert.That(logger.LogEntries.Count, Is.EqualTo(2));
            Assert.That(logger.LogEntries[0].Severity, Is.EqualTo(logInformation_1.Severity));
            Assert.That(logger.LogEntries[0].Message, Is.EqualTo(logInformation_1.Message));
            Assert.That(logger.LogEntries[1].Severity, Is.EqualTo(logInformation_2.Severity));
            Assert.That(logger.LogEntries[1].Message, Is.EqualTo(logInformation_2.Message));

            Assert.That(reader.DanceCoreIlmoittautumiset.Count, Is.EqualTo(0));
        }

        [Test]
        public void ReadValidCouplesFile()
        {
            // --- Arrange ----------------------------------------------------

            string sheet1Name = "Sheet1";
            var logInformation_1 = new LogEntry(LoggingEventType.Information, $"Reading sheet {sheet1Name} from file");
            var logInformation_2 = new LogEntry(LoggingEventType.Information, $"Read 6 rows from sheet {sheet1Name}.");

            var logger = new TestLoggingAdapter();
            var reader = new VakLatIlmoittautumisetReader(logger);

            // --- Act --------------------------------------------------------

            reader.ReadRegisteredCouples(excel_ValidCouplesWorkbook);

            // --- Assert -----------------------------------------------------

            Assert.That(logger.LogEntries.Count, Is.EqualTo(2));
            Assert.That(logger.LogEntries[0].Severity, Is.EqualTo(logInformation_1.Severity));
            Assert.That(logger.LogEntries[0].Message, Is.EqualTo(logInformation_1.Message));
            Assert.That(logger.LogEntries[1].Severity, Is.EqualTo(logInformation_2.Severity));
            Assert.That(logger.LogEntries[1].Message, Is.EqualTo(logInformation_2.Message));

            Assert.That(reader.DanceCoreIlmoittautumiset.Count, Is.EqualTo(5));
        }
    }
}
