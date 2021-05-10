using System;
using VPFCalculator.Helpers;
using System.Windows.Controls;

namespace VPFCalculator.Calculators
{
    class Classic : ICalculator
    {
        /// <summary>
        /// Side variable
        /// </summary>
        private static string Start = string.Empty, End = string.Empty;
        private string Operator;
        /// <summary>
        /// Returns <see cref="Start"/> or <see cref="End"/> depending on <seealso cref="OnStart"/>'s value
        /// </summary>
        private static string Side
        {
            get => (OnStart) ? Start : End;
            set 
            { 
                if (OnStart) Start = value; 
                else End = value; 
            }
        }
        private static bool OnStart = true, NegativeNumber = false;
        private readonly Label LabelResult, LabelEquation;

        public Classic(Label LabelResult, Label LabelEquation)
        {
            this.LabelResult = LabelResult;
            this.LabelEquation = LabelEquation;
        }

        /// <summary>
        /// Adds a number to <see cref="Side"/> and displays on <see cref="LabelResult"/>
        /// </summary>
        /// <param name="num"></param>
        public void AddNumber(string num)
        {
            Side += num;
            LabelResult.Content += num;
        }
        /// <summary>
        /// Handles when operators are clicked, may call <see cref="HandleCalculations"/> if needed
        /// </summary>
        /// <param name="Operator">Operator that called method</param>
        public void AddOperator(string Operator)
        {
            if (Start == "0" && LabelResult.Content.ToString() == string.Empty && Operator != "-") return;
            else if (Operator == "-" && Start == string.Empty || Operator == "-" && End == string.Empty) 
                NegativeNumber = true;

            if (!NegativeNumber)
            {
                this.Operator = Operator;
                bool CalculationHandled = HandleCalculations(true);
                if (!OnStart && CalculationHandled)
                    LabelEquation.Content += $" {Operator} ";
            }
            LabelResult.Content += (Operator == "-" && NegativeNumber) ? $"{Operator}" : $" {Operator} ";

            if (OnStart && !NegativeNumber)
                OnStart = false;
        }

        #region Technical
        /// <summary>
        /// Handles if an operator is clicked and End was last value or if <see cref="ButtonEquals"/> was clicked
        /// </summary>
        public bool HandleCalculations(bool OperatorCalled)
        {
            if (End == string.Empty || OnStart && Start != string.Empty) return false;
            else if (NegativeNumber)
            {
                Side = $"-{Side}";
                NegativeNumber = false;
            }
            LabelEquation.Content += (LabelEquation.Content.ToString() == string.Empty) ?
                $"{Start} {Operator} {End} " : (OperatorCalled) ?
                $"{End} " : $"{Operator} {End} ";

            Start = CalculateEquation();
            LabelResult.Content = Start;
            End = string.Empty;
            return true;
        }
        /// <summary>
        /// Adds calculation and calculates the equation
        /// </summary>
        /// <param name="start">Number 1</param>
        /// <param name="Operator">Operator type</param>
        /// <param name="end">Number 2</param>
        /// <returns>Returns Result</returns>
        public string CalculateEquation()
        {
            double
                start = Convert.ToDouble(Start),
                end = Convert.ToDouble(End),
                result = (Operator == "+") ? (start + end) :
                    (Operator == "-") ? (start - end) :
                    (Operator == "*") ? (start * end) :
                    (Operator == "/") ? (start / end) : 0;

            return result.ToString();
        }
        #endregion

        #region Clear
        /// <summary>
        /// Clears LabelResult
        /// </summary>
        public void Clear()
        {
            LabelResult.Content = Start;
            if (LabelEquation.Content.ToString() == string.Empty)
                OnStart = true;
            End = string.Empty;
        }
        /// <summary>
        /// Clears LabelResult & LabelEquation
        /// </summary>
        public void ClearAll()
        {
            LabelResult.Content = Start = string.Empty;
            LabelEquation.Content = string.Empty;
            End = string.Empty;
            OnStart = true;
        }
        /// <summary>
        /// Removes a character at LabelResult
        /// </summary>
        public void Remove()
        {
            LabelResult.Content = LabelResult.Content.ToString().Substring(0, LabelResult.Content.ToString().Length - 1);
            Side = Side.Substring(0, Start.Length - 1);
        }
        #endregion
    }
}
