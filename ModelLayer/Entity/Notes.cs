using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entity
{
   
        public class Notes
        {
          
            public int NotesId { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }

            public DateTime? Reminder { get; set; }

            public string Colour { get; set; } = "#ffffff";

            public string Image { get; set; }

            public bool IsArchive { get; set; } = false;

            public bool IsPin { get; set; } = false;

            public bool IsTrash { get; set; } = false;

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

            public int UserId { get; set; }

            public User User { get; set; }

        
        }
}  



