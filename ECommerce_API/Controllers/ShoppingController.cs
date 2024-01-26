using ECommerce_API.DataAccess;
using ECommerce_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        readonly IDataAccess dataAccess;
        private readonly string DateFormat;
        public ShoppingController(IDataAccess dataAccess, IConfiguration configuration)
        {
            this.dataAccess = dataAccess;
            DateFormat = configuration["Constants:DateFormat"];
        }

        //Register User
        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            user.CreatedAt = DateTime.Now.ToString(DateFormat);
            user.ModifiedAt = DateTime.Now.ToString(DateFormat);

            var result = dataAccess.InsertUser(user);

            string message;
            if (result) message = "inserted";
            else message = "email not available";
            return Ok(message);
        }

        //Login User
        [HttpPost("LoginUser")]
        public IActionResult LoginUser([FromBody] User user)
        {
            var token = dataAccess.IsUserPresent(user.Email, user.Password);
            if (token == "") token = "invalid";
            return Ok(token);
        }

        //Get Active Cart of User
        [HttpGet("GetActiveCartOfUser/{id}")]
        public IActionResult GetActiveCartOfUser(int id)
        {
            var result = dataAccess.GetActiveCartOfUser(id);
            return Ok(result);
        }

        //Get Previous Cart of User
        [HttpGet("GetAllPreviousCartsOfUser/{id}")]
        public IActionResult GetAllPreviousCartsOfUser(int id)
        {
            var result = dataAccess.GetAllPreviousCartsOfUser(id);
            return Ok(result);
        }

        //Get Product Category List
        [HttpGet("GetCategoryList")]
        public IActionResult GetCategoryList()
        {
            var result = dataAccess.GetProductCategories();
            return Ok(result);
        }


        //Insert Product
        [HttpPost("InsertProduct")]
        public IActionResult InsertProduct(Product product)
        {
            var id = dataAccess.InsertProduct(product);
            return Ok(id.ToString());
        }

        //Get All Products
        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var result = dataAccess.GetAllProducts();
            return Ok(result);
        }

        //Get Products
        [HttpGet("GetProducts")]
        public IActionResult GetProducts(string category, string subcategory, int count)
        {
            var result = dataAccess.GetProducts(category, subcategory, count);
            return Ok(result);
        }

        //Get Product by Id
        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = dataAccess.GetProduct(id);
            return Ok(result);
        }

        //Delete Product
        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = dataAccess.DeleteProduct(id);
            return Ok(result);
        }

        //Insert Cart Item
        [HttpPost("InsertCartItem/{userid}/{productid}")]
        public IActionResult InsertCartItem(int userid, int productid)
        {
            var result = dataAccess.InsertCartItem(userid, productid);
            return Ok(result ? "inserted" : "not inserted");
        }

        [HttpDelete("RemoveCartItem/{userid}/{productid}")]
        public IActionResult RemoveCartItem(int userid, int productid)
        {
            var deleteitem = dataAccess.RemoveCartItem(userid, productid);
            return Ok(deleteitem ? "Deleted" : "Could not deleted");
        }

        //Insert Review
        [HttpPost("InsertReview")]
        public IActionResult InsertReview([FromBody] Review review)
        {
            review.CreatedAt = DateTime.Now.ToString(DateFormat);
            dataAccess.InsertReview(review);
            return Ok("inserted");
        }

        //Get Product Reviews
        [HttpGet("GetProductReviews/{productId}")]
        public IActionResult GetProductReviews(int productId)
        {
            var result = dataAccess.GetProductReviews(productId);
            return Ok(result);
        }

        //Insert Order
        [HttpPost("InsertOrder")]
        public IActionResult InsertOrder(Order order)
        {
            order.CreatedAt = DateTime.Now.ToString();
            var id = dataAccess.InsertOrder(order);
            return Ok(id.ToString());
        }

        //Insert Payment
        [HttpPost("InsertPayment")]
        public IActionResult InsertPayment(Payment payment)
        {
            payment.CreatedAt = DateTime.Now.ToString();
            var id = dataAccess.InsertPayment(payment);
            return Ok(id.ToString());
        }

        //Get Payment
        [HttpGet("GetPaymentMethods")]
        public IActionResult GetPaymentMethods()
        {
            var result = dataAccess.GetPaymentMethods();
            return Ok(result);
        } 
    }
}
