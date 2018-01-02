using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace SOAP_WCF_DATABASE_TEMPLATE
{
    [DataContract]
    public class Movie
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Titel { get; set; }
        [DataMember]
        public int Rating { get; set; }

        public Movie()
        {

        }

        public Movie(int id, string titel, int rating)
        {
            Id = id;
            Titel = titel;
            Rating = rating;
        }


        //public override string ToString()
        //{
        //    return $"{nameof(Id)}: {Id}, {nameof(Titel)}: {Titel}, {nameof(Rating)}: {Rating}";
        //}
    }
}