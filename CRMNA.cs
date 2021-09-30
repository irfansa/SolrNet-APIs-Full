using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolrNet.Attributes;

namespace SolrNetCoreAPIs
{
    public class CRMNA
    {
        [SolrField("id")]
        public string id { get; set; }
        [SolrField("CustomerId")]
        public ICollection<string> CustomerId { get; set; }
        [SolrField("CustomerNameinAR")]
        public string CustomerNameinAR { get; set; }
        [SolrField("CustomerCategoryCode")]
        public ICollection<string> CustomerCategoryCode { get; set; }
        [SolrField("Customertypecode")]
        public ICollection<string> Customertypecode { get; set; }

        [SolrField("CustomerTypeName")]
        public string CustomerTypeName { get; set; }
        [SolrField("CustomerCategoryName")]
        public string CustomerCategoryName { get; set; }
        [SolrField("NationalityNameAr")]
        public string NationalityNameAr { get; set; }
        [SolrField("HijriBirthDate")]
        public ICollection<string> HijriBirthDate { get; set; }

        [SolrField("Laboroffice")]
        public ICollection<string> Laboroffice { get; set; }
        [SolrField("Sequencenumber")]
        public ICollection<string> Sequencenumber { get; set; }

        [SolrField("SevenHunderdNo")]
        public ICollection<string> SevenHunderdNo { get; set; }
        [SolrField("PermitDateHijri")]
        public ICollection<string> PermitDateHijri { get; set; }

        [SolrField("PermitExpDateHijri")]
        public ICollection<string> PermitExpDateHijri { get; set; }
        [SolrField("MobileNumber")]
        public ICollection<string> MobileNumber { get; set; }
        [SolrField("Email")]
        public ICollection<string> Email { get; set; }
        [SolrField("IsMain")]
        public ICollection<string> IsMain { get; set; }

        [SolrField("PID")]
        public ICollection<string> PID { get; set; }
        [SolrField("CID")]
        public ICollection<string> CID { get; set; }

        [SolrField("PIDIssuanceDate")]
        public ICollection<string> PIDIssuanceDate { get; set; }
        [SolrField("ServiceNo")]
        public ICollection<string> ServiceNo { get; set; }
        [SolrField("Status")]
        public ICollection<string> Status { get; set; }
        [SolrField("alixis_StartDate")]
        public ICollection<string> alixis_StartDate { get; set; }
        [SolrField("SubscriptionEndDate")]
        public ICollection<string> SubscriptionEndDate { get; set; }
        [SolrField("SubscriptionTypeNameAr")]
        public string SubscriptionTypeNameAr { get; set; }
        [SolrField("SubscriptionTypeNameEn")]
        public ICollection<string> SubscriptionTypeNameEn { get; set; }
        [SolrField("BuildingNo")]
        public ICollection<string> BuildingNo { get; set; }
        [SolrField("AdditionalNumber")]
        public ICollection<string> AdditionalNumber { get; set; }

        [SolrField("ZipCode")]
        public ICollection<string> ZipCode { get; set; }
        [SolrField("UnitNo")]
        public ICollection<string> UnitNo { get; set; }
        [SolrField("UnitTypeID")]
        public ICollection<string> UnitTypeID { get; set; }
        [SolrField("FloorNumber")]
        public ICollection<string> FloorNumber { get; set; }
        [SolrField("StreetNameAR")]
        public string StreetNameAR { get; set; }
        [SolrField("StreetNameEN")]
        public ICollection<string> StreetNameEN { get; set; }

        [SolrField("DistrictAreaAR")]
        public string DistrictAreaAR { get; set; }
        [SolrField("DistrictAreaEN")]
        public ICollection<string> DistrictAreaEN { get; set; }

        [SolrField("Latitude")]
        public ICollection<string> Latitude { get; set; }
        [SolrField("Longitude")]
        public ICollection<string> Longitude { get; set; }
        [SolrField("IsDefaultAddress")]
        public ICollection<string> IsDefaultAddress { get; set; }
        [SolrField("CityNameAR")]
        public string CityNameAR { get; set; }

        [SolrField("CityId")]
        public ICollection<string> CityId { get; set; }
        [SolrField("GISCityID")]
        public ICollection<string> GISCityID { get; set; }
        [SolrField("CityNameEN")]
        public ICollection<string> CityNameEN { get; set; }
        [SolrField("RegionNameAR")]
        public string RegionNameAR { get; set; }
        [SolrField("RegionNameEN")]
        public ICollection<string> RegionNameEN { get; set; }
        [SolrField("RegionId")]
        public ICollection<string> RegionId { get; set; }
        [SolrField("GISRegionId")]
        public ICollection<string> GISRegionId { get; set; }

        [SolrField("NAUpdateRequestDateTime")]
        public ICollection<string> NAUpdateRequestDateTime { get; set; }
        [SolrField("Old_BuildingNo")]
        public ICollection<string> Old_BuildingNo { get; set; }

        [SolrField("old_AdditionalNumber")]
        public ICollection<string> old_AdditionalNumber { get; set; }
        [SolrField("old_ZipCode")]
        public ICollection<string> old_ZipCode { get; set; }
        [SolrField("old_UnitNo")]
        public ICollection<string> old_UnitNo { get; set; }
        [SolrField("old_UnitTypeID")]
        public ICollection<string> old_UnitTypeID { get; set; }
        [SolrField("old_FlatNumber")]
        public ICollection<string> old_FlatNumber { get; set; }
        [SolrField("Old_StreetNameAR")]
        public string Old_StreetNameAR { get; set; }
        [SolrField("Old_StreetNameEN")]
        public ICollection<string> Old_StreetNameEN { get; set; }

        [SolrField("old_DistrictAreaAR")]
        public string old_DistrictAreaAR { get; set; }
        [SolrField("old_DistrictAreaEN")]
        public ICollection<string> old_DistrictAreaEN { get; set; }
        [SolrField("old_Latitude")]
        public ICollection<string> old_Latitude { get; set; }
        [SolrField("old_Longitude")]
        public ICollection<string> old_Longitude { get; set; }
        [SolrField("old_CityNameAR")]
        public string old_CityNameAR { get; set; }
        [SolrField("old_CityNameEN")]
        public ICollection<string> old_CityNameEN { get; set; }

        [SolrField("old_CityId")]
        public ICollection<string> old_CityId { get; set; }
        [SolrField("old_GISCityID")]
        public ICollection<string> old_GISCityID { get; set; }
        [SolrField("old_RegionNameAR")]
        public string old_RegionNameAR { get; set; }
        [SolrField("old_RegionNameEN")]
        public ICollection<string> old_RegionNameEN { get; set; }
        [SolrField("old_RegionId")]
        public ICollection<string> old_RegionId { get; set; }
        [SolrField("old_GISRegionId")]
        public ICollection<string> old_GISRegionId { get; set; }

        [SolrField("SubscriptionStatus")]
        public string SubscriptionStatus { get; set; }
        [SolrField("ModifiedOn")]
        public ICollection<string> ModifiedOn { get; set; }



    }

}
