using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeePayroll_ASP.NETMVC.Models
{
    public class Department
    {
        /// <summary>
        /// Gets or sets the dept identifier.
        /// </summary>
        /// <value>
        /// The dept identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }
        /// <summary>
        /// Gets or sets the name of the dept.
        /// </summary>
        /// <value>
        /// The name of the dept.
        /// </value>
        public string DeptName { get; set; }
    }
}