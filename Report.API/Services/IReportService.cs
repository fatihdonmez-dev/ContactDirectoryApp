using Report.API.Dtos;

namespace Report.API.Services
{
    public interface IReportService
    {
        Task<List<Models.Report>> GetAllReportsAsync();
        Task<Models.Report> GetReportByIdAsync(string id);
        Task<bool> ReportSuspend(ReportRequestDto reportRequestDto);
    }
}
