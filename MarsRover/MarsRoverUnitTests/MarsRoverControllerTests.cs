using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MarsRoverExercise;

namespace MarsRoverUnitTests
{
    [TestClass]
    public class MarsRoverControllerTests
    {

        private List<string> TestInput
        {
            get
            {
                var input = new List<string>();
                input.Add("5 5");
                input.Add("1 2 N");
                input.Add("LMLMLMLMM");

                input.Add("3 3 E");
                input.Add("MMRMMRMRRM");

                return input;
            }
        }


        [TestMethod]
        public void GetRoverInstructionsTest()
        {
            MarsRoverController controller = new MarsRoverController();

            var instructions = controller.GetRoverInstructions(TestInput);

            Assert.AreEqual(2, instructions.Count);

            var rover1InitialState = instructions[0].Item1;

            Assert.AreEqual(1, rover1InitialState.RoverPosition.X);

            Assert.AreEqual(2, rover1InitialState.RoverPosition.Y);

            Assert.AreEqual(Direction.N, rover1InitialState.RoverDirection);

            var rover1Moves = instructions[0].Item2;

            Assert.AreEqual("LMLMLMLMM", rover1Moves);


            var rover2InitialState = instructions[1].Item1;

            Assert.AreEqual(3, rover2InitialState.RoverPosition.X);

            Assert.AreEqual(3, rover2InitialState.RoverPosition.Y);

            Assert.AreEqual(Direction.E, rover2InitialState.RoverDirection);

            var rover2Moves = instructions[1].Item2;

            Assert.AreEqual("MMRMMRMRRM", rover2Moves);

        }
    }
}
