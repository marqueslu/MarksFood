using MarksFoodApi.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarksFoodApi.Domain.Commands.Results
{
    public class RegisterAndUpdateCommandResult : ICommandResult
    {
        public RegisterAndUpdateCommandResult()
        {

        }
       
        public bool Success { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }
    }
}
