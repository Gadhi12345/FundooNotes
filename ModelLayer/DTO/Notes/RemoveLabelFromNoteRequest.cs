using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO.Notes
{
    public class RemoveLabelFromNoteRequest
    {
        public int NoteId { get; set; }
        public int LabelId { get; set; }
    }
}
