using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportingGroupAPI.Models
{
    public class Fixture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FixId { get; set; }
        public string Sport { get; set; }
        public string Name { get; set; }
    }
}
