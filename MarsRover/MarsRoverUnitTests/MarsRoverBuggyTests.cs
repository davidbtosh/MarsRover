using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverExercise;

namespace MarsRoverUnitTests
{
    [TestClass]
    public class MarsRoverBuggyTests
    {

        [TestMethod]
        public void MoveLeftTest()
        {
            RoverState initialState = new RoverState();
            initialState.RoverPosition.X = 0;
            initialState.RoverPosition.Y = 0;
            initialState.RoverDirection = Direction.N;

            MarsRoverBuggy buggy = new MarsRoverBuggy(initialState);

            buggy.TurnLeft();
            Assert.AreEqual(Direction.W, buggy.RoverState.RoverDirection);

            buggy.TurnLeft();
            Assert.AreEqual(Direction.S, buggy.RoverState.RoverDirection);

            buggy.TurnLeft();
            Assert.AreEqual(Direction.E, buggy.RoverState.RoverDirection);

            buggy.TurnLeft();
            Assert.AreEqual(Direction.N, buggy.RoverState.RoverDirection);

        }

        [TestMethod]
        public void MoveRightTest()
        {
            RoverState initialState = new RoverState();
            initialState.RoverPosition.X = 0;
            initialState.RoverPosition.Y = 0;
            initialState.RoverDirection = Direction.N;

            MarsRoverBuggy buggy = new MarsRoverBuggy(initialState);

            buggy.TurnRight();
            Assert.AreEqual(Direction.E, buggy.RoverState.RoverDirection);

            buggy.TurnRight();
            Assert.AreEqual(Direction.S, buggy.RoverState.RoverDirection);

            buggy.TurnRight();
            Assert.AreEqual(Direction.W, buggy.RoverState.RoverDirection);

            buggy.TurnRight();
            Assert.AreEqual(Direction.N, buggy.RoverState.RoverDirection);
        }


        [TestMethod]
        public void MoveForwardTest()
        {
            RoverState initialState = new RoverState();
            initialState.RoverPosition.X = 0;
            initialState.RoverPosition.Y = 0;
            initialState.RoverDirection = Direction.N;

            MarsRoverBuggy buggy = new MarsRoverBuggy(initialState);


            buggy.MoveForward();
            Assert.AreEqual(0, buggy.RoverState.RoverPosition.X);
            Assert.AreEqual(1, buggy.RoverState.RoverPosition.Y);
            Assert.AreEqual(Direction.N, buggy.RoverState.RoverDirection);

            buggy.MoveForward();
            Assert.AreEqual(0, buggy.RoverState.RoverPosition.X);
            Assert.AreEqual(2, buggy.RoverState.RoverPosition.Y);
            Assert.AreEqual(Direction.N, buggy.RoverState.RoverDirection);

            buggy.TurnRight();
            buggy.MoveForward();
            Assert.AreEqual(1, buggy.RoverState.RoverPosition.X);
            Assert.AreEqual(2, buggy.RoverState.RoverPosition.Y);
            Assert.AreEqual(Direction.E, buggy.RoverState.RoverDirection);

            buggy.MoveForward();
            Assert.AreEqual(2, buggy.RoverState.RoverPosition.X);
            Assert.AreEqual(2, buggy.RoverState.RoverPosition.Y);
            Assert.AreEqual(Direction.E, buggy.RoverState.RoverDirection);

            buggy.TurnLeft();
            buggy.MoveForward();
            Assert.AreEqual(2, buggy.RoverState.RoverPosition.X);
            Assert.AreEqual(3, buggy.RoverState.RoverPosition.Y);
            Assert.AreEqual(Direction.N, buggy.RoverState.RoverDirection);

            buggy.MoveForward();
            Assert.AreEqual(2, buggy.RoverState.RoverPosition.X);
            Assert.AreEqual(4, buggy.RoverState.RoverPosition.Y);
            Assert.AreEqual(Direction.N, buggy.RoverState.RoverDirection);

            buggy.TurnRight();
            buggy.TurnRight();
            buggy.MoveForward();
            Assert.AreEqual(2, buggy.RoverState.RoverPosition.X);
            Assert.AreEqual(3, buggy.RoverState.RoverPosition.Y);
            Assert.AreEqual(Direction.S, buggy.RoverState.RoverDirection);

            buggy.MoveForward();
            Assert.AreEqual(2, buggy.RoverState.RoverPosition.X);
            Assert.AreEqual(2, buggy.RoverState.RoverPosition.Y);
            Assert.AreEqual(Direction.S, buggy.RoverState.RoverDirection);
           


        }

       
    }
}
