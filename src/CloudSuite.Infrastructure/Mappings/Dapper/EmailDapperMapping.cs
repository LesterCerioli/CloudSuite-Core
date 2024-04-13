using CloudSuite.Domain.Enums;
using CloudSuite.Domain.Models;
using Dapper;
using Dapper.FluentMap.Dommel.Mapping;
using System.Data;

namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class EmailDapperMapping
    {
        private readonly IDbConnection _connection;
        public EmailDapperMapping(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Email>> GetAllEmailsAsync()
        {
            var query = @"SELECT Subject, Body, Sender, Recipient, SentDate, IsRead,
                          SendAttempsts, CodeErrorEmail From Emails";
            return await _connection.QueryAsync<Email>(query);
        }

        public async Task<Email> GetEmailByCodeErrorAsync(CodeErrorEmail emailCodeError)
        {
            var query = @"
                SELECT 
                    CodeError
                FROM
                    Emails
                WHERE
                    CodeError = @EmailCodeError";

            return await _connection.QueryFirstOrDefaultAsync<Email>(query, new { EmailCodeError = emailCodeError });
        }

        public async Task<Email> GetEmailByRecipientAsync(string emailRecipient)
        {
            var query = @"
                SELECT 
                    Recipient
                FROM
                    Emails
                WHERE
                    Recipient = @EmailRecipient";

            return await _connection.QueryFirstOrDefaultAsync<Email>(query, new { EmailRecipient = emailRecipient });
        }

        public async Task<Email> GetEmailBySenderAsync(string emailSender)
        {
            var query = @"
                SELECT 
                    Sender
                FROM
                    Emails
                WHERE
                    Sender = @EmailSender";

            return await _connection.QueryFirstOrDefaultAsync<Email>(query, new { EmailSender = emailSender });
        }

    }
}