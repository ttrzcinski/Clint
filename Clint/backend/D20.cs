using System;

namespace Clint.backend
{
    /*
        Represents a single 20-sided dice.
     */
    /// <summary>
    /// Represents a single 20-sided dice.
    /// </summary>>
    public class D20
    {
        // Number of sides on the dice.
        /// <summary>
        /// Number of sides on the dice.
        /// </summary>
        private const int numberOfSides = 20;

        // Represens a random numger generator.
        /// <summary>
        /// Represens a random numger generator.
        /// </summary>
        private Random random;

        // Keeps the last rolled score.
        /// <summary>
        /// Keeps the last rolled score.
        /// </summary>
        private int theLastScore = -1;

        // Obtains and keeps for the future a Random Number generator.
        /// <summary>
        /// Obtains and keeps for the future a Random Number generator.
        /// </summary>
        private void obtainARandomNumberGenerator()
        {
            if (random == null)
            {
                random = new Random(20);
            }
        }

        // Rolls a dice.
        /// <summary>
        /// Rolls a dice.
        /// </summary>
        /// <returns>
        /// Score from the top side of dice.
        /// </returns>
        public int Roll()
        {
            obtainARandomNumberGenerator();
            theLastScore = random.Next(1, numberOfSides);
            return theLastScore;
        }

        // Returns last score.
        /// <summary>
        /// Returns last score, -1 means, that no roll happened yet.
        /// </summary>
        /// <returns>Last core</returns>
        public int LastScore()
        {
            return theLastScore;
        }
    }
}
