using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService
{
    public class Login : ILogin
    {
        public bool Authenticate(int id, string password)
        {
            TrainingDBEntities db = new TrainingDBEntities();
            if (id <= 0)
                throw new ArgumentException("ID cant be negative or zero");
            else if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password cannot be blank");

            else
            {
                var data = db.RegisterShoppings.Where(x => x.Id == id && x.Password == password).SingleOrDefault();

                if (data == null)
                    throw new ArgumentException("Invalid Username/Password");
                else
                    return true;
            }
        }
    }
}
