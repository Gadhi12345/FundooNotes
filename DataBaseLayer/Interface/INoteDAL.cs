using ModelLayer.DTO.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Interface
{
    public interface INoteDAL
    {
        NoteResponse CreateNote(CreateNoteRequest createNoteRequest, int userId);
        NoteResponse UpdateNote(int notesId, int userId, UpdateNoteRequest updateNoteRequest);
        List<NoteResponse> GetAllNotes(int userId);
        NoteResponse GetNoteById(int notesId, int userId);
        bool DeleteNote(int notesId,int userId);
        bool MoveToTrash(int notesId,int userId);
        List<NoteResponse> GetTrashedNotes(int userId);
    }
}
