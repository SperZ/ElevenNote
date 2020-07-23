﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryListItem
    {
        [Display(Name ="CategoryId")]
        public int CategoryId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
