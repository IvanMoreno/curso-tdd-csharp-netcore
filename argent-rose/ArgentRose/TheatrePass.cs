namespace ArgentRose;

public class TheatrePass(int sellIn, Quality quality) : Product(sellIn, quality, "Theatre Pass") {
    protected override Quality UpdateQuality() 
        => Expired 
            ? Quality.Min 
            : Quality.IncreaseBy(Appreciation());

    int Appreciation() => SellIn <= 6 ? 3 : 1;
}