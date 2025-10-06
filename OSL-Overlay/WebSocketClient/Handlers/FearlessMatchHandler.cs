using Newtonsoft.Json.Linq;
using OSL_Overlay.Phase.Fearless;
using OSL_RGDP.WebSocketResponse;
using OSL_Utils;

namespace OSL_Overlay.WebSocketClient.Handlers
{
    /// <summary>
    /// Handler for the "fearlessGameMatch" message type.
    /// </summary>
    public class FearlessMatchHandler : IMessageHandler
    {
        private static readonly Logger _logger = new("FearlessMatchHandler");

        private readonly IServiceProvider _serviceProvider;

        public FearlessMatchHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public string Type => "fearlessGameMatch";

        /// <inheritdoc />
        public Task HandleAsync(JToken jsonData)
        {
            var fearlessState = _serviceProvider.GetRequiredService<FearlessState>();

            var data = jsonData.ToObject<FearlessMatchDto>();
            _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🎯 Fearless match management");
            if (data != null)
                fearlessState.AddFearlessList(data);
            return Task.CompletedTask;
        }
    }
}
