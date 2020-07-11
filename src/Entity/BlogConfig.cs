using System;
using EasyBlogImageForTypora.Common;
using Newtonsoft.Json;

namespace EasyBlogImageForTypora.Entity
{
    public class BlogConfig
    {
        public string BlogUrl { get; set; }

        public string MetaWeblogUrl { get; set; }

        public string BlogId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [JsonIgnore]
        public string PasswordDecrypt => Utils.Instance.AESDecrypt(Password);

        public override string ToString()
        {
            return $"{Environment.NewLine}BlogUrl:{BlogUrl}{Environment.NewLine}" +
                   $"MetaWeblogUrl:{MetaWeblogUrl}{Environment.NewLine}" +
                   $"BlogId:{BlogId}{Environment.NewLine}" +
                   $"UserName:{UserName}{Environment.NewLine}" +
                   $"Password:******{Environment.NewLine}";
        }

        public string SerializeObject()
        {
            Password = Utils.Instance.AESEncrypt(Password);
            return JsonConvert.SerializeObject(this);
        }

    }
}
