namespace ArgentRose;

public class TheatrePass(int sellIn, Quality quality) : Product(sellIn, quality, "Theatre Pass") {
    protected override Quality UpdateQuality() {
        return SellIn <= 0 ? 0 : Quality.IncreaseBy(SellIn <= 6 ? 3 : 1);
    }
}