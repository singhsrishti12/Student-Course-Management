namespace SchoolManagement.Middlewares
{
    public class AppException : Exception
    {
        public int StatusCode { get; }

        public AppException(string msg,int code = 400) :base(msg)
        {
            StatusCode = code;
        }
    }
}
