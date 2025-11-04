using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConnectNow.Models
{
    public class SocialFeedItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public string ParentFeedUserKey { get; set; }
        public string ParentFeedUserFirstName { get; set; }
        public string ParentFeedUserLastName { get; set; }
        public string ParentFeedUserImagePath { get; set; }
        public string ParentFeedTimestamp { get; set; }
        public string ParentFeed_Link { get; set; }
        public string ParentFeed_Feed { get; set; }
        public string ParentFeed_ImagePath { get; set; }
        public string ParentFeed_FeedKey { get; set; }
        public string FeedLink { get; set; }




        private bool _SizeUpdate;
        public bool SizeUpdate
        {


            get { return _SizeUpdate; }
            set
            {
                SetProperty(ref _SizeUpdate, value);
                OnPropertyChanged(nameof(SizeUpdate));
            }
        }
        
        private double _RowHeight;
        public double RowHeight
        {
            get { return _RowHeight; }
            set { SetProperty(ref _RowHeight, value); }
        }


        private bool _IsPlaying;
        public bool IsPlaying
        {
            get { return _IsPlaying; }
            set { SetProperty(ref _IsPlaying, value); }
        }
        public string BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string UserKey { get; set; }
        public string UserNickName { get; set; }
        public string UserFirstName { get; set; }
        public string dbLastName { get; set; }
        public string UserName { get; set; }
        public string FeedKey { get; set; }
        public string FeedImagePath { get; set; }
        public string BusinessLogoPath { get; set; }
        public string UserImagePath { get; set; }
        public string Subject { get; set; }
        public string Feed { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Feed_Schedule_ID { get; set; }
        public string Time { get; set; }
        public DateTime Timestamp { get; set; }
        public string Comment_FeedKey { get; set; }
        public string Comment_CommentKey { get; set; }
        public string Comment_UserKey { get; set; }

        public string Comment_Comment
        {
            get { return _Comment_Comment; }
            set { SetProperty(ref _Comment_Comment, value); }
        }
        private string _Comment_Comment;


        public string Comment_Timestamp
        {
            get { return _Comment_Timestamp; }
            set { SetProperty(ref _Comment_Timestamp, value); }
        }
        private string _Comment_Timestamp;

        public string Comment_ParentCommentKey { get; set; }

        public string Comment_NickName { get; set; }
        public string Comment_FirstName
        {
            get { return _Comment_FirstName; }
            set { SetProperty(ref _Comment_FirstName, value); }
        }
        private string _Comment_FirstName;
        public string Comment_LastName
        {
            get { return _Comment_LastName; }
            set { SetProperty(ref _Comment_LastName, value); }
        }
        private string _Comment_LastName;

        public string Comment_UserName { get; set; }
        public string Comment_Password { get; set; }
        public string Comment_Phone { get; set; }
        public string Comment_DOB { get; set; }
        public string Comment_Country { get; set; }
        public string Comment_City { get; set; }
        public string Comment_State { get; set; }
        public string Comment_Address { get; set; }
        public string Comment_Zipcode { get; set; }
        public string Comment_Latitude { get; set; }
        public string Comment_Longitude { get; set; }
        public string Comment_ImagePath
        {
            get { return _Comment_ImagePath; }
            set { SetProperty(ref _Comment_ImagePath, value); }
        }
        private string _Comment_ImagePath;
        public string Comment_CoverImagePath { get; set; }
        public string Comment_Active { get; set; }
        public string Comment_RegistrationTimestamp { get; set; }

        public string dbActive { get; set; }
        public string FeedCommentKey { get; set; }
        public string FeedorComment { get; set; }

        public bool IsEmoji_0Update { get; set; }
        public bool IsEmoji_1Update { get; set; }
        public bool IsEmoji_2Update { get; set; }
        public bool IsEmoji_3Update { get; set; }
        public bool IsEmoji_4Update { get; set; }
        public bool IsEmoji_5Update { get; set; }
        public bool IsEmoji_6Update { get; set; }
        public bool IsEmoji_7Update { get; set; }

        public int UserEmoji_0 { get; set; }
        public int UserEmoji_1 { get; set; }
        public int UserEmoji_2 { get; set; }
        public int UserEmoji_3 { get; set; }
        public int UserEmoji_4 { get; set; }
        public int UserEmoji_5 { get; set; }
        public int UserEmoji_6 { get; set; }
        public int UserEmoji_7 { get; set; }
        public int UserEmojis_Count { get; set; }
        private int _Emoji_0;

        public int Emoji_0
        {
            get { return _Emoji_0; }
            set
            {
                SetProperty(ref _Emoji_0, value);
            }
        }
        private int _Emoji_1;

        public int Emoji_1
        {
            get { return _Emoji_1; }
            set { SetProperty(ref _Emoji_1, value); }
        }
        private int _Emoji_2;

        public int Emoji_2
        {
            get { return _Emoji_2; }
            set { SetProperty(ref _Emoji_2, value); }
        }
        private int _Emoji_3;

        public int Emoji_3
        {
            get { return _Emoji_3; }
            set { SetProperty(ref _Emoji_3, value); }
        }
        private int _Emoji_4;

        public int Emoji_4
        {
            get { return _Emoji_4; }
            set { SetProperty(ref _Emoji_4, value); }
        }
        private int _Emoji_5;

        public int Emoji_5

        {

            get { return _Emoji_5; }
            set
            {
                SetProperty(ref _Emoji_5, value);
            }
        }
        private int _Emoji_6;

        public int Emoji_6
        {
            get { return _Emoji_6; }
            set { SetProperty(ref _Emoji_6, value); }
        }
        private int _Emoji_7;

        public int Emoji_7
        {
            get { return _Emoji_7; }
            set { SetProperty(ref _Emoji_7, value); }
        }
        private int _Emojis_Count;

        public int Emojis_Count
        {
            get { return _Emojis_Count; }
            set { SetProperty(ref _Emojis_Count, value); }
        }


        private string _TotalComments;
        public string TotalComments
        {
            get { return _TotalComments; }
            set { SetProperty(ref _TotalComments, value); }
        }





        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class SearchConnectionItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isConnected;
        public bool isConnected
        {
            get { return _isConnected; }
            set { SetProperty(ref _isConnected, value); }
        }
        public string UserKey { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string DOB { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ImagePath { get; set; }
        public string CoverImagePath { get; set; }
        public string Active { get; set; }
        public string RegistrationTimestamp { get; set; }
        public string Hobby { get; set; }
        public string Married { get; set; }
        public string About { get; set; }
        public string Company { get; set; }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    public class CommentItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string FeedKey { get; set; }
        public string CommentKey { get; set; }
        public string UserKey { get; set; }
        public string Comment { get; set; }
        public string ParentCommentKey { get; set; }
        public string Timestamp { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string DOB { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ImagePath { get; set; }
        public string CoverImagePath { get; set; }
        public string Active { get; set; }
        public string RegistrationTimestamp { get; set; }
        public bool IsEmoji_0Update { get; set; }
        public bool IsEmoji_1Update { get; set; }
        public bool IsEmoji_2Update { get; set; }
        public bool IsEmoji_3Update { get; set; }
        public bool IsEmoji_4Update { get; set; }
        public bool IsEmoji_5Update { get; set; }
        public bool IsEmoji_6Update { get; set; }
        public bool IsEmoji_7Update { get; set; }

        public int UserEmoji_0 { get; set; }
        public int UserEmoji_1 { get; set; }
        public int UserEmoji_2 { get; set; }
        public int UserEmoji_3 { get; set; }
        public int UserEmoji_4 { get; set; }
        public int UserEmoji_5 { get; set; }
        public int UserEmoji_6 { get; set; }
        public int UserEmoji_7 { get; set; }
        public int UserEmojis_Count { get; set; }
        private int _Emoji_0;

        public int Emoji_0
        {
            get { return _Emoji_0; }
            set
            {
                SetProperty(ref _Emoji_0, value);
            }
        }
        private int _Emoji_1;

        public int Emoji_1
        {
            get { return _Emoji_1; }
            set { SetProperty(ref _Emoji_1, value); }
        }
        private int _Emoji_2;

        public int Emoji_2
        {
            get { return _Emoji_2; }
            set { SetProperty(ref _Emoji_2, value); }
        }
        private int _Emoji_3;

        public int Emoji_3
        {
            get { return _Emoji_3; }
            set { SetProperty(ref _Emoji_3, value); }
        }
        private int _Emoji_4;

        public int Emoji_4
        {
            get { return _Emoji_4; }
            set { SetProperty(ref _Emoji_4, value); }
        }
        private int _Emoji_5;

        public int Emoji_5

        {

            get { return _Emoji_5; }
            set
            {
                SetProperty(ref _Emoji_5, value);
            }
        }
        private int _Emoji_6;

        public int Emoji_6
        {
            get { return _Emoji_6; }
            set { SetProperty(ref _Emoji_6, value); }
        }
        private int _Emoji_7;

        public int Emoji_7
        {
            get { return _Emoji_7; }
            set { SetProperty(ref _Emoji_7, value); }
        }
        private int _Emojis_Count;

        public int Emojis_Count
        {
            get { return _Emojis_Count; }
            set { SetProperty(ref _Emojis_Count, value); }
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class BusinessFeedItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string UserKey { get; set; }
        public string UserName { get; set; }
        public string FeedKey { get; set; }
        public string UserImagePath { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Feed_Schedule_ID { get; set; }
        public string Time { get; set; }
        public string Timestamp { get; set; }
        public string Column1 { get; set; }
        public bool SizeUpdate { get; set; }
        public double ExpRow { get; set; }

        private double _FeedHeight;
        public double FeedHeight
        {
            get { return _FeedHeight; }
            set { SetProperty(ref _FeedHeight, value); }
        }
        public string FeedTextHeight { get; set; }
        public string BusinessLogoPath { get; set; }
        public string Subject { get; set; }
        public string FeedShort { get; set; }
        public string Feed { get; set; }
        public string BusinessName { get; set; }
        public string BusinessKey { get; set; }
        public string FeedImagePath { get; set; }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

    public class BusinessFeedItemNew : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public string ParentFeedUserKey { get; set; }
        public string ParentFeedUserFirstName { get; set; }
        public string ParentFeedUserLastName { get; set; }
        public string ParentFeedUserImagePath { get; set; }
        public string ParentFeedTimestamp { get; set; }
        public string ParentFeed_Link { get; set; }
        public string ParentFeed_Feed { get; set; }
        public string ParentFeed_ImagePath { get; set; }
        public string ParentFeed_FeedKey { get; set; }
        public string FeedLink { get; set; }




        private bool _SizeUpdate;
        public bool SizeUpdate
        {


            get { return _SizeUpdate; }
            set
            {
                SetProperty(ref _SizeUpdate, value);
                OnPropertyChanged(nameof(SizeUpdate));
            }
        }

        private double _RowHeight;
        public double RowHeight
        {
            get { return _RowHeight; }
            set { SetProperty(ref _RowHeight, value); }
        }


        private bool _IsPlaying;
        public bool IsPlaying
        {
            get { return _IsPlaying; }
            set { SetProperty(ref _IsPlaying, value); }
        }
        public string BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string UserKey { get; set; }
        public string UserNickName { get; set; }
        public string UserFirstName { get; set; }
        public string dbLastName { get; set; }
        public string UserName { get; set; }
        public string FeedKey { get; set; }
        public string FeedImagePath { get; set; }
        public string BusinessLogoPath { get; set; }
        public string UserImagePath { get; set; }
        public string Subject { get; set; }
        public string Feed { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Feed_Schedule_ID { get; set; }
        public string Time { get; set; }
        public DateTime Timestamp { get; set; }
        public string Comment_FeedKey { get; set; }
        public string Comment_CommentKey { get; set; }
        public string Comment_UserKey { get; set; }

        public string Comment_Comment
        {
            get { return _Comment_Comment; }
            set { SetProperty(ref _Comment_Comment, value); }
        }
        private string _Comment_Comment;


        public string Comment_Timestamp
        {
            get { return _Comment_Timestamp; }
            set { SetProperty(ref _Comment_Timestamp, value); }
        }
        private string _Comment_Timestamp;

        public string Comment_ParentCommentKey { get; set; }

        public string Comment_NickName { get; set; }
        public string Comment_FirstName
        {
            get { return _Comment_FirstName; }
            set { SetProperty(ref _Comment_FirstName, value); }
        }
        private string _Comment_FirstName;
        public string Comment_LastName
        {
            get { return _Comment_LastName; }
            set { SetProperty(ref _Comment_LastName, value); }
        }
        private string _Comment_LastName;

        public string Comment_UserName { get; set; }
        public string Comment_Password { get; set; }
        public string Comment_Phone { get; set; }
        public string Comment_DOB { get; set; }
        public string Comment_Country { get; set; }
        public string Comment_City { get; set; }
        public string Comment_State { get; set; }
        public string Comment_Address { get; set; }
        public string Comment_Zipcode { get; set; }
        public string Comment_Latitude { get; set; }
        public string Comment_Longitude { get; set; }
        public string Comment_ImagePath
        {
            get { return _Comment_ImagePath; }
            set { SetProperty(ref _Comment_ImagePath, value); }
        }
        private string _Comment_ImagePath;
        public string Comment_CoverImagePath { get; set; }
        public string Comment_Active { get; set; }
        public string Comment_RegistrationTimestamp { get; set; }

        public string dbActive { get; set; }
        public string FeedCommentKey { get; set; }
        public string FeedorComment { get; set; }

        public bool IsEmoji_0Update { get; set; }
        public bool IsEmoji_1Update { get; set; }
        public bool IsEmoji_2Update { get; set; }
        public bool IsEmoji_3Update { get; set; }
        public bool IsEmoji_4Update { get; set; }
        public bool IsEmoji_5Update { get; set; }
        public bool IsEmoji_6Update { get; set; }
        public bool IsEmoji_7Update { get; set; }

        public int UserEmoji_0 { get; set; }
        public int UserEmoji_1 { get; set; }
        public int UserEmoji_2 { get; set; }
        public int UserEmoji_3 { get; set; }
        public int UserEmoji_4 { get; set; }
        public int UserEmoji_5 { get; set; }
        public int UserEmoji_6 { get; set; }
        public int UserEmoji_7 { get; set; }
        public int UserEmojis_Count { get; set; }
        private int _Emoji_0;

        public int Emoji_0
        {
            get { return _Emoji_0; }
            set
            {
                SetProperty(ref _Emoji_0, value);
            }
        }
        private int _Emoji_1;

        public int Emoji_1
        {
            get { return _Emoji_1; }
            set { SetProperty(ref _Emoji_1, value); }
        }
        private int _Emoji_2;

        public int Emoji_2
        {
            get { return _Emoji_2; }
            set { SetProperty(ref _Emoji_2, value); }
        }
        private int _Emoji_3;

        public int Emoji_3
        {
            get { return _Emoji_3; }
            set { SetProperty(ref _Emoji_3, value); }
        }
        private int _Emoji_4;

        public int Emoji_4
        {
            get { return _Emoji_4; }
            set { SetProperty(ref _Emoji_4, value); }
        }
        private int _Emoji_5;

        public int Emoji_5

        {

            get { return _Emoji_5; }
            set
            {
                SetProperty(ref _Emoji_5, value);
            }
        }
        private int _Emoji_6;

        public int Emoji_6
        {
            get { return _Emoji_6; }
            set { SetProperty(ref _Emoji_6, value); }
        }
        private int _Emoji_7;

        public int Emoji_7
        {
            get { return _Emoji_7; }
            set { SetProperty(ref _Emoji_7, value); }
        }
        private int _Emojis_Count;

        public int Emojis_Count
        {
            get { return _Emojis_Count; }
            set { SetProperty(ref _Emojis_Count, value); }
        }


        // private string _TotalComments;
        // public string TotalComments
        // {
        //     get { return _TotalComments; }
        //     set { SetProperty(ref _TotalComments, value); }
        // }





        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class BusinessListItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //public string BusinessTimeZone { get; set; }
        //public string TimeDiff { get; set; }
        //public string DST { get; set; }
        //public string IsFavorite { get; set; }
        //public string BusinessKey { get; set; }
        //public string BusinessName { get; set; }
        //public string Phone { get; set; }
        //public string Logo { get; set; }
        //public string About { get; set; }
        //public string Description { get; set; }
        //public string StartTime_Sunday { get; set; }
        //public string EndTime_Sunday { get; set; }
        //public string StartTime_Monday { get; set; }
        //public string EndTime_Monday { get; set; }
        //public string StartTime_Tuesday { get; set; }
        //public string EndTime_Tuesday { get; set; }
        //public string StartTime_Wednesday { get; set; }
        //public string EndTime_Wednesday { get; set; }
        //public string StartTime_Thursday { get; set; }
        //public string EndTime_Thursday { get; set; }
        //public string StartTime_Friday { get; set; }
        //public string EndTime_Friday { get; set; }
        //public string StartTime_Saturday { get; set; }
        //public string EndTime_Saturday { get; set; }
        //public string AverageReviews { get; set; }
        public string RowNum { get; set; }
        public int DataType { get; set; }
        public string DataTypeDesc { get; set; }
        public string BusinessTimeZone { get; set; }
        public string TimeDiff { get; set; }
        public string DST { get; set; }
        public string PaymentTerms { get; set; }
        public string DataRow { get; set; }
        public string IsFavorite { get; set; }
        public string BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
        public string About { get; set; }
        public string Description { get; set; }
        public string StartTime_Sunday { get; set; }
        public string EndTime_Sunday { get; set; }
        public string StartTime_Monday { get; set; }
        public string EndTime_Monday { get; set; }
        public string StartTime_Tuesday { get; set; }
        public string EndTime_Tuesday { get; set; }
        public string StartTime_Wednesday { get; set; }
        public string EndTime_Wednesday { get; set; }
        public string StartTime_Thursday { get; set; }
        public string EndTime_Thursday { get; set; }
        public string StartTime_Friday { get; set; }
        public string EndTime_Friday { get; set; }
        public string StartTime_Saturday { get; set; }
        public string EndTime_Saturday { get; set; }
        public string AverageReviews { get; set; }
        public string ParentMessageKey { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        private string _OpenClose;
        public string OpenClose
        {
            get { return _OpenClose; }
            set { SetProperty(ref _OpenClose, value); }
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class OffersListItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string IsFavorite { get; set; }
        public string BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string OfferKey { get; set; }
        public string ThumbnailPath { get; set; }
        public string ImagePath { get; set; }
        public string CodeThumbnailPath { get; set; }
        public string CodeImagePath { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Timestamp { get; set; }
        public bool SizeUpdate { get; set; }
        public double ExpRow { get; set; }

        private double _FeedHeight;
        public double FeedHeight
        {
            get { return _FeedHeight; }
            set { SetProperty(ref _FeedHeight, value); }
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class SocialPhotos : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string ThumbnailPath { get; set; }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
