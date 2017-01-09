using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicModel
{
    public class Message
    {
        public bool Success { get; set; }

        public string Content { get; set; }

        public int? ReturnId { get; set; }

        public string ReturnStrId { get; set; }

        public Message()
        {
            Success = true;
            Content = string.Empty;
        }
    }
}
