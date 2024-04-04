using CloudSuite.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CloudSuite.Domain.Models
{
    public class Vendor : Entity, IAggregateRoot
    {
        private Cnpj cnpj;
        private DateTimeOffset? createdOn;
        private DateTimeOffset? latestUpdatedOn;
        private bool value1;
        private bool value2;

        public Vendor(Guid userId, string? name, string? slug, string? description, Cnpj cnpj, Email email, DateTimeOffset? createdOn, DateTimeOffset? latestUpdatedOn, bool? isActive, bool? isDeleted)
        {
            UserId = userId;
            Name = name;
            Slug = slug;
            Description = description;
            Cnpj = cnpj;
            Email = email;
            CreatedOn = createdOn;
            LatestUpdatedOn = latestUpdatedOn;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }

        public Vendor(Guid userId, string? name, string? slug, string? description, Cnpj cnpj, DateTimeOffset? createdOn, DateTimeOffset? latestUpdatedOn, bool? isActive, bool? isDeleted)
        {
            UserId = userId;
            Name = name;
            Slug = slug;
            Description = description;
            Cnpj = cnpj;
            CreatedOn = createdOn;
            LatestUpdatedOn = latestUpdatedOn;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }

        public Vendor()
        {

        }

        public Vendor(string? name, string? slug, string? description, Cnpj cnpj, DateTimeOffset? createdOn, DateTimeOffset? latestUpdatedOn, bool value1, bool value2)
        {
            Name = name;
            Slug = slug;
            Description = description;
            this.cnpj = cnpj;
            this.createdOn = createdOn;
            this.latestUpdatedOn = latestUpdatedOn;
            this.value1 = value1;
            this.value2 = value2;
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Slug { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? Description { get; private set; }

        public Cnpj Cnpj { get; private set; }

        public Guid CnpjId { get; private set; }

        public Email Email { get; private set; }

        public Guid EmailId { get; private set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public DateTimeOffset? LatestUpdatedOn { get; private set; }

        public bool? IsActive { get; private set; }

        public bool? IsDeleted { get; private set; }

        public IList<User> Users { get; set; } = new List<User>();

        public User User { get; private set; }

        public Guid UserId { get; private set; }
    }
}