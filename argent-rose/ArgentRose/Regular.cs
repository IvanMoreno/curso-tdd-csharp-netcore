namespace ArgentRose;

public class Regular(int sellIn, Quality quality, string description) : Product(sellIn, quality, description) {
    protected override Quality UpdateQuality() {
        return quality.DecreaseBy(sellIn <= 0 ? 4 : 2);
    }
}