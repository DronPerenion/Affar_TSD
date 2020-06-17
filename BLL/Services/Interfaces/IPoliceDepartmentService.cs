using System;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IPoliceDepartmentService
    {
        Task<PoliceDepartmentDTO> GetPoliceDepartmentAsync(Guid id);
        Task<PoliceDepartmentDTO> AddPoliceDepartmentAsync(PoliceDepartmentDTO policeDepartment);
        Task RemovePoliceDepartmentAsync(Guid id);
    }
}