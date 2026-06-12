using System;

namespace ArgentRose;

public class Product {
    readonly string description;
    readonly int sellIn;
    readonly Quality quality;

    Product(int sellIn, Quality quality, string description) {
        this.sellIn = sellIn;
        this.quality = quality;
        this.description = description;
    }

    public Product Update() => new(sellIn - 1, quality.DecreaseBy(Devaluation()), description);
    int Devaluation() => sellIn < 1 ? 4 : 2;

    bool Equals(Product other) {
        return description == other.description && sellIn == other.sellIn && quality.Equals(other.quality);
    }

    public override bool Equals(object obj) {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Product)obj);
    }

    public override int GetHashCode() {
        return HashCode.Combine(description, sellIn, quality);
    }

    public override string ToString() {
        return $"{nameof(description)}: {description}, {nameof(sellIn)}: {sellIn}, {nameof(quality)}: {quality}";
    }

    public static Product Regular(int sellIn, Quality quality) {
        return new Product(sellIn, quality, "Regular");
    }
}