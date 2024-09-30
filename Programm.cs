using System;

namespace Football
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Team homeTeam = new Team("Home Team");
            Team awayTeam = new Team("Away Team");

            List<Team> teams = new List<Team>() { homeTeam, awayTeam };


            foreach (var team in teams)
            {
                for (int i = 0; i < 10; i++)
                {
                    team.AddPlayer(new Player($"{team.Name}:{i + 1}"));
                }
            }

            Stadium stadium = new Stadium(100, 50); // Width, Height
            Game game = new Game(homeTeam, awayTeam, stadium);

            Gates awayGates = new Gates('*', 7, 15); // X = 7, Y = 15
            awayGates.CreateGates();
           


            Gates homeGates = new Gates('*', 93, 15); // X = 93, Y = 15
            homeGates.CreateGates();

            homeTeam.StartGame(stadium.Width, stadium.Height);
            awayTeam.StartGame(stadium.Width, stadium.Height);
           
             Console.Clear();
             stadium.Draw(); 
             awayTeam.Draw();
             homeTeam.Draw();
             awayGates.CreateGates();
             homeGates.CreateGates();

            // Start the game
            game.Start();

            while (true)
            {
               
                Thread.Sleep(500);
                game.Move();
                awayGates.ball = game.Ball;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Away team ");
                awayGates.Counter();


                homeGates.ball = game.Ball;
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Home team ");
                homeGates.Counter();

            }

        }
    }
}
