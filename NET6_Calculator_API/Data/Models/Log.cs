namespace NET6_Calculator_API.Data.Models
{
    public class Log
    {
        public int Id { get; set; }
        public float FirstNumber { get; set; }
        public string ArithmeticOperator { get; set; }
        public float SecondNumber { get; set; }
        public float? Result { get; set; }
        public bool SuccessfulResult { get; set; }
    }
}
