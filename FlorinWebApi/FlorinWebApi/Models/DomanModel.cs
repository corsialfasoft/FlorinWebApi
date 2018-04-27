using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace FlorinWebApi.Models {
	public class Prodotto{
		public int		ID			{get;set;}
		public string	Descr		{get;set;}
		public int		Quantita	{get;set;}
	}
	public class DomainModel{
		
		public Prodotto CercaId(int id){
			Prodotto res = new Prodotto();
			SqlConnection connection = new SqlConnection(GetConnection());
			try{
				connection.Open();
				SqlCommand command = new SqlCommand("CercaId",connection);
				command.CommandType= CommandType.StoredProcedure;
				command.Parameters.Add("@ID",SqlDbType.Int).Value=id;
				SqlDataReader reader= command.ExecuteReader();
				while(reader.Read()){
					res.ID = reader.GetInt32(0);
					res.Descr = reader.GetString(1);
					res.Quantita= reader.GetInt32(2);
				}
				reader.Close();
				command.Dispose();
				return res;
			}catch(Exception e){
				throw e;
			}finally{
				connection.Close();
			}
		}

		private string GetConnection() {
			SqlConnectionStringBuilder  SB = new SqlConnectionStringBuilder();
			SB.DataSource = @"(localdb)\MSSQLLocalDB";
			SB.InitialCatalog = "RICHIESTE";
			return SB.ToString();
			}

		public List<Prodotto> CercaDescr(string descr){
			List<Prodotto> result = new List<Prodotto>();
			SqlConnection connection= new SqlConnection(GetConnection());
			try{
				connection.Open();
				SqlCommand command = new SqlCommand("CercaDescr",connection);
				command.CommandType= CommandType.StoredProcedure;
				command.Parameters.Add("@Descr",SqlDbType.NVarChar).Value=descr;
				SqlDataReader reader= command.ExecuteReader();
				while(reader.Read()){
					Prodotto res = new Prodotto();
					res.ID = reader.GetInt32(0);
					res.Descr = reader.GetString(1);
					res.Quantita= reader.GetInt32(2);
					result.Add(res);
				}
				reader.Close();
				command.Dispose();
				return result;
			}catch(Exception e ){
				throw e;
			}finally{
				connection.Dispose();
			}
		}
		public void AggiungiCarrello(int codice , int Quantita){
			//using(var db = new LogisticaEntities()){
			//	OrdiniProdotti op = new OrdiniProdotti();
			//	op.Prodotti_Id=codice;
			//	op.quantita=Quantita;
			//	db.OrdiniProdotti.Add(op);
			//	db.SaveChanges();
			//}
		}
		public void InviaOrdine(List<Prodotto> prodotti){
			//using(var db = new LogisticaEntities()){
			//	OrdiniSet os = new OrdiniSet();
			//	os.data = DateTime.Now;
			//	db.OrdiniSet.Add(os);
			//	db.SaveChanges();
			//	//OrdiniProdotti Op = new OrdiniProdotti();
			//	//Op.Ordini_Id=os.Id;
			//	//Op.Prodotti_Id;
			//	foreach(Prodotto p in prodotti){
   //                 OrdiniProdotti op = new OrdiniProdotti();
   //                 op.ProdottiSet= db.ProdottiSet.Find(p.ID);
   //                 op.OrdiniSet = os;
   //                 op.quantita = p.Quantita;
   //                 db.OrdiniProdotti.Add(op);
   //                 db.SaveChanges();
   //             }
			}

		}
	}
