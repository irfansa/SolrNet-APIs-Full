using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static SolrNetCoreAPIs.Misc;

namespace SolrNetCoreAPIs
{
    public class RegisteredCustomerSearchWS
    {

        public List<Address> Solr_IqamaNumber(List<SolrAddressCRM> lstSolrAddresses, String pid, string lang)
        {
            DataSet crmidds = new DataSet();
            //SqlCommand cmd = new SqlCommand();

            int CRMDataUpdHours = 0;
            CRMDataUpdHours = 0;// int.Parse(System.Configuration.ConfigurationManager.AppSettings["CRMData_UpdHours"].ToString());


            AddressOutPutParams returnObj = new AddressOutPutParams();

            List<SolrAddressCRM> lsCRM = new List<SolrAddressCRM>();

            try
            {

                returnObj.Addresses = new List<Address>();

                //loop through Solr records.
                foreach (SolrAddressCRM dr in lstSolrAddresses)
                {
                    Address additm = new Address();

                    //get the last update hours from config.
                    bool AddressOld = false;
                    if (dr.NAUpdateRequestDateTime != null)
                    {
                        double totalHours = ((DateTime.Now) - Convert.ToDateTime(dr.NAUpdateRequestDateTime[0].ToString())).TotalHours;
                        if (!double.IsNaN(totalHours) && totalHours < CRMDataUpdHours)
                        {
                            AddressOld = true;
                        }
                    }

                    if (lang.ToLower() == "e")
                    {
                        additm.Address1 = (AddressOld ? (dr.Old_BuildingNo != null ? dr.Old_BuildingNo[0].ToString() : null) : (dr.BuildingNo != null ? dr.BuildingNo[0].ToString() : null)) + " " +
                          (AddressOld ? (dr.Old_StreetNameEN != null ? dr.Old_StreetNameEN[0] : null) : (dr.StreetNameEN != null ? dr.StreetNameEN[0] : null)) + " - " +
                          (AddressOld ? (dr.old_DistrictAreaEN != null ? dr.old_DistrictAreaEN[0] : null) : (dr.DistrictAreaEN != null ? dr.DistrictAreaEN[0] : null));
                        additm.Address2 = (AddressOld ? (dr.old_CityNameEN != null ? dr.old_CityNameEN[0].ToString() : null) : (dr.CityNameEN != null ? dr.CityNameEN[0].ToString() : null)) + " " +
                            (AddressOld ? (dr.old_ZipCode != null ? dr.old_ZipCode[0].ToString() : null) : (dr.ZipCode != null ? dr.ZipCode[0].ToString() : null)) + " - " +
                            (AddressOld ? (dr.old_AdditionalNumber != null ? dr.old_AdditionalNumber[0].ToString() : null) : (dr.AdditionalNumber != null ? dr.AdditionalNumber[0].ToString() : null));
                        additm.District = (AddressOld ? (dr.old_DistrictAreaEN != null ? dr.old_DistrictAreaEN[0].ToString() : null) : (dr.DistrictAreaEN != null ? dr.DistrictAreaEN[0].ToString() : null));
                        additm.City = (AddressOld ? (dr.old_CityNameEN != null ? dr.old_CityNameEN[0].ToString() : null) : (dr.CityNameEN != null ? dr.CityNameEN[0].ToString() : null));
                        additm.Street = (AddressOld ? (dr.Old_StreetNameEN != null ? dr.Old_StreetNameEN[0].ToString() : null) : (dr.StreetNameEN != null ? dr.StreetNameEN[0].ToString() : null));
                        additm.RegionName = (AddressOld ? (dr.old_RegionNameEN != null ? dr.old_RegionNameEN[0].ToString() : null) : (dr.RegionNameEN != null ? dr.RegionNameEN[0].ToString() : null));
                        additm.RegionName_L2 = (AddressOld ? (dr.old_RegionNameAR != null ? dr.old_RegionNameAR.ToString() : null) : (dr.RegionNameAR != null ? dr.RegionNameAR.ToString() : null));
                        additm.City_L2 = (AddressOld ? (dr.old_CityNameAR != null ? dr.old_CityNameAR.ToString() : null) : (dr.CityNameAR != null ? dr.CityNameAR.ToString() : null));
                        additm.Street_L2 = (AddressOld ? (dr.Old_StreetNameAR != null ? dr.Old_StreetNameAR.ToString() : null) : (dr.StreetNameAR != null ? dr.StreetNameAR.ToString() : null));
                        additm.District_L2 = (AddressOld ? (dr.old_DistrictAreaAR != null ? dr.old_DistrictAreaAR.ToString() : null) : (dr.DistrictAreaAR != null ? dr.DistrictAreaAR.ToString() : null));
                    }
                    else
                    {
                        additm.Address1 = (AddressOld ? (dr.Old_BuildingNo != null ? dr.Old_BuildingNo[0].ToString() : null) : (dr.BuildingNo != null ? dr.BuildingNo[0].ToString() : null)) + " " +
                            (AddressOld ? (dr.Old_StreetNameAR != null ? dr.Old_StreetNameAR : null) : (dr.StreetNameAR != null ? dr.StreetNameAR : null)) + " - " +
                            (AddressOld ? (dr.old_DistrictAreaAR != null ? dr.old_DistrictAreaAR : null) : (dr.DistrictAreaAR != null ? dr.DistrictAreaAR : null));
                        additm.Address2 = (AddressOld ? (dr.old_CityNameAR != null ? dr.old_CityNameAR.ToString() : null) : (dr.CityNameAR != null ? dr.CityNameAR.ToString() : null)) + " " +
                           (AddressOld ? (dr.old_ZipCode != null ? dr.old_ZipCode[0].ToString() : null) : (dr.ZipCode != null ? dr.ZipCode[0].ToString() : null)) + " - " +
                           (AddressOld ? (dr.old_AdditionalNumber != null ? dr.old_AdditionalNumber[0].ToString() : null) : (dr.AdditionalNumber != null ? dr.AdditionalNumber[0].ToString() : null));
                        additm.District = (AddressOld ? (dr.old_DistrictAreaAR != null ? dr.old_DistrictAreaAR.ToString() : null) : (dr.DistrictAreaAR != null ? dr.DistrictAreaAR.ToString() : null));
                        additm.City = (AddressOld ? (dr.old_CityNameAR != null ? dr.old_CityNameAR.ToString() : null) : (dr.CityNameAR != null ? dr.CityNameAR.ToString() : null));
                        additm.Street = (AddressOld ? (dr.Old_StreetNameAR != null ? dr.Old_StreetNameAR.ToString() : null) : (dr.StreetNameAR != null ? dr.StreetNameAR.ToString() : null));
                        additm.RegionName = (AddressOld ? (dr.old_RegionNameAR != null ? dr.old_RegionNameAR.ToString() : null) : (dr.RegionNameAR != null ? dr.RegionNameAR.ToString() : null));
                        additm.RegionName_L2 = (AddressOld ? (dr.old_RegionNameEN != null ? dr.old_RegionNameEN[0].ToString() : null) : (dr.RegionNameEN != null ? dr.RegionNameEN[0].ToString() : null));
                        additm.City_L2 = (AddressOld ? (dr.old_CityNameEN != null ? dr.old_CityNameEN[0].ToString() : null) : (dr.CityNameEN != null ? dr.CityNameEN[0].ToString() : null));
                        additm.Street_L2 = (AddressOld ? (dr.Old_StreetNameEN != null ? dr.Old_StreetNameEN[0].ToString() : null) : (dr.StreetNameEN != null ? dr.StreetNameEN[0].ToString() : null));
                        additm.District_L2 = (AddressOld ? (dr.old_DistrictAreaEN != null ? dr.old_DistrictAreaEN[0].ToString() : null) : (dr.DistrictAreaEN != null ? dr.DistrictAreaEN[0].ToString() : null));
                    }
                    additm.ObjLatLng = (AddressOld ? (dr.old_Longitude != null ? dr.old_Longitude[0].ToString() : null) : (dr.Longitude != null ? dr.Longitude[0].ToString() : null)) + " " +
                                        (AddressOld ? (dr.old_Latitude != null ? dr.old_Latitude[0].ToString() : null) : (dr.Latitude != null ? dr.Latitude[0].ToString() : null));
                    additm.BuildingNumber = (AddressOld ? (dr.Old_BuildingNo != null ? dr.Old_BuildingNo[0].ToString() : null) : (dr.BuildingNo != null ? dr.BuildingNo[0].ToString() : null));
                    additm.PostCode = (AddressOld ? (dr.old_ZipCode != null ? dr.old_ZipCode[0].ToString() : null) : (dr.ZipCode != null ? dr.ZipCode[0].ToString() : null));
                    additm.AdditionalNumber = (AddressOld ? (dr.old_AdditionalNumber != null ? dr.old_AdditionalNumber[0].ToString() : null) : (dr.AdditionalNumber != null ? dr.AdditionalNumber[0].ToString() : null));
                    additm.IsPrimaryAddress = (dr.IsDefaultAddress != null ? dr.IsDefaultAddress[0].ToString() : null);
                    additm.UnitNumber = (AddressOld ? (dr.old_UnitNo != null ? dr.old_UnitNo[0].ToString() : null) : (dr.UnitNo != null ? dr.UnitNo[0].ToString() : null));
                    additm.Latitude = (AddressOld ? (dr.old_Latitude != null ? dr.old_Latitude[0].ToString() : null) : (dr.Latitude != null ? dr.Latitude[0].ToString() : null));
                    additm.Longitude = (AddressOld ? (dr.old_Longitude != null ? dr.old_Longitude[0].ToString() : null) : (dr.Longitude != null ? dr.Longitude[0].ToString() : null));
                    additm.CityId = (AddressOld ? (dr.old_GISCityID != null ? dr.old_GISCityID[0].ToString() : null) : (dr.GISCityID != null ? dr.GISCityID[0].ToString() : null));
                    additm.RegionId = (AddressOld ? (dr.old_GISRegionId != null ? dr.old_GISRegionId[0].ToString() : null) : (dr.GISRegionId != null ? dr.GISRegionId[0].ToString() : null));
                    additm.Restriction = "";
                    additm.PKAddressID = (AddressOld ? (dr.old_ZipCode != null ? dr.old_ZipCode[0].ToString() : null) : (dr.ZipCode != null ? dr.ZipCode[0].ToString() : null)) +
                                           (AddressOld ? (dr.Old_BuildingNo != null ? dr.Old_BuildingNo[0].ToString() : null) : (dr.BuildingNo != null ? dr.BuildingNo[0].ToString() : null)) +
                                             (AddressOld ? (dr.old_AdditionalNumber != null ? dr.old_AdditionalNumber[0].ToString() : null) : (dr.AdditionalNumber != null ? dr.AdditionalNumber[0].ToString() : null));
                    additm.DistrictID = "";
                    additm.GovernorateID = "";
                    additm.Governorate = "";
                    additm.Governorate_L2 = "";

                    returnObj.Addresses.Add(additm);
                }

                returnObj.PostCode = null;
            }
            catch (Exception e)
            {
                returnObj.success = false;
                returnObj.fullexception = "";
                returnObj.statusdescription = e.Message;
                return returnObj.Addresses;
            }

            return returnObj.Addresses;
        }
    }
}
