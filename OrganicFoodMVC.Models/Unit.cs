﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrganicFoodMVC.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Tên đơn vị tính")]
        public string Name { get; set; }
    }
}
