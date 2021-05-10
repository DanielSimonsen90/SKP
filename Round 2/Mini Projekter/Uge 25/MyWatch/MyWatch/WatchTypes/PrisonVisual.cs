using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WatchProject.WatchTypes
{
    /// <summary>
    /// Visual class to draw the, what I want to call, "prison lines"
    /// </summary>
    class PrisonVisual : BasicWatch
    {
        #region Variables
        /// <summary>
        /// The canvas to draw the visuals on
        /// </summary>
        private readonly Canvas paper;
        /// <summary>
        /// Last line that was drawn - used to determine next position for both next <see cref="DrawVertical"/> or next <see cref="DrawObliquely"/>
        /// </summary>
        private Line lastLine;
        /// <summary>
        /// Returns the number used for the for-loop in <see cref="Draw(DateTime)"/>
        /// </summary>
        private int CurrentlyRunning;
        /// <summary>
        /// Returns the default position of whichever part of the time we're running in the for-loop in <see cref="Draw(DateTime)"/>
        /// </summary>
        private int GetDefaultPosition
        {
            get
            {
                //Depending if we're drawing seconds, minutes or hours, return the default position
                switch (CurrentlyRunning)
                {
                    case 0: return 600;
                    case 1: return 400;
                    case 2: return 200;
                    default: return -1;
                }
            }
        }
        /// <summary>
        /// bool that determines if we're drawing the first line or not
        /// </summary>
        private bool FirstTime = true;
        #endregion

        public PrisonVisual(TextBlock display, Dispatcher dispatcher, string format, Canvas paper) : base(display, dispatcher, format)
        {
            this.paper = paper;
            CreateTime(delegate { Draw(DateTime.Now); }, Timer_Tick);
            Time.Interval = new TimeSpan(0, 0, 1);
        }

        #region Draws
        /// <summary>
        /// Draws current time on <see cref="paper"/>
        /// </summary>
        /// <param name="time"></param>
        public void Draw(DateTime time)
        {
            //Time values as ints, [0] = second [1] = minute [2] = hour
            int[] timeAsInts = { time.Second, time.Minute, time.Hour };

            //Runs through the timeAsInts[] to draw seconds, minutes & hours on paper
            for (CurrentlyRunning = 0; CurrentlyRunning < timeAsInts.Length; CurrentlyRunning++)
            {
                lastLine = NewLine(); //lastLine resets
                Draw(timeAsInts[CurrentlyRunning]); //Draw lines accordingly to number provided
            }

        }
        /// <summary>
        /// Draws the specified number on <see cref="paper"/> - called from <see cref="Draw(DateTime)"/>
        /// </summary>
        /// <param name="number">Number to draw onto <see cref="paper"/></param>
        private void Draw(int number)
        {
            //Make a new line for each number in provided number
            //If number is a 5th, call DrawObliquely, else DrawVertical
            //Add returned Line to paper.Children
            for (int x = 1; x <= number; x++)
                paper.Children.Add((x % 5 == 0 && x != 0) ? DrawObliquely() : DrawVertical());
        }

        /// <summary>
        /// Draws a vertical line on <see cref="paper"/>
        /// </summary>
        /// <returns>Line to add to <see cref="paper"/>.Children</returns>
        private Line DrawVertical()
        {
            //If code is running for the first time, lastLine shouldn't be modified
            if (!FirstTime)
            {
                //If condition returns true, there are 3 5's on the paper - meaning we should switch line
                if (lastLine.X1 < GetDefaultPosition - 115)
                {
                    //Moves both Ys "a line" down
                    lastLine.Y1 += 40;
                    lastLine.Y2 += 40;
                    //Resets both Xs to its default position
                    lastLine.X1 = GetDefaultPosition;
                    lastLine.X2 = GetDefaultPosition;
                }

                //Moves both Xs a step to the left
                lastLine.X1 -= 10;
                lastLine.X2 -= 10;
            }
            else FirstTime = false;

            return new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 4,
                X1 = lastLine.X1,
                X2 = lastLine.X2,
                Y1 = lastLine.Y1,
                Y2 = lastLine.Y2
            };
        }
        /// <summary>
        /// Draws an obliquely line, when there are already 4 vertical lines
        /// </summary>
        /// <returns>The new line to add to <see cref="paper"/>.Children</returns>
        private Line DrawObliquely() =>
            new Line
            {
                X1 = lastLine.X1 - 2,
                Y1 = lastLine.Y1 - 2,
                X2 = lastLine.X2 + 36,
                Y2 = lastLine.Y2 + 2,
                Stroke = Brushes.Black,
                StrokeThickness = 4
            };
        #endregion

        /// <summary>
        /// Default values for <see cref="lastLine"/>
        /// </summary>
        /// <returns>Returns the default values of <see cref="lastLine"/></returns>
        private Line NewLine() =>
            new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 4,
                X1 = GetDefaultPosition,
                Y1 = 70,
                X2 = GetDefaultPosition,
                Y2 = 50
            };
        /// <summary>
        /// Clears the <see cref="paper"/> and draws a new visual using <see cref="Draw(DateTime)"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Timer_Tick(object sender, EventArgs e)
        {
            paper.Children.Clear();
            Draw(DateTime.Now);
        }
    }
}
