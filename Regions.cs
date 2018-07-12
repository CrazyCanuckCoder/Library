using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public class Regions
    {
        private Regions()
        {
            this.SetupUSStates();
            this.SetupCdnProvinces();
        }




        private static Regions _instance = null;
        private static readonly object _padlock = new object();




        /// <summary>
        /// Returns the single instance for this class.
        /// </summary>
        /// 
        /// <remarks>
        /// This object is thread safe.
        /// </remarks>
        /// 
        public static Regions Instance
        {
            get
            {
                lock (_padlock)
                {
                    return _instance ?? (_instance = new Regions());
                }
            }
        }

        /// <summary>
        /// A list of the 50 American States.
        /// </summary>
        /// 
        public List<string> USStates { get; } = new List<string>(50);

        /// <summary>
        /// A list of the 10 Provinces and 3 Territories of Canada.
        /// </summary>
        /// 
        public List<string> CdnProvinces { get; } = new List<string>(13);




        private void SetupUSStates()
        {
            const string stateNames = "Alabama,Alaska,Arizona,Arkansas,California,Colorado,Connecticut,Delaware,Florida,"    +
                                      "Georgia,Hawaii,Idaho,Illinois,Indiana,Iowa,Kansas,Kentucky,Louisiana,Maine,Maryland," +
                                      "Massachusetts,Michigan,Minnesota,Mississippi,Missouri,Montana,Nebraska,Nevada,"       +
                                      "New Hampshire,New Jersey,New Mexico,New York,North Carolina,North Dakota,Ohio,"       +
                                      "Oklahoma,Oregon,Pennsylvania,Rhode Island,South Carolina,South Dakota,Tennessee,"     +
                                      "Texas,Utah,Vermont,Virginia,Washington,West Virginia,Wisconsin,Wyoming";
            this.USStates.AddRange(stateNames.Split(','));
        }

        private void SetupCdnProvinces()
        {
            const string cdnProvinces = "Alberta,British Columbia,Manitoba,New Brunswick,Newfoundland and Labrador," +
                                        "Nova Scotia,Nunavut,Ontario,Prince Edward Island,Quebec,Saskatchewan,"      +
                                        "Northwest Territories,Yukon";
            this.CdnProvinces.AddRange(cdnProvinces.Split(','));
        }
    }
}


