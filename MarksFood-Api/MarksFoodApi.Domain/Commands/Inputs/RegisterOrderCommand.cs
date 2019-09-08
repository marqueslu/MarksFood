using MarksFoodApi.Shared.Commands;
using System.Collections.Generic;

namespace MarksFoodApi.Domain.Commands.Inputs
{
    class RegisterOrderCommand : ICommand
    {
        public IEnumerable<RegisterSnackCommand> Items { get; set; }
    }
}
