using NUnit.Framework;
using static ArgentRose.Product;

// [x] - [] => []
// [x] - [(s:1, q:0)] => [(s:0, q:0)]
// [x] - [(s:10, q:10)] => [(s:9, q:8)]
// [x] - [(s:0, q:10)] => [(s:-1, q:6)]
// [x] - [(s:3, q:0)] => [(s:2, q:0)]
// [x] - [(s:0, q:3)] => [(s:-1, q:0)]
// [x] sellIn public?
// [x] quality public?
// [x] Quality object?
// [x] - [(s:1, q:2), (s:0, q:4)] => [(s:0, q:0), (s:-1, q:0)]

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
    }
}