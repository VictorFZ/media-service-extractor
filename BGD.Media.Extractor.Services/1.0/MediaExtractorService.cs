using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BGD.API.Extractor.Contracts;
using BGD.Media.Extractor.Services._1._0.Contracts;

namespace BGD.Media.Extractor.Services._1._0
{
    public class MediaExtractorService : IMediaExtractorService
    {
        private const string BLOB_EXTRACTED_MEDIA_CONTAINER = "third-party-extracted-media";

        private readonly IMediaExtractor _mediaExtractor;

        public MediaExtractorService(IMediaExtractor mediaExtractor)
        {
            _mediaExtractor = mediaExtractor;
        }

        public async Task<IEnumerable<string>> Extract(IEnumerable<string> mediaUrls)
        {
            var urls = new List<string>();

            foreach (var facebookMediaUrl in mediaUrls)
            {
                var url = await Extract(facebookMediaUrl);

                urls.Add(url);
            }

            return urls.Where(u => !string.IsNullOrEmpty(u)).ToList();
        }

        public async Task<string> Extract(string mediaUrl)
        {
            var uri = await _mediaExtractor.ExtractMedia(BLOB_EXTRACTED_MEDIA_CONTAINER, mediaUrl);

            return uri?.AbsoluteUri;
        }
    }
}
