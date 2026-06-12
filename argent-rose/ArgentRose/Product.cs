using System;

namespace ArgentRose;

public class Product {
    readonly int sellIn;
    readonly int quality;
    readonly Quality qualityNew;

    Product(int sellIn, int quality) {
        this.sellIn = sellIn;
        this.quality = quality;
        this.qualityNew = new Quality(quality);
    }

    public Product Update() {
        var newSellIn = sellIn - 1;
        var qualityDecrement = newSellIn < 0 ? 4 : 2;
        return Create(newSellIn, Math.Max(quality - qualityDecrement, 0));
    }

    public override bool Equals(object obj) {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Product)obj);
    }

    bool Equals(Product other) {
        return sellIn == other.sellIn && qualityNew.Equals(other.qualityNew);
    }

    public override int GetHashCode() {
        return HashCode.Combine(sellIn, qualityNew);
    }

    public override string ToString() {
        return $"{nameof(sellIn)}: {sellIn}, {nameof(qualityNew)}: {qualityNew}";
    }

    public static Product Create(int sellIn, int quality) {
        return new Product(sellIn, quality);
    }
}