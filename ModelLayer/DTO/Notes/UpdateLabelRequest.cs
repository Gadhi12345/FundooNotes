using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO.Notes
{
    public class UpdateLabelRequest
    {
        public int LabelId { get; set; }
        public string LabelName { get; set; }
    }
}
