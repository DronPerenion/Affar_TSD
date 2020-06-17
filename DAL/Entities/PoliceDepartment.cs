using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class PoliceDepartment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid RegionId { get; set; }
        public Region Region { get; set; }
        public ICollection<Affair> Affairs { get; set; }
        public string Name { get; set; }
        public uint Employees { get; set; }
    }
}
