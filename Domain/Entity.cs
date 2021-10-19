using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
        //public Guid CreatedBy { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public Guid? UpdatedBy { get; set; }
        //public DateTime? UpdatedAt { get; set; }
    }
}
