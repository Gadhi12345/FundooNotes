using BussinessLogicLayer.Interface;
using DataBaseLayer.Context;
using DataBaseLayer.Interface;
using ModelLayer.DTO.Notes;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Services
{
    public class NoteBLL : INoteBLL
    {
        private readonly INoteDAL _noteDAL;

        public NoteBLL(INoteDAL noteDAL)
        {
            _noteDAL = noteDAL;
        }

        public NoteResponse CreateNote(CreateNoteRequest createNoteRequest, int userId)
        {
            return _noteDAL.CreateNote(createNoteRequest, userId);
        }

        public NoteResponse UpdateNote(int notesId, int userId, UpdateNoteRequest updateNoteRequest)
        {
            return _noteDAL.UpdateNote(notesId, userId, updateNoteRequest);
        }
    }
}
