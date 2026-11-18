
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using WebApplication1Practical8_InventoryManagement.Models;

namespace WebApplication1Practical8_InventoryManagement.Controllers
{
    public class ProductController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString;

        public ActionResult Index()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    products.Add(new Product
                    {
                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        ProductName = dr["ProductName"].ToString(),
                        Quantity = Convert.ToInt32(dr["Quantity"]),
                        Price = Convert.ToDecimal(dr["Price"])
                    });
                }
            }

            return View(products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "INSERT INTO Products VALUES (@Name, @Qty, @Price)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", p.ProductName);
                cmd.Parameters.AddWithValue("@Qty", p.Quantity);
                cmd.Parameters.AddWithValue("@Price", p.Price);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Product p = new Product();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ProductId=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    p.ProductId = Convert.ToInt32(dr["ProductId"]);
                    p.ProductName = dr["ProductName"].ToString();
                    p.Quantity = Convert.ToInt32(dr["Quantity"]);
                    p.Price = Convert.ToDecimal(dr["Price"]);
                }
            }

            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "UPDATE Products SET ProductName=@Name, Quantity=@Qty, Price=@Price WHERE ProductId=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", p.ProductId);
                cmd.Parameters.AddWithValue("@Name", p.ProductName);
                cmd.Parameters.AddWithValue("@Qty", p.Quantity);
                cmd.Parameters.AddWithValue("@Price", p.Price);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductId=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }
    }
}
