namespace ArgentRose;

public class TheatrePass(int sellIn, Quality quality) : Product(sellIn, quality, "Theatre Pass") {
    bool IsWeekOfPerformance => SellIn <= 6;

    protected override Quality UpdateQuality() 
        => Expired 
            ? Quality.Zero 
            : Quality.IncreaseBy(Appreciation());

    int Appreciation() => IsWeekOfPerformance ? 3 : 1;
}