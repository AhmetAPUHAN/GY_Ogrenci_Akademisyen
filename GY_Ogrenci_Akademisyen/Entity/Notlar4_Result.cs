//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GY_Ogrenci_Akademisyen.Entity
{
    using System;
    
    public partial class Notlar4_Result
    {
        public int Not_ID { get; set; }
        public string DersAdı { get; set; }
        public string ÖğrenciAdSoyad { get; set; }
        public Nullable<int> Sınav1 { get; set; }
        public Nullable<int> Sınav2 { get; set; }
        public Nullable<int> Sınav3 { get; set; }
        public Nullable<int> Quiz1 { get; set; }
        public Nullable<int> Quiz2 { get; set; }
        public Nullable<int> Proje { get; set; }
        public Nullable<decimal> Ortalama { get; set; }
    }
}
