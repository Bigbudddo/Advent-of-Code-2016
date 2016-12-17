using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2016 {
    
    public static class Day10 {
        
        public static Dictionary<int, Bot> FactoryBots = new Dictionary<int,Bot>();

        public static void RunPart1(string[] instructions) {
            BuildBotFactory(instructions);
            ExecuteFactoryInstructions(instructions);
        }

        public static void BuildBotFactory(string[] instructions) {
            //value 61 goes to bot 166
            foreach (string s in instructions) {
                string[] _s = s.Split(' ');
                if (_s[0] == "value") {
                    int botId = int.Parse(_s[_s.Length - 1]);
                    if (FactoryBots.ContainsKey(botId)) {
                        if (FactoryBots[botId].BotChipA == 0) {
                            FactoryBots[botId].BotChipA = int.Parse(_s[1]);
                        }
                        else if (FactoryBots[botId].BotChipB == 0) {
                            FactoryBots[botId].BotChipB = int.Parse(_s[1]);
                        }
                    }
                    else {
                        FactoryBots.Add(botId, new Bot() {
                            BotId = botId,
                            BotChipA = int.Parse(_s[1])
                        });
                    }
                }
            }
        }

        public static void ExecuteFactoryInstructions(string[] instructions) {
            //bot 2 gives low to bot 1 and high to bot 0
            //bot 1 gives low to output 1 and high to bot 0
            foreach (string s in instructions) {
                string[] _s = s.Split(' ');
                if (_s[0] == "bot") {
                    if (FactoryBots.ContainsKey(int.Parse(_s[1]))) {

                    }
                    else {

                    }
                }
            }
        }
    }

    public class Bot {
        public int BotId { get; set; }
        public int? BotChipA { get; set; }
        public int? BotChipB { get; set; }

        public int? GetLow() {
            if (BotChipA == null && BotChipA == null) return null;
            else if (BotChipA == null && BotChipB != null) return BotChipB;
            else if (BotChipA != null && BotChipB == null) return BotChipA;
            else if (BotChipA != null && BotChipB != null) {
                if (BotChipA >= BotChipB) return BotChipB;
                else return BotChipA;
            }
            else return null;
        }

        public int? GetHigh() {
            if (BotChipA == null && BotChipA == null) return null;
            else if (BotChipA == null && BotChipB != null) return BotChipB;
            else if (BotChipA != null && BotChipB == null) return BotChipA;
            else if (BotChipA != null && BotChipB != null) {
                if (BotChipA >= BotChipB) return BotChipA;
                else return BotChipB;
            }
            else return null;
        }
    }
}
