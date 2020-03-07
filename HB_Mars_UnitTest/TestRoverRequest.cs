using System;
using System.Collections.Generic;
using System.Text;
using HB_Mars.Helper.Models;

namespace HB_Mars_UnitTest
{
    public class TestRoverRequest : RoverRequest
    {
        public int ExpectedXCoordinate { get; set; }
        public int ExpectedYCoordinate { get; set; }
        public string ExpectedFace { get; set; }
    }
}
