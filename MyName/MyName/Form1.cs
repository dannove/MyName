using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MyName
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string fileName;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "..\\";
            openFileDialog1.Filter = "txt files(*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            Graphics g = panel1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 3);
           using(StreamReader sr = new StreamReader(fileName))
           {
               string oneLine = sr.ReadLine();
               while (oneLine!="END")
               {
                    List<Point> oneLineDate = new List<Point>();
                   while ((oneLine=sr.ReadLine() )!= "END")
                   {    
                       string[] onePointDate = oneLine.Split(',');
                       oneLineDate.Add(new Point(Convert.ToInt16(onePointDate[0]), Convert.ToInt16(onePointDate[1])));
                   }
                   Point[] oneLinePoints = new Point[oneLineDate.Count];
                   for (int i = 0; i < oneLineDate.Count; i++)
                   {
                       oneLinePoints[i] = oneLineDate[i];
                   }
                   g.DrawLines(pen, oneLinePoints);
                   g.DrawLine(pen, oneLinePoints[oneLineDate.Count - 1], oneLinePoints[0]);
                   oneLine = sr.ReadLine();
               }
           }

        }


    }
}
