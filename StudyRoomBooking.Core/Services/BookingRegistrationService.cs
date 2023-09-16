using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.DataAccess.Repository.Interfaces;
using StudyRoomBooking.Models;
using StudyRoomBooking.Models.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace StudyRoomBooking.Core.Services
{
    public class BookingRegistrationService : IBookingRegistration
    {
        private readonly IBookingRegistrationRepo _registrationRepo;
        public BookingRegistrationService(IBookingRegistrationRepo registrationRepo)
        {
            _registrationRepo = registrationRepo;
        }
        public BookingRegistrationService()
        {
            
        }
        public string RoomAvilabilty(UserDetails userDetails)
        {
           
                Room roomDetails = _registrationRepo.RoomAvilabity();
                if (roomDetails==null) {
                    
                    return "no";
                }
              
                BookingDetails bookingDetails = new()
                {
                    FirstName = userDetails.FirstName,
                    LastName = userDetails.LastName,
                    Email=userDetails.Email,
                    Date = userDetails.Date,
                    RoomDetails = roomDetails
                };
                _registrationRepo.ChangeRoomAvilability(roomDetails.RoomNo);
                _registrationRepo.SaveBookingDetails(bookingDetails);
           
                return roomDetails.Id.ToString();
            
        }


        public bool UserDetailsValidation(UserDetails userDetails)
        {
           BookingRegistrationService bookingRegistrationService = new BookingRegistrationService();
            if (!bookingRegistrationService.NameValidation(userDetails.FirstName))
            {
                return false;
            }
            else if (!bookingRegistrationService.NameValidation(userDetails.LastName))
            {
                return false;
            }
            else if (!bookingRegistrationService.Emailvalidation(userDetails.Email))
            {
                return false;
            }
            else if (!bookingRegistrationService.DateValidation(userDetails.Date))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public  bool NameValidation(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 4 || name.Length > 20)
            {
                return false;
            }
            if (!name.All(ch => char.IsLetter(ch) || char.IsWhiteSpace(ch)))
            {
                return false;
            }

            return true;

        }
        public  bool Emailvalidation(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            const string pattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
            return Regex.IsMatch(email, pattern);
        }
        public  bool DateValidation(DateTime date)
        {
            string desiredFormat = "yyyy-MM-dd";
            string formattedDate = date.ToString(desiredFormat);
            DateTime parsedDate;

            if (DateTime.TryParseExact(formattedDate, desiredFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return date.Date == parsedDate.Date && date >= DateTime.Today;
            }

            return false;
            
        }


       

        public void ChangeRoomavilabity(string refRoomNo)
        {
            _registrationRepo.ChangeRoomAvilability(refRoomNo);
        }

        public int BookingIdByRoomId(string roomNo)
        {
           
            return _registrationRepo.BookingIdByRoomId(roomNo);
        }
    }
}
