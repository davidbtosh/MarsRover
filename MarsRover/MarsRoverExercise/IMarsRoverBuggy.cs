namespace MarsRoverExercise
{
    public interface IMarsRoverBuggy
    {
        RoverState RoverState { get; set; }

        string ProcessMoveInstructions(string moves);

        void ProcessMove(char move);

        void MoveForward();

        RoverState TurnLeft();

        RoverState TurnRight();
        
    }
}
