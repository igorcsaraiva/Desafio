using System.Collections.Generic;
using System.Linq;

namespace Desafio.Domain.Validation
{
    public class ValidationResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get { return Erros.Count() == 0; } }
        public IEnumerable<string> Erros { get; set; }
        public ValidationResponse()
        {
            Erros = new List<string>();
        }
    }
}
