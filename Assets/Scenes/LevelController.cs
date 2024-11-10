using System.Collections;
using System.Collections.Generic;

public static class LevelController
{
    static Level _level = Level.Hard;

    public enum Level
    { 
        Easy, Normal, Hard
    }

    static public Level level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
    }
}
