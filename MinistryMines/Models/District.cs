using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryMines.Models
{
    public class District
    {

        [Key]
        public int District_Id { get; set; }
        public string District_Name { get; set; }
        public State State { get; set; }
    }
}
