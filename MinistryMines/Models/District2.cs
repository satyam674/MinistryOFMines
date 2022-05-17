using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryMines.Models
{
    public class District2
    {

        [Key]
        public int Dis_Id { get; set; }
        public string Dis_Name { get; set; }
        public State2 State2 { get; set; }
    }
}
