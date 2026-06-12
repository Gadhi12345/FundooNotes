using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO.Collaborator
{
    public class CollaboratorResponse
    {
        public int CollaboratorId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
