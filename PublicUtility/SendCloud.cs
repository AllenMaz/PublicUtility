using PublicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PublicUtility
{
    /// <summary>
    /// https://sendcloud.sohu.com/
    /// </summary>
    public class SendCloud
    {
        /// <summary>
        /// 邮件发送url
        /// </summary>
        private string _sendColudMailUrl = string.Empty;
        private static string _apiUser = string.Empty;
        private static string _apiKey = string.Empty;
        public SendCloud(string apiUser,string apiKey)
        {
            _apiUser = apiUser;
            _apiKey = apiKey;
        }

        /// <summary>
        /// 邮件发送
        /// </summary>
        /// <param name="sendCloudMailUrl">http://api.sendcloud.net/apiv2/mail/send</param>
        /// <param name="mail"></param>
        /// <returns></returns>
        public static Message SendMail(string sendCloudMailUrl,Mail mail)
        {
            Message message = new Message();
            message.Success = true;

            HttpClient client = null;
            HttpResponseMessage response = null;

            try
            {
                client = new HttpClient();

                List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();

                paramList.Add(new KeyValuePair<string, string>("apiUser", _apiUser));
                paramList.Add(new KeyValuePair<string, string>("apiKey", _apiKey));
                paramList.Add(new KeyValuePair<string, string>("from", mail.From));
                paramList.Add(new KeyValuePair<string, string>("fromName", mail.Creator));
                paramList.Add(new KeyValuePair<string, string>("to", mail.To));
                paramList.Add(new KeyValuePair<string, string>("subject", mail.Subject));
                paramList.Add(new KeyValuePair<string, string>("html", mail.Body));

                response = client.PostAsync(sendCloudMailUrl, new FormUrlEncodedContent(paramList)).Result;
                String result = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception e)
            {
                message.Success = false;
                message.Content = "邮件发送失败。异常：" + e.Message;

            }
            finally
            {
                if (null != client)
                {
                    client.Dispose();
                }
            }

            return message;
        }
    }
}
