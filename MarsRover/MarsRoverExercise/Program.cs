using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string s;
                List<string> input = new List<string>();
                var controller = new MarsRoverController();

                Console.WriteLine("Enter 2 integers (separated by space) to specify size of exploration grid. Then press Enter.");
                string gridSize = Console.ReadLine();

                var validations = controller.ValidateGridSize(gridSize);
                if(ProcessValidations(validations))
                {
                    return;
                }

                input.Add(gridSize);


                do
                {
                    Console.WriteLine("Enter 3 values (2 integers and a letter, each separated by a space) to specify grid co-ordinates and cardinal direction (N, E, S, W) . Then press Enter.");
                    string startPos = Console.ReadLine();

                    validations = controller.ValidateInitialState(startPos);                   
                    if (ProcessValidations(validations))
                    {
                        return;
                    }
                    input.Add(startPos);

                    Console.WriteLine("Enter any number of mars rover moves. ('L' left, 'R' right, 'M' move one grid square.  Then press Enter.");
                    string moves = Console.ReadLine();
                    validations = controller.ValidateMoves(moves);
                    if (ProcessValidations(validations))
                    {
                        return;
                    }
                    input.Add(moves);

                    Console.WriteLine("Type 'GO' and hit enter to move rovers inputted so far or just enter to input another rover.");

                    s = Console.ReadLine();
                }
                while (s != "GO");

                //validate entire input.
                validations = controller.Validate(input);
                if (ProcessValidations(validations))
                {
                    return;
                }               
                
               
                var roverInstructions = controller.GetRoverInstructions(input);

                foreach (var roverInstruction in roverInstructions)
                {
                    var roverIntialState = roverInstruction.Item1;
                    var rover = new MarsRoverBuggy(roverIntialState);
                    Console.WriteLine(rover.ProcessMoveInstructions(roverInstruction.Item2));
                }

                Console.WriteLine("End of Processing. Hit any key to exit.");
                Console.ReadKey();


            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Unexpected exception {0}. Fix error and restart to try again."), e.Message);
            }
           
        }

        private static bool ProcessValidations(List<string> validations)
        {
            if (validations.Any())
            {
                foreach (var v in validations)
                {
                    Console.WriteLine(v);
                }
                Console.WriteLine("End of Processing. Hit any key to exit.");
                Console.ReadKey();
                return true;
            }
            return false;
        }
    }
}
