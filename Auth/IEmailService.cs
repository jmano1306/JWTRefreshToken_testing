namespace JWTRefreshToken.Auth
{
    public interface IEmailService
    {
        void sendMail(EmailModel emailModel);
    }
}
