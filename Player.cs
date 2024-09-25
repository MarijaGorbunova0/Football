using System;

namespace Football;

public class Player
{
    public string Name { get; }
    public double X { get; private set; }
    public double Y { get; private set; }
    private double _vx, _vy; // samm
    public Team? Team { get; set; } = null;

    // Maksimaalse kiiruse ja palli tabamise kauguse konstandid
    private const double MaxSpeed = 5;
    private const double MaxKickSpeed = 25;
    private const double BallKickDistance = 10; // дальность удара

    // Juhuslike arvude generaator juhuslike löögikiiruste genereerimiseks
    private Random _random = new Random();

    public Player(string name)
    {
        Name = name;
    }

    public Player(string name, double x, double y, Team team)
    {
        Name = name;
        X = x;
        Y = y;
        Team = team;
    }

    // Mängija positsiooni määramine väljakul
    public void SetPosition(double x, double y)
    {
        X = x;
        Y = y;
    }
    // Hankige mängija absoluutne positsioon, võttes arvesse meeskonna positsiooni
    public (double, double) GetAbsolutePosition()
    {
        return Team!.Game.GetPositionForTeam(Team, X, Y);
    }
    // Arvutage kaugus mängijast pallini
    public double GetDistanceToBall()
    {
        var ballPosition = Team!.GetBallPosition();
        var dx = ballPosition.Item1 - X;
        var dy = ballPosition.Item2 - Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    // Mängija liikumine palli poole
    public void MoveTowardsBall()
    {
        var ballPosition = Team!.GetBallPosition(); // Saame palli asukoht
        var dx = ballPosition.Item1 - X;
        var dy = ballPosition.Item2 - Y;
        // Liikumisvektori normaliseerimine
        var ratio = Math.Sqrt(dx * dx + dy * dy) / MaxSpeed;
        _vx = dx / ratio;
        _vy = dy / ratio;
    }

    public void Move()
    {
        if (Team.GetClosestPlayerToBall() != this)
        {
            _vx = 0;
            _vy = 0;
        }

        // Kui mängija on palli löögikauguses, määrake palli kiirus
        if (GetDistanceToBall() < BallKickDistance)
        {
            Team.SetBallSpeed(
                MaxKickSpeed * _random.NextDouble(),
                MaxKickSpeed * (_random.NextDouble() - 0.5)
                );
        }

        var newX = X + _vx;
        var newY = Y + _vy;
        var newAbsolutePosition = Team.Game.GetPositionForTeam(Team, newX, newY);

        // Kontrollime, kas uus asukoht on staadioni sees
        if (Team.Game.Stadium.IsIn(newAbsolutePosition.Item1, newAbsolutePosition.Item2))
        {
            X = newX;
            Y = newY;
        }
        else
        {
            _vx = _vy = 0;
        }
    }
}