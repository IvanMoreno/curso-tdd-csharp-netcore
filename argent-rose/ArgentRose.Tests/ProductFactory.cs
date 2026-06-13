namespace ArgentRose;

public static class ProductFactory {
    public static Product Regular(int sellIn, Quality quality) {
        return Product.Create(sellIn, quality, "Regular");
    }

    public static Product TheatrePass(int sellIn, Quality quality) {
        return Product.Create(sellIn, quality, "Theatre Pass");
    }
}