using ModelLayer.DTO.Collaborator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Interface
{
    public interface ICollaboratorDAL
    {
        bool AddCollaborator(int noteId, int ownerUserId, AddCollaboratorRequest request);
        List<CollaboratorResponse> GetCollaborators(int noteId, int ownerUserId);
        bool RemoveCollaborator(int noteId, int ownerUserId, int collaboratorUserId);
        List<SharedNoteResponse> GetSharedNotes(int collaboratorUserId);
    }
}
