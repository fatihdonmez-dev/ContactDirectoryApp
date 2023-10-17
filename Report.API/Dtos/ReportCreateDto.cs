using static Report.API.Helper.Enums;

namespace Report.API.Dtos
{
    public class ReportCreateDto
    {
        public string ReportId { get; set; }
        public string Location { get; set; }
    }
}
