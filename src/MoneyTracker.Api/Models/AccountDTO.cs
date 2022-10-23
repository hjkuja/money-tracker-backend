using MoneyTracker.Api.Context.Entities;
using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.Api.Models
{
    public class AccountDTO
    {
        [Required]
        public string Username { get; set; } = null!;
    }

    public static class AccountDTOUtils
    {
        public static AccountDTO ToDTO(this Account account)
        {
            return new AccountDTO
            {
                Username = account.Username,
            };
        }
    }

    
}
