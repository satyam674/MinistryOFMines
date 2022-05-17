using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryMines.Models
{
    public class State2
    {
        [Key]
        public int S_Id { get; set; }
        public string State_Name { get; set; }

    }
}
