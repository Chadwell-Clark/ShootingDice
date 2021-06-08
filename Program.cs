using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootingDice
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine();
            Console.Clear();
            Console.WriteLine("Lets Shoot some Dice");
            Console.WriteLine();
            Console.WriteLine("\u2680 \u2685 \u2685  \u2680  ");

            Player player1 = new Player();
            player1.Name = "Bob";

            Player player2 = new Player();
            player2.Name = "Sue";

            player2.Play(player1);

            Console.WriteLine("-------------------");

            Player player3 = new Player();
            player3.Name = "Wilma";

            player3.Play(player2);

            Console.WriteLine("-------------------");

            Player large = new LargeDicePlayer();
            large.Name = "Bigun Rollsalot";

            large.Play(player3);

            Console.WriteLine("-------------------");

            Player taunto = new SmackTalkingPlayer();
            taunto.Name = "YellsAlot";

            taunto.Play(large);

            Console.WriteLine("-------------------");

            Player oneup = new OneHigherPlayer();
            oneup.Name = "BeatYouByOne";

            oneup.Play(taunto);

            Console.WriteLine("-------------------");

            Player smartass = new CreativeSmackTalkingPlayer();
            smartass.Name = "InsultingFrenchman";

            smartass.Play(oneup);

            Console.WriteLine("-------------------");

            Player sore = new SoreLoserPlayer();
            sore.Name = "Major Whiner";

            sore.Play(smartass);

            Console.WriteLine("-------------------");

            Player upper = new UpperHalfPlayer();
            upper.Name = "Better Half";
            upper.Play(sore);

            Console.WriteLine("-------------------");

            Player soreUpper = new SoreLoserUpperHalfPlayer();
            soreUpper.Name = "Upper Minor Whiner ";
            soreUpper.Play(upper);

            Console.WriteLine("-------------------");



            List<Player> players = new List<Player>() {
                player1, player2, player3, large, taunto, oneup, smartass, sore, upper, soreUpper
            };

            PlayMany(players);
        }

        static void PlayMany(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine("Let's play a bunch of times, shall we?");

            // We "order" the players by a random number
            // This has the effect of shuffling them randomly
            Random randomNumberGenerator = new Random();
            List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

            // We are going to match players against each other
            // This means we need an even number of players
            int maxIndex = shuffledPlayers.Count;
            if (maxIndex % 2 != 0)
            {
                maxIndex = maxIndex - 1;
            }

            // Loop over the players 2 at a time
            for (int i = 0; i < maxIndex; i += 2)
            {
                Console.WriteLine("-------------------");

                // Make adjacent players play noe another
                Player player1 = shuffledPlayers[i];
                Player player2 = shuffledPlayers[i + 1];
                player1.Play(player2);
            }
        }
    }
}