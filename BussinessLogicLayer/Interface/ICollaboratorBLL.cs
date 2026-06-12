using ModelLayer.DTO.Collaborator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Interface
{
    public interface ICollaboratorBLL
    {
        bool AddCollaborator(int noteId, int ownerUserId, AddCollaboratorRequest request);
    }
}
