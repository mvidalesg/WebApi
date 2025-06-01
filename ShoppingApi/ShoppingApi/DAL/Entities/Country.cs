using System.ComponentModel.DataAnnotations;
using WebApi.DAL.Entities;

namespace ShoppingApi.DAL.Entities
{
    public class Country: Auditbase
    {
        [Display(Name = "Pais")] // para identificar el nombre mas facil
        [MaxLength(50, ErrorMessage = "El campo {0} debe de tener maximo {1} caracteres.")] // longitud maxima del campo
        [Required(ErrorMessage = "es campo {0} es obligatorio")]  //campo obligatorio
        public string Name { get; set; }

        [Display(Name = "Estados/Departamento")]
        public ICollection<State>? States { get; set; }

    }
    
    }

