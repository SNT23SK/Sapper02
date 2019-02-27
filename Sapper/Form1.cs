using Sapper.Controllers;
using Sapper.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper
{
    public partial class FormMain : Form
    {
        #region Variables
        private int size = 20;
        #endregion
        public FormMain()
        {
            InitializeComponent();
        }

        private void CreateField()
        {
            panel1.Controls.Clear();// очищение панели 
            for (int i = 0; i < Game.GetPole().GetLength(0); i++) // Game.GetPole().GetLength(0)- возвращает длину массива, где ноль это строка
            {
                for (int j = 0; j < Game.GetPole().GetLength(1); j++)//  Game.GetPole().GetLength(1)- возвращает длину массива, где еденица это столбец
                {
                    Cell cell = new Cell(i, j) // создание ячейки(кнопки с индексами i,j) с необходимыми параметрами
                    {
                        Left = i * size,
                        Top = j * size,
                        Width = size,
                        Height = size
                    };
                    cell.MouseUp += Cell_Click; //привязываем Клик(событие клик) к кнопке
                  
                    panel1.Controls.Add(cell); // добавляем кнопку(кнопку с индексами или виджет) на панель
                }


            }
            //Выравнивание контейнера по количеству ячеек
            panel1.Height = Game.GetPole().GetLength(0) * size;
            panel1.Width = Game.GetPole().GetLength(1) * size;

        }
        /// <summary>
        /// Событие на клик левой  и правой кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cell_Click(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                int value = Game.GetPole()[((Cell)sender).I, ((Cell)sender).J];
                if (value==-1)
                {
                    ((Cell)sender).Text = "Ж";
                    ((Cell)sender).FlatStyle = FlatStyle.Flat;
                }

                if (string.IsNullOrEmpty(((Cell)sender).Text))
                {
                    ((Cell)sender).FlatStyle = FlatStyle.Flat;
                }


            }
            if (e.Button == MouseButtons.Right)
            {
                if (((Cell)sender).FlatStyle != FlatStyle.Flat)
                {
                    if (string.IsNullOrEmpty(((Cell)sender).Text))
                    {
                        ((Cell)sender).Text = "P";
                    }
                    else
                    {
                        ((Cell)sender).Text = string.Empty;
                    }
                }
            }

        }
        #region Methods
        /// <summary>
        /// Метод 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private Cell GetCellByCoordinates(int i, int j)
        {
            foreach (Cell item in panel1.Controls)
            {

                // написать проверку пределов должна возвращать 0
                if (item.I == i && item.J == j)
                {
                    return item;
                }
                
            }
            return null;
           // throw new NotImplementedException();
        }

        private void ShowArea(Cell cell)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           // Game.StartGame(10, 10, 10);
           // CreateField();

        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.StartGame(10, 10, 10);
            CreateField();
        }
    }
}
