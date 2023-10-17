using AutoMapper;
using MassTransit;
using MongoDB.Driver;
using Report.API.Dtos;
using Report.API.Settings;
using static Report.API.Helper.Enums;

namespace Report.API.Que.Consumer
{
    public class ReportConsumer : IConsumer<ReportCreateDto>
    {
        private readonly IMongoCollection<ReportDto> _reportCollection;
        private readonly IMongoCollection<PersonDto> _personCollection;

        public ReportConsumer(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _reportCollection = database.GetCollection<ReportDto>(databaseSettings.ReportCollectionName);
            _personCollection = database.GetCollection<Dtos.PersonDto>(databaseSettings.CollectionName);
        }

        public async Task Consume(ConsumeContext<ReportCreateDto> context)
        {
            var report = await _reportCollection.Find<ReportDto>(p => p.Id == context.Message.ReportId).FirstOrDefaultAsync();
            if(report != null) 
            {
                var persons = await _personCollection.Find<PersonDto>(x => x.ContactInfo != null).ToListAsync();

                var person_counter = 0;
                var phone_counter = 0;
                persons.ForEach(x =>
                {
                    var location = x.ContactInfo.Where(z => z.InfoType == InfoType.Location && z.InfoContent == context.Message.Location).FirstOrDefault();
                    if (location != null)
                    {
                        person_counter++;
                        phone_counter += x.ContactInfo.Where(z => z.InfoType == InfoType.PhoneNumber).Count();
                    }
                });

                report.RegisteredPersonCount = person_counter;
                report.PhoneCount = phone_counter;
                report.Status = ReportStatusType.Ready;
                await _reportCollection.FindOneAndReplaceAsync(x => x.Id == report.Id, report);
            }

        }
    }
}
