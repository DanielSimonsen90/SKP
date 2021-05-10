namespace VPFCalculator.Helpers
{
    public interface IShape : ICalculator
    {
        /// <summary>
        /// Continues the Step-By-Step to <see cref="GetArea"/>
        /// </summary>
        void NextStep();
        /// <summary>
        /// Gets the total area of figure
        /// </summary>
        void GetArea();
    }
}