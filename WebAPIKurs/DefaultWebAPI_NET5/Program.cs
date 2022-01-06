using Autofac;
using DefaultWebAPI_NET5.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultWebAPI_NET5
{

    public class Program
    {
        //public static void Main(string[] args)
        //{

        //    //BuidContainer fügen wir Interface und deren Instanzen dem Autofac IOC Container hinzu
        //    //var container = BuildContainer();
            
        //    ////Rufen wir die Instanz von Autofac ab 
        //    //var personListResolver = container.Resolve<IPersonBusiness>();
        //    //var personList = personListResolver.GetPersonList();
        //    //foreach (var person in personList)
        //    //{
        //    //    Console.WriteLine(person);
        //    //}


        //    //Build = Schritt 3
        //    //Run = Schritt 4


        //    CreateHostBuilder(args).Build().Run();
        //}

        //Schritt 1: 
        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args) //Kestrel Implementierung ist hier vorhanden
        //        .ConfigureWebHostDefaults(webBuilder => ///Lambda Expression werden verwendet 
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();


        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<PersonBusiness>().As<IPersonBusiness>();
            return builder.Build();
        }
    }
}
