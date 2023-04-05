using RestSharp;
using Newtonsoft.Json;


Console.WriteLine("Apı Key:");
var apiKey = Console.ReadLine();

var openAI = new OpenAI("https://api.openai.com/v1/chat/", apiKey);

while (true)
{
  Console.WriteLine("::");
  var prompt = Console.ReadLine();
  var choices = openAI.AskToAI(prompt);

  Console.WriteLine(choices);
}
public class OpenAI
{
  private string _apiKey { get; set; }
  private RestClient _client { get; set; }
  public Chat _chat { get; set; }

  public OpenAI(string apiUrl, string apiKey)
  {
    // Create a new RestClient instance
    _client = new RestClient(apiUrl);
    _apiKey = apiKey;
    _chat = new Chat()
    {
      model = "gpt-3.5-turbo",
      messages = new List<Message>()
    };
    _chat.messages = new List<Message>();
 
  }
  public string AskToAI(string content)
  {
    var choices = "";
    // Create a new RestRequest instance with the desired HTTP method and resource path
    var req = new RestRequest("completions", Method.Post);
    _chat.messages.Add(new Message() { role = "user" , content = content});

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
      
      var yy =JsonConvert.DeserializeObject<dynamic>(responseData).choices[0];
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
public class Chat
{
  public string model { get; set; }
  public List<Message> messages { get; set; }
}
public class Message
{
  public string role { get; set; }
  public string content { get; set; }
}


