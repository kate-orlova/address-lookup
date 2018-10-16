using LocationService.Interfaces;
using PostcodeEverywhere;
using System;
using System.Collections.Specialized;
using Address = LocationService.Business_Entities.Address;

namespace LocationService.Services
{
    public class UKAddressProvider : IAddressInfoProvider
    {
        private readonly string _serialNumber;
        private readonly string _password;
        private readonly string _userId;
        private readonly string _property;
        private readonly string _countyType;

        public UKAddressProvider(NameValueCollection settings)
        {
            _serialNumber = settings["serialNumber"];
            _password = settings["password"];
            _userId = settings["userId"];
            _property = settings["property"];
            _countyType = settings["countyType"];

            //TODO create an address parser instance

        }

        private AddressResultsList GetAddresssLIst(string postCode)
        {
            AddressResultsList addressResultsList;
            if (!string.IsNullOrEmpty(postCode))
            {
                var pService = new PostcodeEverywhereSoapClient();
                try
                {
                    addressResultsList = pService.AddressList(_serialNumber, _password, _userId, postCode, _property,
                        _countyType);
                }
                catch (TimeoutException)
                {
                    throw new TimeoutException("Remote service doesn't answer");
                }
                finally
                {
                  
                }

            }
            else
            {
                addressResultsList = new AddressResultsList
                {
                    intTotalRecordsFound = 1,
                    lstAddresses = new[] { "Error: Empty postcode" }
                };
            }
            return addressResultsList;
        }

        public Address AddressLookup(string strPostcode)
        {
            throw new NotImplementedException();
        }

        public IAddressParser AddressParser { get; set; }
    }
}
