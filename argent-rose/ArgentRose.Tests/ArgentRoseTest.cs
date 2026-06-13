using NUnit.Framework;
using static ArgentRose.ProductFactory;

// [x] Product has a description
// [x] - [(s:7, q: 0)] => [(s:6, q: 1)]
// [x] - [(s:6, q: 0)] => [(s:5, q: 3)]
// [x] - [(s:1, q: 0)] => [(s:0, q: 3)]
// [] - [(s:0, q: 0)] => [(s:-1, q: 0)]
// [x] - [(s:0, q: 40)] => [(s:-1, q: 0)]
// [x] - [(s:7, q: 50)] => [(s:6, q: 50)]
// [x] - [(s:6, q: 48)] => [(s:5, q: 50)]
// [x] - Quality implicit conversion

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

        [Test]
        public void TheatrePassQuality_DropsToZero_AfterExpirationDate() {
            var sut = new ArgentRoseStore([TheatrePass(sellIn: 0, quality: 40)]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([TheatrePass(sellIn: -1, quality: 0)])));
        }
    }
}