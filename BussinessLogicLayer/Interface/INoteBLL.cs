using ModelLayer.DTO.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Interface
{
    public interface INoteBLL
    {
        NoteResponse CreateNote(CreateNoteRequest createNoteRequest, int userId);
        NoteResponse UpdateNote(int notesId,int userId,UpdateNoteRequest updateNoteRequest);
        List<NoteResponse> GetAllNotes(int userId);
        NoteResponse GetNoteById(int notesId, int userId);
        bool DeleteNote(int notesId,int userId);
        bool MoveToTrash(int  notesId,int userId);
        List<NoteResponse> GetTrashedNotes(int userId);
        bool RestoreNote(int notesId, int userId);
        bool ArchiveNote(int notesId, int userId);
        List<NoteResponse> GetArchivedNotes(int userId);
        bool PinNote(int notesId, int userId);
    }
}

