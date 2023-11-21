using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LangController : ControllerBase
    {
        readonly RequestLocalizationOptions _localizationOptions;

        public LangController(IOptions<RequestLocalizationOptions> localizationOptions)
            => _localizationOptions = localizationOptions.Value;
        [HttpGet]
        public IActionResult AllLanguages()
        {
            IRequestCultureFeature requestCulture = HttpContext.Features.Get<IRequestCultureFeature>();
            var allCultures = _localizationOptions.SupportedCultures
                    .Select(culture => new
                    {
                        Name = culture.Name,
                        Text = culture.DisplayName
                    }).ToList();
            return Ok(allCultures);
        }
    }
}
