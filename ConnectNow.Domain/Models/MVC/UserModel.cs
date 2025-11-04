using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Domain.Models.MVC
{
    public class UserModel
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public string? Auth0UserId { get; set; }
        public string? FullName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Picture { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public int UserType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ImagePath { get; set; }
        public string? CoverImagePath { get; set; }
    }

}
