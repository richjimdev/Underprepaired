using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Underprepaired.Models.Interfaces;

namespace Underprepaired.Controllers
{
    public class CartController : Controller
    {
        private ICart _cart;

        public CartController(ICart cart)
        {
            _cart = cart;
        }

        public IActionResult Index()
        {
            return View();
        }


        //Task<Cart> GetCart(int id);

        //Task<List<CartItem>> GetAllCartItems(Cart cart);

        //Task AddToCart(CartItem ci);

        //Task RemoveFromCart(int cartId, int productId);

        //Task UpdateQuantity(CartItem ci);
    }
}
