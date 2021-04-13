using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using JafEcomRCL;
using JafEcomRCL.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JafEcommerce.Pages
{
    public class successModel : PageModel
    {
        [BindProperty]
         public string Result { get; set; }


        private JafEcomRCLDbContext _JafEcomRCLDbContext;
        public  successModel(JafEcomRCLDbContext JafEcomRCLDbContext)
        {
            _JafEcomRCLDbContext = JafEcomRCLDbContext;
        }
        public void OnGet()
        {

            string Status = string.Empty;
            SSLCommerz.vmPaymentPostback result = null;
            try
            {
                result = GetResponseData();
                if (result != null)
                {
                    SavePayment(result);
                    Status = "Payment Done!";
                }
                else
                {
                    Status = "Payment Fails!";
                }
            }
            catch (Exception)
            {
                Status = "";
            }


            Result = "success";
        }

       
        public SSLCommerz.vmPaymentPostback GetResponseData()
        {
            SSLCommerz.vmPaymentPostback objrspParam = null;
            string[] keys = null;  // Request.Form.All();
            var key = keys[1]; //1 = val_id
            var valId = Request.Form[keys[1]]; //1 = val_id
            var storeID = "YourstoreID"; //Replace with LiveID Or your Sandbox StoreId
            var storePass = "YourstorePass@ssl"; //Replace with LivePassword Or your Sandbox StorePass

            var validateurl = "https://sandbox.sslcommerz.com/validator/api/validationserverAPI.php?val_id=" + valId + "&Store_Id=" + storeID + "&Store_Passwd=" + storePass + "&v=3&format=json"; //Replace with LiveValidURL
            try
            {
                //request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(validateurl);
                request.Method = "GET";

                //response
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                objrspParam = JsonConvert.DeserializeObject<SSLCommerz.vmPaymentPostback>(reader.ReadToEnd().ToString());
            }
            catch (Exception)
            {
            }
            return objrspParam;
        }

        public int SavePayment(SSLCommerz.vmPaymentPostback _Payment)
        {
            int status = 0;
            try
            {
                PaymentLog objPay = new PaymentLog
                {
                    tran_id = _Payment.tran_id,
                    tran_date = Convert.ToDateTime(_Payment.tran_date),
                    status = _Payment.status,
                    val_id = _Payment.status,
                    amount = _Payment.amount,
                    store_amount = _Payment.store_amount,
                    currency = _Payment.currency,
                    bank_tran_id = _Payment.bank_tran_id,
                    card_type = _Payment.card_type,
                    card_no = _Payment.card_no,
                    card_issuer = _Payment.card_issuer,
                    card_brand = _Payment.card_brand,
                    card_issuer_country = _Payment.card_issuer_country,
                    card_issuer_country_code = _Payment.card_issuer_country_code,
                    currency_type = _Payment.currency_type,
                    currency_amount = _Payment.currency_amount,
                    currency_rate = _Payment.currency_rate,
                    base_fair = _Payment.base_fair,
                    value_a = _Payment.value_a,
                    value_b = _Payment.value_b,
                    value_c = _Payment.value_c,
                    risk_title = _Payment.risk_title,
                    risk_level = _Payment.risk_level,
                    APIConnect = _Payment.APIConnect,
                    validated_on = _Payment.validated_on,
                    gw_version = _Payment.gw_version,
                };
                _JafEcomRCLDbContext.PaymentLog.Add(objPay);
                _JafEcomRCLDbContext.SaveChanges();
                status = 1;

            }
            catch
            {
                status = 0;
            }
            return status;
        }
    }
}
