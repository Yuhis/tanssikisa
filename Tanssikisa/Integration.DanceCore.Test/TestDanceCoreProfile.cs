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

            
            Assert.IsNotNull(dto.VakLatPari.Vieja);
            Assert.AreEqual("123", dto.VakLatPari.Vieja.HenkiloId);
            Assert.AreEqual("Viejäetu", dto.VakLatPari.Vieja.Etunimi);
            Assert.AreEqual("Viejäsuku", dto.VakLatPari.Vieja.Sukunimi);
            Assert.IsNotNull(dto.VakLatPari.Seuraaja);
            Assert.AreEqual("456", dto.VakLatPari.Seuraaja.HenkiloId);
            Assert.AreEqual("Seuraajaetu", dto.VakLatPari.Seuraaja.Etunimi);
            Assert.AreEqual("Seuraajasuku", dto.VakLatPari.Seuraaja.Sukunimi);
            Assert.IsNotNull(dto.VakLatPari.Edustusseura);
            Assert.AreEqual("Tanssiseura", dto.VakLatPari.Edustusseura.EdustusseuraNimi);
            Assert.AreEqual("Tanssipaikka", dto.VakLatPari.Edustusseura.EdustusseuraPaikkakunta);
            Assert.IsNotNull(dto.VakLatKilpailu);
            Assert.AreEqual("S1DV", dto.VakLatKilpailu.KilpailuId);
            Assert.AreEqual("Seniori 1 D Vakio", dto.VakLatKilpailu.KilpailuNimi);
        }
    }
}
