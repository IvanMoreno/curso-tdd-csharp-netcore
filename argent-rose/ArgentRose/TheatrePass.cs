namespace ArgentRose;

public class TheatrePass(int sellIn, Quality quality) : Product(sellIn, quality, "Theatre Pass") {
    protected override Quality UpdateQuality() {
        return sellIn <= 0 ? 0 : quality.IncreaseBy(sellIn <= 6 ? 3 : 1);
    }
}