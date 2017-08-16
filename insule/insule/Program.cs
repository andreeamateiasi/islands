using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insule
{
    public class Coord
    {
        public int x, y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[,] matrix = new int[n,n];
            Random random = new Random();
            List<Coord> coor = new List<Coord>();
            List<Coord> list = new List<Coord>();

            Coord coordinates = new Coord();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                   
                    int test = random.Next(0, 2);
                    matrix[i, j] = test;
                    if(test == 1)
                    {
                        coordinates.x = i;
                        coordinates.y = j;
                        coor.Add(new Coord() {x=i, y=j });
                    }
                    Console.Write(test + " ");
                    

                }
                Console.WriteLine("\n");
            }
            for (int k = 0; k<coor.Count;k++)
            {
                Insula(list, coor[k].x, coor[k].y, matrix);
                for(int  c=0;c<list.Count;c++)
                {
                    Console.Write(k + ". " + list[c].x + " " + list[c].y + " ");
                }

            }
            Console.ReadKey();


        }
        static List<Coord> Insula(List<Coord> list, int istart, int jstart, int[,] Matrix)
        {
            if(istart>=0 &&istart<5 && jstart>=0 && jstart <5 && Matrix[istart,jstart] == 1 && Found(list, istart, jstart) == false)
            {
                
                if(Found(list, istart,jstart) == false)
                    list.Add(new Coord() { x=istart, y=jstart});
                Insula(list, istart + 1, jstart, Matrix);
                Insula(list, istart - 1, jstart, Matrix);
                Insula(list, istart, jstart + 1, Matrix);
                Insula(list, istart, jstart - 1, Matrix);
            }
            return list;

        }
        static bool Found(List<Coord> list, int istart, int jstart)
        {
            Coord co = new Coord();
            co.x = istart;
            co.y = jstart;
            if (list.Contains(co) == true)
            {
                return true;
            }
            return false;
        }
    }
}
