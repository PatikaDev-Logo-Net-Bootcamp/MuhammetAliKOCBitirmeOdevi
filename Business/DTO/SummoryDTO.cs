namespace Business.DTO
{
    public class SummoryDTO
    {
        public SummoryDTO(string text, decimal amount)
        {
            Text = text;
            Amount = amount;
        }
        public string Text { get; set; }
        public decimal Amount { get; set; }
    }
}
