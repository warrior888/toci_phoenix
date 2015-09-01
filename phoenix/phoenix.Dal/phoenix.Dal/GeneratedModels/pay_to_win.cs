using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace UnitTestProject.res
{
    public class pay_to_win : Model
    {
        public pay_to_win() : base("pay_to_win")
        {
        }
         
        public const string ID = "id";
        public int Id
            {
                get
                {
                     return GetValue<int>(ID);
                }
                set
                {
                    SetValue(ID, value);
                }
            }
         
        public const string TRANSFER_CASH_AMOUNT = "transfer_cash_amount";
        public decimal TransferCashAmount
            {
                get
                {
                     return GetValue<decimal>(TRANSFER_CASH_AMOUNT);
                }
                set
                {
                    SetValue(TRANSFER_CASH_AMOUNT, value);
                }
            }
         
        public const string TRANSFER_TIME = "transfer_time";
        public DateTime TransferTime
            {
                get
                {
                     return GetValue<DateTime>(TRANSFER_TIME);
                }
                set
                {
                    SetValue(TRANSFER_TIME, value);
                }
            }
         
        public const string ID_USERS = "id_users";
        public int IdUsers
            {
                get
                {
                     return GetValue<int>(ID_USERS);
                }
                set
                {
                    SetValue(ID_USERS, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new pay_to_win();
        }
    }
}
