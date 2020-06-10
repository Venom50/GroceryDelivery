using GroceryDelivery.Models;
using GroceryDelivery.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GroceryDelivery.Controllers
{
    public class ShopController : Controller
    {
        private ApplicationDbContext _context;
        private double ShopDistance = 10;//Max Distance in Km
        private string GoogleGeocodeAPIKey = "AIzaSyAz1BRGW3DxpKbmSKAXe5hMKici_1VUvAQ";

        public ShopController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Shop
        [HttpGet]
        public ActionResult ShopListView()
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);
            var userAddress = user.City + " " + user.Street + " " + user.HouseNumber;

            DataTable userLocationDT = GetdtLatLongStreet(getRequestUrl(userAddress));
            var userLong = float.Parse(userLocationDT.Rows[0]["Longtitude"].ToString(), CultureInfo.InvariantCulture);
            var userLat = float.Parse(userLocationDT.Rows[0]["Latitude"].ToString(), CultureInfo.InvariantCulture);
            var shops = getNearShops(userLong, userLat, _context.ShopModels.ToList(), ShopDistance);
            return View(shops);
        }
        public string getRequestUrl(string address)
        {
            address.Replace(" ", "%20");
            string url = "https://maps.google.com/maps/api/geocode/xml?address=" + address + "&sensor=false&key=" + GoogleGeocodeAPIKey;
            return url;
        }
        public DataTable GetdtLatLongStreet(string url)
        {
            DataTable dtGMap = null;
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
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
                    catch (NullReferenceException e)
                    {
                        //W razie błedu Api Zwracamy tabele z domyślną lokalizacją.
                        dtCoordinates.Rows.Add(1, "Zielona Góra", "51.9356691", "15.505642");
                    }

                    dtGMap = dtCoordinates;
                    return dtGMap;
                }

            }
        }


        //Calculate Distance Between user location and shop location
        public double GetDistance(float userlat, float userlong, float shoplat, float shoplong)
        {
            var R = 6371; //Earth Radius in Km
            var dLat = toRadians(shoplat - userlat);
            var dLong = toRadians(shoplong - userlong);
            var a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(toRadians(userlat)) * Math.Cos(toRadians(shoplat)) *
                Math.Sin(dLong / 2) * Math.Sin(dLong / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distance = R * c;//Final distance in Km
            return distance;
        }
        public double toRadians(double deg)
        {
            return deg * (Math.PI / 180);
        }
        public List<ShopModel> getNearShops(float userLong, float userlat, List<ShopModel> shops, double maxDistance)
        {
            List<ShopModel> nearShops = new List<ShopModel>();
            foreach (var shop in shops)
            {
                if (GetDistance(userlat, userLong, shop.latidute, shop.longtitude) <= maxDistance)
                {
                    nearShops.Add(shop);
                }
            }
            return nearShops;
        }
        [HttpGet]
        public ActionResult OrderView(int shopId)
        {
            var shop = _context.ShopModels.SingleOrDefault(s => s.Id == shopId);
            List<ProductModel> products = _context.ProductModels.Where(p => p.Shop == shop.ShopType).ToList();
            OrderViewModel model = new OrderViewModel()
            {
                shop = shop,
                products = products
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult OrderView(OrderViewModel viewModel)
        {
            List<double?> pola = new List<double?>();
            ProductModel product;
            
            for(int i = 0;i < viewModel.products.Count(); i++)
            {

                if(viewModel.products[i].Quanity!=null)
                //product = _context.ProductModels.SingleOrDefault(x => x.Id == viewModel.products[i].Id);
                //produktyzviewmoelu.add(product);
                pola.Add(viewModel.products[i].Price * viewModel.products[i].Quanity);
            }
               //ViewModel = Viewmodel(){
               //VMProdukty = produktyzviewmodelu,
               //ilosci = pola};
                //return View("TutajWidokKoncowy", ViewModel);
            return View("SumUp");
        }

        [HttpGet]
        public ActionResult SumUp()
        {
            //tutaj bedzie bal kurwa jego mac
            return View();
        }

        async private void SendMail()
        {


            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("sendnotifiactionemail@gmail.com");
                message.To.Add("dupa@gmail.com");


                message.Subject = "Temat";
                message.Body = "Body";
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("sendnotifiactionemail@gmail.com", "H4$l00!qAz");
                client.Send(message);
                message = null;


            }

            catch (Exception ex)
            {

            }
        }
    }
}