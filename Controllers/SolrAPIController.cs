using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolrNet;
using SolrNet.Commands.Parameters;
using CommonServiceLocator;
using Newtonsoft.Json;
using static SolrNetCoreAPIs.Misc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SolrNetCoreAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolrAPIController : ControllerBase
    {

        public readonly ISolrOperations<CRMNA> _SolrOpn;
        public SolrAPIController(IConfiguration configuration, IHostingEnvironment hostingEnvironment, ISolrOperations<CRMNA> solrOperations, IHttpContextAccessor httpContextAccessor = null)
        {
            _SolrOpn = solrOperations;
        }


        // GET: api/SolrAPI
        [HttpGet]
        public async Task<ActionResult<object>> GetSolr(string PID)
        {


            //--- 1. Call Solr FreeTextSearch API to get JSON result first


            AddressOutPutParams result = new AddressOutPutParams();
            List<Address> lstAddresses = new List<Address>();
            ISolrIndexService<CRMNA> solrIndexService;
            try
            {
                await Task.Run(() =>
                {
                    ISolrOperations<CRMNA> _solr = _SolrOpn;
                      //ServiceLocator.Current.GetInstance<ISolrOperations<CRMNA>>();

                    QueryOptions queryOptions = new QueryOptions { Start = 0, Rows = 10 };
                    //ApiType api_Type = (ApiType)Enum.Parse(typeof(ApiType), API_Type.ToString(), true);
                    if (!string.IsNullOrWhiteSpace(PID))
                    {
                        var query = "";
                        //if (api_Type == ApiType.SolrDirectSearchByID)
                        //    query += $"+PID:\"{PID}\"^=1.0 ";
                        //else
                        //    query += $"+(CID:\"{PID}\"^=1.0  SevenHunderdNo: \"{PID}\"^=1.0)";

                        //if (api_Type == ApiType.SolrDirectSearchByID)
                        //    query += $"+Customertypecode:\"{1}\"^=1.0 ";
                        //else
                        //    query += $"+Customertypecode:\"{2}\"^=1.0 ";

                        query += $"+Status:\"{1}\"^=1.0 ";
                        if (!string.IsNullOrWhiteSpace(query))
                        {
                            SolrQuery queries = new SolrQuery(query);
                            var solrQueryResults = _solr.Query(queries, queryOptions);
                            
                            string strJsonResult = JsonConvert.SerializeObject(solrQueryResults);

                            List<SolrAddressCRM> lstJsonObjects = JsonConvert.DeserializeObject<List<SolrAddressCRM>>(strJsonResult);


                            RegisteredCustomerSearchWS BindSolrResult = new RegisteredCustomerSearchWS();

                            //List<SolrAddressCRM> sLstAddress = new List<SolrAddressCRM>();

                            //sLstAddress = SolrAddressCRMObject(lstJsonObjects, API_Type, lang);

                            result.Addresses = BindSolrResult.Solr_IqamaNumber(lstJsonObjects, "", "A");

                            //result.Addresses = SolrAddressCRMObject(lstJsonObjects, API_Type, lang);


                            if (result.Addresses.Count == 0)
                            {
                                result.success = false;
                                result.totalSearchResults = "0";
                                result.statusdescription = "Subscription not found";
                            }
                            else
                            {
                                result.success = true;
                                result.statusdescription = "SUCCESS";
                                result.totalSearchResults = result.Addresses.Count.ToString();
                            }

                        }
                        else
                        {

                            result.statusdescription = "An error has occured.";
                            result.totalSearchResults = "0";
                            result.success = false;

                        }

                    }
                    else
                    {
                        var solrQueryResults = "";


                        string strJsonResult = JsonConvert.SerializeObject(solrQueryResults);

                        List<SolrAddressCRM> lstJsonObjects = JsonConvert.DeserializeObject<List<SolrAddressCRM>>(strJsonResult);

                        result.Addresses = SolrAddressCRMObject(lstJsonObjects, 0, "A");

                        if (PID == "")
                            result.statusdescription = "An error has occured.";
                        else
                            result.statusdescription = "Please define mandatory parameters.";

                        result.totalSearchResults = "0";
                        result.success = false;
                    }
                });
            }
            catch (Exception e)
            {
                result.totalSearchResults = "0";
                result.statusdescription = "An error has occured";
                result.success = false;
            }


            return result;
        }



        public List<Address> SolrAddressCRMObject(List<SolrAddressCRM> lstSolrAddresses, int apitype, string lang)
        {
            List<Address> lstAddresses = new List<Address>();

            //language languageParam = (language)Enum.Parse(typeof(language), lang, true);
            //ApiType api_Type = (ApiType)Enum.Parse(typeof(ApiType), apitype.ToString(), true);

            if (lstSolrAddresses != null)
            {
                //if (api_Type == ApiType.SolrDirectSearchByID || api_Type == ApiType.SolrDirectSearchByCID)
                //{
                    foreach (var item in lstSolrAddresses)
                    {
                        //Address obj = JsonConvert.DeserializeObject<Address>(item.ToString());
                        Address obj = new Address();
                        obj.AdditionalNumber = (item.AdditionalNumber != null && item.AdditionalNumber.Length > 0) ? item.AdditionalNumber[0] : "";
                        obj.BuildingNumber = (item.BuildingNo != null && item.BuildingNo.Length > 0) ? item.BuildingNo[0] : "";
                        obj.CityId = (item.CityId != null && item.CityId.Length > 0) ? item.CityId[0] : "";
                        //obj.DistrictID = (item.districtid != null && item.districtid.Length > 0) ? item.districtid[0] : "";
                        obj.PolygonString = null;//(item.geometrystring != null && item.geometrystring.Length > 0) ? item.geometrystring[0] : "";
                        obj.IsPrimaryAddress = null;
                        obj.PostCode = (item.ZipCode != null && item.ZipCode.Length > 0) ? item.ZipCode[0] : "";
                        obj.RegionId = (item.RegionId != null && item.RegionId.Length > 0) ? item.RegionId[0] : "";
                        //obj.Restriction = (item.Restriction != null && item.Restriction.Length > 0) ? item.Restriction[0] : "";
                        obj.PKAddressID = obj.PostCode + obj.BuildingNumber + obj.AdditionalNumber;

                        obj.UnitNumber = null; //(item.NumberOfUnits != null && item.NumberOfUnits.Length > 0) ? item.NumberOfUnits[0] : "";
                        //obj.GovernorateID = item.fkGovernorateID;
                        obj.Governorate = null;
                        obj.Governorate_L2 = null;
                        obj.CompanyName_L2 = null;
                        obj.Title = null;
                        obj.Title_L2 = null;

                        obj.Latitude = (item.Latitude != null && item.Latitude.Length > 0) ? item.Latitude[0] : ""; //(item.Latitude != null) ? item.Latitude : "";
                        obj.Longitude = (item.Longitude != null && item.Longitude.Length > 0) ? item.Longitude[0] : ""; //(item.Longitude != null) ? item.Longitude : "";
                        obj.ObjLatLng = obj.Latitude + " " + obj.Longitude;

                        if (lang == "A")
                        {
                            obj.City = item.CityNameAR;
                            obj.City_L2 = (item.CityNameEN != null && item.CityNameEN.Length > 0) ? item.CityNameEN[0] : "";

                            obj.District = item.DistrictAreaAR;
                            obj.District_L2 = (item.DistrictAreaEN != null && item.DistrictAreaEN.Length > 0) ? item.DistrictAreaEN[0] : "";

                            obj.RegionName = item.RegionNameAR;
                            obj.RegionName_L2 = (item.RegionNameEN != null && item.RegionNameEN.Length > 0) ? item.RegionNameEN[0] : "";

                            obj.Street = item.StreetNameAR;
                            obj.Street_L2 = (item.StreetNameEN != null && item.StreetNameEN.Length > 0) ? item.StreetNameEN[0] : ""; //item.StreetNameEN;

                            //obj.Street = item.StreetNameAR;
                            //obj.Street_L2 = (item.StreetNameEN != null && item.StreetNameEN.Length > 0) ? item.StreetNameEN[0] : ""; //item.StreetNameEN;
                        }
                        else
                        {
                            obj.City_L2 = item.CityNameAR;
                            obj.City = (item.CityNameEN != null && item.CityNameEN.Length > 0) ? item.CityNameEN[0] : "";

                            obj.District_L2 = item.DistrictAreaAR;
                            obj.District = (item.DistrictAreaEN != null && item.DistrictAreaEN.Length > 0) ? item.DistrictAreaEN[0] : "";

                            obj.RegionName_L2 = item.RegionNameAR;
                            obj.RegionName = (item.RegionNameEN != null && item.RegionNameEN.Length > 0) ? item.RegionNameEN[0] : "";

                            obj.Street_L2 = item.StreetNameAR;
                            obj.Street = (item.StreetNameEN != null && item.StreetNameEN.Length > 0) ? item.StreetNameEN[0] : ""; //item.StreetNameEN;

                            //obj.Street_L2 = item.StreetNameAR;
                            //obj.Street = (item.StreetNameEN != null && item.RegionNameEN.Length > 0) ? item.RegionNameEN[0] : ""; //item.StreetNameEN;
                        }

                        obj.Address1 = (obj.BuildingNumber + " " + obj.Street + " - " + obj.District).Trim();
                        obj.Address2 = (obj.City + " " + obj.PostCode + " - " + obj.AdditionalNumber).Trim();
                        obj.ShortAddress = item.ShortAddress;

                        lstAddresses.Add(obj);
                    }

            }
            return lstAddresses;

        }

    }
}
