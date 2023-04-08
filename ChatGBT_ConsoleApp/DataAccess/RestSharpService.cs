using MyAIAssistant.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MyAIAssistant.DataAccess
{
  public class RestSharpService : IRestSharp
  {
    private string _apiKey { get; set; }
    private RestClient _client { get; set; }
    public ChatModel _chat { get; set; }



    public RestSharpService(string apiUrl, string apiKey)
    {
      // Create a new RestClient instance
      _client = new RestClient(apiUrl);
      _apiKey = apiKey;
      _chat = new ChatModel()
      {
        model = "gpt-3.5-turbo",
        messages = new List<Message>()
      };
      _chat.messages = new List<Message>();

    }
    public string Post(string content)
    {
      var choices = "";
      // Create a new RestRequest instance with the desired HTTP method and resource path
      var req = new RestRequest("completions", Method.Post);
      _chat.messages.Add(new Message() { role = "user", content = content });

      req.AddBody(JsonConvert.SerializeObject(_chat));

      // Add headers to the request
      req.AddHeader("Authorization", "Bearer " + _apiKey);
      req.AddHeader("Content-Type", "application/json");

      // Execute the request and get the response
      var res = _client.Execute(req);

      // Handle the response
      if (res.StatusCode == System.Net.HttpStatusCode.OK)
      {
        // Do something with the response data
        var responseData = res.Content;

        var yy = JsonConvert.DeserializeObject<dynamic>(responseData).choices[0];
        choices = yy.message.content;


      }
      else
      {
        // Handle the error
        var errorResponse = res.Content;
      }

      return choices;
    }
  }
}
