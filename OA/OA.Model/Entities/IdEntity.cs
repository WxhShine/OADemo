using System.ComponentModel.DataAnnotations;

namespace OA.Model {
    public class IdEntity {
        [Key]
        public int Id { get; set; }
    }
}