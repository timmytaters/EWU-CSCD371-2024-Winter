using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//You should consider the relationship between Student and Employee and refactor the common code shared between them. ❌✔
namespace Logger
{
    public record class Person(FullName PersonName) : EntityBase
    { 
        public override string Name
        {
            get => PersonName.GetFullName();
        }
    }
}
