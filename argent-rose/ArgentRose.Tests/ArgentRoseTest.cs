using NUnit.Framework;

// [x] - [] => []
// [x] - [(s:1, q:0)] => [(s:0, q:0)]
// [x] - [(s:10, q:10)] => [(s:9, q:8)]
// [x] - [(s:0, q:10)] => [(s:-1, q:6)]
// [x] - [(s:3, q:0)] => [(s:2, q:0)]
// [x] - [(s:0, q:3)] => [(s:-1, q:0)]
// [x] sellIn public?
// [x] quality public?
// [] Quality object?
// [x] - [(s:1, q:2), (s:0, q:4)] => [(s:0, q:0), (s:-1, q:0)]
    
namespace ArgentRose.Tests
{
    public class ArgentRoseTest
    {
        [Test]
        public void EmptyInventory_RemainsEmpty() {
            var sut = new ArgentRoseStore([]);

            sut.Update();
            
            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([])));
        }

        [Test]
        public void SellIn_Decreases_ByOne() {
            var sut = new ArgentRoseStore([new Product(sellIn: 1, quality: 0)]);
            
            sut.Update();
            
            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([new Product(sellIn: 0, quality: 0)])));
        }

        [Test]
        public void Quality_DecreasesByTwo_WhenUnexpired() {
            var sut = new ArgentRoseStore([new Product(sellIn: 10, quality: 10)]);
            
            sut.Update();
            
            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([new Product(sellIn: 9, quality: 8)])));
        }

        [Test]
        public void Quality_DecreasesByFour_WhenExpired() {
            var sut = new ArgentRoseStore([new Product(sellIn: 0, quality: 10)]);
            
            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([new Product(sellIn: -1, quality: 6)])));
        }

        [TestCase(3, 0)]
        [TestCase(0, 3)]
        public void Quality_CannotBeLower_ThanZero(int sellIn, int quality) {
            var sut = new ArgentRoseStore([new Product(sellIn, quality)]);
            
            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([new Product(sellIn: sellIn - 1, quality: 0)])));
        }

        [Test]
        public void UpdateManyProducts() {
            var sut = new ArgentRoseStore([new Product(sellIn: 1, quality: 2), new Product(sellIn: 0, quality: 4)]);
            
            sut.Update();

            Assert.That(sut, Is.EqualTo(new ArgentRoseStore([new Product(sellIn: 0, quality: 0), new Product(sellIn: -1, quality: 0)])));
        }
    }
}
