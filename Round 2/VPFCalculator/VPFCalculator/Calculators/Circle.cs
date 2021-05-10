using System;
using VPFCalculator.Helpers;

namespace VPFCalculator.Calculators
{
    class Circle : Shape
    {
        internal static string Radius;
        public Circle(MainWindow app) : base(app) { }

        /// <summary>
        /// Waits for User to set the value of <see cref="Radius"/>
        /// </summary>
        internal void GetRadius()
        {
            LabelEquation.Content = StepMessage($"Insert radius of {GetType().Name}");
            LabelResult.Content = "Radius: ";
        }

        #region IShape Methods
        /// <summary>
        /// Gets the area of circle
        /// </summary>
        public override void GetArea() => GetRadius();
        public override void NextStep()
        {
            CurrentStep += 1;

            switch (CurrentStep)
            {
                case 1:
                    if (Radius == string.Empty || Convert.ToInt32(Radius) < 1)
                    {
                        CurrentStep -= 2;
                        return;
                    }
                    DisplayArea(CalculateArea());
                    break;
                default:
                    ClearAll();
                    break;
            }
        }
        internal override double CalculateArea() => Math.Round(Math.Pow(Convert.ToDouble(Radius), 2) * Math.PI, 2);
        internal override bool DisplayArea(double Area)
        {
            LabelEquation.Content = StepMessage($"Area of a {Radius} radius {GetType().Name} is: {Area}");
            LabelResult.Content = $"Area: {Area}";
            //Draw.DrawCircle();
            return true;
        }
        #endregion

        #region ICalculator Methods
        public override void AddNumber(string num)
        {
            Radius += num;
            LabelResult.Content += num;
        }
        public override void ClearAll()
        {
            Radius = string.Empty;
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
                    Radius = Radius.Substring(0, Radius.Length - 1);
                    LabelResult.Content = LabelResult.Content.ToString().Substring(0, LabelResult.Content.ToString().Length - 1);
                    break;
                case 1:
                    ClearAll();
                    break;
            }
        }
        #endregion
    }
}