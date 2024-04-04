using CloudSuite.Domain.Enums;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CloudSuite.Domain.Models
{
    public class Media : Entity, IAggregateRoot
    {
        private object value;

        public Media(string? caption, int? fileSize, string? fileName)
        {
            Caption = caption;
            FileSize = fileSize;
            FileName = fileName;
        }

        public Media(string? caption, int? fileSize, string? fileName, object value)
        {
            Caption = caption;
            FileSize = fileSize;
            FileName = fileName;
            this.value = value;
        }

        public Media(Guid id, string? caption, int? fileSize, string? fileName, MediaType mediaType) {
            Id = id;
            Caption = caption;
            FileSize = fileSize;
            FileName = fileName;
            MediaType = mediaType;
        }

        [Required(ErrorMessage = "Este campo � de preenchimento obrigat�rio.")]
        [StringLength(450)]
        public string? Caption { get; set; }

        [Required(ErrorMessage ="Este campo � obrigat�rio.")]
        public int? FileSize { get; set; }

        [Required(ErrorMessage ="Este campo � de preencimento obrigat�rio.")]
        [StringLength(450)]
        public string? FileName { get; set; }

        public MediaType MediaType { get; set; }
    }
}