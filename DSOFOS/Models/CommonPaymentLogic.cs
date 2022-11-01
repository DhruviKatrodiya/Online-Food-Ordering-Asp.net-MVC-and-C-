using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSOFOS.Models
{
    public class CommonPaymentLogic
    {
        private UserMaster objuserMaster;
        private Payment objpayments;

        public CommonPaymentLogic()
        {
            objuserMaster = new UserMaster();
            objpayments = new Payment();
        }
        public void InsertPayment(PaymentUserModel model)
        {
            UserMaster userMaster = model.MyUser;
             //objuserMaster.Insert(userMaster);

            Payment payment = model.MyPayment;
            //objpayments.Insert(payment);

        }
    }
}