namespace MarsRoverExercise
{
    public class RoverState
    {
        public RoverState()
        {
            RoverPosition = new CoOrdinates();
        }
        public CoOrdinates RoverPosition { get; set; }

        public Direction RoverDirection { get; set; }
    }
}
