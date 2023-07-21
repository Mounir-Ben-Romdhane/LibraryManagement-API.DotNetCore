namespace GestionLivres.Helpers
{
    public static class EmailBody
    {
        public static string EmailStringBody(string email, string emailToken)
        {
            return $@"<html>
            <head>
            <title>Verify Email</title>
            </head>
                <body style=""margin:0;padding:0;font-family: Arial, Helvetica, sans-serif;"">  
                    <div style=""height: auto ;background: linear-gradient(to top, #cff2f2 30%, #1CA3E5 90%) no-repeat;width:400px; padding: 30px "">
                        <div>
                            <div>
                                <h1>Reset your password</h1>
                                <hr>
                                <p>You're receiving this email because you requested a password reset for your account.</p>

                              <p>Please tap the button below to choose a new password</p>
    
                                <a href=""http://localhost:4200/reset?email={email}&code={emailToken}"" target="" _blanc"" style=""background-color: #0d6efd;border: none;color: white;padding: 10px;border-raduis:10px;text-align: center;width:50%;text-decoration: none;display: block;font-size: 16px;margin: 0 auto;"">Reset Password</a>
                                
                                <p>Thanks,</p>
                                <p>Mounir Ben Romdhane</p> 
                            </div>
                        </div>
                    </div>
                </body>
            </html>";
        }
    }
}
