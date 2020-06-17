using System;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork.Interfaces;

namespace BLL.Services
{
    public class PoliceDepartmentService : IPoliceDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PoliceDepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(
                              nameof(unitOfWork));
        }

        public async Task<PoliceDepartmentDTO> GetPoliceDepartmentAsync(Guid id)
        {
            var department = await GetByIdAsync(id);

            return new PoliceDepartmentDTO()
            {
                Id = department.Id,
                Employees = department.Employees,
                Name = department.Name,
                RegionId = department.RegionId
            };
        }

        public async Task<PoliceDepartmentDTO> AddPoliceDepartmentAsync(PoliceDepartmentDTO policeDepartment)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var entity = new PoliceDepartment()
            {
                Employees = policeDepartment.Employees,
                Name = policeDepartment.Name,
                RegionId = policeDepartment.RegionId
            };
            var result = await _unitOfWork.InsertAsync(entity);
            await _unitOfWork.CommitAsync();

            return new PoliceDepartmentDTO()
            {
                Id = result.Id,
                Employees = result.Employees,
                Name = result.Name,
                RegionId = result.RegionId
            };
        }

        public async Task RemovePoliceDepartmentAsync(Guid id)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var local = await GetByIdAsync(id);
            _unitOfWork.Remove(local);
            await _unitOfWork.CommitAsync();
        }

        private async Task<PoliceDepartment> GetByIdAsync(Guid id)
        {
            var region = await _unitOfWork.GetByIdAsync<PoliceDepartment>(id);

            if (region == null)
            {
                throw new Exception("Police department with following id was not found");
            }

            return region;
        }
    }
}