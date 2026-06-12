using System;

namespace ArgentRose;

public class Product {
    readonly int sellIn;
    readonly Quality quality;
    int Devaluation => sellIn < 1 ? 4 : 2;

    Product(int sellIn, Quality quality) {
        this.sellIn = sellIn;
        this.quality = quality;
    }

    public Product Update() {
        return Create(sellIn - 1, quality.DecreaseBy(Devaluation));
    }

    public override bool Equals(object obj) {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Product)obj);
    }

    bool Equals(Product other) {
        return sellIn == other.sellIn && quality.Equals(other.quality);
    }

    public override int GetHashCode() {
        return HashCode.Combine(sellIn, quality);
    }

    public override string ToString() {
        return $"{nameof(sellIn)}: {sellIn}, {nameof(quality)}: {quality}";
    }

    public static Product Create(int sellIn, Quality quality) {
        return new Product(sellIn, quality);
    }
}