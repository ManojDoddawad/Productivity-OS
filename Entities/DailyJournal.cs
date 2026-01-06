namespace ProductivityOS.Entities
{
    public class DailyJournal
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int Mood { get; set; } // 1-10
    }

}
