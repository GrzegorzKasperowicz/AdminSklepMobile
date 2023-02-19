using AdminServiceConnection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models
{
    public class ClientForView
    {
        public int IdClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }

        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }


        public ClientForView() { }
        public ClientForView(Client client)
        {
            IdClient = client.IdClient;
            FirstName = client.FirstName;
            LastName = client.LastName;
            Street = client.Street;
            HouseNumber = client.HouseNumber;
            ApartmentNumber = client.ApartmentNumber;
            City = client.City;
            Province = client.Province;
            PostalCode = client.PostalCode;
            Country = client.Country;
            PhoneNumber = client.PhoneNumer;
            Email = client.Email;
        }
    }
}
