using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public int? CatId { get; set; } //this cannot have the same name as the Id in the foreign key it is referencing
        [ForeignKey(nameof(CatId))]// 1 to many relationship 1 category to many notes
        public virtual Category Category { get; set; } // GIVES US ACCESS TO POINT TO ANY PROPERTY WITHIN THE Category class by using note.Category.Name
    }
}
