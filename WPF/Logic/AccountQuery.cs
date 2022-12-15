using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models;

namespace WPF.Logic
{
     class AccountQuery
    {
        public List<Models.Account> GetAllAccount(int id)
         {
            using (var context = new TestWPFContext())
            {
                if (id == 0)
                    return context.Accounts.ToList();
                else
                    return context.Accounts.Where(x => x.Id == id).ToList();
            }
        }
       
    }
}
