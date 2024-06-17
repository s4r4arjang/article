using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.Domain.Articles.Entities
{
    public class FileTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string FileType { get; set; }
        public string Path { get; set; }
        public byte[] FileContent { get; set; }
        public Article article { get; set; }
        public int ArticleId { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
