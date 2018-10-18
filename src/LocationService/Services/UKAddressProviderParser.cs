namespace LocationService.Services
{
    public class UKAddressProviderParser
    {
        private static UKAddressProviderParser _ukAddressProviderParser = new UKAddressProviderParser();
        private static object _locker = new object();

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
    }
}
