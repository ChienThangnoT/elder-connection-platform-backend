﻿namespace ElderConnectionPlatform.API.Helper
{
    public class MailTemplate
    {
        public static string ConfirmTemplate(string email, string token)
        {
            string body = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset=""utf-8"" />
                    <title>Xác thực email</title>
                </head>
                <body>
                    <div style=""container"">
                        <div style=""header"">
                            <img src=""https://firebasestorage.googleapis.com/v0/b/estudyhub-a1699.appspot.com/o/logo%2Flogo-black.png?alt=media&token=892e67fd-fa5a-4a95-8705-de863eb9afe5"" alt=""Logo"" style=""width:120px;"">
                        </div>
                        <div style=""content"">
                            <h3>Xác thực Account của bạn</h3>
                            <p style=""font-size: 15px;"">Bạn đã đăng ký {email} tại ứng dụng Elder Connection.</p>
                            <p style=""font-size: 15px;"">Để xác thực địa chỉ email của bạn hãy nhấn vào nút bên dưới.</p>
                            <div style=""push-button"">
                                <a href=""{token}"" style=""background-color: #4CAF50; color: white; padding: 10px 20px; text-decoration: none; font-size: 16px; border-radius: 5px; display: inline-block;""><strong>XÁC NHẬN</strong></a>
                            </div>
                            <div style=""note"">
                                <p style=""font-size: 15px; font-style: italic;"">* Lưu ý: Tài khoản chỉ có thể đăng nhập được khi đã xác thực.</p>
                            </div>
                        </div>
                        <div style=""footer"">
                            <div style=""info"">
                                <p>Liên lạc đến elderconnect0105@gmail.com để hiểu rõ hơn.</p>
                            </div>
                        </div>
                    </div>
                </body>
                </html>";
            return body;
        }
    }
}
