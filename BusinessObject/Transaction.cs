using System.ComponentModel.DataAnnotations;
using System.Net;

namespace DUVAS
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public DateTime TransactionDateTime { get; set; }
        public decimal Money { get; set; }
        public string TransactionType { get; set; }

        public int RoomId { get; set; }
        public Room? Room { get; set; }

        public int ServicePostId { get; set; }
        public ServicePost? ServicePost { get; set; }

        public int IDThue { get; set; }
        public User? User { get; set; }
    }
}
