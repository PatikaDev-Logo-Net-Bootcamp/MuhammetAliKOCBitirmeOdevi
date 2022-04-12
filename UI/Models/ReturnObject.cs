namespace UI.Models
{
    public class ReturnObject
    {
        public ReturnObject()
        {
            IsSuccess = true;
            ErrorMessage = "";
        }
        public bool IsSuccess { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public object data { get; set; }
    }
}
