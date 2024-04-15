using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FogSoft.EF.Library.Entities
{
    /// <summary>
    /// Задача. Может быть назначена на <see cref="User"/>, а может быть ни на кого не назначена.
    /// </summary>
    [Table("Tasks")]
    public class Task
    {
        [Key]
        public long Id { get; set; }

        [Column, Required]
        public string? Subject { get; set; }

        [Column]
        public string? Description { get; set; }

        public List<User>? Users { get; set; } = new ();
        
    }
}