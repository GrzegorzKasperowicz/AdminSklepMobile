using Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class ClientAddViewModel:BaseViewModel<ClientForView>
    {
        private int id;
        private string firstName;
        private string lastName;
        private string street;
        private string houseNumber;
        private string apartmentNumber;
        private string city;
        private string province;
        private string postalCode;
        private string country;
        private string phoneNumber;
        private string email;

        public ClientAddViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return Id > 0
                && !String.IsNullOrEmpty(firstName);
        }
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }
        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }
        public string Street
        {
            get => street;
            set => SetProperty(ref street, value);
        }
        public string ApartmentNumber
        {
            get => apartmentNumber;
            set => SetProperty(ref apartmentNumber, value);
        }
        public string HouseNumber
        {
            get => houseNumber;
            set => SetProperty(ref houseNumber, value);
        }
        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }
        public string PostalCode
        {
            get => postalCode;
            set => SetProperty(ref postalCode, value);
        }
        public string Province
        {
            get => province;
            set => SetProperty(ref province, value);
        }
        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            ClientForView newItem = new ClientForView()
            {
                IdClient = Id,
                FirstName = FirstName,
                LastName = LastName,
                Street = Street,
                HouseNumber = HouseNumber,
                ApartmentNumber = ApartmentNumber,
                City = City,
                PostalCode = PostalCode,
                Province= Province,
                Country = Country,
                PhoneNumber = PhoneNumber,
                Email = Email

            };
            await DataStore.AddItemAsync(newItem);

            await Shell.Current.GoToAsync("..");
        }
    }

}
