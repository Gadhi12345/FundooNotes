using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entity
{
    public class Label
    {

        [Key]
        public int LabelId { get; set; }
        public string LabelName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<NoteLabel> NoteLabels { get; set; }

    }
}
