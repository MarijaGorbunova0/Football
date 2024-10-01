using System;

namespace Football
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Team homeTeam = new Team("Home Team");
            Team awayTeam = new Team("Away Team");
            int homeTeamCount = 0;
            int awayTeamCount = 0;
            List<Team> teams = new List<Team>() { homeTeam, awayTeam };


            foreach (var team in teams)
            {
                for (int i = 0; i < 10; i++)
                {
                    team.AddPlayer(new Player($"{team.Name}:{i + 1}"));
                }
            }

            Stadium stadium = new Stadium(100, 50); 
            Game game = new Game(homeTeam, awayTeam, stadium);

            Gates awayGates = new Gates('*', 1, 15); 
            
           


            Gates homeGates = new Gates('*', 80, 15);
        

            homeTeam.StartGame(stadium.Width, stadium.Height);
            awayTeam.StartGame(stadium.Width, stadium.Height);
           
             Console.Clear();
             
             stadium.Draw(); 
             awayTeam.Draw();
             homeTeam.Draw();
             awayGates.CreateGates(homeTeamCount);
             homeGates.CreateGates(awayTeamCount);
   
            game.Start();

            while (true)
            {
               
                Thread.Sleep(500);
                game.Move();

                game.CheckForGoal(awayGates, ref homeTeamCount, "Home");
                game.CheckForGoal(homeGates, ref awayTeamCount, "Away");

                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"Home Team: {homeTeamCount} | Away Team: {awayTeamCount}");

            }

        }
    }
}
