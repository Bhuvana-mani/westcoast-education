using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Teacher",Schema="Staff")]
    public class Staff
    {
        public int Id { get; set; }
         [Column(TypeName = "VARCHAR(80)")]
         public string FirstName { get; set; }
        [Column(TypeName = "VARCHAR(40)")]
        public string LastName { get; set; }
        [Column(TypeName = "VARCHAR(15)")]
        public string Address { get; set; }
       
        [Column(TypeName = "VARCHAR(60)")]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public string Phone { get; set; }
         [Column(TypeName = "VARCHAR(30)")]
        public string Subject { get; set; }
       [Column(TypeName = "VARCHAR(128)")]
       public string UserName { get; set; }
    }
}