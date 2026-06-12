using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO.Collaborator
{
    public class SharedNoteResponse
    {
        public int NoteId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
