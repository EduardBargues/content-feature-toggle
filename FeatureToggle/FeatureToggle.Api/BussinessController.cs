using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FeatureToggle.Api
{
    [ApiController]
    [Route("[controller]")]
    public class BussinessController : ControllerBase
    {
        private readonly ILogger<BussinessController> _logger;

        public BussinessController(ILogger<BussinessController> logger)
        {
            _logger = logger;
        }

        private const string FeatureName = "feature-name";
        [HttpGet]
        [DefineFeature(FeatureName)]
        public IActionResult Get()
        {
            return Ok($"Feature {FeatureName} is active :) !");
        }
    }
}
