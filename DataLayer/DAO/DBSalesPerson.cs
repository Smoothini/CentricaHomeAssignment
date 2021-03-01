using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataLayer.Interface;
using DataLayer.Model;

namespace DataLayer.DAO
{
    public class DBSalesPerson : IDAO<SalesPerson>
    {
        private readonly DBConnect conn;
        public DBSalesPerson()
        {
            this.conn = new DBConnect();
        }

        public void Create(SalesPerson t)
        {
            if (String.IsNullOrEmpty(t.Name)) throw new IllegalDataArgumentException("Salesperson name CAN NOT be empty", new ArgumentNullException());

            string query = $"INSERT INTO SalesPerson (Name, Surname) VALUES ('{t.Name}', '{t.Surname}')";
            try
            {
                var link = conn.GetSqlConnection();
                using (SqlCommand cmd = new SqlCommand(query, link))
                {
                    link.Open();
                    var response = cmd.ExecuteReader();
                    link.Close();
                }
            }
            catch (Exception e)
            {
                throw new DataLayerException("SalesPerson Create Failed", e);
            }

        }

        public void Delete(int id)
        {
            if (id < 1) throw new IllegalDataArgumentException($"Provided ID value ({id}) is illegal. ID must be greater than 0.", new ArgumentOutOfRangeException());

            string query = $"DELETE FROM SalesPerson WHERE ID={id}";

            try
            {
                var link = conn.GetSqlConnection();
                using (SqlCommand cmd = new SqlCommand(query, link))
                {
                    link.Open();
                    var response = cmd.ExecuteReader();
                    link.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("SalesPerson Delete Failed", e);
            }
        }


        public SalesPerson Get(int id)
        {
            if (id < 1) throw new IllegalDataArgumentException($"Provided ID value ({id}) is illegal. ID must be greater than 0.", new ArgumentOutOfRangeException());

            var result = new SalesPerson();

            string query = $"SELECT * FROM SalesPerson WHERE ID={id}";

            try
            {
                var link = conn.GetSqlConnection();
                using (SqlCommand cmd = new SqlCommand(query, link))
                {
                    link.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {
                            reader.Read();
                            result.ID = reader.GetInt32(0);
                            result.Name = reader.GetString(1);
                            result.Surname = reader.GetString(2);
                        }
                        catch (Exception e)
                        {
                            link.Close();
                            throw new DataLayerException($"Could not get the salesperson with ID={id}", e);
                        }
                    }
                    link.Close();
                }
            }
            catch (Exception e)
            {
                throw new DataLayerException($"Could not get the salesperson with ID={id}", e);
            }
            return result;
        }

        public IEnumerable<SalesPerson> GetAll()
        {
            var result = new List<SalesPerson>();
            string query = "SELECT * FROM SalesPerson";

            try
            {
                var link = conn.GetSqlConnection();
                using (SqlCommand cmd = new SqlCommand(query, link))
                {
                    link.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalesPerson sp = new SalesPerson();
                            try
                            {
                                sp.ID = reader.GetInt32(0);
                                sp.Name = reader.GetString(1);
                                sp.Surname = reader.GetString(2);
                                result.Add(sp);
                            }
                            catch (Exception e)
                            {
                                link.Close();
                                throw new DataLayerException("Could not get a salesperson", e);
                            }
                        }
                    }
                    link.Close();
                }
            }
            catch (Exception e)
            {
                throw new DataLayerException("Could not get the salespersons list", e);
            }

            return result;
        }

        public void Update(SalesPerson t)
        {
            if (t == null) throw new IllegalDataArgumentException("Salesperson object is null", new NullReferenceException());
            if (t.ID < 0) throw new IllegalDataArgumentException("Salesperson ID must be greater than 0", new ArgumentOutOfRangeException());

            string query = $"UPDATE SalesPerson SET Name='{t.Name}', Surname='{t.Surname}' WHERE ID={t.ID}";

            try
            {
                var link = conn.GetSqlConnection();
                using (SqlCommand cmd = new SqlCommand(query, link))
                {
                    link.Open();
                    try
                    {
                        var response = cmd.ExecuteReader();
                    }
                    catch (Exception e)
                    {
                        link.Close();
                        throw new DataLayerException("Update failed", e);
                    }
                    link.Close();
                }

            }
            catch (Exception e)
            {
                throw new Exception("Salesperson Update Failed", e);
            }
        }
    }
}
