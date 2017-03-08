using System;
using System.Collections.Generic;

namespace MyCities.Engine
{
    public class CityEval
    {
        private readonly Micropolis city;
        private readonly Random PRNG;

        /// <summary>
        /// Percentage of population "approving" the mayor. Derived from cityScore.
        /// </summary>
        public int cityYes;

        /// <summary>
        /// Percentage of population "disapproving" the mayor. Derived from cityScore.
        /// </summary>
        public int cityNo;

        /// <summary>
        /// City assessment value.
        /// </summary>
        public int cityAssValue;

        /** Player's score, 0-1000. */
        public int cityScore;

        /// <summary>
        /// Change in cityScore since last evaluation.
        /// </summary>
        public int deltaCityScore;

        /// <summary>
        /// City population as of current evaluation.
        /// </summary>
        public int cityPop;

        /// <summary>
        /// Change in cityPopulation since last evaluation.
        /// </summary>
        public int deltaCityPop;

        /// <summary>
        /// Classification of city size. 0==village, 1==town, etc.
        /// </summary>
        public int cityClass; // 0..5

        /// <summary>
        /// City's top 4 (or fewer) problems as reported by citizens.
        /// </summary>
        public CityProblem[] problemOrder = new CityProblem[0];

        /// <summary>
        /// Number of votes given for the various problems identified by problemOrder[]. 
        /// </summary>
        public Dictionary<CityProblem, int> problemVotes = new Dictionary<CityProblem, int>();

        /// <summary>
        /// Score for various problems.
        /// </summary>
	    public Dictionary<CityProblem, int> problemTable = new Dictionary<CityProblem, int>();


        public CityEval(Micropolis engine)
        {
            city = engine;
            PRNG = engine.PRNG;
        }

        /// <summary>
        /// Perform an evaluation.
        /// </summary>
        void CityEvaluation()
        {
            if(city.totalPop != 0)
            {
                CalculateAssValue();
                DoPopNum();
                DoProblems();
                CalculateScore();
                DoVotes();
            }
            else
            {
                EvalInit();
            }
        }

        private void CalculateAssValue()
        {
            throw new NotImplementedException();
        }

        private void DoPopNum()
        {
            throw new NotImplementedException();
        }

        private void CalculateScore()
        {
            throw new NotImplementedException();
        }

        private void DoProblems()
        {
            throw new NotImplementedException();
        }

        private void DoVotes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Evaluate an empty city.
        /// </summary>
        void EvalInit()
        {
            cityYes = 0;
            cityNo = 0;
            cityAssValue = 0;
            cityClass = 0;
            cityScore = 500;
            deltaCityScore = 0;
            // problemVotes.clear();
            problemOrder = new CityProblem[0];
        }
    }
}