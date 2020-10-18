using System;

namespace Blog.Model.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            IsDeleted = false;
            CreatedDate = DateTime.Now;
            EditedDate = DateTime.Now;
        }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatorId { get; set; }

        public DateTime EditedDate { get; set; }

        public int EditorId { get; set; }
    }
}
