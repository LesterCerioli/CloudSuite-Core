using CloudSuite.Domain.Models;
using Dapper;
using Dapper.FluentMap.Dommel.Mapping;
using System.Data;

namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class MediaDapperMapping
    {
        private readonly IDbConnection _connection;

        public MediaDapperMapping(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Media>> GetAllEmailsAsync()
        {
            var query = @"SELECT Caption, FileSize, FileName, MediaType FROM Medias";
            return await _connection.QueryAsync<Media>(query);
        }

        public async Task<Media> GetEmailByCaptionAsync(string mediaCaption)
        {
            var query = @"
                SELECT 
                    Caption
                FROM
                    Medias
                WHERE
                    Caption = @MediaCaption";

            return await _connection.QueryFirstOrDefaultAsync<Media>(query, new { MediaCaption = mediaCaption });
        }

        public async Task<Media> GetMediaByFileNameAsync(string mediaFileName)
        {
            var query = @"
                SELECT 
                    FileName
                FROM
                    Medias
                WHERE
                    Caption = @MediaFileName";

            return await _connection.QueryFirstOrDefaultAsync<Media>(query, new { MediaFileName = mediaFileName });
        }

        public async Task<Media> GetMediaByFileSizeAsync(int mediaFileSize)
        {
            var query = @"
                SELECT 
                    FileSize
                FROM
                    Medias
                WHERE
                    FileSize = @MediaFileSize";

            return await _connection.QueryFirstOrDefaultAsync<Media>(query, new { MediaFileSize = mediaFileSize });
        }

    }
}