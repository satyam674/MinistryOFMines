using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryMines.Models
{
    public class Title
    {
        [Key]
        public int Id { get; set; }
        public string TitleName { get; set; }
      


    }
}
