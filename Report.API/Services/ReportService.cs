using AutoMapper;
using MassTransit;
using MongoDB.Driver;
using Report.API.Dtos;
using Report.API.Settings;

namespace Report.API.Services
{
    public class ReportService : IReportService
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IMongoCollection<Models.Report> _reportCollection;
        private readonly IMapper _mapper;

        public ReportService(ISendEndpointProvider sendEndpointProvider, IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _reportCollection = database.GetCollection<Models.Report>(databaseSettings.CollectionName);
        }

        public async Task<List<ReportDto>> GetAllReportsAsync()
        {
            var report = await _reportCollection.Find<Models.Report>(p => true).ToListAsync();
            if (!report.Any())
            {
                report = new List<Models.Report> { };
            }

            return _mapper.Map<List<ReportDto>>(report);
        }

        public async Task<ReportDto> GetReportByIdAsync(string id)
        {
            var report = await _reportCollection.Find<Models.Report>(p => p.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<ReportDto>(report);
        }

        public async Task<bool> ReportSuspend(ReportRequestDto reportRequestDto)
        {
            try
            {
                var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-report"));

                var newReport = new Models.Report { Location = reportRequestDto.Location, PhoneCount = 0, RegisteredPersonCount = 0, ReportDate = DateTime.Now, Status = Helper.Enums.ReportStatusType.Processing };

                await _reportCollection.InsertOneAsync(newReport);
                reportRequestDto.ReportId = newReport.Id;

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
