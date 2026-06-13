using System;

namespace ArgentRose;

public class TheatrePass : Product {
    public TheatrePass(int sellIn, Quality quality) : base(sellIn, quality, "Theatre Pass") { }
    
    protected override Quality UpdateQuality() {
        return sellIn <= 0 ? 0 : quality.IncreaseBy(sellIn <= 6 ? 3 : 1);
    }
}

public class Regular : Product {
    public Regular(int sellIn, Quality quality, string description) : base(sellIn, quality, description) { }
    
    protected override Quality UpdateQuality() {
        return quality.DecreaseBy(sellIn <= 0 ? 4 : 2);
    }
}

public abstract class Product {
    readonly string description;
    protected readonly int sellIn;
    protected readonly Quality quality;

    protected Product(int sellIn, Quality quality, string description) {
        this.sellIn = sellIn;
        this.quality = quality;
        this.description = description;
    }

    public Product Update() => Create(sellIn - 1, UpdateQuality(), description);

    protected abstract Quality UpdateQuality();

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
        return Create(sellIn, quality, "Regular");
    }

    public static Product TheatrePass(int sellIn, Quality quality) {
        return Create(sellIn, quality, "Theatre Pass");
    }

    static Product Create(int sellIn, Quality quality, string description) {
        if (description == "Theatre Pass")
            return new TheatrePass(sellIn, quality);
        
        return new Regular(sellIn, quality, description);
    }
}