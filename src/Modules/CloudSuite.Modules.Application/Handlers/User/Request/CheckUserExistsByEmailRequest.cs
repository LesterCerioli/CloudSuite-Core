using CloudSuite.Modules.Application.Handlers.User.Responses;
using MediatR;
using EmailEntity = CloudSuite.Domain.Models.Email;

namespace CloudSuite.Modules.Application.Handlers.User.Request
{
    public class CheckUserExistsByEmailRequest : IRequest<CheckUserExistsByEmailResponse>
    {
        private string email;

        public Guid Id { get; set; }

        public EmailEntity Email { get; private set; }

        public CheckUserExistsByEmailRequest(EmailEntity email)
        {
            Id = Guid.NewGuid();
            Email = email;
        }

        public CheckUserExistsByEmailRequest(string email)
        {
            this.email = email;
        }
    }
}

