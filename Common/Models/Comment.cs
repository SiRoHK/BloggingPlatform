using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Comment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string PostId { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}
