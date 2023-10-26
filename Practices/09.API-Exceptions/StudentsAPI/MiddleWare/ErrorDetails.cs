using Newtonsoft.Json;

namespace StudentsAPI.MiddleWare
{
    public class ErrorDetails
    {
        public string ErrorType { get; set; }

        public List<string> Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}