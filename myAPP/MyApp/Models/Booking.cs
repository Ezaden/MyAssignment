//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Booking
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Flight Name")]
        // public string FlightName { get; set; }
        private string flightName = "Qantas Airline";

        public string FlightName
        {
            get
            {
                return flightName;
            }
            set
            {
                flightName = value;
            }

        }

        [Display(Name = "Departure City")]
        public string Dept_City { get; set; }
        [Display(Name = "Arrival City")]
        public string Arrival_City { get; set; }
        [Display(Name = "Departure Date")]
        public string Dept_Date { get; set; }
        [Display(Name = "Return Date")]
        public string Retrun_Date { get; set; }
        //public Nullable<double> Price { get; set; }
        private double price = 1300;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        [Display(Name = "Seat Number")]
        public Nullable<int> SeatNumber { get; set; }
        [Display(Name = "Number of Passenger(s)")]
        public Nullable<int> NumberOfPassenger { get; set; }
    }
}
