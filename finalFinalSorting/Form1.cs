using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace finalFinalSorting
{
    public partial class Form1 : Form
    {
        Random randGen = new Random();
        int num1, num2, num3, num4, num5, num6;

        //Arrays       
        int[] selectionSorted = new int[6];
        int[] bubbleSorted = new int[6];
        int[] insertionSorted = new int[6];

        //Ints
        int loopCounter;
        int comparisonCounter;
        int shiftCounter;

        public Form1()
        {
            InitializeComponent();

            num1 = randGen.Next(1, 7);
            num2 = randGen.Next(1, 7);
            num3 = randGen.Next(1, 7);
            num4 = randGen.Next(1, 7);
            num5 = randGen.Next(1, 7);
            num6 = randGen.Next(1, 7);

            int[] originalArray = { num1, num2, num3, num4, num5, num6 };

            originalArray.CopyTo(selectionSorted, 0);
            originalArray.CopyTo(bubbleSorted, 0);
            originalArray.CopyTo(insertionSorted, 0);

            selection(selectionSorted);
            loopCounter = 0;
            comparisonCounter = 0;
            shiftCounter = 0;

            bubble(bubbleSorted);
            loopCounter = 0;
            comparisonCounter = 0;
            shiftCounter = 0;

            insertion(insertionSorted);

            originalOutput.Text = selectionSortedOutput.Text = "";

            foreach (int i in originalArray)
            {
                originalOutput.Text += i + "\n";
            }

            foreach (int i in selectionSorted)
            {
                selectionSortedOutput.Text += i + "\n";
            }
            foreach (int i in bubbleSorted)
            {
                bubbleSortedOutput.Text += i + "\n";
            }
            foreach (int i in insertionSorted)
            {
                insertionSortedOutput.Text += i + "\n";
            }
        }
        public void selection(int[] tempArray)
        {
            int temp;

            //starting stopwatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < tempArray.Length; i++)
            {
                loopCounter++;

                for (int j = i + 1; j < tempArray.Length; j++)
                {
                    comparisonCounter++;
                    if (tempArray[j] < tempArray[i])
                    {
                        shiftCounter++;
                        temp = tempArray[i];
                        tempArray[i] = tempArray[j];
                        tempArray[j] = temp;
                    }
                }
            }
            //ending stopwatch
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = Convert.ToString(ts.TotalMilliseconds);

            selectionShiftOutputLabel.Text = Convert.ToString(shiftCounter);
            selectionLoopOutputLabel.Text = Convert.ToString(loopCounter);
            selectionComparisonOutputLabel.Text = Convert.ToString(comparisonCounter);
            selectionTimerOutput.Text = elapsedTime;
        }

        public void bubble(int[] tempArray)
        {
            int bottom = tempArray.Length - 1;
            int temp;
            Boolean sw = true;

            //starting stopwatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            while (sw == true)
            {
                sw = false;
                loopCounter++;

                for (int j = 0; j < bottom; j++)
                {
                    comparisonCounter++;
                    if (tempArray[j] > tempArray[j + 1])
                    {
                        shiftCounter++;
                        sw = true;
                        temp = tempArray[j];
                        tempArray[j] = tempArray[j + 1];
                        tempArray[j + 1] = temp;
                    }
                }
                bottom--;
            }
            //ending stopwatch
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = Convert.ToString(ts.TotalMilliseconds);

            bubbleShiftOutputLabel.Text = Convert.ToString(shiftCounter);
            bubbleLoopOutputLabel.Text = Convert.ToString(loopCounter);
            bubbleComparisonOutputLabel.Text = Convert.ToString(comparisonCounter);
            bubbleTimerOutput.Text = elapsedTime;
        }

        public void insertion(int[] tempArray)
        {
            int temp, j;

            //starting stopwatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int n = 0; n < tempArray.Length; n++)
            {
                loopCounter++;

                temp = tempArray[n];
                j = n - 1;
                comparisonCounter++;

                while (j >= 0 && tempArray[j] > temp)
                {
                    shiftCounter++;

                    tempArray[j + 1] = tempArray[j];
                    j--;
                }

                tempArray[j + 1] = temp;
            }
            //ending stopwatch
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = Convert.ToString(ts.TotalMilliseconds);

            insertionShiftOutputLabel.Text = Convert.ToString(shiftCounter);
            insertionLoopOutputLabel.Text = Convert.ToString(loopCounter);
            insertionComparisonOutputLabel.Text = Convert.ToString(comparisonCounter);
            insertionTimerOutput.Text = elapsedTime;
        }

        private void lineLabel_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Times New Roman", 18);
            Brush brush = new SolidBrush(Color.Black);
            e.Graphics.TranslateTransform(30, 20);
            e.Graphics.RotateTransform(90);
            e.Graphics.DrawString("______________________________", font, brush, 0, 0);
        }
    }
}
