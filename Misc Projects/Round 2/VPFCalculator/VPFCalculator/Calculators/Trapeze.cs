using System;
using VPFCalculator.Helpers;
namespace VPFCalculator.Calculators
{
    class Trapeze : Shape
    {
        public Trapeze(MainWindow app) : base(app) {}
        private string AB, DC, Height;

        private void GetAB()
        {
            LabelEquation.Content = StepMessage($"Insert length of AB");
            LabelResult.Content = "AB: ";
        }
        private void GetDC()
        {
            LabelEquation.Content = StepMessage($"Insert length of DC");
            LabelResult.Content = "DC: ";
        }
        private void GetHeight()
        {
            LabelEquation.Content = StepMessage($"Insert height");
            LabelResult.Content = "Height: ";
        }

        #region IShape
        public override void GetArea() => GetAB();
        public override void NextStep()
        {
            CurrentStep += 1;
            switch (CurrentStep)
            {
                case 1:
                    if(AB == string.Empty || Convert.ToInt32(AB) < 1)
                    {
                        CurrentStep -= 2;
                        return;
                    }
                    GetDC();
                    break;
                case 2:
                    if(DC == string.Empty || Convert.ToInt32(DC) < 1)
                    {
                        CurrentStep -= 2;
                        return;
                    }
                    GetHeight();
                    break;
                case 3:
                    if (Height == string.Empty || Convert.ToInt32(Height) < 1)
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
        internal override double CalculateArea() =>
            0.5 * (Convert.ToInt32(AB) + Convert.ToInt32(DC)) * Convert.ToInt32(Height);
        internal override bool DisplayArea(double Area)
        {
            LabelEquation.Content = StepMessage($"Area of a Trapeze with AB: {AB}, DC: {DC}, & Height: {Height}, is: {Area}");
            LabelResult.Content = $"Area: {Area}";
            return true;
        }
        #endregion

        #region ICalculator
        public override void AddNumber(string num)
        {
            if (CurrentStep == 0)
                AB += num;
            else if (CurrentStep == 1)
                DC += num;
            else if (CurrentStep == 2)
                Height += num;
            LabelResult.Content += num;
        }
        public override void ClearAll()
        {
            AB = string.Empty;
            DC = string.Empty;
            Height = string.Empty;
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
                    AB = AB.Substring(0, AB.Length - 1);
                    break;
                case 1:
                    DC = DC.Substring(0, DC.Length - 1);
                    break;
                case 2:
                    Height = Height.Substring(0, DC.Length - 1);
                    break;
                case 3:
                    ClearAll();
                    break;
            }
            LabelResult.Content = LabelResult.Content.ToString().Substring(0, LabelResult.Content.ToString().Length - 1);
        }
        #endregion
    }
}
