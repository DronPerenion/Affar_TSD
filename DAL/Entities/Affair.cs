using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Affair
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public PoliceDepartment PoliceDepartment { get; set; }
        public Guid PoliceDepartmentId { get; set; }
        public string Description { get; set; }
        public int Section { get; set; }
        public int Paragraph { get; set; }

    }
}