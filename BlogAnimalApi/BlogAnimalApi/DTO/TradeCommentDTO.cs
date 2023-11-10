namespace BlogAnimalApi.DTO
{
    public class TradeCommentDTO
    {
        public string Content { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public string? AccountId { get; set; }
        public string? TradeId { get; set; }

        public virtual AccountDTO? Account { get; set; }
    }
}
