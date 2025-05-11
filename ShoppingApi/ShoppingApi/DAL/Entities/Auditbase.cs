using System.ComponentModel.DataAnnotations;

namespace ShoppingApi.DAL.Entities
{
    public class Auditbase
    {
        [Key] //  PK esta sera la llave primaria de todas las tablas
        [Required] // significa qu este campo es obligatorio /esta sera la llave primaria de todas las tablas
        public virtual Guid Id { get; set; }  // esta sera el PK de todas las tablas
        public virtual DateTime CreatedDate { get; set; }  // esta sera la fecha de creacion

        public virtual DateTime ModifiedDate { get; set; } // esta sera la fecha de modificacion
    }
}
        