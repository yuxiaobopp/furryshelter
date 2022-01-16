using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Util.Helper
{
    /// <summary>
    /// 邮件发送类
    /// </summary>
    public class EmailHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="adminemail"></param>
        /// <param name="toEmail"></param>
        /// <param name="t"></param>
        /// <param name="content"></param>
        public static void SendEmail(string subject,string adminemail, string toEmail, DateTime t,string content)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();//实例化对象
                mailMsg.From = new MailAddress(adminemail, subject);//源邮件地址和发件人
                mailMsg.To.Add(new MailAddress(toEmail));//收件人地址
                mailMsg.Subject = $"{subject} {t.ToString("yyyy年MM月dd日HH时mm分ss秒")}";//发送邮件的标题
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"----------{t.ToString("yyyy年MM月dd日HH时mm分ss秒")}--------------------");
                sb.AppendLine($"您的{subject}");
                sb.AppendLine(content);
                sb.AppendLine("------------------------------");


                mailMsg.Body = sb.ToString();//发送邮件的内容
                                             //指定smtp服务地址（根据发件人邮箱指定对应SMTP服务器地址）
                SmtpClient client = new SmtpClient();//格式：smtp.126.com  smtp.164.com
                client.Host = "smtp.qq.com";
                //要用587端口
                client.Port = 587;//端口
                                  //加密
                client.EnableSsl = true;
                //通过用户名和密码验证发件人身份
                client.Credentials = new NetworkCredential(adminemail, "emeqrvfrmyoybgee"); // emeqrvfrmyoybgee

                client.SendAsync(mailMsg,null);
            }
            catch (SmtpException ex)
            {
                throw;
            }
        }
    }
}
