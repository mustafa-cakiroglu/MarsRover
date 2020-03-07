namespace HB_Mars.Helper.Models
{
    public class RoverRequest
    {
        public int TopPositionX { get; set; }
        public int TopPositionY { get; set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public string CurrentFacing { get; set; }
        public int SecondRoverX { get; set; }
        public int SecondRoverY { get; set; }
        public string SecondFacing { get; set; }
        public string Direction { get; set; }
        public string SecondDirection { get; set; }

    }
}
