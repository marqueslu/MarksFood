using System;

namespace MarksFoodApi.Domain.Commands.Results
{
    public class RegisterAndUpdateOutput
    {
        public RegisterAndUpdateOutput()
        {

        }
       
        public bool Success { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }
    }
}
