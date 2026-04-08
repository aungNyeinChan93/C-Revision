namespace Domain_WebApi_01.Models
{
    public class BaseResponseModel
    {
        public int ResCode { get; set; }

        public string ResDesc { get; set; } =string.Empty;

        public EnumResponseType ResType { get; set; }

        public bool IsSuccess { get; set; }

        public bool IsError {  get { return !IsSuccess; }  }
    }

    public enum EnumResponseType
    {
        None,
        Success,
        ValidationError,
        SystemError,
    }
}
