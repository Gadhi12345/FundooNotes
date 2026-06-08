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

        public bool DeleteNote(int noteId, int userId)
        {
            return _noteDAL.DeleteNote(noteId, userId);
        }
        public bool MoveToTrash(int notesId, int userId)
        {
            return _noteDAL.MoveToTrash(notesId, userId);
        }
        public List<NoteResponse> GetTrashedNotes(int userId)
        {
            return _noteDAL.GetTrashedNotes(userId);

        }


        public List<NoteResponse> GetAllNotes(int userId)
        {
            return _noteDAL.GetAllNotes(userId);
        }

        public NoteResponse GetNoteById(int notesId, int userId)
        {
            return _noteDAL.GetNoteById(notesId, userId);
        }


        public NoteResponse UpdateNote(int notesId, int userId, UpdateNoteRequest updateNoteRequest)
        {
            return _noteDAL.UpdateNote(notesId, userId, updateNoteRequest);
        }

        public bool RestoreNote(int notesId, int userId)
        {
            return _noteDAL.RestoreNote(notesId, userId);

        }

        public bool ArchiveNote(int notesId, int userId)
        {
            return _noteDAL.ArchiveNote(notesId, userId);
        }

        public List<NoteResponse> GetArchivedNotes(int userId)
        {
            return _noteDAL.GetArchivedNotes(userId);
        }
    }
}
