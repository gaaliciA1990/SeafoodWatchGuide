using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    public class JsonFileFeedbackService
    {
        // Class member variable for setting our JSON writing options when reading data
        private JsonWriterOptions writerOptions = new JsonWriterOptions { SkipValidation = false, Indented = true };

        public JsonFileFeedbackService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "SiteFeedback.json"); }
        }

        public IEnumerable<FeedbackModel> GetAllFeedback()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<FeedbackModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Create a new feedback rating using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public void CreateFeedback(int rating, string comment)
        {
            var feedback = new FeedbackModel()
            {
                ID = System.Guid.NewGuid().ToString(),
                Rating = rating,
                Comment = comment
            };

            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var feedbackSet = GetAllFeedback();
            feedbackSet = feedbackSet.Append(feedback);

            SaveFeedback(feedbackSet);

            //return feedback;
        }

        /// <summary>
        /// Find the feedback record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public FeedbackModel UpdateFeedback(FeedbackModel data)
        {
            var feedback = GetAllFeedback();
            var feedbackData = feedback.FirstOrDefault(x => x.ID.Equals(data.ID));
            if (feedbackData == null)
            {
                return null;
            }

            // Update the data to the new passed in values
            feedbackData.Rating = data.Rating;
            feedbackData.Comment = data.Comment.Trim();

            SaveFeedback(feedback);

            return feedbackData;
        }

        /// <summary>
        /// Save All feedback data to storage
        /// </summary>
        private void SaveFeedback(IEnumerable<FeedbackModel> feedback)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<FeedbackModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    feedback
                );
            }
        }

        /// <summary>
        /// Remove the feedback from the system
        /// </summary>
        /// <returns></returns>
        public FeedbackModel DeleteFeedback(string id)
        {
            // Get the current set, and append the new record to it
            var feedbackSet = GetAllFeedback();
            var feedback = feedbackSet.FirstOrDefault(m => m.ID.Equals(id));

            var newFeedbackSet = GetAllFeedback().Where(m => m.ID.Equals(id) == false);

            SaveFeedback(newFeedbackSet);

            return feedback;
        }
    }
}