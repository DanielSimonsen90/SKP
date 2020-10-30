using System.Windows.Controls;

namespace VPFCalculator.Helpers
{
    public abstract class Shape : IShape
    {
        #region Public
        public abstract void NextStep();
        public abstract void GetArea();

        public Shape(MainWindow app)
        {
            LabelResult = app.LabelResult;
            LabelEquation = app.LabelEquation;
            this.app = app;
        }

        #region ICalculator
        public abstract void AddNumber(string num);
        public void AddOperator(string Operator) { }
        public void Clear()
        {
            CurrentStep -= 2;
            NextStep();
        }
        public abstract void ClearAll();
        public abstract void Remove();
        #endregion

        #endregion

        #region Private
        /// <summary>
        /// The UI of the calculator
        /// </summary>
        internal readonly MainWindow app;
        internal readonly Label LabelResult, LabelEquation;
        internal Draw Draw;
        /// <summary>
        /// The current step in the Step-By-Step process of <see cref="NextStep"/>
        /// </summary>
        internal int CurrentStep;
        /// <summary>
        /// Send a message to user, adding "Press = to continue"
        /// </summary>
        /// <param name="message">Message to send to user</param>
        /// <returns>Use <see cref="LabelResult"/> or <see cref="LabelEquation"/></returns>
        internal string StepMessage(string message) => $"{message}. \nPress = to continue, \"Clear All\" to go back to Classic Mode.";
        /// <summary>
        /// Does the calculations to get the total Area
        /// </summary>
        /// <returns>Total Area</returns>
        internal abstract double CalculateArea();
        /// <summary>
        /// Display the total area to user
        /// </summary>
        /// <param name="Area">Total area</param>
        /// <returns></returns>
        internal abstract bool DisplayArea(double Area);
        #endregion
    }
}