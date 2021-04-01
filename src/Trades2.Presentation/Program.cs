using SimpleInjector;
using SimpleInjector.Diagnostics;
using System;
using System.Windows.Forms;
using Trades2.Application;
using Trades2.Application.Interfaces;
using Trades2.Domain;
using Trades2.Domain.Interfaces;
using Trades2.Repository;
using Trades2.Repository.Interfaces;

namespace Trades2.Presentation
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var container = Configure();

            System.Windows.Forms.Application.Run(container.GetInstance<Form1>());
        }

        private static Container Configure()
        {
            var container = new Container();

            ConfigureServices(container);
            AutoRegisterWindowsForms(container);
            container.Verify();

            return container;
        }

        private static void ConfigureServices(Container container)
        {
            container.Register<ITradeApp, TradeApp>();
            container.Register<ITradeServices, TradeServices>();
            container.Register<ITradeRepository, TradeRepository>();
        }

        private static void AutoRegisterWindowsForms(Container container)
        {
            var types = container.GetTypesToRegister<Form>(typeof(Program).Assembly);

            foreach (var type in types)
            {
                var registration =
                    Lifestyle.Transient.CreateRegistration(type, container);

                registration.SuppressDiagnosticWarning(
                    DiagnosticType.DisposableTransientComponent,
                    "Forms should be disposed by app code; not by the container.");

                container.AddRegistration(type, registration);
            }
        }
    }
}
