using System;
using AutoMapper;
using NUnit.Framework;
using Tanssikisa.DTO;

namespace Integration.DanceCore.Test
{
    [TestFixture()]
    [Category("Unit")]
    public class TestDanceCoreProfile
    {
        private IMapper Mapper;

        [SetUp]
        public void SetUp()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DanceCoreProfile>();
            });
            config.AssertConfigurationIsValid();

            Mapper = new Mapper(config);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestProfile()
        {
            // --- Arrange ----------------------------------------------------

            var dancecore = new DanceCoreVakLatIlmoittautuminen()
            {
                ID = "123_456",
                MID = "123",
                EtunimiM = "Viejäetu",
                SukunimiM = "Viejäsuku",
                NID = "456",
                EtunimiN = "Seuraajaetu",
                SukunimiN = "Seuraajasuku",
                Seura = "Tanssiseura",
                Paikkakunta = "Tanssipaikka",
                Luokka = "Seniori 1",
                Sarja = "D(V)",
                TasoL = "C",
                TasoV = "D",
                Maksettu = "",
                Ilmoittautunut = ""
            };

            // --- Act --------------------------------------------------------

            var dto = Mapper.Map<DanceCoreVakLatIlmoittautuminen, VakLatKilpailuOsallistuminenDTO>(dancecore);

            // --- Assert -----------------------------------------------------

            Assert.That(dto, Is.Not.Null);
            Assert.That(dto.VakLatPari, Is.Not.Null);
            Assert.That(dto.VakLatPari.ParitanssiPariId, Is.EqualTo("123_456"));

            Assert.That(dto.VakLatPari.Vieja, Is.Not.Null);
            Assert.That(dto.VakLatPari.Vieja.HenkiloId, Is.EqualTo("123"));
            Assert.That(dto.VakLatPari.Vieja.Etunimi, Is.EqualTo("Viejäetu"));
            Assert.That(dto.VakLatPari.Vieja.Sukunimi, Is.EqualTo("Viejäsuku"));
            Assert.That(dto.VakLatPari.Seuraaja, Is.Not.Null);
            Assert.That(dto.VakLatPari.Seuraaja.HenkiloId, Is.EqualTo("456"));
            Assert.That(dto.VakLatPari.Seuraaja.Etunimi, Is.EqualTo("Seuraajaetu"));
            Assert.That(dto.VakLatPari.Seuraaja.Sukunimi, Is.EqualTo("Seuraajasuku"));
            Assert.That(dto.VakLatPari.Edustusseura, Is.Not.Null);
            Assert.That(dto.VakLatPari.Edustusseura.EdustusseuraNimi, Is.EqualTo("Tanssiseura"));
            Assert.That(dto.VakLatPari.Edustusseura.EdustusseuraPaikkakunta, Is.EqualTo("Tanssipaikka"));
            Assert.That(dto.VakLatKilpailu, Is.Not.Null);
            Assert.That(dto.VakLatKilpailu.KilpailuId, Is.EqualTo("S1DV"));
            Assert.That(dto.VakLatKilpailu.KilpailuNimi, Is.EqualTo("Seniori 1 D Vakio"));
        }
    }
}
