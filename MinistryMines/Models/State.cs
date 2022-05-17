using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryMines.Models
{
    public class State
    {
        [Key]
        public int State_Id { get; set; }
        public string St_Name { get; set; }
     
    }
}
