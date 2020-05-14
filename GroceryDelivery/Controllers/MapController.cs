using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GroceryDelivery.Controllers
{
    public class MapController : Controller
    {
        private string GoogleGeocodeAPIKey = "AIzaSyAz1BRGW3DxpKbmSKAXe5hMKici_1VUvAQ";
        // GET: Map
        public ActionResult Index()
        {
            return View();
        }

        public string getRequestUrl(string address)
        {
            address.Replace(" ", "%20");
            string url = "https://maps.google.com/maps/api/geocode/xml?address="+address+"&sensor=false&key=" + GoogleGeocodeAPIKey;
            return url;
        }
        public DataTable GetdtLatLongStreet(string url)
        {
            DataTable dtGMap = null;
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using(StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);
                    DataTable dtCoordinates = new DataTable();
                    dtCoordinates.Columns.AddRange(new DataColumn[4] {
                        new DataColumn("ID",typeof(int)),
                        new DataColumn("Adress",typeof(string)),
                        new DataColumn("Latitude",typeof(string)),
                        new DataColumn("Longtitude",typeof(string))});
                    try
                    {
                        foreach (DataRow row in dsResult.Tables["result"].Rows)
                        {
                            string geometry_id = dsResult.Tables["geometry"].Select("result_id = " + row["result_id"].ToString())[0]["geometry_id"].ToString();

                            DataRow location = dsResult.Tables["location"].Select("geometry_id = " + geometry_id)[0];

                            dtCoordinates.Rows.Add(row["result_id"], row["formatted_address"], location["lat"], location["lng"]);
                        }
                    }
                    catch(NullReferenceException e)
                    {
                        dtCoordinates.Rows.Add(1, "Zielona Gura", "51.9356691", "15.505642");
                    }
                    
                    dtGMap = dtCoordinates;
                    return dtGMap;
                }
                
            }
        }
    }
}