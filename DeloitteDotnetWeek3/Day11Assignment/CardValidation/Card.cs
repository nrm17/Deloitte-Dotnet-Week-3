using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardValidation
{
    public class Card : ICard
    {
        StudentDBEntities db = new StudentDBEntities();
        public bool Authenticate(int cardno, string cvv)
        {
            var data = db.CardInfoes.Where(x => x.Card_No == cardno && x.cvvno == cvv).SingleOrDefault();

            if (data == null)
                throw new ArgumentException("Invalid CardNo/CVV");
            else
                return true;

        }

        public bool DateCheck(int cardno, DateTime dt)
        {

            var data = db.CardInfoes.Where(x => x.Card_No == cardno && x.expdate > DateTime.Now).SingleOrDefault();

            if (data == null)
                throw new ArgumentException("Card has expired, Please contact your bank");
            else
                return true;
        }

        public decimal Trans(int cardno, decimal amt)
        {
            var data = db.CardInfoes.Where(x => x.Card_No == cardno && x.balance > amt).SingleOrDefault();

            if (data == null)
                throw new ArgumentException("Balance is low");
            else
                data.balance -= amt;
            return data.balance;
        }
    }
}
