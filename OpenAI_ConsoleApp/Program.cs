using MyAIAssistant.Service;

Console.WriteLine("API Key:");
var apiKey = Console.ReadLine();

var chat = new ChatService(apiKey);

while (true)
{
  Console.WriteLine("Ask Me Anyting::");
  var prompt = Console.ReadLine();
  
  var aiResponse = chat.AskToAI(prompt);
  Console.WriteLine("--------------------------------------------------------------------------"); 
  Console.WriteLine(""); 
  Console.WriteLine("");
  Console.WriteLine(aiResponse);
  Console.WriteLine("");
  Console.WriteLine("");
  Console.WriteLine("--------------------------------------------------------------------------");
}



