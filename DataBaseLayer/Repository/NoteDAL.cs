using DataBaseLayer.Context;
using DataBaseLayer.Interface;
using ModelLayer.DTO.Notes;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Repository
{
    public class NoteDAL : INoteDAL
    {
        private UserDbContext _context;

        public NoteDAL(UserDbContext context)
        {
            _context = context;
        }

        public bool ArchiveNote(int notesId, int userId)
        {
            Notes note = _context.Notes.FirstOrDefault(x =>x.NotesId == notesId && x.UserId == userId);

            if (note == null)
            {
                return false;
            }

            note.IsArchive = true;

            _context.SaveChanges();

            return true;
        }

        public NoteResponse CreateNote(CreateNoteRequest createNoteRequest, int userId)
        {
            Notes note = new Notes()
            {
                Title = createNoteRequest.Title,
                Description = createNoteRequest.Description,
                Reminder = createNoteRequest.Reminder,
                Colour = createNoteRequest.Colour,
                Image = createNoteRequest.Image,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                UserId = userId

            };
            _context.Notes.Add(note);
            _context.SaveChanges();
            return new NoteResponse()
            {
                NotesId = note.NotesId,
                Title = note.Title,
                Description = note.Description,
                Reminder = note.Reminder,
                Colour = note.Colour,
                Image = note.Image,
                IsArchive = note.IsArchive,
                IsPin = note.IsPin,
                IsTrash = note.IsTrash,
                CreatedAt = note.CreatedAt,
                UpdatedAt = note.UpdatedAt,
                UserId = note.UserId
            };

        }

        public bool DeleteNote(int notesId, int userId)
        {
            Notes note = _context.Notes.FirstOrDefault(x =>x.NotesId == notesId && x.UserId == userId);
            if (note == null)
            {
                return false;
            }
            _context.Notes.Remove(note);
            _context.SaveChanges();
            return true;
        }

        public List<NoteResponse> GetAllNotes(int userId)
        {
            List<Notes> notes = _context.Notes.Where(x => x.UserId == userId).ToList();

            List<NoteResponse> response = new List<NoteResponse>();
            foreach (var note in notes)
            {
                response.Add(new NoteResponse
                {
                    NotesId = note.NotesId,
                    Title = note.Title,
                    Description = note.Description,
                    Reminder = note.Reminder,
                    Colour = note.Colour,
                    Image = note.Image,
                    IsArchive = note.IsArchive,
                    IsPin = note.IsPin,
                    IsTrash = note.IsTrash,
                    CreatedAt = note.CreatedAt,
                    UpdatedAt = note.UpdatedAt,
                    UserId = note.UserId
                });
            }
            return response;
        }

        public List<NoteResponse> GetArchivedNotes(int userId)
        {
            List<Notes> notes = _context.Notes.Where(x => x.UserId == userId && x.IsArchive == true).ToList();

            List<NoteResponse> response = new List<NoteResponse>();

            foreach (var note in notes)
            {
                response.Add(new NoteResponse
                {
                    NotesId = note.NotesId,
                    Title = note.Title,
                    Description = note.Description,
                    Reminder = note.Reminder,
                    Colour = note.Colour,
                    Image = note.Image,
                    IsArchive = note.IsArchive,
                    IsPin = note.IsPin,
                    IsTrash = note.IsTrash,
                    CreatedAt = note.CreatedAt,
                    UpdatedAt = note.UpdatedAt,
                    UserId = note.UserId
                });
            }

            return response;
        }

        public NoteResponse GetNoteById(int notesId, int userId)
        {
            Notes note = _context.Notes.FirstOrDefault(x => x.NotesId == notesId && x.UserId == userId);
            if (note == null)
            {
                return null;
            }
            return new NoteResponse
            {
                NotesId = note.NotesId,
                Title = note.Title,
                Description = note.Description,
                Reminder = note.Reminder,
                Colour = note.Colour,
                Image = note.Image,
                IsArchive = note.IsArchive,
                IsPin = note.IsPin,
                IsTrash = note.IsTrash,
                CreatedAt = note.CreatedAt,
                UpdatedAt = note.UpdatedAt,
                UserId = note.UserId
            };

        }

        public List<NoteResponse> GetTrashedNotes(int userId)
        {

            List<Notes> notes = _context.Notes
                .Where(x => x.UserId == userId && x.IsTrash == true)
                .ToList();

            List<NoteResponse> response = new List<NoteResponse>();

            foreach (var note in notes)
            {
                response.Add(new NoteResponse
                {
                    NotesId = note.NotesId,
                    Title = note.Title,
                    Description = note.Description,
                    Reminder = note.Reminder,
                    Colour = note.Colour,
                    Image = note.Image,
                    IsArchive = note.IsArchive,
                    IsPin = note.IsPin,
                    IsTrash = note.IsTrash,
                    CreatedAt = note.CreatedAt,
                    UpdatedAt = note.UpdatedAt,
                    UserId = note.UserId
                });
            }

            return response;
        }

        public bool MoveToTrash(int notesId, int userId)
        {
            Notes note = _context.Notes.FirstOrDefault(x => x.NotesId == notesId && x.UserId == userId);
            if (note == null)
            {
                return false;
            }
            note.IsTrash = true;
            _context.SaveChanges();
            return true;

        }

        public bool RestoreNote(int notesId, int userId)
        {
            Notes note = _context.Notes.FirstOrDefault(x =>x.NotesId == notesId && x.UserId == userId);

            if (note == null)
            {
                return false;
            }

            note.IsTrash = false;

            _context.SaveChanges();

            return true;
        }

        public NoteResponse UpdateNote(int notesId, int userId, UpdateNoteRequest updateNoteRequest)
        {
            Notes note = _context.Notes
        .FirstOrDefault(x => x.NotesId == notesId && x.UserId == userId);

            if (note == null)
            {
                return null;
            }
            note.Title = updateNoteRequest.Title;
            note .Description = updateNoteRequest.Description;
            note.Reminder = updateNoteRequest.Reminder;
            note.Colour= updateNoteRequest.Colour;
            note.Image = updateNoteRequest.Image;
            note.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();

            return new NoteResponse
            {
                NotesId = note.NotesId,
                Title = note.Title,
                Description = note.Description,
                Reminder = note.Reminder,
                Colour = note.Colour,
                Image = note.Image,
                IsArchive = note.IsArchive,
                IsPin = note.IsPin,
                IsTrash = note.IsTrash,
                CreatedAt = note.CreatedAt,
                UpdatedAt = note.UpdatedAt,
                UserId = note.UserId
            };
        }

        
    }  
}   
