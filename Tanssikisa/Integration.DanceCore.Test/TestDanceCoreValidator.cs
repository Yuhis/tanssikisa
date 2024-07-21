using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using NUnit.Framework;

namespace Integration.DanceCore.Test
{
    public class TestDanceCoreValidator
    {
        private DanceCoreValidator Validator;
        private DanceCoreVakLatIlmoittautuminen Ilmoittautuminen;

        [SetUp]
        public void SetUp()
        {
            Validator = new DanceCoreValidator();
            Ilmoittautuminen = new DanceCoreVakLatIlmoittautuminen
            {
                ID = "123_456",
                MID = "123",
                NID = "456",
                EtunimiM = "MiesEtu",
                SukunimiM = "MiesSuku",
                EtunimiN = "NainenEtu",
                SukunimiN = "NainenSuku",
                Seura = "Parin Seura",
                Paikkakunta = "Seuran Paikkakunta",
                Luokka = "Seniori 1",
                Sarja = "C(V)",
                TasoV = "C",
                TasoL = "D",
                Maksettu = "maksu pvm",
                Ilmoittautunut = "ilmoittautumis pvm"
            };
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestValidator()
        {
            // --- Arrange ----------------------------------------------------

            // --- Act --------------------------------------------------------

            ValidationResult result = Validator.Validate(Ilmoittautuminen);

            // --- Assert -----------------------------------------------------

            Assert.That(result.IsValid, Is.True);
        }

        [Test]
        public void ValidationFailsGivenIncorrectSarja()
        {
            // --- Arrange ----------------------------------------------------

            Ilmoittautuminen.Sarja = "G";

            // --- Act --------------------------------------------------------

            ValidationResult result = Validator.Validate(Ilmoittautuminen);

            // --- Assert -----------------------------------------------------

            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Errors.First().ToString(), Is.EqualTo("Sarja ei ole oikeassa muodossa"));
        }
    }
}
