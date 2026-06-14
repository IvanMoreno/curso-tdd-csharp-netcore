namespace ArgentRose;

public class Regular(int sellIn, Quality quality, string description) : Product(sellIn, quality, description) {
    protected override Quality UpdateQuality() => Quality.DecreaseBy(Devaluation());
    int Devaluation() => SellIn <= 0 ? 4 : 2;
}