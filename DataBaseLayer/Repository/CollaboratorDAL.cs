using DataBaseLayer.Context;
using DataBaseLayer.Interface;
using Microsoft.EntityFrameworkCore;
using ModelLayer.DTO.Collaborator;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Repository
{
    public class CollaboratorDAL : ICollaboratorDAL
    {
        private readonly UserDbContext _context;
        public CollaboratorDAL(UserDbContext context)
        {
            _context = context;
        }
        public bool AddCollaborator(int noteId, int ownerUserId, AddCollaboratorRequest request)
        {
            var note = _context.Notes.FirstOrDefault(
         n => n.NotesId == noteId && n.UserId == ownerUserId);

            if (note == null)
            {
                return false;
            }

            var collaboratorUser = _context.Users.FirstOrDefault(
                u => u.Email == request.Email);

            if (collaboratorUser == null)
            {
                return false;
            }

            if (collaboratorUser.UserId == ownerUserId)
            {
                return false;
            }

            var existingCollaborator = _context.Collaborators.FirstOrDefault(
                c => c.NoteId == noteId &&
                     c.CollaboratorUserId == collaboratorUser.UserId);

            if (existingCollaborator != null)
            {
                return false;
            }

            var collaborator = new Collaborator
            {
                NoteId = noteId,
                OwnerUserId = ownerUserId,
                CollaboratorUserId = collaboratorUser.UserId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Collaborators.Add(collaborator);
            _context.SaveChanges();

            return true;
        }
    }
}
