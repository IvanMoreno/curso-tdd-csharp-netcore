using System;

namespace ArgentRose;

public readonly struct Quality {
    public readonly int level;

    public Quality(int level) {
        if (level < 0 || level > 50)
            throw new ArgumentException("Quality must be between 0 and 50");
        
        this.level = level;
    }
}