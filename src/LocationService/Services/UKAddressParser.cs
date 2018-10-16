using LocationService.Business_Entities;
using LocationService.Interfaces;
using System;

namespace LocationService.Services
{
    public class UKAddressParser : IAddressParser
    {
        /// <summary>
        /// Parses an address string to the Address structure
        /// </summary>
        /// <param name="addressString"></param>
        /// <param name="baseAddress"></param>
        /// <returns></returns>
        public Address Parse(string addressString, Address baseAddress)
        {
            var addressResult = new Address()
            {
                HouseNo = addressString,
                AddressLine1 = baseAddress.AddressLine1,
                AddressLine2 = baseAddress.AddressLine2,
                County = baseAddress.County,
                ErrorMessage = "",
                PostCode = baseAddress.PostCode,
                Town = baseAddress.Town
            };

            // remove postcode
            addressResult.HouseNo = addressResult.HouseNo.Substring(addressResult.PostCode.Length);

            // remove county
            addressResult.HouseNo =
                addressResult.HouseNo.IndexOf(baseAddress.County, StringComparison.InvariantCultureIgnoreCase) ==
                addressResult.HouseNo.Length - baseAddress.County.Length
                    ? addressResult.HouseNo.Substring(0, addressResult.HouseNo.Length - baseAddress.County.Length)
                    : addressResult.HouseNo;
            addressResult.HouseNo = addressResult.HouseNo.Trim(' ').Trim(',');

            // remove town
            addressResult.HouseNo =
                addressResult.HouseNo.LastIndexOf(baseAddress.Town, StringComparison.InvariantCultureIgnoreCase) ==
                addressResult.HouseNo.Length - baseAddress.Town.Length
                    ? addressResult.HouseNo.Substring(0, addressResult.HouseNo.Length - baseAddress.Town.Length)
                    : addressResult.HouseNo;
            addressResult.HouseNo = addressResult.HouseNo.Trim(' ').Trim(',');

            // remove AddressLine2
            addressResult.HouseNo =
                addressResult.HouseNo.LastIndexOf(baseAddress.AddressLine2,
                    StringComparison.InvariantCultureIgnoreCase) ==
                addressResult.HouseNo.Length - baseAddress.AddressLine2.Length
                    ? addressResult.HouseNo.Substring(0, addressResult.HouseNo.Length - baseAddress.AddressLine2.Length)
                    : addressResult.HouseNo;
            addressResult.HouseNo = addressResult.HouseNo.Trim(' ').Trim(',');

            // remove AddressLine1
            addressResult.HouseNo =
                addressResult.HouseNo.LastIndexOf(baseAddress.AddressLine1,
                    StringComparison.InvariantCultureIgnoreCase) ==
                addressResult.HouseNo.Length - baseAddress.AddressLine1.Length
                    ? addressResult.HouseNo.Substring(0, addressResult.HouseNo.Length - baseAddress.AddressLine1.Length)
                    : addressResult.HouseNo;
            addressResult.HouseNo = addressResult.HouseNo.Trim(' ').Trim(',').Trim(Convert.ToChar("\t"));

            return addressResult;
        }
    }
}