using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataLayer.Interface;
using DataLayer.Model;

namespace DataLayer.DAO
{
    public class DBDistrict : IDAO<District>, ISecondaryDistrictSalesPerson
    {
        private readonly DBConnect conn;
        public DBDistrict(DBConnect db)
        {
            conn = db;
        }

        public void Create(District t)
        {
            if (String.IsNullOrEmpty(t.Name)) throw new IllegalDataArgumentException("District name CAN NOT be empty", new ArgumentNullException());

            string query = $"INSERT INTO District (Name, PrimarySalesPersonID) VALUES ('{t.Name}', '{t.PSPID}')";
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
                throw new DataLayerException("District Create Failed", e);
            }
        }


        // Delete process:
        // 1. sets foreign keys to null in stores table
        // 2. deletes all entries with district id from ssp mapping
        // 3. finally deletes the district


        public void Delete(int id)
        {
            if (id < 1) throw new IllegalDataArgumentException($"Provided ID value ({id}) is illegal. ID must be greater than 0.", new ArgumentOutOfRangeException());

            string query = $"EXEC spSafeDeleteDistrictByID {id}";

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
                throw new DataLayerException("District Delete Failed", e);
            }
        }

        public District Get(int id)
        {
            if (id < 1) throw new IllegalDataArgumentException($"Provided ID value ({id}) is illegal. ID must be greater than 0.", new ArgumentOutOfRangeException());

            var result = new District();

            string query = $"SELECT * FROM District WHERE ID={id}";

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
                            result.PSPID = reader.GetInt32(2);
                            result.PSPName = reader.GetString(3);
                            result.SSPCount = reader.GetInt32(4);
                        }
                        catch (Exception e)
                        {
                            link.Close();
                            throw new DataLayerException($"Could not get the district with ID={id}", e);
                        }
                    }
                    link.Close();
                }
            }
            catch (Exception e)
            {
                throw new DataLayerException($"Could not get the district with ID={id}", e);
            }
            return result;
        }

        public IEnumerable<District> GetAll()
        {
            var result = new List<District>();
            string query = "EXEC spDistrictSPView";

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
                            District ds = new District();
                            try
                            {
                                ds.ID = reader.GetInt32(0);
                                ds.Name = reader.GetString(1);
                                ds.PSPID = reader.GetInt32(2);
                                ds.PSPName = reader.GetString(3);
                                ds.SSPCount = reader.GetInt32(4);
                                result.Add(ds);
                            }
                            catch (Exception e)
                            {
                                link.Close();
                                throw new DataLayerException("Could not get a district", e);
                            }
                        }
                    }
                    link.Close();
                }
            }
            catch (Exception e)
            {
                throw new DataLayerException("Could not get the districts list", e);
            }

            return result;
        }


        public void Update(District t)
        {
            if (t == null) throw new IllegalDataArgumentException("District object is null", new NullReferenceException());
            if (t.ID < 0) throw new IllegalDataArgumentException("District ID must be greater than 0", new ArgumentOutOfRangeException());

            string query = $"UPDATE District SET Name='{t.Name}', PrimarySalesPersonID='{t.PSPID}' WHERE ID={t.ID}";

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
                throw new DataLayerException("District Update Failed", e);
            }
        }


        #region SECONDARY SALES PERSON MANAGEMENT

        public void AddSecondary(int districtID, int salesPersonID)
        {
            if (districtID < 0) throw new IllegalDataArgumentException("District ID must be greater than 0", new ArgumentOutOfRangeException());
            if (salesPersonID < 0) throw new IllegalDataArgumentException("Salesperson ID must be greater than 0", new ArgumentOutOfRangeException());

            string query = $"EXEC spDistrictAppendSSP '{districtID}', '{salesPersonID}'";

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
                        throw new DataLayerException("Secondary Salesperson Appending operation failed", e);
                    }
                    link.Close();
                }

            }
            catch (Exception e)
            {
                throw new DataLayerException("Secondary Salesperson Appending operation failed", e);
            }
        }
    
        public void RemoveSecondary(int districtID, int salesPersonID)
        {
            if (districtID < 0) throw new IllegalDataArgumentException("District ID must be greater than 0", new ArgumentOutOfRangeException());
            if (salesPersonID < 0) throw new IllegalDataArgumentException("Salesperson ID must be greater than 0", new ArgumentOutOfRangeException());

            string query = $"EXEC spDistrictRemoveSSP '{districtID}', '{salesPersonID}'";

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
                throw new DataLayerException("Secondary Salesperson Removal Operation Failed", e);
            }
        }

        public IEnumerable<SalesPerson> GetPossibleSecondary(int DistrictID)
        {
            var result = new List<SalesPerson>();
            string query = $"EXEC spDistrictPossibleSSP '{DistrictID}'";

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

        #endregion
    }
}
