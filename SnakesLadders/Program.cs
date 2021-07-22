using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakesLadders
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Ladders and Snakes");

            int size = 10;
            Console.WriteLine("Write the size of the board (between 10 and 20");
            var str = Console.ReadLine();
            if(!int.TryParse(str, out size))
                size = 10;

            if(size < 10) size = 10;
            if(size > 20) size = 20;

            int players = 2;
            Console.WriteLine("Write number of players (between 2 and 5)");
            str = Console.ReadLine();
            if(!int.TryParse(str, out players))
                players = 2;


            if(players < 2) players = 2;
            if(players > 5) players = 5;

            Game game = new Game(players, size);

            while(true)
            {

                Random random = new Random();
                var ladders = new List<Segment>(); //5 ladders
                for(int i = 0; i < 5; i++)
                {
                    int a = random.Next(1, size * size);
                    int b = random.Next(1, size * size );
                    Segment s = new Segment(Math.Max(a, b), Math.Min(a, b));
                    ladders.Add(s);
                }

                var snakes = new List<Segment>(); //5 snakes
                for(int i = 0; i < 5; i++)
                {
                    int a = random.Next(1, size * size );
                    int b = random.Next(1, size * size);
                    Segment s = new Segment(Math.Max(a, b), Math.Min(a, b));
                    snakes.Add(s);
                }

                try
                {
                    game.SetLaddersAndSnakes(ladders, snakes);
                    break;
                }
                catch(Exception) { }
            }

            Console.WriteLine("end");



            Random dice = new Random();
            while(true)
            {
                for(int i = 0; i < players; i++)
                {
                    int d = dice.Next(1, 7);
                    Console.Write($"Player {i + 1} move dice {d}");
                    game.Move(i, d);

                    Console.WriteLine($"   position= {game.GetScoreOfPlayer(i)}");

                    if(game.Winner.HasValue)
                    {
                        Console.WriteLine($"Player {i + 1} won !!!!");
                        return;
                    }

                    Thread.Sleep(100);
                }

            }
        }
    }
}
