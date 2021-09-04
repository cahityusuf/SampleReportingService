using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Data;
using Abstractions.Dtos;
using Abstractions.Results;
using Abstractions.Services;
using Application.Constants;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<UserDto>> GetByIdAsync(long id)
        {
            try
            {
                if (id == 0) return new ErrorDataResult<UserDto>(Messages.InvalidId);

                var _users = _unitOfWork.GetRepository<User>();

                var result = await _users.GetFirstOrDefaultAsync(predicate: p => p.Id == id,
                                                                    include: i => i.Include(c => c.ContactInfo)
                                                                                                .ThenInclude(t => t.ContactType));

                if (result != null)
                {
                    return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(result));
                }

                return new ErrorDataResult<UserDto>(Messages.Error);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<IDataResult<List<UserDto>>> GetListAsync()
        {
            var _users = _unitOfWork.GetRepository<User>();

            var result = await _users.GetAllAsync();

            if (result != null)
            {
                return new SuccessDataResult<List<UserDto>>(_mapper.Map<List<UserDto>>(result));
            }

            return new ErrorDataResult<List<UserDto>>(Messages.Error);
        }

        public async Task<IDataResult<UserDto>> InsertAsync(UserDto user)
        {
            if (user == null) return new ErrorDataResult<UserDto>(Messages.InvalidId);

            var _users = _unitOfWork.GetRepository<User>();

            var result = await _users.InsertAsync(_mapper.Map<User>(user));

            if (result != null)
            {
                var save = await _users.SaveChangesAsync();

                if (save > 0)
                {
                    return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(result));
                }

            }

            return new ErrorDataResult<UserDto>(Messages.Error);
        }

        public async Task<IDataResult<UserDto>> UpdateAsync(UserDto user)
        {
            if (user == null) return new ErrorDataResult<UserDto>(Messages.InvalidId);

            var _users = _unitOfWork.GetRepository<User>();

            _users.Update(_mapper.Map<User>(user));

            var result = await _users.SaveChangesAsync();

            if (result != 0)
            {
                return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(result));
            }

            return new ErrorDataResult<UserDto>(Messages.Error);
        }

        public async Task<IResult> DeleteAsync(long id)
        {
            if (id == 0) return new ErrorResult(Messages.InvalidId);

            var _users = _unitOfWork.GetRepository<User>();

            _users.Delete(id);

            var result = await _users.SaveChangesAsync();

            if (result != 0)
            {
                return new Result(true);
            }

            return new ErrorResult(Messages.Error);
        }
    }
}
