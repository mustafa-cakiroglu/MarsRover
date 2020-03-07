using System;
using HB_Mars.Helper.Models;
using HB_Mars.Main;
using Xunit;

namespace HB_Mars_UnitTest
{
    public class RoverMovementUnitTest
    {

        [Theory, ClassData(typeof(RoverRequestTestTheoryData))]
        public void RoverMovement_ValidObjectPassed_ReturnedResponseModel(TestRoverRequest testRoverRequest)
        {

            var roverMovement = new RoverMovement();
            var responseModel = roverMovement.RoverMove(testRoverRequest);
            Assert.IsType<TestRoverRequest>(testRoverRequest);
            Assert.Equal(testRoverRequest.ExpectedFace, responseModel.Position.Face);
            Assert.Equal(testRoverRequest.ExpectedXCoordinate, responseModel.Position.xCoordinate);
            Assert.Equal(testRoverRequest.ExpectedYCoordinate, responseModel.Position.yCoordinate);
        }

        [Fact]
        public void RoverMovement_ShouldArgumentNullException_WhenTopPositionXIsNull()
        {
            var testRoverRequest =new TestRoverRequest
            {
                TopPositionX = 0,
                TopPositionY = 5,
                CurrentX = 1,
                CurrentY = 2,
                CurrentFacing = "N",
                Direction = "LMLMLMLMM",
                ExpectedFace = "N",
                ExpectedXCoordinate = 1,
                ExpectedYCoordinate = 3
            };

            var roverMovement = new RoverMovement();
            var result = Record.Exception(() => roverMovement.RoverMove(testRoverRequest));
            Assert.NotNull(result);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expectedErrorMessage = "TopPositionX with value 0 should be more than zero.";
            Assert.Equal(expectedErrorMessage, actual);
        }

        [Fact]
        public void RoverMovement_ShouldArgumentNullException_WhenTopPositionYIsNull()
        {
            var testRoverRequest = new TestRoverRequest
            {
                TopPositionX = 5,
                TopPositionY = 0,
                CurrentX = 1,
                CurrentY = 2,
                CurrentFacing = "N",
                Direction = "LMLMLMLMM",
                ExpectedFace = "N",
                ExpectedXCoordinate = 1,
                ExpectedYCoordinate = 3
            };

            var roverMovement = new RoverMovement();
            var result = Record.Exception(() => roverMovement.RoverMove(testRoverRequest));
            Assert.NotNull(result);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expectedErrorMessage = "TopPositionY with value 0 should be more than zero.";
            Assert.Equal(expectedErrorMessage, actual);
        }
    }

    public class RoverRequestTestTheoryData : TheoryData<RoverRequest>
    {
        public RoverRequestTestTheoryData()
        {
            Add(new TestRoverRequest
            {
                TopPositionX = 5,
                TopPositionY = 5,
                CurrentX = 1,
                CurrentY = 2,
                CurrentFacing = "N",
                Direction = "LMLMLMLMM",
                ExpectedFace = "N",
                ExpectedXCoordinate = 1,
                ExpectedYCoordinate = 3
            });

            Add(new TestRoverRequest
            {
                TopPositionX = 5,
                TopPositionY = 5,
                CurrentX = 3,
                CurrentY = 3,
                CurrentFacing = "E",
                Direction = "MMRMMRMRRM",
                ExpectedFace = "E",
                ExpectedXCoordinate = 5,
                ExpectedYCoordinate = 1
            });
        }
    }
}
