using BussinessLogicLayer.Interface;
using DataBaseLayer.Interface;
using ModelLayer.DTO.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Services
{
    public class LabelBLL : ILabelBLL
    {
        private readonly ILabelDAL _labelDAL;

        public LabelBLL(ILabelDAL labelDAL)
        {
            _labelDAL = labelDAL;
        }

        public LabelResponse CreateLabel(CreateLabelRequest request, int userId)
        {
            return _labelDAL.CreateLabel(request, userId);
        }

        public LabelResponse UpdateLabel(UpdateLabelRequest request, int userId)
        {
            return _labelDAL.UpdateLabel(request, userId);
        }

        public bool DeleteLabel(int labelId, int userId)
        {
            return _labelDAL.DeleteLabel(labelId, userId);
        }

        public bool AddLabelToNote(AddLabelToNoteRequest request, int userId)
        {
            return _labelDAL.AddLabelToNote(request, userId);
        }

        public bool RemoveLabelFromNote(RemoveLabelFromNoteRequest request, int userId)
        {
            return _labelDAL.RemoveLabelFromNote(request, userId);
        }
    }
}
