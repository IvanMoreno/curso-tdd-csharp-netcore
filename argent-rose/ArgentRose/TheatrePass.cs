namespace ArgentRose;

public class TheatrePass(int sellIn, Quality quality) : Product(sellIn, quality, "Theatre Pass") {
    protected override Quality UpdateQuality() {
        if (SellIn <= 0)
            return Quality.Minimum;
        
        return Quality.IncreaseBy(Increment());
    }

    int Increment() => SellIn <= 6 ? 3 : 1;
}