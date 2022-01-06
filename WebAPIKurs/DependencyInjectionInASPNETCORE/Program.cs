using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjectionInASPNETCORE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            
            //Lebenzyklen 
            serviceCollection.AddSingleton<ICarService, CarService>(); 
            //serviceCollection.AddTransient<ICarService, CarService>();
            //serviceCollection.AddScoped<ICarService, CarService>();

            //ServiceProvider bietet die Instanzen an. Dher wird der Initialisierung von BuildServiceProvider abgeschlossen

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(); 

            ICarService carService = serviceProvider.GetService<ICarService>(); 
            ICarService carService2 = serviceProvider.GetRequiredService<ICarService>();
        }
    }




    #region Dependency Inversion 

    //Interfaces.dll
    public interface ICar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ConstrutionYear { get; set; }
    }

    public interface ICarService
    {
        void RepairCar(ICar car);
    }

    //Entity.dll
    public class Car : ICar // Programmierer A: 5 Tage
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ConstrutionYear { get; set; }
    }


    //Service.dll 

    public class CarService : ICarService // Programmierer B: 3 Tage
    {
        public void RepairCar(ICar car)
        {
            //Mach was
        }
    }
    public class MockCar : ICar
    {
        public string Brand { get; set; } = "VW";
        public string Model { get; set; } = "Polo";
        public int ConstrutionYear { get; set; } = 1999;
    }
    #endregion 
}
