using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectNow.Models
{
    public class AllBusinessCategories
    {
        public string Category_Main_ID { get; set; }
        public string Category_Main_Name { get; set; }
        public string Category_Main_ImagePath { get; set; }
        public string Category_Main_Description { get; set; }
        public string MainCategoryBusinessCounts { get; set; }
        public string SubCategoryBusinessCounts { get; set; }
        public string Category_Main_ID_FULL { get; set; }
        public string Category_Sub_ID { get; set; }
        public string Category_Sub_Name { get; set; }
        public string Category_Sub_Description { get; set; }
        public string Timestamp { get; set; }
    }



    public class MainCategory : BindableObject
    {
        bool _isDetailVisible;

        public string Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
        public string Icon { get; set; }
        public Color Color { get; set; }

        public bool IsDetailVisible
        {
            get { return _isDetailVisible; }
            set
            {
                Task.Run(async () =>
                {
                    await Task.Delay(value ? 0 : 250);
                    _isDetailVisible = value;
                    OnPropertyChanged();
                });
            }
        }
        public List<SubCategory> SubCategories { get; set; }

    }


    public class SubCategory
    {

        public string Category_Main_ID { get; set; }
        public string Category_Main_Name { get; set; }
        public string Category_Main_Description { get; set; }
        public string Category_Sub_ID { get; set; }
        public string Category_Sub_Name { get; set; }
        public string Category_Sub_Description { get; set; }
        public string Timestamp { get; set; }
        public string MainCategoryBusinessCounts { get; set; }
        public string SubCategoryBusinessCounts { get; set; }
        public bool Done { get; set; }
        public bool IsLatest { get; set; }
    }


    public class CatergoryList 
    {

        public string db_Category_Main_ID { get; set; }
        public string dbName { get; set; }
        public string dbDescription { get; set; }
        public string dbTimestamp { get; set; }
        public string dbImagePath { get; set; }
        public string dbKeywords { get; set; }
        public string dbVisibility { get; set; }

         public bool IsSelected { get; set; }
         
    }

    public class SubCatergoryList 
    {

        public string db_Category_Sub_ID { get; set; }
        public string db_Category_Main_ID { get; set; }
        public string dbName { get; set; }
        public string dbDescription { get; set; }
        public string dbTimestamp { get; set; }
        public string dbKeywords { get; set; }
        public string dbVisibility { get; set; }
        public bool IsSelected { get; set; }
       
    }




}
