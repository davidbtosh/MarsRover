using System;

namespace MarsRoverExercise
{
    public static class Extensions
    {
        public static bool IsOddNumber(this int val)
        {
            return !(val % 2 == 0);
        }

        public static Direction GetDirection(this string direction)
        {
            Direction d;
            Enum.TryParse(direction, out d);

            return d;

        }

        
    }
}
