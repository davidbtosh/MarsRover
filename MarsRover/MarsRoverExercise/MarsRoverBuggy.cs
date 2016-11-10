namespace MarsRoverExercise
{
    public class MarsRoverBuggy : IMarsRoverBuggy
    {
        public MarsRoverBuggy(RoverState rs)
        {
            RoverState = rs;
        }

        public RoverState RoverState { get; set; }

        
        public string ProcessMoveInstructions(string moves)
        {
            foreach (var move in moves)
            {
                ProcessMove(move);
            }
            return string.Format("{0} {1} {2}", RoverState.RoverPosition.X, RoverState.RoverPosition.Y, RoverState.RoverDirection);
        }

        public void ProcessMove(char move)
        {
            switch (move)
            {
                case 'R':
                    TurnRight();
                    break;
                case 'L':
                    TurnLeft();
                    break;
                case 'M':
                    MoveForward();
                    break;
            }
        }

        public void MoveForward()
        {
            if (RoverState.RoverDirection == Direction.N)
            {
                RoverState.RoverPosition.Y++;
            }
            else if (RoverState.RoverDirection == Direction.E)
            {
                RoverState.RoverPosition.X++;
            }
            else if (RoverState.RoverDirection == Direction.S)
            {
                RoverState.RoverPosition.Y--;
            }
            else if (RoverState.RoverDirection == Direction.W)
            {
                RoverState.RoverPosition.X--;
            }
        }

        public RoverState TurnLeft()
        {
            RoverState.RoverDirection = RoverState.RoverDirection == Direction.N ? Direction.W : RoverState.RoverDirection - 1;
            return RoverState;
        }

        public RoverState TurnRight()
        {
            
            RoverState.RoverDirection = RoverState.RoverDirection == Direction.W ? Direction.N : RoverState.RoverDirection + 1;
            return RoverState;
            
        }
    }
}
