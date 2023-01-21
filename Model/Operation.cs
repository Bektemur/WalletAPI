using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletAPI.Model
{
    public class Operation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime Time { get; set; } = DateTime.UtcNow;
        [ForeignKey("WalletId")]
        public int WalletId { get; set; }
    }
}
