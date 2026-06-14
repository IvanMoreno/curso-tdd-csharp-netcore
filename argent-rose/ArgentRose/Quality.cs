using System;

namespace ArgentRose;

public readonly struct Quality {
    readonly int level;

    Quality(int level) {
        if (level < 0 || level > 50)
            throw new ArgumentException("Quality must be between 0 and 50");
        
        this.level = level;
    }

    public Quality DecreaseBy(int devaluation) {
        if (devaluation < 0)
            throw new ArgumentException("Cannot decrease by a negative value, use IncreaseBy instead");
                
        return Math.Max(level - devaluation, Zero);
    }

    public Quality IncreaseBy(int appreciation) {
        if (appreciation < 0)
            throw new ArgumentException("Cannot increase by a negative value, use DecreaseBy instead");
        
        return Math.Min(level + appreciation, Max);
    }

    public override string ToString() {
        return $"{nameof(level)}: {level}";
    }
    
    public static implicit operator Quality(int level) => new(level);
    public static implicit operator int(Quality quality) => quality.level;

    public static Quality Zero => 0;
    public static Quality Max => 50;
}