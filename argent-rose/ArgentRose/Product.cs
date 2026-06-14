using System;

namespace ArgentRose;

public abstract class Product {
    readonly string description;
    protected readonly int SellIn;
    protected readonly Quality Quality;
    protected bool Expired => SellIn <= 0;

    protected Product(int sellIn, Quality quality, string description) {
        SellIn = sellIn;
        Quality = quality;
        this.description = description;
    }

    public Product Update() => ProductFactory.Create(SellIn - 1, UpdateQuality(), description);

    protected abstract Quality UpdateQuality();

    bool Equals(Product other) {
        return description == other.description && SellIn == other.SellIn && Quality.Equals(other.Quality);
    }

    public override bool Equals(object obj) {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Product)obj);
    }

    public override int GetHashCode() {
        return HashCode.Combine(description, SellIn, Quality);
    }

    public override string ToString() {
        return $"{nameof(description)}: {description}, {nameof(SellIn)}: {SellIn}, {nameof(Quality)}: {Quality}";
    }
}