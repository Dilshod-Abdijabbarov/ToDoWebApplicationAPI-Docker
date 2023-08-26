namespace ToDoWebApplication.Services.Exceptions
{
    public class ToDoException : System.Exception
    {
        public int Code { get; set; }

        public ToDoException(int Code,string message):base(message)
        {
            this.Code = Code;
        }
    }
}
