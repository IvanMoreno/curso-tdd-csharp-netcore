using System;

namespace ArgentRose;

public readonly struct Quality {
    readonly int level;

    Quality(int level) {
        if (level < 0 || level > 50)
            throw new ArgumentException("Quality must be between 0 and 50");
        
        this.level = level;
    }

    public Quality DecreaseBy(int amount) {
        if (amount < 0)
            throw new ArgumentException("Cannot decrease by a negative value, use IncreaseBy instead");
                
        return Math.Max(level - amount, Min);
    }

    public Quality IncreaseBy(int addend) {
        if (addend < 0)
            throw new ArgumentException("Cannot increase by a negative value, use DecreaseBy instead");
        
        return Math.Min(level + addend, Max);
    }

    public override string ToString() {
        return $"{nameof(level)}: {level}";
    }
    
    public static implicit operator Quality(int level) => new(level);
    public static implicit operator int(Quality quality) => quality.level;

    public static Quality Min => 0;
    public static Quality Max => 50;
}