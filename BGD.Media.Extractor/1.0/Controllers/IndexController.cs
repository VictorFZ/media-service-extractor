using System;
using System.Threading.Tasks;
using BGD.API.Versioning.Attributes;
using BGD.Media.Extractor.Entities._1._0.Requests;
using BGD.Media.Extractor.Entities._1._0.Responses;
using BGD.Media.Extractor.Services._1._0.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BGD.Media.Extractor._1._0.Controllers
{
    [ApiVersion("1.0")]
    [VersionedRoute("")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly IMediaExtractorService _mediaExtractorService;

        public IndexController(IMediaExtractorService mediaExtractorService)
        {
            _mediaExtractorService = mediaExtractorService;
        }

        public async Task<ActionResult> Post([FromBody] ExtractRequest request)
        {
            try
            {
                var extractedMediaUrl = await _mediaExtractorService.Extract(request.MediaUrl);

                return Ok(new ExtractResponse
                {
                    MediaUrl = extractedMediaUrl
                });
            }
            catch (Exception e)
            {
                return BadRequest(new {error = e.Message});
            }
        }
    }

  
}
