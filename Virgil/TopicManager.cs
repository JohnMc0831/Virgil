using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Virgil
{
    /// <summary>
    /// The TopicManager class encapsulates all client/server communications
    /// for the Virgil client.  All communications are using RESTful principles,
    /// and also use JSON for serialization.  XML support is not planned.
    /// </summary>
    class TopicManager
    {
        //Intentional hard-code.  
        private const string WebServerUrl = "http://http://virgil.ftltech.org/";

        public HttpClient Client { get; set; }
        public TopicManager()
        {
            Client = new HttpClient { BaseAddress = new Uri(WebServerUrl) };
        }

        /// <summary>
        /// GetTopicsAsync() returns an IList<Topic>
        /// for consumption by platform-specific clients.
        /// </summary>
        /// <returns>List<Topic></returns>
        public async Task<List<Topic>> GetTopicsAsync()
        {
            var response = await Client.GetAsync("/api/Topics");
            var topicsJson = response.Content.ReadAsStringAsync().Result;
            var listTopics = JsonConvert.DeserializeObject<List<Topic>>(topicsJson);
            return listTopics;
        }

        /// <summary>
        /// GetTopicAsync returns a single topic with all associated children...
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Topic</returns>
        public async Task<Topic> GetTopicAsync(Int32 id)
        {
            var response = await Client.GetAsync($"/api/Topics/{id}");
            var topicJson = response.Content.ReadAsStringAsync().Result;
            var topic = JsonConvert.DeserializeObject<Topic>(topicJson);
            return topic;
        }
    }
}
