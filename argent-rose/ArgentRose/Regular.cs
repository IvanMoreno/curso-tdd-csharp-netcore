namespace ArgentRose;

public class Regular(int sellIn, Quality quality, string description) : Product(sellIn, quality, description) {
    const int DevaluationRate = 2;

    protected override Quality UpdateQuality() => Quality.DecreaseBy(Devaluation());

    int Devaluation()
        => Expired
            ? DevaluationRate * 2
            : DevaluationRate;
}