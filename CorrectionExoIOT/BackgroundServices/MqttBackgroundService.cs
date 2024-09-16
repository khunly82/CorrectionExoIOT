
using CorrectionExoIOT.DAL.Entities;
using CorrectionExoIOT.DAL.Enums;
using CorrectionExoIOT.DAL.Repositories;
using CorrectionExoIOT.Infrastructures;

namespace CorrectionExoIOT.BackgroundServices
{
    public class MqttBackgroundService(
        MqttConnection connection, 
        InfoMaisonRepository infoMaisonRepository
    ) : BackgroundService
    {
        //private MqttConnection connection;
        //private InfoMaisonRepository infoMaisonRepository;

        //public MqttBackgroundService(MqttConnection connection, InfoMaisonRepository infoMaisonRepository)
        //{
        //    this.connection = connection;
        //    this.infoMaisonRepository = infoMaisonRepository;
        //}

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // methode qui sera exécutée en arriere plan
            connection.SubscribeAsync("temperatureMaisonKhun", OnNewTemperature);

            return Task.CompletedTask;
        }

        private void OnNewTemperature(string value)
        {
            // sauver la température dans la db
            infoMaisonRepository.Insert(new InfoMaison
            {
                Value = decimal.Parse(value),
                Date = DateTime.Now,
                Type = InfoType.Temperature
            });
        }
    }
}
