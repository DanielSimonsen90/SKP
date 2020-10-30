using System;
using VPFCalculator.Helpers;
using VPFCalculator.Calculators;
using System.Windows;

namespace VPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassicCalc = new Classic(LabelResult, LabelEquation);
        }
        /// <summary>
        /// If <see cref="ClassicCalculator"/> is used
        /// </summary>
        private bool Classic = true;
        private readonly Classic ClassicCalc;
        /// <summary>
        /// If <see cref="ClassicCalculator"/> is null, new <see cref="Calculators.Classic"/> else return <see cref="ClassicCalculator"/>
        /// </summary>
        /// <summary>
        /// The Shape/Figure calculator
        /// </summary>
        private IShape ShapeCalc;

        #region Call AddNumber()
        private void ButtonZero_Click(object sender, RoutedEventArgs e) => AddNumber("0");
        private void ButtonOne_Click(object sender, RoutedEventArgs e) => AddNumber("1");
        private void ButtonTwo_Click(object sender, RoutedEventArgs e) => AddNumber("2");
        private void ButtonThree_Click(object sender, RoutedEventArgs e) => AddNumber("3");
        private void ButtonFour_Click(object sender, RoutedEventArgs e) => AddNumber("4");
        private void ButtonFive_Click(object sender, RoutedEventArgs e) => AddNumber("5");
        private void ButtonSix_Click(object sender, RoutedEventArgs e) => AddNumber("6");
        private void ButtonSeven_Click(object sender, RoutedEventArgs e) => AddNumber("7");
        private void ButtonEight_Click(object sender, RoutedEventArgs e) => AddNumber("8");
        private void ButtonNine_Click(object sender, RoutedEventArgs e) => AddNumber("9");

        private void ButtonComma_Click(object sender, RoutedEventArgs e) => AddNumber(",");
        #endregion

        /// <summary>
        /// Handles comma & numbered events
        /// </summary>
        /// <param name="num"></param>
        private void AddNumber(string num)
        {
            if (Classic) ClassicCalc.AddNumber(num);
            else ShapeCalc.AddNumber(num);
        }

        #region Call AddOperator()
        private void ButtonPlus_Click(object sender, RoutedEventArgs e) => AddOperator("+");
        private void ButtonMinus_Click(object sender, RoutedEventArgs e) => AddOperator("-");
        private void ButtonMultiply_Click(object sender, RoutedEventArgs e) => AddOperator("*");
        private void ButtonDivide_Click(object sender, RoutedEventArgs e) => AddOperator("/");
        #endregion

        /// <summary>
        /// Handles when operators are clicked, may call <see cref="HandleCalculations"/> if needed
        /// </summary>
        /// <param name="Operator">Operator that called method</param>
        private void AddOperator(string Operator)
        {
            if (Classic) ClassicCalc.AddOperator(Operator);
            else ShapeCalc.AddOperator(Operator);
        }

        #region Technical
        private void ButtonEquals_Click(object sender, RoutedEventArgs e) => HandleCalculations(false);
        /// <summary>
        /// Handles if an operator is clicked and End was last value or if <see cref="ButtonEquals"/> was clicked
        /// </summary>
        private void HandleCalculations(bool OperatorCalled)
        {
            if (Classic) ClassicCalc.HandleCalculations(OperatorCalled);
            else ShapeCalc.NextStep();
        }

        #region Clear
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            if (Classic) ClassicCalc.Clear();
            else ShapeCalc.Clear();
        }
        private void ButtonClearAll_Click(object sender, RoutedEventArgs e)
        {
            if (Classic) ClassicCalc.ClearAll();
            else ShapeCalc.ClearAll();
        }
        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (Classic) ClassicCalc.Remove();
            else ShapeCalc.Remove();
        }
        #endregion

        #endregion

        #region Shapes
        private void ButtonCircle_Click(object sender, RoutedEventArgs e) => SwitchMode(new Circle(this));
        private void ButtonCustomEdge_Click(object sender, RoutedEventArgs e) => SwitchMode(new Custom(this));
        private void ButtonTrapez_Click(object sender, RoutedEventArgs e) => SwitchMode(new Trapeze(this));
        private void ButtonCone_Click(object sender, RoutedEventArgs e) => SwitchMode(new Cone(this));

        /// <summary>
        /// Switches <see cref="Classic"/> (<see cref="Calculators.Classic"/> to <see cref="Shape"/>)
        /// </summary>
        /// <param name="shape"></param>
        private void SwitchMode(IShape shape)
        {
            HandleClassic();
            ShapeCalc = shape;
            ShapeCalc.GetArea();
        }

        /// <summary>
        /// Switches the value of <see cref="Classic"/>
        /// </summary>
        public void HandleClassic() => Classic = (Classic) ? false : true; 
        #endregion
    }
}
