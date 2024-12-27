﻿using System.ComponentModel.DataAnnotations;
namespace DUVAS
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Name { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string ProfilePicture { get; set; }
        public decimal Money { get; set; }

        public int? RoleAdmin { get; set; }
        public int? RoleUser { get; set; }
        public int? RoleLandlord { get; set; }
        public int? RoleService { get; set; }

        public virtual ICollection<Transaction>? Transactions { get; set; }
        public virtual ICollection<UserFeedback>? UserFeedbacks { get; set; }
        public virtual ICollection<ServiceLicense>? ServiceLicenses { get; set; }
        public virtual ICollection<OwnerLicense>? OwnerLicenses { get; set; }
        public virtual ICollection<Report>? Reports { get; set; }
        public virtual ICollection<RentalList>? RentalLists { get; set; }
    }
}
