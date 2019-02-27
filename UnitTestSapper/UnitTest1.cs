using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sapper.Controllers;

namespace UnitTestSapper
{
    [TestClass]
    public class UnitTestGame
    {
        [TestMethod]
        public void Testgame()
        {
            Game.StartGame(10, 10, 10);
            ShowPole(Game.GetPole());
        }

        private void ShowPole(int[,] pole)
        {
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                string row = string.Empty;
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    row += pole[i, j].ToString() + "  ";
                }
                Console.WriteLine(row);
            }
           // throw new NotImplementedException();
        }
    }
}
