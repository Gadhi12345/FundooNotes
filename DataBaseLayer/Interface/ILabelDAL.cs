using ModelLayer.DTO.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Interface
{
    public interface ILabelDAL
    {
        LabelResponse CreateLabel(CreateLabelRequest request, int userId);
        LabelResponse UpdateLabel(UpdateLabelRequest request, int userId);
        bool DeleteLabel(int labelId, int userId);
        bool AddLabelToNote(AddLabelToNoteRequest request, int userId);

        bool RemoveLabelFromNote(RemoveLabelFromNoteRequest request, int userId);
    }
}
