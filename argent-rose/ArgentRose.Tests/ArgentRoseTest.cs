using NUnit.Framework;
using static ArgentRose.ProductFactory;

namespace ArgentRose.Tests {
    public class ArgentRoseTest {
        [Test]
        public void EmptyInventory_RemainsEmpty() {
            var sut = new ArgentRoseStore([]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([])));
        }

        [Test]
        public void SellIn_Decreases_ByOne() {
            var sut = new ArgentRoseStore([Regular(sellIn: 1, quality: 0)]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([Regular(sellIn: 0, quality: 0)])));
        }

        [Test]
        public void Quality_DecreasesByTwo_WhenUnexpired() {
            var sut = new ArgentRoseStore([Regular(sellIn: 10, quality: 10)]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([Regular(sellIn: 9, quality: 8)])));
        }

        [Test]
        public void Quality_DecreasesByFour_WhenExpired() {
            var sut = new ArgentRoseStore([Regular(sellIn: 0, quality: 10)]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([Regular(sellIn: -1, quality: 6)])));
        }

        [TestCase(3, 0)]
        [TestCase(0, 3)]
        public void Quality_CannotBeLower_ThanZero(int sellIn, int quality) {
            var sut = new ArgentRoseStore([Regular(sellIn, quality)]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([Regular(sellIn: sellIn - 1, quality: 0)])));
        }

        [Test]
        public void UpdateManyProducts() {
            var sut = new ArgentRoseStore([Regular(sellIn: 1, quality: 2), Regular(sellIn: 0, quality: 4)]);

            sut.Update();

            Assert.That(sut,
                Is.EqualTo(new ArgentRoseStore([Regular(sellIn: 0, quality: 0), Regular(sellIn: -1, quality: 0)])));
        }

        [Test]
        public void TheatrePassQuality_Increases_ByOne() {
            var sut = new ArgentRoseStore([TheatrePass(sellIn: 7, quality: 0)]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([TheatrePass(sellIn: 6, quality: 1)])));
        }

        [TestCase(6, 0)]
        [TestCase(1, 3)]
        public void TheatrePassQuality_Increases_ByThree_WhenCloseToExpiration(int sellIn, int quality) {
            var sut = new ArgentRoseStore([TheatrePass(sellIn, quality: quality)]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([TheatrePass(sellIn - 1, quality: quality + 3)])));
        }

        [TestCase(7, 50)]
        [TestCase(6, 48)]
        public void Quality_CannotBeGreater_ThanFifty(int sellIn, int quality) {
            var sut = new ArgentRoseStore([TheatrePass(sellIn, quality)]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([TheatrePass(sellIn - 1, quality: 50)])));
        }

        [TestCase(0, 40)]
        [TestCase(0, 0)]
        public void TheatrePassQuality_DropsToZero_AfterExpirationDate(int sellIn, int quality) {
            var sut = new ArgentRoseStore([TheatrePass(sellIn, quality)]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([TheatrePass(sellIn - 1, quality: 0)])));
        }
    }
}