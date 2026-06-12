using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

// [] => []
// [(s:10, q:10)] => [(s:9, q:8)]
// [(s:1, q:2)] => [(s:0, q:0)]
// [(s:0, q:10)] => [(s:-1, q:6)]
// [(s:0, q:4)] => [(s:-1, q:0)]
// [(s:3, q:0)] => [(s:2, q:0)]
// [(s:1, q:1)] => [(s:0, q:0)]
// [(s:0, q:3)] => [(s:-1, q:0)]
    
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
    }

    public class ArgentRoseStore {
        readonly List<Product> inventory;

        public ArgentRoseStore(List<Product> inventory) {
            this.inventory = inventory;
        }

        public void Update() {
            
        }

        public override bool Equals(object obj) {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ArgentRoseStore)obj);
        }

        bool Equals(ArgentRoseStore other) {
            return inventory.SequenceEqual(other.inventory);
        }

        public override int GetHashCode() {
            return (inventory != null ? inventory.GetHashCode() : 0);
        }
    }

    public class Product {
        
    }
}
