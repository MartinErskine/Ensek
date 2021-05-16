using System.ComponentModel.DataAnnotations.Schema;

namespace Ensek.Data.Entities
{
    [Table("Accounts")]
    public class Account
    {
        public int AccountId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }    
    }
}