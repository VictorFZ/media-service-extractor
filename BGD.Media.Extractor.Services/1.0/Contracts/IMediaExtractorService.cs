using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGD.Media.Extractor.Services._1._0.Contracts
{
    public interface IMediaExtractorService
    {
        Task<IEnumerable<string>> Extract(IEnumerable<string> mediaUrls);
        Task<string> Extract(string mediaUrl);
    }
}
