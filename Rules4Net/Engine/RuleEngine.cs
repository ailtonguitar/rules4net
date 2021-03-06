﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rules4Net.Data;
using Rules4Net.Repository;
using System.Reflection;
using Rules4Net.Helpers;
using Rules4Net.Listener;
using Rules4Net.Listener.Repository;
using Rules4Net.Strategies;
using Rules4Net.Logging;

namespace Rules4Net.Engine
{
    public class RuleEngine : IRuleEngine
    {
        private static readonly ILog Logger = LogProvider.For<RuleEngine>();
        private IRuleStore _pool;
        private IRuleEvaluationStrategy _strategy { get; set; }

        public RuleEngine(IRuleStore pool) : this(pool, new SimpleRuleEvaluationStrategy())
        {
        }

        public RuleEngine(IRuleStore pool, IRuleEvaluationStrategy strategy)
        {
            _pool = pool;
            _strategy = strategy;
        }

        public IEnumerable<IRule> Evaluate(IDictionary<string, object> data)
        {
            var rules = _pool.Get();
            var matchRules = _strategy.Evaluate(rules, data);
            Logger.DebugFormat("{0} rule(s) matched the criteria", rules.Count());
            return matchRules;
        }

        public IEnumerable<IRule> Evaluate(object data)
        {
            return this.Evaluate(ObjectHelper.ToDictionary(data));
        }

        public IEnumerable<IRule> EvaluateAndFire(object data)
        {
            var rules = this.Evaluate(data);
            FireRulesEvent(data, rules);
            return rules;
        }

        public IEnumerable<IRule> EvaluateAndFire(IDictionary<string, object> data)
        {
            var rules = this.Evaluate(data);
            FireRulesEvent(data, rules);
            return rules;
        }

        private void FireRulesEvent(object data, IEnumerable<IRule> rules)
        {
            foreach (var rule in rules)
            {
                foreach (var listener in rule.Listeners) {
                    Logger.Debug("Triggering listener.");
                    listener.Handle(data);
                }
            }
        }
    } //class
}
