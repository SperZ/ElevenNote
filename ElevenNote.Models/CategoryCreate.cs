using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryCreate
    {
        [Required]
        [MinLength(5, ErrorMessage ="The Category name must be at least five characters long")]
        [MaxLength(100, ErrorMessage = "The Category name cannot be over 100 characteres")]
        public string Name { get; set; }
    }
}
