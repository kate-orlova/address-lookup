# Address Lookup
Address lookup is a CMS agnostic service based on [Postcode Everywhere API](http://ws.afd.co.uk/) provided by [AFD Software](https://www.afd.co.uk/).
Solution is organised into the following folders:
1. Business Entities definingg the address structure and list of the UK counties
2. Interfaces specifying interfaces for address parser and provider
3. Services composing of the PostcodeServiceClient and UK address provider & parser
