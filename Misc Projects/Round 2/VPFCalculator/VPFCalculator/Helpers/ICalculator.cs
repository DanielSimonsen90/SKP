namespace VPFCalculator.Helpers
{
    public interface ICalculator
    {
        /// <summary>
        /// Adds a number to <see cref="Side"/> and displays on <see cref="LabelResult"/>
        /// </summary>
        /// <param name="num"></param>
        void AddNumber(string num);
        /// <summary>
        /// Handles when operators are clicked, may call <see cref="HandleCalculations"/> if needed
        /// </summary>
        /// <param name="Operator">Operator that called method</param>
        void AddOperator(string Operator);
        /// <summary>
        /// Clears LabelResult
        /// </summary>
        void Clear();
        /// <summary>
        /// Clears LabelResult & LabelEquation
        /// </summary>
        void ClearAll();
        /// <summary>
        /// Removes a character at LabelResult
        /// </summary>
        void Remove();
    }
}