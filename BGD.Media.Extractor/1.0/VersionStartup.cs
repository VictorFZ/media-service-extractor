using BGD.API.Versioning.Entities;
using BGD.Media.Extractor.Services._1._0;
using BGD.Media.Extractor.Services._1._0.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace BGD.Media.Extractor._1._0
{
    public class VersionStartup : BaseVersionStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMediaExtractorService, MediaExtractorService>();
        }
    }
}
