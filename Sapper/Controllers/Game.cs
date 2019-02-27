using Sapper.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapper.Controllers
{
    public static class Game
    {
        #region Variables
        private static int[,] Pole;
        #endregion
        //______________________________________________________________
        //**************************************************************

        #region Interfce
        public static void StartGame(int i,int j, int bombs)
        {
            CreatePole(i,j);
            InitPole();
            SeedPole(bombs);
            //throw new NotImplementedException();
        }
        #endregion
        #region Methods
        private static void CreatePole(int i, int j)
        {
            Pole = null;
            Pole = new int[i, j];
        }
        private static void InitPole()
        {
            for (int i = 0; i < Pole.GetLength(0); i++)
            {
                for (int j = 0; j < Pole.GetLength(1); j++)
                {
                    Pole[i, j] = 0;
                }
            }
        }
        private static void SeedPole(int bombs)
        {
            int TotalCell = Pole.GetLength(0) * Pole.GetLength(1);
            if (bombs == 0) throw new ArgumentException("bombs equal zero");
            if (bombs > TotalCell) throw new ArgumentException("Слишком много бомб!");
            Random rnd = new Random();
            int i;
            int j;
            int count = bombs;

            do
            {
                i = rnd.Next(0, Pole.GetLength(0));
                j = rnd.Next(0, Pole.GetLength(1));
                if (Pole[i, j] == 0)
                {
                    Pole[i, j] = -1;
                    count--;
                }
            }
            while (count > 0);
        }

        private static int CalcNeigbourCells(Cell cell)
        {
              int i = cell.I;
              int j = cell.J;
              int result = 0;
            //проверить ячейки на то что они в поле и на наличие бомбы(9 условий) на самом деле 4 значения
            //throw new NotImplementedException();
            //1
            if (i>0 && j>0 &&  Pole[i-1,j-1]==-1)
            {
                result++;
            }
            //2
            if(j>0 && Pole[i,j-1]==-1)
            {
                result++;
            }
            //3
            if(i<Pole.GetLength(0)-1 && Pole[i+1,j-1] ==-1)
            {
                result++;
            }
            //4
            if(i>0 && Pole[i-1,j]==-1)
            {
                result++;
            }
            //5
            if(i<Pole.GetLength(0)-1 && Pole[i+1,j]==-1)
            {
                result++;
            }
            //6
            if (i>0 && j<Pole.GetLength(1)-1 && Pole[i-1,j+1]==-1)
            {
                result++;
            }
            //7
            if(j<Pole.GetLength(1)-1 && Pole[i,j+1]==-1)
            {
                result++;
            }
            //8
            if(i<Pole.GetLength(0)-1 && j<Pole.GetLength(1)-1 && Pole[i+1,j+1]==-1)
            {
                result++;
            }
            
            return result;
        }
        public static int[,] GetPole()
        {

            return Pole;
        }
        
        #endregion

    }
}
