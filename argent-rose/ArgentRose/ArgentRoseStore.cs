using System.Collections.Generic;
using System.Linq;

namespace ArgentRose;

public class ArgentRoseStore {
    readonly List<Product> inventory;

    public ArgentRoseStore(List<Product> inventory) {
        this.inventory = inventory;
    }

    public void Update() {
        if (inventory.Count > 0) {
            inventory[0] = new Product(inventory[0].sellIn - 1, 0);
        }
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