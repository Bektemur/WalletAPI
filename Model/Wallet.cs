using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WalletAPI.Model
{
    public class Wallet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public double Balance { get; set; }
        public bool IsIdentified { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
    }
}
