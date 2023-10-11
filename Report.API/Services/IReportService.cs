using Report.API.Dtos;

namespace Report.API.Services
{
    public interface IReportService
    {
        Task<List<ReportDto>> GetAllReportsAsync();
        Task<ReportDto> GetReportByIdAsync(string id);
        Task<bool> ReportSuspend(ReportRequestDto reportRequestDto);
    }
}
