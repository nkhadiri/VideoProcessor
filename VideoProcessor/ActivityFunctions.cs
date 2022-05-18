using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace VideoProcessor
{
    public static partial class ActivityFunctions
    {
        [FunctionName(nameof(TransCodeVideo))]
        public static async Task<string> TransCodeVideo([ActivityTrigger] string inputVideo, ILogger log)
        {
            log.LogInformation($"Transcoding {inputVideo}.");
            //simulate doing the activity
            await Task.Delay(5000);
            return $"{Path.GetFileNameWithoutExtension(inputVideo)}-transcoded.mp4";
        }
        [FunctionName(nameof(ExtractThumbnail))]
        public static async Task<string> ExtractThumbnail([ActivityTrigger] string inputVideo, ILogger log)
        {
            log.LogInformation($"Extracting Thumbnail {inputVideo}.");
            //simulate doing the activity
            await Task.Delay(5000);
            return $"{Path.GetFileNameWithoutExtension(inputVideo)}-thumbnail.png";
        }
        [FunctionName(nameof(PrependIntro))]
        public static async Task<string> PrependIntro([ActivityTrigger] string inputVideo, ILogger log)
        {
            var introLocation = Environment.GetEnvironmentVariable("IntroLocation");
            log.LogInformation($"Extracting Thumbnail {introLocation}.");
            //simulate doing the activity
            await Task.Delay(5000);
            return $"{Path.GetFileNameWithoutExtension(inputVideo)}-withintro.mp4";
        }
    }
}