using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverExercise
{
    public class MarsRoverController : IMarsRoverController
    {
        private const string InvalidGridSizeMsg = "Argument passed to SetGridSize is not formatted as expected.  Expectation is 2 integers separated by a space.";
        private const string InvaliidInputMsg = "Input is invalid.  There needs to be a grid size input at least 1 set of instructions.";
        private const string InvalidNumberofInstructionsMsg = "Input needs minimum 3 instructions.  Grid size and 1 set of instructions.";
        private const string InputMissingMsg = "Input is missing";
                
        private const int NumberOfInstructionsInSet = 2;

        public List<string> Validate(List<string> input)
        {
            var validations = new List<string>();

            if (input == null || !input.Any())
            {
                validations.Add(InputMissingMsg);
            }
            else
            {
                validations.AddRange(ValidateGridSize(input.First()));
            }

            if (input.Count <= NumberOfInstructionsInSet)
            {
                validations.Add(InvalidNumberofInstructionsMsg);
            }

            if (!input.Count.IsOddNumber())
            {
                validations.Add(InvaliidInputMsg);
            }

            return validations;
        }


        public List<string> ValidateInitialState(string initPos)
        {
            var validations = new List<string>();

            var instructions = initPos.Split(' ');

            if (instructions.Length != 3)
            {
                validations.Add("Input is invalid. There should be 2 co-ordinates (x and y) and initial direction");
                return validations;
            }

            validations.AddRange(ValidateCoOrdinates(instructions[0], instructions[1]));

            //Direction d = instructions[2]
           

            return validations;
        }

        public List<string> ValidateMoves(string moves)
        {
            var validations = new List<string>();

            moves = moves.Trim();
            int tot = CountMoves(moves, 'M') + CountMoves(moves, 'L') + CountMoves(moves, 'R');
            if(tot != moves.Length)
            {
                validations.Add("Invalid characters in moves input.");
            }
            return validations;
        }

        public List<string> ValidateGridSize(string gridSize)
        {
            var validations = new List<string>();

            var size = gridSize.Split(' ');

            if (size.Length != 2)
            {
                validations.Add("Grid size input is invalid. There should be 2 co-ordinates x and y");
                return validations;
            }

            validations.AddRange(ValidateCoOrdinates(size[0], size[1]));

            return validations;

        }

        private int CountMoves(string moves, char move)
        {
            return moves.ToUpper().Count(m => m == move);
        }

        private List<string> ValidateCoOrdinates(string x, string y)
        {
            int coOrd;
            var validations = new List<string>();

            if (!int.TryParse(x, out coOrd))
            {
                validations.Add("Grid size input is invalid. Co-Ordinate X should be an integer.");
            }

            if (!int.TryParse(y, out coOrd))
            {
                validations.Add("Grid size input is invalid. Co-Ordinate Y should be an integer.");
            }

            return validations;
        }

        public CoOrdinates SetGridSize(string gridSize)
        {
            var size = gridSize.Split(' ');

            return new CoOrdinates(Convert.ToInt32(size[0]), Convert.ToInt32(size[1]));
        }

        public List<Tuple<RoverState, string>> GetRoverInstructions(List<string> input)
        {
            var instructions = new List<Tuple<RoverState, string>>();

            //skip initial size of grid
            List<string> instructionInput = input.Skip(1).ToList();

            while (instructionInput.Any())
            {
                var instructionSet = instructionInput.Take(NumberOfInstructionsInSet).ToList();

                var roverState = new RoverState();
                string initialPos = instructionSet.First().ToString();

                var posItems = initialPos.Split(' ');

                roverState.RoverPosition.X = Convert.ToInt32(posItems[0]);
                roverState.RoverPosition.Y = Convert.ToInt32(posItems[1]);

                roverState.RoverDirection = (Direction)posItems[2].GetDirection();

                string moves = instructionSet.Last();
                var instruction = new Tuple<RoverState, string>(roverState, moves);
                instructions.Add(instruction);

                instructionInput = instructionInput.Skip(NumberOfInstructionsInSet).ToList();

            }

            return instructions;
        }
    }
}
