using System;

namespace DependencyInjectionSample
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //An Tag 4 und 5 bauche ich mir Dummy/Mock Objekte
            ICar car = new Car();
            car.MacheRadioAn("Hit Radio FFH");
            ICarService service = new CarService();
            service.RepairCar(car);

        }
    }

    #region BadCode
    //Contras: 
    // Entity.dll und Service.dll wären eine logische Einheit und daher unflexibel 
    // Programmieren im Team ist unflexibel, weil Änderungen in einer Klasse Auswirkungen in eine andere Klasse haben 

    //Entity.dll
    public class BadCar // Programmierer A: 5 Tage
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = default!;
        public int ConstrutionYear { get; set; }
    }

    //Service.dll
    public class BadCarService // Programmierer B: 3 Tage
    {
        public void RepairCar(BadCar car)
        {
            // repariere das Auto 
        }
    }
    #endregion


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



    public static class CarExtentionClass
    {
        public static void MacheRadioAn(this Car car, string radioSender)
        {
            Console.WriteLine("Mache das Radio an und wir hören " + radioSender);
        }

        public static void MacheRadioAn(this ICar car, string radioSender)
        {
            Console.WriteLine("Mache das Radio an und wir hören " + radioSender);
        }
    }

    #endregion 
}
