using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Addresses
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string HouseNo{ get; set; }
        public string Street{ get; set; }
        public string City { get; set; }
        public string State{ get; set; }
        public int Pincode{ get; set; }
        public string Country { get; set; }

        public Addresses(int addressId, int userId, string houseNo, string street,
            string city, string state, int pincode, string country)
        {
            AddressId = addressId;
            UserId = userId;
            HouseNo = houseNo;
            Street = street;
            City = city;
            State = state;
            Pincode = pincode;
            Country = country;
        }
    }
}