using System;

namespace ArgentRose;

public class Product {
    readonly int sellIn;
    readonly Quality quality;

    Product(int sellIn, Quality quality) {
        this.sellIn = sellIn;
        this.quality = quality;
    }

    public Product Update() {
        var newSellIn = sellIn - 1;
        var qualityDecrement = newSellIn < 0 ? 4 : 2;
        int quality = Math.Max(this.quality.level - qualityDecrement, 0);
        return Create(newSellIn, new Quality(quality));
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