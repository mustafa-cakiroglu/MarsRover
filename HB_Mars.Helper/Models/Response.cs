using System;

namespace HB_Mars.Helper.Models
{
    public class ResponseModel
    {
        public Position Position{ get; set; }
        public Exception Exception { get; set; }
        public bool IsError { get; set; }
    }
}
