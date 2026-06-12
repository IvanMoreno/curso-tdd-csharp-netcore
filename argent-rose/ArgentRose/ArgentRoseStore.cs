using System.Collections.Generic;
using System.Linq;

namespace ArgentRose;

public class ArgentRoseStore {
    List<Product> inventory;

    public ArgentRoseStore(List<Product> inventory) {
        this.inventory = inventory;
    }

    public void Update() {
        inventory = inventory.Select(product => product.Update()).ToList();
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
        return inventory != null ? inventory.GetHashCode() : 0;
    }

    public override string ToString() {
        return $"{nameof(inventory)}: {string.Join("\n", inventory)}";
    }
}