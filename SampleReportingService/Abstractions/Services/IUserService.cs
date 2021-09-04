using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Dtos;
using Abstractions.Results;

namespace Abstractions.Services
{
    public interface IUserService:IBusinessService
    {
        Task<IDataResult<UserDto>> GetByIdAsync(long id);
        Task<IDataResult<List<UserDto>>> GetListAsync();
        Task<IDataResult<UserDto>> InsertAsync(UserDto user);

        Task<IDataResult<UserDto>> UpdateAsync(UserDto user);

        Task<IResult> DeleteAsync(long id);
    }
}
