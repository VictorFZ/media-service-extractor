using System;
using Autofac;
using BGD.API.AzureStorage;
using BGD.API.DependencyInjection.Extensions;
using BGD.API.Extractor.AzureBlob.Extensions;
using BGD.API.Versioning.Extensions;
using Bornlogic.Azure.Storage.Blob.Standard;
using Bornlogic.Azure.Storage.Blob.Standard.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BGD.Media.Extractor
{
    public class Startup
    {
        private static CloudBlobClient _sharedCloudBlobClient;

        public Startup(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            HostingEnvironment = hostingEnvironment;
            Configuration = configuration;

            _sharedCloudBlobClient = new BornlogicBlobConnection(
                    new AzureStorageEnvironmentVariables(HostingEnvironment).SharedAzureStorageSettings.ConnectionString)
                .Connect();
        }

        public IHostingEnvironment HostingEnvironment { get; }
        public IConfiguration Configuration { get; }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddVersioningOptions();
            services.AddVersionStartupOptions();

            var containerBuilder = new ContainerBuilder();
            
            services
                .AddAzureBlobExtractorOptions()
                .AddAzureStorageBlobOptions(_sharedCloudBlobClient);

            return services.WrapToAutofac(containerBuilder);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseApiVersioning();

            app.UseMvc();
        }
    }
}
