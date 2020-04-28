using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.Models;

namespace Kolokwium.Services
{
    public class SqlDbService : IDbService
    {
        public string AddMed(int id, List<Medicament> reqlist)
        {
            var list = new List<Prescription>();
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s17064;Integrated Security=True"))
            using (var com = new SqlCommand())

            {
                com.Connection = con;
                con.Open();
                var tran = con.BeginTransaction();
                com.Transaction = tran;
                com.CommandText = "select * from prescription where idPrescription = @id";
                com.Parameters.AddWithValue("id", id);
                var dr = com.ExecuteReader();
                if(!dr.HasRows) return null;
                dr.Close();
                foreach (Medicament med in reqlist)
                {
                    com.CommandText = "insert into Prescription_Medicament(IdMedicament, IdPrescription, Dose, Details) values (@idmed, @id, @dose, @detail)";
                    com.Parameters.AddWithValue("idmed", med.idMedicament);
                    com.Parameters.AddWithValue("id", id);
                    com.Parameters.AddWithValue("dose", med.Dose);
                    com.Parameters.AddWithValue("detail", med.Details);
                    com.ExecuteNonQuery();
                    tran.Commit();
                    
                }
                return "dodane";
            }
        }

        public List<Prescription> GetAllPresc()
        {
            var list = new List<Prescription>();
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s17064;Integrated Security=True"))
            using (var com = new SqlCommand())

            {
                com.Connection = con;
                con.Open();
                var tran = con.BeginTransaction();
                com.Transaction = tran;
                com.CommandText = "select * from prescription order by prescription.Date DESC";
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var pr = new Prescription();
                    pr.idPrescription = (int)dr["IdPrescription"];
                    pr.Date = dr["Date"].ToString();
                    pr.DueDate = dr["DueDate"].ToString();
                    pr.idPatient = (int)dr["IdPatient"];
                    pr.idDoctor = (int)dr["IdDoctor"];
                    list.Add(pr);

                }
                return list;
            }
        }

        public List<Prescription> GetPresFor(int id)
        {
            var list = new List<Prescription>();
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s17064;Integrated Security=True"))
            using (var com = new SqlCommand())

            {
                com.Connection = con;
                con.Open();
                var tran = con.BeginTransaction();
                com.Transaction = tran;
                com.CommandText = "select * from prescription where idPatient = @id order by prescription.Date DESC";
                com.Parameters.AddWithValue("id", id);
                var dr = com.ExecuteReader();
                if (!dr.HasRows) return null;
                while (dr.Read())
                {
                    var pr = new Prescription();
                    pr.idPrescription = (int)dr["IdPrescription"];
                    pr.Date = dr["Date"].ToString();
                    pr.DueDate = dr["DueDate"].ToString();
                    pr.idPatient = (int)dr["IdPatient"];
                    pr.idDoctor = (int)dr["IdDoctor"];
                    list.Add(pr);
                }
                return list;
            }
        }
    }
}