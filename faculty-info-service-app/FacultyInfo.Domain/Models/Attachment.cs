using FacultyInfo.Domain.Enums.Attachment;

namespace FacultyInfo.Domain.Models
{
    public class Attachment : Entity
    {
        public string OriginalName { get; set; }
        public string Url { get; set; }
        public AttachmentType AttachmentType { get; set; }
        public Guid? PostId { get; set; }
        public Post Post { get; set; }
        public Guid? CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
