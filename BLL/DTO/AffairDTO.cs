using System;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Entities;

namespace BLL.DTO
{
    public class AffairDTO
    {
        public Guid Id { get; set; }
        public Guid PoliceDepartmentId { get; set; }
        public string Description { get; set; }
        public int Section { get; set; }
        public int Paragraph { get; set; }
    }
}