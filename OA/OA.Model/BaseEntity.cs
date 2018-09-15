using System.ComponentModel.DataAnnotations;

namespace OA.Model {
    public class BaseEntity {
        [Key]
        public int Id { get; set; }
    }
}
