using System;

namespace ArgentRose;

public readonly struct Quality {
    readonly int level;

    public Quality(int level) {
        if (level < 0 || level > 50)
            throw new ArgumentException("Quality must be between 0 and 50");
        
        this.level = level;
    }

    public Quality DecreaseBy(int amount) => new(Math.Max(level - amount, 0));
    public Quality IncreaseBy(int addend) => new(Math.Min(level + addend, 50));

    public override string ToString() {
        return $"{nameof(level)}: {level}";
    }
}