using System;

namespace ArgentRose;

public readonly struct Quality {
    readonly int level;

    Quality(int level) {
        if (level < Min || level > Max)
            throw new ArgumentException("Quality must be between 0 and 50");
        
        this.level = level;
    }

    public Quality DecreaseBy(int amount) => Math.Max(level - amount, Min);
    public Quality IncreaseBy(int addend) => Math.Min(level + addend, Max);

    public override string ToString() {
        return $"{nameof(level)}: {level}";
    }
    
    public static implicit operator Quality(int level) => new(level);
    public static implicit operator int(Quality quality) => quality.level;

    public static Quality Min => 0;
    public static Quality Max => 50;
}