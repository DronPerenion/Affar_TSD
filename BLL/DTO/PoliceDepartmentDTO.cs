using System;
using DAL.Entities;

namespace BLL.DTO
{
    public class PoliceDepartmentDTO
    {
        public Guid Id { get; set; }
        public Guid RegionId { get; set; }
        public Region Region { get; set; }
        public string Name { get; set; }
        public uint Employees { get; set; }
    }
}