using System.ComponentModel.DataAnnotations;

namespace GymMembershipApi.BLL.DTOs
{
    public class CreateClientDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}