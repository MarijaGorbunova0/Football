using System;
using System.Collections.Generic;

namespace Football
{
    public class Gates
    {
        public char symb;
        public int x; // Координата X ворот
        public int y; // Координата Y ворот
        public int count = 0;
        public List<int> gatesY = new List<int>();

        public Ball ball; // Ссылка на мяч

        public Gates(char sym, int x, int y)
        {
            symb = sym;
            this.x = x;
            this.y = y; // Инициализация координаты Y ворот
        }

        public void CreateGates()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(this.x, this.y + i);
                Console.WriteLine(symb);
                gatesY.Add(this.y + i); // Добавляем координаты Y ворот
            }
            foreach (var number in gatesY)
            {
                Console.WriteLine(number);
            }
        }

        public void Counter()
        {
            // Проверяем, был ли мяч инициализирован
            if (ball != null)
            {
                // Проверяем, забит ли гол
                if (ball.X == x && gatesY.Contains((int)ball.Y))
                {
                    count++;
                    Console.SetCursorPosition(0,0);
                    Console.WriteLine($"gool{count}");
                }
                else
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine($"{count}");
                }
            }
            else
            {
                Console.WriteLine("non");
            }
        }
    }
}
