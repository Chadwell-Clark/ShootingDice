using System;
using System.Collections.Generic;

namespace ShootingDice
{
    // A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
    public class CreativeSmackTalkingPlayer : Player
    {
        public List<string> taunts = new List<string>()
        {
            "You are English types ,you silly King",
            "You pigdogs.",
                  "Go and Boil your bottoms",
                "You Empty headed animal food trough water",
                "Sons of a silly person",
                "I blow my nose at you",
                "I fart in your general direction",
                "Your mother was a hamster and your father smelt of elderberries"
            };
        public int Taunt()
        {
            Random random = new Random();
            int num = random.Next(taunts.Count);
            return num;
        }
        public override int Roll()
        {
            // Return a random number between 1 and DiceSize
            Console.WriteLine(taunts[Taunt()]);
            return new Random().Next(DiceSize) + 1;
        }
    }
}