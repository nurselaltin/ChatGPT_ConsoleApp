using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAIAssistant.DataAccess
{
  public interface IRestSharp
  {
    string Post(string content);
  }
}
