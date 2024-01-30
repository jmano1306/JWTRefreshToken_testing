namespace JWTRefreshToken.Auth
{
    public class ApiException
    {
        public ApiException()
        {
        }

        public ApiException(int statuCode,string message=null,string details=null) 
        {
            StatuCode = statuCode;
            Message = message;
            Details = details;
        }
        public int StatuCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}
