using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;

namespace ClinicService.Data
{
    [Table("Consultations")]
    public class Consultation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConsultationID { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientID { get; set; }

        [ForeignKey(nameof(Pet))]
        public int PetId { get; set; }

        [Column]
        public DateTime ConsultationDate { get; set; }

        [Column]
        public string Description { get; set; }
        public virtual Client Client { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
