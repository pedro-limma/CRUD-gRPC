using System.ComponentModel.DataAnnotations.Schema;

namespace GrpcCRUD.DataAccess
{
    public class Equipament
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipamentID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }   
    }
}