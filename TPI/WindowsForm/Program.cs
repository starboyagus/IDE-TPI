using System;
using System.Collections.Generic;
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
