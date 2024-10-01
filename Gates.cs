using System;
using System.Collections.Generic;

namespace Football
{
    public class Gates
    {
        public char symb;
        public int x, y;
   

        public Gates(char symb, int x, int y)
        {
            this.symb = symb;
            this.x = x;
            this.y = y;
        }
        public void CreateGates(int count)
        {
            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.SetCursorPosition(x + j, y + i);
                    Console.Write(symb);
                }
            }
        }
    }
}
