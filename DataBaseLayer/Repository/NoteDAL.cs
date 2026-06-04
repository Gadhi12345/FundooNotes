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
                UpdatedAt=DateTime.UtcNow,
                UserId= userId

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
    }
}
