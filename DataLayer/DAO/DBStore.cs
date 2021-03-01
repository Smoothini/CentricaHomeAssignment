﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataLayer.Interface;
using DataLayer.Model;

namespace DataLayer.DAO
{
    public class DBStore : IDAO<Store>
    {
        private DBConnect con = null;

        public DBStore()
        {
            con = new DBConnect();
        }

        public void Create(Store t)
        {
            if (String.IsNullOrEmpty(t.Name)) throw new IllegalDataArgumentException("Store name CAN NOT be empty", new ArgumentNullException());
            if (t.DistrictID < 1) throw new IllegalDataArgumentException("District ID must be greater than 0", new ArgumentOutOfRangeException());

            string query = $"EXEC spStoreCreate '{t.Name}','{t.Info}',{t.DistrictID}";

            try
            {
                var link = con.GetSqlConnection();
                using(SqlCommand cmd = new SqlCommand(query,link))
                {
                    link.Open();
                    var response = cmd.ExecuteReader();
                    link.Close();
                }
            }
            catch (Exception e)
            {
                throw new DataLayerException("Store Create Failed", e);
            }
        }

        public void Delete(int id)
        {
            if (id < 1) throw new IllegalDataArgumentException("Provided ID value is illegal. ID must be greater than 0.", new ArgumentOutOfRangeException());

            string query = $"EXEC spStoreDeleteById {id}";

            try
            {
                var link = con.GetSqlConnection();
                using(SqlCommand cmd = new SqlCommand(query,link))
                {
                    link.Open();
                    var response = cmd.ExecuteReader();
                    link.Close();
                }
            }
            catch (Exception e)
            {
                throw new DataLayerException("Store Delete Failed", e);
            }
        }

        public Store Get(int id)
        {
            if (id < 1) throw new IllegalDataArgumentException("Provided ID value is illegal. ID must be greater than 0.", new ArgumentOutOfRangeException());

            Store store = new Store();

            string query = $"EXEC spStoreReadById {id}";

            try
            {
                var link = con.GetSqlConnection();
                using (SqlCommand cmd = new SqlCommand(query, link))
                {
                    link.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        try
                        {
                            store.ID = reader.GetInt32(0);
                            store.Name = reader.GetString(1);
                            store.Info = reader.GetString(2);
                            store.DistrictID = reader.GetInt32(3);
                        }
                        catch(Exception e)
                        {
                            link.Close();
                            throw new Exception("haha oops", e);
                        }
                    }
                    link.Close();
                }
            }
            catch (Exception e)
            {
                throw new DataLayerException("Store Delete Failed", e);
            }
            return store;
        }

        public IEnumerable<Store> GetAll()
        {
            List<Store> stores = new List<Store>();

            string query = $"EXEC spStoreReadAll";

            try
            {
                var link = con.GetSqlConnection();
                using (SqlCommand cmd = new SqlCommand(query, link))
                {
                    link.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Store store = new Store();
                            try
                            {
                                store.ID = reader.GetInt32(0);
                                store.Name = reader.GetString(1);
                                store.Info = reader.GetString(2);
                                store.DistrictID = reader.GetInt32(3);
                                stores.Add(store);
                            }
                            catch (Exception e)
                            {
                                throw new Exception("haha oops", e);
                            }
                        }
                    }
                    link.Close();
                }
            }
            catch (Exception e)
            {
                throw new DataLayerException("Store Delete Failed", e);
            }

            return stores;
        }

        public void Update(Store t)
        {
            if (t == null) throw new IllegalDataArgumentException("Store object is null", new NullReferenceException());
            if (t.ID < 0) throw new IllegalDataArgumentException("Store ID must be greater than 0", new ArgumentOutOfRangeException());

            string query = $"EXEC spStoreUpdate {t.ID},'{t.Name}','{t.Info}',{t.DistrictID}";

            try
            {
                var link = con.GetSqlConnection();
                using (SqlCommand cmd = new SqlCommand(query,link))
                {
                    link.Open();
                    var response = cmd.ExecuteReader();
                    link.Close();
                }

            }
            catch (Exception e)
            {
                throw new DataLayerException("Store Update Failed", e);
            }
        }
    }
}