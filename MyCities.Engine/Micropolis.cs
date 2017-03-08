using System;

namespace MyCities.Engine
{
    /// <summary>
    /// The main simulation engine for Micropolis.
    /// The front-end should call animate() periodically
    /// to move the simulation forward in time.
    /// </summary>
    public class Micropolis
    {
        static readonly Random DEFAULT_PRNG = new Random();

        public Random PRNG;

        // full size arrays
        char[][] map;
        bool[][] powerMap;

        // half-size arrays

        /// <summary>
        /// For each 2x2 section of the city, the land value of the city (0-250).
        /// 0 is lowest land value; 250 is maximum land value.
        /// Updated each cycle by ptlScan().
        /// </summary>
        int[][] landValueMem;

        /// <summary>
        /// For each 2x2 section of the city, the pollution level of the city (0-255).
        /// 0 is no pollution; 255 is maximum pollution.
        /// Updated each cycle by ptlScan(); affects land value.
        /// </summary>
        public int[][] pollutionMem;

        /**
         * For each 2x2 section of the city, the crime level of the city (0-250).
         * 0 is no crime; 250 is maximum crime.
         * Updated each cycle by crimeScan(); affects land value.
         */
        public int[][] crimeMem;

        /// <summary>
        /// For each 2x2 section of the city, the crime level of the city (0-250).
        /// 0 is no crime; 250 is maximum crime.
        /// Updated each cycle by crimeScan(); affects land value.
        /// </summary>
        public int[][] popDensity;

        /// <summary>
        /// For each 2x2 section of the city, the traffic density (0-255).
        /// If less than 64, no cars are animated.
        /// If between 64 and 192, then the "light traffic" animation is used.
        /// If 192 or higher, then the "heavy traffic" animation is used.
        /// </summary>
        int[][] trfDensity;

        // quarter-size arrays

        /// <summary>
        /// For each 4x4 section of the city, an integer representing the natural
        /// land features in the vicinity of this part of the city.
        /// </summary>
        int[][] terrainMem;

        // eighth-size arrays

        /// <summary>
        /// For each 8x8 section of the city, the rate of growth.
        /// Capped to a number between -200 and 200.
        /// Used for reporting purposes only; the number has no affect.
        /// </summary>
        public int[][] rateOGMem; //rate of growth?

        int[][] fireStMap;      //firestations- cleared and rebuilt each sim cycle
        public int[][] fireRate;       //firestations reach- used for overlay graphs
        int[][] policeMap;      //police stations- cleared and rebuilt each sim cycle
        public int[][] policeMapEffect;//police stations reach- used for overlay graphs

        /// <summary>
        /// For each 8x8 section of city, this is an integer between 0 and 64,
        /// with higher numbers being closer to the center of the city.
        /// </summary>
        int[][] comRate;

        static readonly int DEFAULT_WIDTH = 120;
        static readonly int DEFAULT_HEIGHT = 100;

        // public readonly CityBudget budget = new CityBudget(this);
        public bool autoBulldoze = true;
        public bool autoBudget = false;
        public Speed simSpeed = Speed.NORMAL;
        public bool noDisasters = false;

        // census numbers, reset in phase 0 of each cycle, summed during map scan
        int poweredZoneCount;
        int unpoweredZoneCount;
        int roadTotal;
        int railTotal;
        int firePop;
        int resZoneCount;
        int comZoneCount;
        int indZoneCount;
        int resPop;
        int comPop;
        int indPop;
        int hospitalCount;
        int churchCount;
        int policeCount;
        int fireStationCount;
        int stadiumCount;
        int coalCount;
        int nuclearCount;
        int seaportCount;
        int airportCount;

        public int totalPop;
        public int lastCityPop;

        // used in generateBudget()
        int lastRoadTotal;
        int lastRailTotal;
        int lastTotalPop;
        int lastFireStationCount;
        int lastPoliceCount;

        int trafficMaxLocationX;
        int trafficMaxLocationY;
        int pollutionMaxLocationX;
        int pollutionMaxLocationY;
        int crimeMaxLocationX;
        int crimeMaxLocationY;
        public int centerMassX;
        public int centerMassY;
        CityLocation meltdownLocation;  //may be null
        CityLocation crashLocation;     //may be null

        int needHospital; // -1 too many already, 0 just right, 1 not enough
        int needChurch;   // -1 too many already, 0 just right, 1 not enough

        int crimeAverage;
        int pollutionAverage;
        int landValueAverage;
        int trafficAverage;

        int resValve;   // ranges between -2000 and 2000, updated by setValves
        int comValve;   // ranges between -1500 and 1500
        int indValve;   // ranges between -1500 and 1500

        bool resCap;  // residents demand a stadium, caps resValve at 0
        bool comCap;  // commerce demands airport,   caps comValve at 0
        bool indCap;  // industry demands sea port,  caps indValve at 0
        int crimeRamp;
        int polluteRamp;

        //
        // budget stuff
        //
        public int cityTax = 7;
        public double roadPercent = 1.0;
        public double policePercent = 1.0;
        public double firePercent = 1.0;

        int taxEffect = 7;
        int roadEffect = 32;
        int policeEffect = 1000;
        int fireEffect = 1000;

        int cashFlow; //net change in totalFunds in previous year

        bool newPower;

        int floodCnt; //number of turns the flood will last
        int floodX;
        int floodY;

        public int cityTime;  //counts "weeks" (actually, 1/48'ths years)
        int scycle; //same as cityTime, except mod 1024
        int fcycle; //counts simulation steps (mod 1024)
        int acycle; //animation cycle (mod 960)

        public Micropolis(int width, int height)
        {
            // var evaluation = new CityEval();
            Init(width, height);
        }

        public void Spend(int amount)
        {
            // budget.totalFunds -= amount;
            FireFundsChanged();
        }

        private void FireFundsChanged()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Init(int width, int height)
        {
            // map = new char[height][width];
            // powerMap = new bool[height][width];

            var hX = (width + 1) / 2;
            var hY = (height + 1) / 2;
        }

        /// <summary>
        /// 
        /// </summary>
        void FireCensusChanged()
        {
            
        }
    }
}
