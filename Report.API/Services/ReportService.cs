using MassTransit;
using Report.API.Dtos;

namespace Report.API.Services
{
    public class ReportService : IReportService
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public ReportService(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task<List<Models.Report>> GetAllReportsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Models.Report> GetReportByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ReportSuspend(ReportRequestDto reportRequestDto)
        {
            try
            {
                var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-report"));

                await sendEndpoint.Send<ReportRequestDto>(reportRequestDto);

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
