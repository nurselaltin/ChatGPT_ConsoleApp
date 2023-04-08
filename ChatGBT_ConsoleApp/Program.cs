using MyAIAssistant.Service;

Console.WriteLine("Apı Key:");
var apiKey = Console.ReadLine();

var chat = new ChatService(apiKey);
//Create a method about mathematical operations with C#?
while (true)
{
  Console.WriteLine("Ask Me Anyting::");
  var prompt = Console.ReadLine();
  
  var choices = chat.AskToAI(prompt);
  Console.WriteLine("--------------------------------------------------------------------------"); 
  Console.WriteLine(""); 
  Console.WriteLine("");
  Console.WriteLine(choices);
  Console.WriteLine("");
  Console.WriteLine("");
  Console.WriteLine("--------------------------------------------------------------------------");
}



