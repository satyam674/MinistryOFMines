using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryMines.Models
{
    public class User_Detail
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Title")]
        public string title { get; set; }
        [DisplayName(" Name")]
        [Required]
        public string name { get; set; }
        [DisplayName("Gender")]
        public string gender { get; set; }
        [DisplayName("Email")]
        [Required]
        public string email { get; set; }
        [DisplayName("Date Of Birth")]
        [Required]
        public DateTime dob { get; set; }
        [DisplayName("Permanent State ")]
        public int state_1 { get; set; }
        [DisplayName("Permanent District Name")]
        public int district_1 { get; set; }
        [DisplayName("Permanent Address  Name")]
        [Required]
        public string address_1 { get; set; }
        [DisplayName("Correspondence State")]
        public int state_2 { get; set; }
        [DisplayName("Correspondence District")]
        public int district_2 { get; set; }
        [Required]
        [DisplayName("Correspondence Address Name")]
        public string address_2 { get; set; }
        public string ImagePath { get; set; }
        [DisplayName("Image Name")]
        [Required]
        [NotMapped]
        public IFormFile image { get; set; }
    }
}
