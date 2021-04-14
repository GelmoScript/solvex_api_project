using System;
namespace Popip.Infrastructure.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DetetedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string FullName { get; set; }
    }
}
