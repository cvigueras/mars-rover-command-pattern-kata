using FluentAssertions;

namespace MarsRover.Test
{
    public class RemotelyControlShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PlaceRoverInInitialPosition()
        {
            var result = RemotelyControl.GetInitialPosition();
            
            result.Should().Be("1,1");
        }
    }

    public class RemotelyControl
    {
        public static object GetInitialPosition()
        {
            throw new NotImplementedException();
        }
    }
}