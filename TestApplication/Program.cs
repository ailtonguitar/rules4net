using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using Rules4Net.Data.Filters;
using Rules4Net.Engine;
using Rules4Net.Logging;
using Rules4Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication {
    class Program {
        static void Main(string[] args) {            
            LogProvider.SetCurrentLogProvider(new ColoredConsoleLogProvider());            

            Rule rule1 = new Rule();
            rule1.Add(new AndFilter(new List<IConstraint> {
                new EqualsConstraint("name", "Joao Paulo")
            }));
                       
            IRuleStore pool = new MemoryRuleStore(new[] { rule1 } );
            IRuleEngine engine = new RuleEngine(pool);
            var result = engine.Evaluate(new {
                name = "Joao Paulo",
                age = 17
            }).ToList();

            Console.Read();
        }
    }
}
