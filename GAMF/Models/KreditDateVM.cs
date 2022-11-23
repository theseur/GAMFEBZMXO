using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GAMF.Models
{
    public class KreditDateVM
    {
       
        [Display(Name = "Családnév")]
        
        public string LastName { get; set; }

        [Display(Name = "Keresztnév")]
      
        public string FirstMidName { get; set; }
        [Display(Name = "Kredit")]
       
        public int Gradesint { get; set; }
    }
}
