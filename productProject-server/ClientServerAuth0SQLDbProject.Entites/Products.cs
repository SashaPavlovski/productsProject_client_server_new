using ClientServerAuth0SQLDbProject.Dal;
using ClientServerAuth0SQLDbProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerAuth0SQLDbProject.Entites
{
    public class Products
    {
        public Products() { }
        public List<Product> ProductList { get; set; }
      

        public void UpdateProduct(System.Data.SqlClient.SqlCommand command, Product product)
        {
           if (command == null && (product == null)) return;
            {
                command.Parameters.AddWithValue("@productID", product.ProductID);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                command.Parameters.AddWithValue("@UnitsInStock", product.UnitInStock);
                int rows = command.ExecuteNonQuery();
            }
        }
        public void DeleteProduct(System.Data.SqlClient.SqlCommand command,int? productId)
        {
            if (command == null && (productId == null) )return;
            command.Parameters.AddWithValue("@productID", productId);
            int rows = command.ExecuteNonQuery();
        }
        public void addProduct(System.Data.SqlClient.SqlDataReader reader)
        {
            ProductList = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product() { ProductName = reader["productName"].ToString(), ProductID = int.Parse(reader["productID"].ToString()), UnitPrice = SqlMoney.Parse(reader["UnitPrice"].ToString()), UnitInStock = int.Parse(reader["UnitsInStock"].ToString()) };
                ProductList.Add(product);
            }


        }

        string insert = "select productID,productName,UnitPrice,UnitsInStock from NewProducts";
        string insertDelete = "delete from newProducts where [ProductID] =  @productID";
        string insertUpdate = "update [dbo].[NewProducts] set [ProductName] = @ProductName ,\r\n[UnitPrice] = @UnitPrice, [UnitsInStock] = @UnitsInStock where [ProductID] =  @productID";
        public List<Product> getProducts()
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            sqlQuery1.runCommand(insert, addProduct);
            return ProductList;
        }

        public void RemoveProduct(string productID)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            sqlQuery1.RunDeleteProduct(insertDelete, DeleteProduct, int.Parse(productID));
        }

        public void UpdateProduct1(ProductTemp product1)
        {
            Product product = new Product() { ProductID = product1.ProductID, UnitPrice = SqlMoney.Parse(product1.UnitPrice), UnitInStock = int.Parse(product1.UnitInStock), ProductName = product1.ProductName };
            SqlQuery sqlQuery1 = new SqlQuery();
            sqlQuery1.RunUpdateProduct(insertUpdate, UpdateProduct, product);
        }
    }
}
