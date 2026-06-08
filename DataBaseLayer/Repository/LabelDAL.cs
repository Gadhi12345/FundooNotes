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
    public class LabelDAL : ILabelDAL
    {

        private readonly UserDbContext _context;

        public LabelDAL(UserDbContext context)
        {
            _context = context;
        }

        public LabelResponse CreateLabel(CreateLabelRequest request, int userId)
        {
            Label label = new Label();
            label.LabelName = request.LabelName;
            label.UserId = userId;
            _context.Labels.Add(label);
            _context.SaveChanges();

            return new LabelResponse
            {
                LabelId = label.LabelId,
                LabelName = label.LabelName,
                CreatedAt = label.CreatedAt
            };
        }

        public bool DeleteLabel(int labelId, int userId)
        {
            Label label = _context.Labels
                          .FirstOrDefault(l => l.LabelId == labelId
                                            && l.UserId == userId);

            if (label == null)
            {
                return false;
            }

            _context.Labels.Remove(label);
            _context.SaveChanges();

            return true;
        }

        public LabelResponse UpdateLabel(UpdateLabelRequest request, int userId)
        {
            Label label = _context.Labels
                         .FirstOrDefault(l => l.LabelId == request.LabelId
                                           && l.UserId == userId);

            if (label == null)
            {
                return null;
            }

            label.LabelName = request.LabelName;
            label.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();

            return new LabelResponse
            {
                LabelId = label.LabelId,
                LabelName = label.LabelName,
                CreatedAt = label.CreatedAt
            };
        }
    }
}
