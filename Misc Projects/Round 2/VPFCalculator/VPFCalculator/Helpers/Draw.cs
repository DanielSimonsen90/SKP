using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace VPFCalculator.Helpers
{
    class Draw
    {
        private readonly int Edges, Length;
        public Line Line;
        public Canvas Paper { get; }

        public Draw(Canvas Paper, int Edges, int Length)
        {
            this.Paper = Paper;
            this.Edges = Edges;
            this.Length = Length;
            Line = new Line()
            {
                X2 = 0,
                Y2 = 0
            };
            DrawLine(100, 0);
        }

        public void DrawFigure(int Degrees)
        {
            if (Degrees < 180) return;
            for (int x = 180; x < Degrees; x += 180)
                DrawLine(GetCoordinate("X"), GetCoordinate("Y"));
                //Use link for reference https://www.youtube.com/watch?v=aHaFwnqH5CU
        }

        private void DrawLine(int X, int Y)
        {
            Paper.Children.Add(Line = new Line()
            {
                Visibility = Visibility.Visible,
                StrokeThickness = 1,
                Stroke = Brushes.Black,
                X1 = Line.X2,
                Y1 = Line.Y2,
                X2 = X,
                Y2 = Y
            });
        }

        /// <summary>
        /// Returns the coordinate depending on <paramref name="XY"/>
        /// </summary>
        /// <param name="XY">X or Y coordinate</param>
        /// <returns></returns>
        private int GetCoordinate(string XY) => (XY == "X") ? 
            Convert.ToInt32(Length * Math.Cos(GetSubtend())) : 
            Convert.ToInt32(Length * Math.Sin(GetSubtend()));

        /// <summary>
        /// Gets the subtend of the shape (vinkelsum)
        /// </summary>
        /// <returns></returns>
        private double GetSubtend()
        {
            int Subtend = 0;
            for (int x = 3; x < Edges; x++)
                Subtend += 180;
            return Subtend / Edges;
        }
    }
}
