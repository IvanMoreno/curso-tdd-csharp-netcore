namespace ArgentRose;

public class TheatrePass(int sellIn, Quality quality) : Product(sellIn, quality, "Theatre Pass") {
    const int AppreciationRate = 1;
    bool IsWeekOfPerformance => SellIn <= 6;

    protected override Quality UpdateQuality()
        => Expired
            ? Quality.Zero
            : Quality.IncreaseBy(Appreciation());

    int Appreciation()
        => IsWeekOfPerformance
            ? AppreciationRate * 3
            : AppreciationRate;
}