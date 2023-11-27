namespace BlogAnimalApi.DTO.requestDTO
{
    public class UpdateTradeDTO
    {
        public string? TradeId { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool? IsTrade { get; set; }
        public bool? IsSecure { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? AccountId { get; set; }
        public decimal? Price { get; set; }
        public string? Title { get; set; }
    }
}
