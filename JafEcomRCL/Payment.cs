using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JafEcomRCL
{
    public class PaymentLog
    {

        public int PaymentLogID { get; set; }

        public string tran_id { get; set; }

        public Nullable<System.DateTime> tran_date { get; set; }

        public string status { get; set; }

        public string val_id { get; set; }

        public Nullable<decimal> amount { get; set; }

        public Nullable<decimal> store_amount { get; set; }

        public string currency { get; set; }

        public string bank_tran_id { get; set; }

        public string card_type { get; set; }

        public string card_no { get; set; }

        public string card_issuer { get; set; }

        public string card_brand { get; set; }

        public string card_issuer_country { get; set; }

        public string card_issuer_country_code { get; set; }

        public string currency_type { get; set; }

        public Nullable<decimal> currency_amount { get; set; }

        public Nullable<decimal> currency_rate { get; set; }

        public Nullable<decimal> base_fair { get; set; }

        public string value_a { get; set; }

        public string value_b { get; set; }

        public string value_c { get; set; }

        public string risk_title { get; set; }

        public Nullable<int> risk_level { get; set; }

        public string APIConnect { get; set; }

        public string validated_on { get; set; }

        public string gw_version { get; set; }



    }
}
