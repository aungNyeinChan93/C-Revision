namespace Domain_WebApi_01.Models
{
    public class BookResponseModel<T>
    {
        public BaseResponseModel? Response { get; set; }

        public T? Result { get; set; } 

    }
}
