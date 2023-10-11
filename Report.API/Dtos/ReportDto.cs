using static Report.API.Helper.Enums;

namespace Report.API.Dtos
{
    public class ReportDto
    {
        public string Id { get; set; }
        public string Location { get; set; }
        public int RegisteredPersonCount { get; set; }
        public int PhoneCount { get; set; }
        public DateTime ReportDate { get; set; }
        public ReportStatusType Status { get; set; }
    }
}
