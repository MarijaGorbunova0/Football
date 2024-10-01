namespace Football;

public class Stadium
{
    public Stadium(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Width { get; }

    public int Height { get; }

    public bool IsIn(double x, double y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }

    public void Draw()
    {
        for (int y = 0; y <= Height; y++)
        {
            for (int x = 0; x <= Width; x++)
            {
                if (x == 0 || x == Width) 
                {
                    Console.Write("|");
                }
                else if (y == 0 || y == Height) 
                {
                    Console.Write("-");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}