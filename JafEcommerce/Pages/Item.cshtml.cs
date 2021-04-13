using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using JafEcomRCL;
using JafEcomRCL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace JafEcommerce.Pages
{
    public class ItemModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string ProductName { get; set; }

        [BindProperty]
        public decimal ProductAmount { get; set; }
        private JafEcomRCL.Model.Item itemSer { get; set; }

        private ItemService _ItemService;
        public ItemModel(ItemService ItemService)
        {
            _ItemService = ItemService;
        }
        public void OnGet()
        {
            
            itemSer =  _ItemService.getItem();

            Id = itemSer.Id;
            ProductName = itemSer.ProductName;

        }

        public void OnPost()
        {

            itemSer = _ItemService.getItem();

            Id = itemSer.Id;
            ProductName = itemSer.ProductName;


            var baseUrl = string.Concat(
                    Request.Scheme,
                    "://",
                    Request.Host.ToUriComponent(),
                    Request.PathBase.ToUriComponent()
                    //,Request.Path.ToUriComponent(),
                    //Request.QueryString.ToUriComponent()
                    );
            System.Collections.Specialized.NameValueCollection PostData = new NameValueCollection();
            PostData.Add("total_amount", ProductAmount.ToString());
            PostData.Add("tran_id", "TESTASPNETCORE1234"+Id.ToString());
            PostData.Add("success_url", baseUrl + "success");
            PostData.Add("fail_url", baseUrl + "fail"); // "Fail" page needs to be created
            PostData.Add("cancel_url", baseUrl + "cancel"); // "Cancel" page needs to be created
            PostData.Add("version", "3.00");
            PostData.Add("cus_name", "ABC XY");
            PostData.Add("cus_email", "abc.xyz@mail.co");
            PostData.Add("cus_add1", "Address Line On");
            PostData.Add("cus_add2", "Address Line Tw");
            PostData.Add("cus_city", "City Nam");
            PostData.Add("cus_state", "State Nam");
            PostData.Add("cus_postcode", "Post Cod");
            PostData.Add("cus_country", "Countr");
            PostData.Add("cus_phone", "0841183758");
            PostData.Add("cus_fax", "0841183758");
            PostData.Add("ship_name", "testcogidax1e");
            PostData.Add("ship_add1", "Address Line On");
            PostData.Add("ship_add2", "Address Line Tw");
            PostData.Add("ship_city", "City Nam");
            PostData.Add("ship_state", "State Nam");
            PostData.Add("ship_postcode", "Post Cod");
            PostData.Add("ship_country", "Countr");
            PostData.Add("value_a", "ref00");
            PostData.Add("value_b", "ref00");
            PostData.Add("value_c", "ref00");
            PostData.Add("value_d", "ref00");
            PostData.Add("shipping_method", "NO");
            PostData.Add("num_of_item", "1");
            PostData.Add("product_name", "Demo");
            PostData.Add("product_profile", "general");
            PostData.Add("product_category", "Demo");

            var storeID = "YourstoreID"; //Replace with LiveID Or your Sandbox StoreId
            var storePass = "YourstorePass@ssl"; //Replace with LivePassword Or your Sandbox StorePass
            SSLCommerz sslcz = new SSLCommerz(storeID, storePass, true);
            String response = sslcz.InitiateTransaction(PostData);
            Response.Redirect(response);

        }



    }
}
