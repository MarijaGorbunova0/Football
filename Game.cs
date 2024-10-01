namespace Football;

public class Game
{
    public Team HomeTeam { get; }
    public Team AwayTeam { get; }
    public Stadium Stadium { get; }
    public Ball Ball { get; private set; }
    public int teamScore = 0;
    public Game(Team homeTeam, Team awayTeam, Stadium stadium)
    {
        HomeTeam = homeTeam;
        homeTeam.Game = this;
        AwayTeam = awayTeam;
        awayTeam.Game = this;
        Stadium = stadium;
    }

    public void Start()
    {
        Ball = new Ball(Stadium.Width / 2, Stadium.Height / 2, this);
        HomeTeam.StartGame(Stadium.Width / 2, Stadium.Height);
        AwayTeam.StartGame(Stadium.Width / 2, Stadium.Height);
        
    }
    private (double, double) GetPositionForAwayTeam(double x, double y)
    {
        return (Stadium.Width - x, Stadium.Height - y);
    }

    public (double, double) GetPositionForTeam(Team team, double x, double y)
    {
        return team == HomeTeam ? (x, y) : GetPositionForAwayTeam(x, y);
    }

    public (double, double) GetBallPositionForTeam(Team team)
    {
        return GetPositionForTeam(team, Ball.X, Ball.Y);
    }

    public void SetBallSpeedForTeam(Team team, double vx, double vy)
    {
        if (team == HomeTeam)
        {
            Ball.SetSpeed(vx, vy);
        }
        else
        {
            Ball.SetSpeed(-vx, -vy);
        }
    }
    public void CheckForGoal(Gates gates, ref int teamScore, string teamName)
    {
        if (Ball.X >= gates.x && Ball.X <= gates.x + 20 && Ball.Y >= gates.y && Ball.Y <= gates.y + 20)
        {
            teamScore++; 
            Console.SetCursorPosition(0, teamName == "Home" ? 0 : 1);
            ResetBall(); 
        }
    }

    public void ResetBall()
    {
        Ball.X = 50; 
        Ball.Y = 25;
    }
    public void Move()
    {
        HomeTeam.Move();
        AwayTeam.Move();
        Ball.Move();
    }
}