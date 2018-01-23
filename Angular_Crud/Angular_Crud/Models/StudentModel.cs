using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angular_Crud.Models
{
    public class StudentModel
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string SName { get; set; }
        public string CityName { get; set; }

        public int State { get; set; }
        public int City { get; set; }
        public int Country { get; set; }

        public string PhnNo { get; set; }

        public string Email { get; set; }

        public string DOB { get; set; }

        public string Gender { get; set; }

        public bool Btech { get; set; }
        public bool Bsc { get; set; }
        public bool Bca { get; set; }
        public bool Ba { get; set; }


        public bool? IsActive { get; set; }


    }

    public class StudentSearch
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }

    public class MainDataSet
    {

      public List<StudentModel> StudentModelList { get; set;}


      public TotalRecord TotalRec { get; set; }
    }
    public class TotalRecord
    {

        public int TotalRecords { get; set; }
    }


}