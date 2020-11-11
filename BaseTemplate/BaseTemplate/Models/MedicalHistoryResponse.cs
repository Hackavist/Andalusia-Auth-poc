using System;
using System.Collections.Generic;

namespace BaseTemplate.Models
{
    public class MedicalHistoryResponse
    {
        public int statusCode { get; set; }
        public List<MedicalHistoryObject> result { get; set; }
    }

    public class MedicalHistoryObject
    {
        public int id { get; set; }
        public int tableID { get; set; }
        public string titleEn { get; set; }
        public string titleAr { get; set; }
        public string month { get; set; }
        public string monthYear { get; set; }
        public int monthInNumbers { get; set; }
        public int year { get; set; }
        public bool active { get; set; }
        public bool chronic { get; set; }
        public DateTime creationDate { get; set; }
        public object updatedDate { get; set; }
        public string category { get; set; }
        public bool isManualAdd { get; set; }
        public bool hasImageAttachment { get; set; }
        public bool hasPDFAttachment { get; set; }
    }
}
/*
 *     public class Result    {
        public int id { get; set; } 
        public int tableID { get; set; } 
        public string titleEn { get; set; } 
        public string titleAr { get; set; } 
        public string month { get; set; } 
        public string monthYear { get; set; } 
        public int monthInNumbers { get; set; } 
        public int year { get; set; } 
        public bool active { get; set; } 
        public bool chronic { get; set; } 
        public DateTime creationDate { get; set; } 
        public object updatedDate { get; set; } 
        public string category { get; set; } 
        public bool isManualAdd { get; set; } 
        public bool hasImageAttachment { get; set; } 
        public bool hasPDFAttachment { get; set; } 
    }

    public class Root    {
        public int statusCode { get; set; } 
        public List<Result> result { get; set; } 
    }
 */