using CloudSuite.Domain.Enums;
using CloudSuite.Modules.Application.Handlers.Email.Responses;
using MediatR;
using EmailEntity = CloudSuite.Domain.Models.Email;

namespace CloudSuite.Modules.Application.Handlers.Email
{
    public class CreateEmailCommand : IRequest<CreateEmailResponse>
    {
        public Guid Id { get; private set; }
        public string? Subject { get; set; }

        public string? Body { get; set; }

        public string? Sender { get; set; }

        public string? Recipient { get; set; } 

        public DateTimeOffset? SentDate { get; set; } 

        public bool? IsRead { get; set; }

        public int? SendAttempts { get; set; }

        public CodeErrorEmail CodeErrorEmail { get; set; }


        public CreateEmailCommand()
        {
            Id = Guid.NewGuid();
        }

        public EmailEntity GetEntity()
        {
            return new EmailEntity(
                this.Subject,
                this.Body,
                this.Sender,
                this.Recipient,
                this.SentDate,
                this.IsRead.Value
                );
        }

    }
}
