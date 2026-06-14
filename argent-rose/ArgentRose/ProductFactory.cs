namespace ArgentRose;

public static class ProductFactory {
    public static Product Create(int sellIn, Quality quality, string description) {
        if (description == "Theatre Pass")
            return new TheatrePass(sellIn, quality);
        
        return new Regular(sellIn, quality, description);
    }

    public static Product Regular(int sellIn, Quality quality) {
        return Create(sellIn, quality, "Regular");
    }

    public static Product TheatrePass(int sellIn, Quality quality) {
        return Create(sellIn, quality, "Theatre Pass");
    }
}