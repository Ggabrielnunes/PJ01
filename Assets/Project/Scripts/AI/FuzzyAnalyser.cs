using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FuzzyLogicController.RuleEngine;
using FuzzyLogicController;
using FuzzyLogicController.MFs;
using FuzzyLogicController.FLC;

    public class FuzzyAnalyser
    {
        private static Config configure;
        private static LingVariable health;
        private static LingVariable mood;
        private static FLC c;
        private static List<Rule> rules;
        private static InferEngine engine;


        public static void Init()
        {
            configure = new Config(ImpMethod.Prod, ConnMethod.Min);

            //Variavel de entrada
            //vida
            health = new LingVariable("Health", VarType.Input); //declare new lingustic variable
            health.setRange(0, 35); // set max - min range for our variables 0 mph -35 mph
            health.addMF(new Trimf("Low", 0, 0, 55)); // trapmf: trapazoid shape behaviour
            health.addMF(new Trimf("Medium", 0, 50, 100)); // trimf: triangle shape behaviour
            health.addMF(new Trimf("High", 45, 100, 100));
        
            mood = new LingVariable("Mood", VarType.Output);
            mood.setRange(0, 65);  // Brake Force
            mood.addMF(new Trimf("Angry", -1, -1, 1));
            mood.addMF(new Trimf("Sad", -1, 0, 1));
            mood.addMF(new Trimf("Happy", 0.45, 1, 1.45));

            //IF Health IS High THEN Mood is Happy
            List<RuleItem> rule1in = new List<RuleItem>();
            List<RuleItem> rule1out = new List<RuleItem>();

            // the if part of the Rule, add more than one if X1 and X2, 
            // add another RuleItem in the list
            rule1in.AddRange(new RuleItem[1] { new RuleItem("Health", "High") });

            // the then part in the Rule
            rule1out.AddRange(new RuleItem[1] { new RuleItem("Mood", "Happy") });

            // List of rules "RuleBase" passed to the Inference Engine
            rules = new List<Rule>();
            rules.Add(new Rule(rule1in, rule1out, Connector.And));

        }
        public static float CalculateEmotionLevels(Data[] p_data, float p_value)
        {
            c = new FLC(configure);
            double healthCurrentCrisp = p_data[0].health;
            FuzzySet fuzzy_health = new FuzzySet(c.Fuzzification(healthCurrentCrisp, health), health.Name);

            List<FuzzySet> input_sets = new List<FuzzySet>();
            input_sets.Add(fuzzy_health);

            engine = new InferEngine(configure, rules, input_sets);
            List<FuzzySet> fuzzy_out = engine.evaluateRules();

            float crisp_mood = (float)c.DeFuzzification(fuzzy_out, mood);

            return crisp_mood;
        }
    }

