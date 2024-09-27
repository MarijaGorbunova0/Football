using System;

namespace Football
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Team homeTeam = new Team("Home Team");
            Team awayTeam = new Team("Away Team");


          
            
            for (int i = 1; i <= 11; i++) // 11 players each team
            {
                homeTeam.AddPlayer(new Player($"HomePlayer{i}"));
                awayTeam.AddPlayer(new Player($"AwayPlayer{i}"));
            }
        

          
            Stadium stadium = new Stadium(100, 50); // Width, Height
            Game game = new Game(homeTeam, awayTeam, stadium);
      

            Ball ball = new Ball(50, 25, game);
           
            homeTeam.StartGame(stadium.Width, stadium.Height);
            awayTeam.StartGame(stadium.Width, stadium.Height);
           
             Console.Clear();
             stadium.Draw(); 
             awayTeam.Draw(); 
             ball.Draw();
            homeTeam.Move(); // Движение игроков домашней команды
            awayTeam.Move();

            // Start the game
            game.Start();
            string WK = Console.ReadLine();
        }
    }
}
