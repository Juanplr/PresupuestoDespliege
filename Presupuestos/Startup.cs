using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ipresupuesto;
using presupuesto;
using SoapCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace practica03
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configurar la protección de datos para usar Azure Blob Storage
            var storageAccount = CloudStorageAccount.Parse("YourAzureStorageConnectionString");
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("dataprotection-keys");
            container.CreateIfNotExists();

            services.AddDataProtection()
                    .PersistKeysToAzureBlobStorage(container, "keys.xml");

            services.AddSoapCore();
            services.TryAddSingleton<iPresupuesto, Presupuesto>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<iPresupuesto>("/Presupuesto.dran", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
            });
        }
    }
}
