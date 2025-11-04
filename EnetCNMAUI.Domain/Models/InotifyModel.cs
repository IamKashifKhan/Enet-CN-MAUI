using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EnetCNMAUI.Models
{
    public class MapPinItem  
    {
        public int BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        //public Position Position { get; set; }
    }

    public class DateItem  
    {
        public string month { get; set; }
        public string day { get; set; }
        public string dayWeek { get; set; }
        public bool selected { get; set; }
        public string backgroundColor { get; set; }

        public string textColor { get; set; }
        

        public ObservableCollection<CurrentEvents> currentevents { get; set; }
    }

    public class CurrentEvents
    {
        public string events { get; set; }

    }

    //public class EventItem  
    //{
    //    public string APPID { get; set; }
    //    public double Latitude { get; set; }
    //    public double Longitude { get; set; }
    //    public int? BusinessKey { get; set; }
    //    public List<string> BusinessName { get; set; }
    //    public int UserKey { get; set; }
    //    public string EventType { get; set; }
    //    public int EventKey { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public DateTime EventStart { get; set; }
    //    public DateTime EventEnd { get; set; }
    //    public double PriceRangeMin { get; set; }
    //    public double PriceRangeMax { get; set; }
    //    public string StreetAddress { get; set; }
    //    public string LocationName { get; set; }
    //    public string City { get; set; }
    //    public string State { get; set; }
    //    public string Zip { get; set; }
    //    public string Phone { get; set; }
    //    public string EventURL { get; set; }
    //    public string ImagePath { get; set; }
    //    public bool IsActive { get; set; }
    //    public DateTime TimeStamp { get; set; }
    //    public string PresentedBy { get; set; }
    //    public DateTime EventTime { get; set; }
    //    public string EventDate { get; set; }
    //    public string Title { get; set; }
    //    public string StartTime { get; set; }
    //    public string EndTime { get; set; }
    //    public string Address { get; set; }
    //    public string IsFavorite { get; set; }

    //    //private bool _Favorite;
    //    //public bool isFavorite
    //    //{


    //    //    get { return _Favorite; }
    //    //    set
    //    //    {
    //    //        SetProperty(ref _Favorite, value);
    //    //        OnPropertyChanged(nameof(isFavorite));
    //    //    }
    //    //}
    //}



    public class EventListItem  
    {

        public DateTime EventTime { get; set; }
        public string EventDate { get; set; }
        public string Title { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Address { get; set; }
        public bool Favorite;
 
    }
    public class UserImagesItem 
    {
        public string ImagePath { get; set; }
    }
}
