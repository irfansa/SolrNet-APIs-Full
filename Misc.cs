using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SolrNetCoreAPIs
{
    public class Misc
    {

        [DataContract]
        public class ReturnArgs
        {
            [DataMember]
            public bool success { get; set; }
            //[DataMember]
            ////ERR101    Internal Error
            ////ERR102    Invalid Submitted Data format
            ////ERR103    No Result
            //public object errorcode { get; set; }
            [DataMember]
            public string result { get; set; }
            [DataMember]
            public string statusdescription { get; set; }
            [DataMember]
            public string fullexception { get; set; }
        }
        [DataContract]
        public class AddressOutPutParams : ReturnArgs
        {
            [DataMember]
            public string totalSearchResults { get; set; }
            [DataMember]
            public List<Address> Addresses { get; set; }
            [DataMember]
            public List<PostCode> PostCode { get; set; }
        }

        [DataContract]
        public class PostCode
        {
            [DataMember]
            public string postCode { get; set; }
            [DataMember]
            public string regionName { get; set; }
            [DataMember]
            public string cityName { get; set; }
            [DataMember]
            public string districtName { get; set; }
            [DataMember]
            public bool hasParcels { get; set; }
            //public string city;
        }

        [DataContract]
        public class Address
        {
            [DataMember]
            public string Title { get; set; }
            [DataMember]
            public string Address1 { get; set; }
            [DataMember]
            public string Address2 { get; set; }
            [DataMember]
            public string ObjLatLng { get; set; }
            [DataMember]
            public string BuildingNumber { get; set; }
            [DataMember]
            public string Street { get; set; }
            [DataMember]
            public string District { get; set; }
            [DataMember]
            public string City { get; set; }
            [DataMember]
            public string PostCode { get; set; }
            [DataMember]
            public string AdditionalNumber { get; set; }
            [DataMember]
            public string RegionName { get; set; }
            [DataMember]
            public string PolygonString { get; set; }
            [DataMember]
            public string IsPrimaryAddress { get; set; }
            [DataMember]
            public string UnitNumber { get; set; }
            [DataMember]
            public string Latitude { get; set; }
            [DataMember]
            public string Longitude { get; set; }
            [DataMember]
            public string CityId { get; set; }
            [DataMember]
            public string RegionId { get; set; }
            [DataMember]
            public string Restriction { get; set; }
            [DataMember]
            public string PKAddressID { get; set; }
            [DataMember]

            public string DistrictID { get; set; }
            [DataMember]
            public string Title_L2 { get; set; }
            [DataMember]
            public string RegionName_L2 { get; set; }
            [DataMember]
            public string City_L2 { get; set; }
            [DataMember]
            public string Street_L2 { get; set; }
            [DataMember]
            public string District_L2 { get; set; }
            [DataMember]
            public string CompanyName_L2 { get; set; }
            [DataMember]
            public string GovernorateID { get; set; }
            [DataMember]
            public string Governorate { get; set; }
            [DataMember]
            public string Governorate_L2 { get; set; }
            [DataMember]
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string ShortAddress { get; set; }
            //[DataMember]
            //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            //public string LandUse_A { get; set; }      
            //[DataMember]
            //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            //public string LandUse_E { get; set; }      
            //[DataMember]
            //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            //public string LandType_A { get; set; }      
            //[DataMember]
            //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            //public string LandType_E { get; set; }      
        }

        public class SolrAddressCRM
        {
            [DataMember]
            public string id { get; set; }
            [DataMember]
            public string[] CustomerId { get; set; }
            [DataMember]
            public string CustomerNameinAR { get; set; }
            [DataMember]
            public string[] IsMain { get; set; }
            [DataMember]
            public string[] ServiceNo { get; set; }
            [DataMember]
            public string[] Status { get; set; }
            [DataMember]
            public string[] alixis_StartDate { get; set; }
            [DataMember]
            public string[] SubscriptionEndDate { get; set; }
            [DataMember]
            public string SubscriptionTypeNameAr { get; set; }
            [DataMember]
            public string[] SubscriptionTypeNameEn { get; set; }
            [DataMember]
            public string CityNameAR { get; set; }
            [DataMember]
            public string[] CityNameEN { get; set; }
            [DataMember]
            public string[] Direction { get; set; }
            [DataMember]
            public string DistrictAreaAR { get; set; }
            [DataMember]
            public string[] DistrictAreaEN { get; set; }
            //[DataMember]
            //public string EmirateArabicName { get; set; }
            //[DataMember]
            //public string[] EmirateEnglishName { get; set; }
            //[DataMember]
            //public string[] Flag { get; set; }
            [DataMember]
            public string[] FloorNumber { get; set; }
            [DataMember]
            public string[] UnitNo { get; set; }
            [DataMember]
            public string[] UnitTypeID { get; set; }
            //[DataMember]
            //public string LandTypearabicDesc { get; set; }
            //[DataMember]
            //public string[] LandTypeenglishDesc { get; set; }
            //[DataMember]
            //public string LandUsearabicDesc { get; set; }
            //[DataMember]
            //public string[] LandUseenglishDesc { get; set; }
            //[DataMember]
            //public string[] NumberOfUnits { get; set; }
            //[DataMember]
            //public string[] Plate { get; set; }
            //[DataMember]
            //public string[] Restriction { get; set; }
            [DataMember]
            public string StreetNameAR { get; set; }
            [DataMember]
            public string[] StreetNameEN { get; set; }
            [DataMember]
            public string[] Latitude { get; set; }
            [DataMember]
            public string[] Longitude { get; set; }
            [DataMember]
            public string[] IsDefaultAddress { get; set; }
            [DataMember]
            public string[] AdditionalNumber { get; set; }
            [DataMember]
            public string[] BuildingNo { get; set; }
            [DataMember]
            public string[] CityId { get; set; }
            [DataMember]
            public string[] GISCityID { get; set; }
            [DataMember]
            public string[] GISRegionId { get; set; }
            [DataMember]
            public string ShortAddress { get; set; }
            [DataMember]
            public string RegionNameAR { get; set; }
            [DataMember]
            public string[] RegionNameEN { get; set; }
            [DataMember]
            public string[] RegionId { get; set; }
            [DataMember]
            public string[] ZipCode { get; set; }
            [DataMember]
            public string[] NAUpdateRequestDateTime { get; set; }

            [DataMember]
            public string[] Old_BuildingNo { get; set; }
            [DataMember]
            public string[] old_AdditionalNumber { get; set; }
            [DataMember]
            public string[] old_ZipCode { get; set; }
            [DataMember]
            public string[] old_UnitNo { get; set; }
            [DataMember]
            public string[] old_UnitTypeID { get; set; }
            [DataMember]
            public string[] old_FlatNumber { get; set; }
            [DataMember]
            public string Old_StreetNameAR { get; set; }
            [DataMember]
            public string[] Old_StreetNameEN { get; set; }
            [DataMember]
            public string old_DistrictAreaAR { get; set; }
            [DataMember]
            public string[] old_DistrictAreaEN { get; set; }
            [DataMember]
            public string[] old_Latitude { get; set; }
            [DataMember]
            public string[] old_Longitude { get; set; }
            [DataMember]
            public string old_CityNameAR { get; set; }
            [DataMember]
            public string[] old_CityNameEN { get; set; }
            [DataMember]
            public string[] old_CityId { get; set; }
            [DataMember]
            public string[] old_GISCityID { get; set; }
            [DataMember]
            public string old_RegionNameAR { get; set; }
            [DataMember]
            public string[] old_RegionNameEN { get; set; }
            [DataMember]
            public string[] old_RegionId { get; set; }
            [DataMember]
            public string[] old_GISRegionId { get; set; }

        }

        public class SolrOptions
        {
            public string BaseAddress { get; set; }
            public string Core { get; set; }
            public string Url => BaseAddress + Core;
        }

    }
}
