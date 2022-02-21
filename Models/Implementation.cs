using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Implementation
    {
        public List<BoutiqueShop> GetBoutique()
        {
            var list = new List<BoutiqueShop>();
            using (SqlConnection Madhu = new SqlConnection("Data Source = RILPT189; Initial Catalog = Test; Persist Security Info = True; User ID = sa; Password = sa123"))
            {
                try
                {
                    Madhu.Open();
                    SqlCommand Cmd = Madhu.CreateCommand();
                    Cmd.CommandText = "select * from BoutiqueShop";
                    var reader = Cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var B = new BoutiqueShop();
                        B.Bid = Convert.ToInt32(reader[0]);
                        B.Bname = reader[1].ToString();
                        B.Bprice = Convert.ToDouble(reader[2]);
                        B.Bcolor = reader[3].ToString();
                        list.Add(B);
                    }
                }
                catch(SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    Madhu.Close();
                }
            }
            return list;
        }
        public void AddBoutique(BoutiqueShop B)
        {
            using (SqlConnection con = new SqlConnection("Data Source = RILPT189; Initial Catalog = Test; Persist Security Info = True; User ID = sa; Password = sa123"))
            {
                var qry = "Insert into BoutiqueShop values(@Bid, @Bname, @Bprice, @Bcolor)";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@Bid", B.Bid);
                cmd.Parameters.AddWithValue("@Bname", B.Bname);
                cmd.Parameters.AddWithValue("@Bprice", B.Bprice);
                cmd.Parameters.AddWithValue("@Bcolor", B.Bcolor);
                try
                {
                    con.Open();
                    int Madhu = cmd.ExecuteNonQuery();
                    if (Madhu == 0)
                        throw new Exception("Table is not Effected plse Add the Values: ");
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public void UpdateBoutique(BoutiqueShop B)
        {
            using (SqlConnection con = new SqlConnection("Data Source = RILPT189; Initial Catalog = Test; Persist Security Info = True; User ID = sa; Password = sa123"))
            {
                var qry = $"update BoutiqueShop set Bname={B.Bname},Bprice={B.Bprice},Bcolor={B.Bcolor} where Bid = {B.Bid}";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    int Madhu = cmd.ExecuteNonQuery();
                    if (Madhu == 0)
                    {
                        throw new Exception("Table is Not is Updated: ");
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public void DeleteBoutique(int Bid)
        {
            using (SqlConnection con = new SqlConnection("Data Source = RILPT189; Initial Catalog = Test; Persist Security Info = True; User ID = sa; Password = sa123"))
            {
                var qry = $"delete * from BoutiqueShop where Bid = {Bid}";
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    int Madhu = cmd.ExecuteNonQuery();
                    if (Madhu == 0)
                    {
                        throw new Exception("Row is Deleted: ");
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

    }
}