using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DWC_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DCDataContext db = new DCDataContext();

        public User GetUser(int Id)
        {
            var user = (from u in db.Users
                        where u.User_Id.Equals(Id)
                        select u).FirstOrDefault();

            if (user == null)
            {
                return null;
            }
            else
            {
                var newUser = new User
                {
                    User_Id = user.User_Id,
                    User_Name = user.User_Name,
                    User_Surname = user.User_Surname,
                    User_Email = user.User_Email,
                    User_PhoneNo = user.User_PhoneNo,
                    User_Password = user.User_Password,
                    User_Type = user.User_Type

                };
                return newUser;
            }
        }

        public int UserRegistration(string name, string surname, string email, string phoneno, string password, int type)
        {
            var checkuser = (from u in db.Users
                             where u.User_Email.Equals(email)
                             select u).FirstOrDefault();

            if (checkuser == null)
            {
                var newUser = new User
                {
                    User_Name = name,
                    User_Surname = surname,
                    User_Email = email,
                    User_PhoneNo = phoneno,
                    User_Password = password,
                    User_Type = type
                };
                db.Users.InsertOnSubmit(newUser);

                try
                {
                    db.SubmitChanges();
                    //Success
                    return 1;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    //Error
                    return -1;
                }
            }
            else
            {
                //User email already in Database
                return 0;
            }
        }

        public int UserLogin(string email, string password)
        {
            var user = (from u in db.Users
                        where u.User_Email.Equals(email) && u.User_Password.Equals(password)
                        select u).FirstOrDefault();

            if (user != null)
            {
                return user.User_Id;
            }
            else
            {
                //User not found in Database
                return 0;
            }
        }

        public int getUserType(int Id)
        {
            var user = (from u in db.Users
                        where u.User_Id.Equals(Id)
                        select u).FirstOrDefault();

            if (user == null)
            {
                return 0;
            }
            else
            {
                return user.User_Type;
            }
        }

        public bool EditUser(int UsersId, int Id, string Name, string Surname, string Email, string Phone)
        {
            var checkuser = getUserType(UsersId);

            if (checkuser != 1)
            {
                //*Not Admin
                return false;
            }
            else
            {
                var user = (from u in db.Users
                            where u.User_Id.Equals(Id)
                            select u).FirstOrDefault();

                if (user != null)
                {
                    user.User_Id = Id;
                    user.User_Name = Name;
                    user.User_Surname = Surname;
                    user.User_Email = Email;
                    user.User_PhoneNo = Phone;
                    user.User_Password = user.User_Password;
                    user.User_Type = user.User_Type;
                    try
                    {
                        db.SubmitChanges();
                        return true;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        ex.GetBaseException();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public Product GetProduct(int Id)
        {
            var Prod = (from p in db.Products
                        where p.Product_Id.Equals(Id)
                        select p).FirstOrDefault();

            if (Prod != null)
            {

                var newProd = new Product();

                newProd.Product_Id = Id;
                newProd.Product_Name = Prod.Product_Name;
                newProd.Product_Category = Prod.Product_Category;
                newProd.Product_Description = Prod.Product_Description;
                newProd.Product_Price = Prod.Product_Price;
                newProd.Product_Quantity = Prod.Product_Quantity;
                newProd.Product_DiscountStatus = Prod.Product_DiscountStatus;
                newProd.Product_DiscountAmount = Prod.Product_DiscountAmount;
                newProd.Product_Image = Prod.Product_Image;
                newProd.Product_Availability = Prod.Product_Availability;
                return newProd;
            }
            else
            {
                return null;
            }
        }

        public List<Product> getAllProducts()
        {
            var result = new List<Product>();

            dynamic prodlist = (from i in db.Products
                                select i);

            foreach (Product prod in prodlist)
            {
                var newProd = new Product
                {
                    Product_Id = prod.Product_Id,
                    Product_Name = prod.Product_Name,
                    Product_Category = prod.Product_Category,
                    Product_Description = prod.Product_Description,
                    Product_Price = prod.Product_Price,
                    Product_Quantity = prod.Product_Quantity,
                    Product_DiscountStatus = prod.Product_DiscountStatus,
                    Product_DiscountAmount = prod.Product_DiscountAmount,
                    Product_Image = prod.Product_Image,
                    Product_Availability = prod.Product_Availability
                };

                result.Add(newProd);
            }

            return result;
        }

        public void AddProduct(int UsersId, string name, string category, string description, decimal price, int quantity, bool discountstatus, decimal discountamount, string image)
        {
            var checkuser = getUserType(UsersId);

            if (checkuser != 1)
            {
                //*Not Admin
            }
            else
            {
                var newPro = new Product();

                newPro.Product_Name = name;
                newPro.Product_Category = category;
                newPro.Product_Description = description;
                newPro.Product_Price = price;
                newPro.Product_Quantity = quantity;
                newPro.Product_DiscountStatus = discountstatus;
                newPro.Product_DiscountAmount = discountamount;
                newPro.Product_Image = image;
                newPro.Product_Availability = true;


                db.Products.InsertOnSubmit(newPro);

                try
                {
                    db.SubmitChanges();
                }
                catch (IndexOutOfRangeException p)
                {
                    p.GetBaseException();
                    Console.WriteLine(p.StackTrace);
                }
            }
        }

        public bool DeleteProduct(int UsersId, string Id)
        {
            var checkuser = getUserType(UsersId);

            if (checkuser != 1)
            {
                //*Not Admin
                return false;
            }
            else
            {
                var Pro = (from u in db.Products
                           where u.Product_Id.Equals(Id)
                           select u).FirstOrDefault();

                if (Pro != null)
                {
                    if (Pro.Product_Availability.Equals(true))
                    {
                        Pro.Product_Availability = false;
                    }

                    try
                    {
                        db.SubmitChanges();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            //db.Products.DeleteOnSubmit(p);

        }

        public bool EditProduct(int UsersId, int Id, string Name, string Description, decimal Price, int quantity, bool discountstatus, decimal discountamount, string image)
        {
            var checkuser = getUserType(UsersId);

            if (checkuser != 1)
            {
                //*Not Admin
                return false;
            }
            else
            {
                var Prod = (from d in db.Products
                            where d.Product_Id.Equals(Id)
                            select d).FirstOrDefault();

                if (Prod != null)
                {
                    Prod.Product_Id = Id;
                    Prod.Product_Name = Name;
                    Prod.Product_Category = Prod.Product_Category;
                    Prod.Product_Description = Description;
                    Prod.Product_Price = Price;
                    Prod.Product_Quantity = quantity;
                    Prod.Product_DiscountStatus = discountstatus;
                    Prod.Product_DiscountAmount = discountamount;
                    Prod.Product_Image = image;
                    Prod.Product_Availability = true;
                    if (Prod.Product_Quantity.Equals(0))
                    {
                        Prod.Product_Availability = false;
                    }

                    try
                    {
                        db.SubmitChanges();
                        return true;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        ex.GetBaseException();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
