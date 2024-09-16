using CorrectionExoIOT.DAL.Enums;

namespace CorrectionExoIOT.DAL.Entities
{
    public class InfoMaison
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public InfoType Type { get; set; }
    }
}
