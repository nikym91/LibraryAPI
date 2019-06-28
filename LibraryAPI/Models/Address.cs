using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

        public Address() { }

        public Address(int addressId, string street, string suite, string city, string zipcode)
        {
            AddressId = addressId;
            Street = street;
            Suite = suite;
            City = city;
            Zipcode = zipcode;
        }
    }
}
