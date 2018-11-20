using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Underprepaired.Models.Interfaces
{
    interface ICart
    {


        Task<CartItem> GetAllCartItems(int id);

        Task GetCart(int id);


    }
}
