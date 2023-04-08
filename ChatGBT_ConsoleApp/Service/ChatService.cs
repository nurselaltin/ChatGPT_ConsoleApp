using MyAIAssistant.DataAccess;
using MyAIAssistant.Model;


namespace MyAIAssistant.Service
{
  public class ChatService
  {
    private RestSharpService _restSharp;

    public ChatService(string apikey)
    {
      _restSharp = new RestSharpService("https://api.openai.com/v1/chat/" , apikey);
    }

    public ChatModel _chat { get; set; }
    public string AskToAI(string content)
    {
      return _restSharp.Post(content);
    }
  }
}
