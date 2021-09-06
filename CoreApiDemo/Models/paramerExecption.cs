using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Models
{
    public class paramerExecption : Exception
    {

        public string comp_code { get; set; }
        public string user_id { get; set; }
        public string customer_id { get; set; }


        public paramerExecption(string comp_code, string user_id, string customer_id)
        {
            this.comp_code = comp_code;
            this.user_id = user_id;
            this.customer_id = customer_id;
        }

        public override string Message
        {
            get
            {
                if (this.comp_code == "")
                {
                    return "請輸入comp_code";
                }
                if (this.user_id == "")
                {
                    return "請輸入user_id";
                }
                if (this.customer_id == "")
                {
                    return "請輸入customer_id";
                }
                return base.Message;
            }
        }
    }
}
