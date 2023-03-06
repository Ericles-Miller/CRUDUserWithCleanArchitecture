
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReceptionistNameSpace {
    [Table("receptionist")]
    public class Receptionist {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Address { get; set; }

        public Receptionist( string address, string name, int number) {
            Id = Guid.NewGuid();
            Address = address;
            Name = name;
            Number = number;
        }

   

}
}

