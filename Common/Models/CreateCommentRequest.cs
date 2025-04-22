using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class CreateCommentRequest
    {
        public string PostId { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}
