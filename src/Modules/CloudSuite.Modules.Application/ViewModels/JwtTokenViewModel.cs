using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class JwtTokenViewModel
    {
        [Key]
        public Guid Id { get; private set; }

        [DisplayName("EncryptedToken")]
        public string? EncryptedToken { get; set; }

        [DisplayName("PublicKey")]
        public string? PublicKey { get; set; }

        [DisplayName("PrivateKey")]
        public string? PrivateKey { get; set; }
    }
}
