using System;
using VPFCalculator.Helpers;
namespace VPFCalculator.Calculators
{
    class Custom : Shape
    {
        public Custom(MainWindow app) : base(app) { }

        private string Edges, Length;
        private void GetEdges()
        {
            LabelEquation.Content = StepMessage("Insert amount of edges of shape.");
            LabelResult.Content = "Edges: ";
        }
        private void GetLength()
        {
            LabelEquation.Content = StepMessage("Insert length of shape.");
            LabelResult.Content = "Length: ";
        }

        #region IShape Methods
        public override void GetArea() => GetEdges();
        public override void NextStep()
        {
            CurrentStep += 1;
            switch (CurrentStep)
            {
                case 1:
                    if (Edges != string.Empty || Convert.ToInt32(Edges) > 3) 
                        GetLength();
                    else
                    {
                        CurrentStep -= 2;
                        Edges = string.Empty;
                        GetEdges();
                        return;
                    }
                    break;
                case 2:
                    if (Length != string.Empty)
                        DisplayArea(CalculateArea());
                    else
                    {
                        CurrentStep -= 2;
                        Length = string.Empty;
                        GetLength();
                        return;
                    }
                    break;
                default:
                    ClearAll();
                    break;
            }
        }
        internal override double CalculateArea() => 
            (Convert.ToInt32(Edges) == 3) ? Convert.ToInt32(Length) * Convert.ToInt32(Length) * 1.2
            : (Convert.ToInt32(Edges) == 4) ? Convert.ToInt32(Length) * Convert.ToInt32(Length)
            : 0.25 * Math.Tan(GetDegrees() / (2 * Convert.ToDouble(Edges))) * 
            Convert.ToDouble(Edges) * Math.Pow(Convert.ToDouble(Length), 2);
        /// <summary>
        /// Returns the amount of degress in the shape, defined by <see cref="Edges"/>
        /// </summary>
        /// <returns></returns>
        private int GetDegrees()
        {
            int Degrees = 0;
            for (int x = 3; x <= Convert.ToInt32(Edges); x++)
                Degrees += 180;
            return Degrees;
        }
        internal override bool DisplayArea(double Area)
        {
            LabelEquation.Content = StepMessage($"Area of a {Edges} edged shape is: {Area}");
            LabelResult.Content = $"Area: {Area}";
            Draw = new Draw(app.CanvasDrawing, Convert.ToInt32(Edges), Convert.ToInt32(Length));
            Draw.DrawFigure(GetDegrees());
            return true;
        }

        #endregion

        #region ICalculator Methods
        public override void AddNumber(string num)
        {
            if (CurrentStep == 0)
                Edges += num;
            else if (CurrentStep == 1)
                Length += num;
            LabelResult.Content += num;
        }
        public override void ClearAll()
        {
            Edges = string.Empty;
            LabelResult.Content = string.Empty;
            LabelEquation.Content = string.Empty;
            CurrentStep = -1;
            app.HandleClassic();
            Draw = null;
        }
        public override void Remove()
        {
            switch (CurrentStep)
            {
                case 0:
                    Edges = Edges.Substring(0, Edges.Length - 1);
                    break;
                case 1:
                    Length = Length.Substring(0, Edges.Length - 1);
                    break;
                case 2:
                    ClearAll();
                    break;
            }
            LabelResult.Content = LabelResult.Content.ToString().Substring(0, LabelResult.Content.ToString().Length - 1);
        }
        #endregion
    }
}
