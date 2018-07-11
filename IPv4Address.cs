#region

using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

#endregion

namespace Library
{
    /// <summary>
    /// A lightweight class for use in managing IPv4 addresses.
    /// </summary>
    /// 
    /// <remarks>
    /// This class is useful when you know all of the IP addresses you will be
    /// dealing with are version 4 addresses.
    /// </remarks>
    /// 
    public class IPv4Address : IIPv4Address
    {
        //  Constants used by this class.

        private const int NUM_QUADRANTS = 4;
        private const int MIN_QUADRANT_VALUE = 0;
        public  const int MAX_QUADRANT_VALUE = 255;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// 
        public IPv4Address()
        {
        }

        /// <summary>
        /// Initializes the address value based on 4 numbers.
        /// </summary>
        /// 
        /// <param name="Quadrant1">
        /// The first quadrant value for the IP address.
        /// </param>
        /// 
        /// <param name="Quadrant2">
        /// The second quadrant value for the IP address.
        /// </param>
        /// 
        /// <param name="Quadrant3">
        /// The third quadrant value for the IP address.
        /// </param>
        /// 
        /// <param name="Quadrant4">
        /// The fourth quadrant value for the IP address.
        /// </param>
        /// 
        public IPv4Address(int Quadrant1, int Quadrant2, int Quadrant3, int Quadrant4)
        {
            var newQuadrants = new int[]
                {
                    Quadrant1,
                    Quadrant2,
                    Quadrant3,
                    Quadrant4
                };
            this.Quadrants = newQuadrants;
        }

        /// <summary>
        /// Initializes the address value based on an array of numbers.
        /// </summary>
        /// 
        /// <param name="NewQuadrants">
        /// An array containing the values to use for the address.
        /// </param>
        /// 
        public IPv4Address(int[] NewQuadrants)
        {
            this.Quadrants = NewQuadrants;
        }

        /// <summary>
        /// Initializes the address value based on a string.
        /// </summary>
        /// 
        /// <param name="NewIPAddress">
        /// A string containing the IP address in standard dot notation format.
        /// </param>
        /// 
        public IPv4Address(string NewIPAddress)
        {
            ConvertStringToQuadrants(NewIPAddress);
        }

        private readonly int[] _quadrants = {0, 0, 0, 0};

        /// <summary>
        /// An array of integers containing the individual components of the
        /// current IP address.
        /// </summary>
        /// 
        /// <remarks>
        /// When a new value is set for this property, the array and the values
        /// within the array are checked for validity.
        /// </remarks>
        /// 
        /// <throws>
        /// Format Exception
        /// Argument Out of Range Exception
        /// </throws>
        /// 
        public int[] Quadrants
        {
            get { return this._quadrants; }

            set
            {
                if (value != null)
                {
                    if (value.Length < NUM_QUADRANTS)
                    {
                        throw new FormatException("Too few elements for Quadrants property.");
                    }
                    else
                    {
                        for (int idx = 0; idx < NUM_QUADRANTS; idx++)
                        {
                            if (value[idx].IsBetween(MIN_QUADRANT_VALUE, MAX_QUADRANT_VALUE))
                            {
                                this._quadrants[idx] = value[idx];
                            }
                            else
                            {
                                throw new ArgumentOutOfRangeException(
                                    String.Format("Quadrant value must be between {0} and {1}.  ", MIN_QUADRANT_VALUE, MAX_QUADRANT_VALUE) +
                                    String.Format("Quadrant value at index {0} was {1}.", idx, value[idx]));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns an IP address consisting entirely of zeros.
        /// </summary>
        /// 
        public static IPv4Address Empty
        {
            get { return new IPv4Address(0, 0, 0, 0); }
        }

        /// <summary>
        /// Determines if the quadrants of this object match the quadrants of
        /// the passed object.
        /// </summary>
        /// 
        /// <param name="obj">
        /// The IPv4Address to check for equality.
        /// </param>
        /// 
        /// <returns>
        /// True if the quadrants of the passed object equal the current object's
        /// quadrant values.
        /// </returns>
        /// 
        public override bool Equals(object obj)
        {
            bool isEqual = (obj is IPv4Address);

            if (isEqual)
            {
                var tempAddress = obj as IPv4Address;

                for (int idx = 0; idx < NUM_QUADRANTS; idx++)
                {
                    if (Quadrants[idx] != tempAddress.Quadrants[idx])
                    {
                        isEqual = false;
                        break;
                    }
                }
            }

            return isEqual;
        }



        /// <summary>
        /// Converts the values in the Quadrants array property to a string in 
        /// the standard format for IP addresses.
        /// </summary>
        /// 
        /// <returns>
        /// A string containing the IP address in standard dot notation format.
        /// </returns>
        /// 
        public override string ToString()
        {
            string addressText = "";

            if (!Equals(IPv4Address.Empty))
            {
                addressText = String.Format("{0}.{1}.{2}.{3}", Quadrants[0], Quadrants[1], Quadrants[2], Quadrants[3]);
            }

            return addressText;
        }

        /// <summary>
        /// Converts an IP address in the standard dotted format to an array of
        /// integers and assigns it to the Quadrants property.
        /// </summary>
        /// 
        /// <param name="IPAddress">
        /// The IP address in the standard dotted format.
        /// </param>
        /// 
        /// <throws>
        /// Format Exception
        /// Argument Out of Range Exception
        /// </throws>
        /// 
        private void ConvertStringToQuadrants(string IPAddress)
        {
            if (Regex.IsMatch(IPAddress, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
            {
                //  Convert the string to an array of ints.  First add a period
                //    to the end of the string for the Split function.

                string[] quadrantsText = IPAddress.Split(new string[] {"."}, StringSplitOptions.None);
                var newQuadrants = new int[NUM_QUADRANTS];

                for (int idx = 0; idx < NUM_QUADRANTS; idx++)
                {
                    newQuadrants[idx] = int.Parse(quadrantsText[idx]);
                }

                //  Assign the converted ints to the int array property where
                //    it will be checked for valid quadrant numbers.

                Quadrants = newQuadrants;
            }
            else
            {
                throw new FormatException("Invalid IP address format.");
            }
        }

        /// <summary>
        /// Converts a string containing an IP address in the standard dotted
        /// format to an IPv4Address object.
        /// </summary>
        /// 
        /// <param name="IPAddress">
        /// The IP address in the standard dotted format.
        /// </param>
        /// 
        /// <returns>
        /// A converted IPv4Address object.
        /// </returns>
        /// 
        /// <throws>
        /// Format Exception
        /// Argument Out of Range Exception
        /// </throws>
        /// 
        public static IPv4Address Parse(string IPAddress)
        {
            IPv4Address newAddress = IPv4Address.Empty;

            if (IPAddress != "")
            {
                newAddress.ConvertStringToQuadrants(IPAddress);
            }

            return newAddress;
        }

        /// <summary>
        /// Converts a string containing an IP address in the standard dotted
        /// format to an IPv4Address object while preventing any exceptions
        /// from being thrown.
        /// </summary>
        /// 
        /// <param name="IPAddress">
        /// The IP address in the standard dotted format.
        /// </param>
        /// 
        /// <param name="NewAddress">
        /// Will contain the converted IP address on success and an empty
        /// IP address object when unsuccessful.
        /// </param>
        /// 
        /// <returns>
        /// True to indicate the address was converted successfully and false
        /// if it wasn't.
        /// </returns>
        /// 
        public static bool TryParse(string IPAddress, out IPv4Address NewAddress)
        {
            bool parseSuccess = true;
            NewAddress = IPv4Address.Empty;

            try
            {
                NewAddress = IPv4Address.Parse(IPAddress);
            }
            catch (FormatException fex)
            {
                Debug.WriteLine(fex.Message);

                parseSuccess = false;
                NewAddress = IPv4Address.Empty;
            }
            catch (ArgumentOutOfRangeException rex)
            {
                Debug.WriteLine(rex.Message);

                parseSuccess = false;
                NewAddress = IPv4Address.Empty;
            }

            return parseSuccess;
        }
    }
}