using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.Retry;
using Polly.Wrap;

namespace CircuitBreakerGateway.Controllers 
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly AsyncFallbackPolicy<IActionResult> _asyncFallbackPolicy;
        private readonly AsyncRetryPolicy<IActionResult> _asyncRetryPolicy;
        private static AsyncCircuitBreakerPolicy? _asyncCircuitBreakerPolicy;
        private readonly AsyncPolicyWrap<IActionResult> _asyncPolicy;

        public GatewayController(IHttpClientFactory factory)
        {
            // Defing the policy
            // to return the fallback respose
            _asyncFallbackPolicy = Policy<IActionResult>
                .Handle<Exception>()
                .FallbackAsync(Content("Sorry, currenty we are not able to process your request"));
            // The retry policy
            _asyncRetryPolicy = Policy<IActionResult>
                .Handle<Exception>()
                .RetryAsync(2); //  Retry 2 times
            /// The CircuitBreakerAsync() method accepts 2 parameters
            /// 1. The Number of exceptions allowed before opening circuit
            /// 2. The duration the circut will stay open before resetting
            if (_asyncCircuitBreakerPolicy == null)
            {
                _asyncCircuitBreakerPolicy = Policy
                    .Handle<Exception>()
                    .CircuitBreakerAsync(2, TimeSpan.FromMinutes(1));
            }

            _asyncPolicy = Policy<IActionResult>
                .Handle<Exception>()    
                .FallbackAsync(Content("Sorry, currenty we are not able to process your request"))
                .WrapAsync(_asyncRetryPolicy)
                .WrapAsync(_asyncCircuitBreakerPolicy);

            _httpClient = factory.CreateClient();
        }
        [HttpGet]
        [ActionName("products")]
        public async Task<IActionResult> Products()
           => await CallTo("https://localhost:7007/api/Products");

        [HttpGet]
        [ActionName("customers")]
        public async Task<IActionResult> Customers()
            => await CallTo("https://localhost:6007/api/Customers");

        //Method to make call to the Actual API
        private async Task<IActionResult> CallTo(string url)
            => await _asyncPolicy.ExecuteAsync(async () => Content(await _httpClient.GetStringAsync(url)));

    }
}
