using System.Linq;
using LocationService.Business_Entities;

namespace LocationService.Services
{
    public class UKAddressProviderParser
    {
        private static UKAddressProviderParser _ukAddressProviderParser = new UKAddressProviderParser();
        private static object _locker = new object();
        private static char[] _separators = new[] { ' ', ',' };

        private UKAddressProviderParser()
        {
        }

        public static UKAddressProviderParser Instance
        {
            get
            {
                lock (_locker)
                {
                    if (_ukAddressProviderParser == null)
                    {
                        lock (_locker)
                        {
                            _ukAddressProviderParser = new UKAddressProviderParser();
                        }
                    }
                }
                return _ukAddressProviderParser;
            }
        }
        public Address GetAddressData(string[] addresses)
        {
            var address = new Address();
            return address;

        }

        private string GetCounty(string address)
        {
            var addressLastItem = address.Split(',').Last().Trim(_separators);
            var hasCounty = Counties.Names.Any(e => e == addressLastItem);
            return hasCounty ? addressLastItem : string.Empty;
        }

        private string GetTown(string address, bool hasCountry)
        {
            var substrings = address.Split(',');
            return substrings.Take(substrings.Length - (hasCountry ? 1 : 0)).Last().Trim(_separators);
        }

        private string[] GetHouseNumbers(string[] addressArray)
        {
            if (addressArray.Length > 1)
            {
                var houseNumbersSplits = addressArray.Select(e => e.Split(' ')).ToArray();

                var countLastRemovesubLeftString = 0;

                var minCount = houseNumbersSplits.Min(e => e.Length) - 1;

                while (addressArray.Length > 1 && countLastRemovesubLeftString < minCount &&
                       houseNumbersSplits.All(
                           e =>
                               e[e.Length - 1 - countLastRemovesubLeftString] ==
                               houseNumbersSplits[0][houseNumbersSplits[0].Length - 1 - countLastRemovesubLeftString])
                )
                {
                    countLastRemovesubLeftString++;
                }
                var generalResultHousesNumber =
                    houseNumbersSplits.Select(
                            e =>
                                string.Join(" ", e.Take(e.Length - countLastRemovesubLeftString).ToArray()).Trim(_separators))
                        .ToArray();
                return generalResultHousesNumber;
            }
            var singleResultSeprate = addressArray[0].Split(' ');
            var sinigleResult = string.Join(",", singleResultSeprate.Take(
                singleResultSeprate.Length -
                (singleResultSeprate.Length > 2 ? 2 : (singleResultSeprate.Length == 2 ? 1 : 0))
            ).ToArray());
            return new[] { sinigleResult };
        }
    }
}
