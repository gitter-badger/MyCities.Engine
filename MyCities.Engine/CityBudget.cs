namespace MyCities.Engine
{
    public class CityBudget
    {
        private readonly Micropolis city;

        /**
	 * The amount of cash on hand.
	 */
        public int totalFunds;

        /**
         * Amount of taxes collected so far in the current financial
         * period (in 1/TAXFREQ's).
         */
        int taxFund;

        /**
         * Amount of prepaid road maintenance (in 1/TAXFREQ's).
         */
        int roadFundEscrow;

        /**
         * Amount of prepaid fire station maintenance (in 1/TAXFREQ's).
         */
        int fireFundEscrow;

        /**
         * Amount of prepaid police station maintenance (in 1/TAXFREQ's).
         */
        int policeFundEscrow;

        CityBudget(Micropolis micropolis)
        {
            city = micropolis;
        }
    }
}