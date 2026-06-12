using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entity
{
    public class Collaborator
    {
        [Key]
        public int CollaboratorId { get; set; }

        [ForeignKey("Notes")]
        public int NoteId { get; set; }

        public Notes Notes { get; set; }

        [ForeignKey("OwnerUser")]
        public int OwnerUserId { get; set; }

        public User OwnerUser { get; set; }

        [ForeignKey("CollaboratorUser")]
        public int CollaboratorUserId { get; set; }

        public User CollaboratorUser { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
