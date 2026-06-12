using BussinessLogicLayer.Interface;
using DataBaseLayer.Interface;
using ModelLayer.DTO.Collaborator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Services
{
    public class CollaboratorBLL : ICollaboratorBLL
    {
        private readonly ICollaboratorDAL _collaboratorDAL;
        public CollaboratorBLL(ICollaboratorDAL collaboratorDAL)
        {
            _collaboratorDAL= collaboratorDAL;
        }
        public bool AddCollaborator(int noteId, int ownerUserId, AddCollaboratorRequest request)
        {
            return _collaboratorDAL.AddCollaborator(noteId, ownerUserId, request);
        }

        public List<CollaboratorResponse> GetCollaborators(int noteId, int ownerUserId)
        {
            return _collaboratorDAL.GetCollaborators(noteId, ownerUserId);
        }

        public List<SharedNoteResponse> GetSharedNotes(int collaboratorUserId)
        {
            return _collaboratorDAL.GetSharedNotes(collaboratorUserId);
        }

        public bool RemoveCollaborator(int noteId, int ownerUserId, int collaboratorUserId)
        {
           return _collaboratorDAL.RemoveCollaborator(noteId,ownerUserId, collaboratorUserId);
        }
    }
}
