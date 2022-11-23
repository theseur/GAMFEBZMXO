using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace GAMF.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        [Display(Name = "Előadás címe")]
        public string Title { get; set; }

        [Display(Name = "Elérhető kredit")]
        
        public int Credits { get; set; }

        [Display(Name = "Jelentkezések")]
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
