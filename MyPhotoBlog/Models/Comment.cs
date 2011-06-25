using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPhotoBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Message { get; set; }
        public int PhotoId { get; set; }
        public bool Approved { get; set; }

        public bool IsValid()
        {
            if (String.IsNullOrWhiteSpace(Name)) return false;
            if (String.IsNullOrWhiteSpace(Email))
            {
                return false;
            }
            else
            {
                bool validAddress = true;
                try
                {
                    var address = new System.Net.Mail.MailAddress(Email).Address;
                }
                catch (FormatException)
                {
                    validAddress = false;
                }

                if (!validAddress) return false;
            }

            if (String.IsNullOrWhiteSpace(Message))
            {
                return false;
            }
            else
            {
                Uri uri;
                if (!System.Uri.TryCreate(Website, UriKind.Absolute, out uri)) return false;
            }
            

            return true;
        }
    }
}