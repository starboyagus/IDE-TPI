using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using API.Clients;
using Microsoft.Extensions.Configuration;

namespace WindowsForm
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var cultura = new CultureInfo("es-AR");
            CultureInfo.DefaultThreadCurrentCulture = cultura;
            CultureInfo.DefaultThreadCurrentUICulture = cultura;
            CultureInfo.CurrentCulture = cultura;
            CultureInfo.CurrentUICulture = cultura;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            ApiClient.Configurar(configuration["ApiBaseUrl"]!);

            Application.Run(new Home());
        }
    }

}
