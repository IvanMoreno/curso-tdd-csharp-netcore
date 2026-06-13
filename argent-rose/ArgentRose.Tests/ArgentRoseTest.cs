using NUnit.Framework;
using static ArgentRose.Product;

// [x] Product has a description
// [x] - [(s:7, q: 0)] => [(s:6, q: 1)]
// [] - [(s:7, q: 49)] => [(s:6, q: 50)]
// [] - [(s:6, q: 0)] => [(s:5, q: 3)]
// [] - [(s:1, q: 0)] => [(s:0, q: 3)]
// [] - [(s:0, q: 0)] => [(s:-1, q: 0)]
// [] - [(s:0, q: 40)] => [(s:-1, q: 0)]
// [] - [(s:7, q: 50)] => [(s:6, q: 50)]
// [] - [(s:6, q: 48)] => [(s:5, q: 50)]
// [] - Quality implicit conversion

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
            var sut = new ArgentRoseStore([Regular(sellIn: 1, quality: new Quality(0))]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([Regular(sellIn: 0, quality: new Quality(0))])));
        }

        [Test]
        public void Quality_DecreasesByTwo_WhenUnexpired() {
            var sut = new ArgentRoseStore([Regular(sellIn: 10, quality: new Quality(10))]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([Regular(sellIn: 9, quality: new Quality(8))])));
        }

        [Test]
        public void Quality_DecreasesByFour_WhenExpired() {
            var sut = new ArgentRoseStore([Regular(sellIn: 0, quality: new Quality(10))]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([Regular(sellIn: -1, quality: new Quality(6))])));
        }

        [TestCase(3, 0)]
        [TestCase(0, 3)]
        public void Quality_CannotBeLower_ThanZero(int sellIn, int quality) {
            var sut = new ArgentRoseStore([Regular(sellIn, new Quality(quality))]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([Regular(sellIn: sellIn - 1, quality: new Quality(0))])));
        }

        [Test]
        public void UpdateManyProducts() {
            var sut = new ArgentRoseStore([
                Regular(sellIn: 1, quality: new Quality(2)), Regular(sellIn: 0, quality: new Quality(4))
            ]);

            sut.Update();

            Assert.That(sut,
                Is.EqualTo(new ArgentRoseStore([
                    Regular(sellIn: 0, quality: new Quality(0)), Regular(sellIn: -1, quality: new Quality(0))
                ])));
        }
        
        [Test]
        public void SpecialProductQuality_Increases_ByOne() {
            var sut = new ArgentRoseStore([TheatrePass(sellIn: 7, quality: new Quality(0))]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([TheatrePass(sellIn: 6, quality: new Quality(1))])));
        }
        
        [Test]
        public void SpecialProductQuality_Increases_ByThree_WhenCloseToExpiration() {
            var sut = new ArgentRoseStore([TheatrePass(sellIn: 6, quality: new Quality(0))]);

            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([TheatrePass(sellIn: 5, quality: new Quality(3))])));
        }
    }
}