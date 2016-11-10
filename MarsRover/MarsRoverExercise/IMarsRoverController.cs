using System;
using System.Collections.Generic;

namespace MarsRoverExercise
{
    public interface IMarsRoverController
    {
        List<string> Validate(List<string> input);

        List<string> ValidateInitialState(string initPos);

        List<string> ValidateMoves(string moves);

        List<string> ValidateGridSize(string gridSize);

        CoOrdinates SetGridSize(string gridSize);

        List<Tuple<RoverState, string>> GetRoverInstructions(List<string> input);
      
    }
}
