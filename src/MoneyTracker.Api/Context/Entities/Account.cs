using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.Api.Context.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }

        public Account(string username)
        {
            Username = username;
        }
    }
}
