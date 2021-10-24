using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Department
{
    [Table("Department")]
    public class Department :Entity
    {
        public string DepartmentName { get; set; }
        public string DepartmentShortName { get; set; } 
    }
}
