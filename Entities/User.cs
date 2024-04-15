using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FogSoft.EF.Library.Entities
{
    /// <summary>
	/// Пользователь. Сейчас исполнитель задачи, а в будущем может использоваться и для других целей.
	/// </summary>
    [Table("Users")]
    public class User
    {

        [Key]
        public long Id { get; set; }

        [Column, Required]
        public string? Name { get; set; }

        public List<Task>? Tasks { get; set; } = new();
    }
}
