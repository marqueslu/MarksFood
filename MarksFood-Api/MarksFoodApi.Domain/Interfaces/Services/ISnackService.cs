using MarksFoodApi.Domain.Commands.Inputs;
using MarksFoodApi.Domain.Commands.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarksFoodApi.Domain.Interfaces.Services
{
    public interface ISnackService
    {
        Task<RegisterAndUpdateOutput> Create(SnackInput snackInput);
        Task<RegisterAndUpdateOutput> Update(SnackInput snackInput);
        Task<IEnumerable<SnackOutput>> GetAllSnacks();
    }
}
