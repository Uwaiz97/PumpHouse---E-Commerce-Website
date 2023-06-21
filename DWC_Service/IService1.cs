using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DWC_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        User GetUser(int Id);

        [OperationContract]
        int UserRegistration(string name, string surname, string email, string phoneno, string password, int type);

        [OperationContract]
        int UserLogin(string email, string password);

        [OperationContract]
        int getUserType(int Id);

        [OperationContract]
        bool EditUser(int UsersId, int Id, string Name, string Surname, string Email, string Phone);

        [OperationContract]
        Product GetProduct(int Id);

        [OperationContract]
        List<Product> getAllProducts();

        [OperationContract]
        void AddProduct(int UsersId, string name, string category, string description, decimal price, int quantity, bool discountstatus, decimal discountamount, string image);
        
        [OperationContract]
        bool DeleteProduct(int UsersId, string Id);
        
        [OperationContract]
        bool EditProduct(int UsersId, int Id, string Name, string Description, decimal Price, int quantity, bool discountstatus, decimal discountamount, string image);
        
        
        
        
        
        // Frontend Cart Code:
        //Create cart session when user adds to cart
        //if cart session == null || search user id in cart table and if == true cart session= that cart id
        //create cart



        //Create 1 session for user make = to user id and use get user.
        //Login returns user id.
        //Logout make all sessions = null

        //.aspx?Product_Id=' + ProductID +'
        //String prodId=Request.QueryString("Product_Id"); Dont declare in page load, declare in parent class
        //Dont use buttons for dynamically added items. use anchor tag
        //Use buttons for adding to cart.
        //Product Catalog 
        //Product Page -Multiple inner html portions

    }
}
