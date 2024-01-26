using ECommerce_API.Models;

namespace ECommerce_API.DataAccess
{
    public interface IDataAccess
    {
        bool InsertUser(User user);
        User GetUser(int id);
        string IsUserPresent(string email, string password);
        Cart GetActiveCartOfUser(int userid);
        List<Cart> GetAllPreviousCartsOfUser(int userid);

        List<ProductCategory> GetProductCategories();
        ProductCategory GetProductCategory(int id);

        List<Product> GetAllProducts();
        int InsertProduct(Product product);
        Product GetProduct(int id);
        List<Product> GetProducts(string category, string subcategory, int count);
        Product DeleteProduct(int id);
      
        void InsertReview(Review review);
        List<Review> GetProductReviews(int productId);

        bool InsertCartItem(int userId, int productId);
        Cart GetCart(int cartid);
        bool RemoveCartItem(int userId, int productId);

        List<PaymentMethod> GetPaymentMethods();

        int InsertPayment(Payment payment);

        Offer GetOffer(int id);

        int InsertOrder(Order order);
    }
}
