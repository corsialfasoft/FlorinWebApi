using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlorinWebApi.Models;

namespace FlorinWebApi.Controllers {
	public class HomeController : Controller {
		public ActionResult Index() {
			ViewBag.Title = "Home Page";

			return View();
		}

		public ActionResult About() {
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact() {
			ViewBag.Message = "Your contact page.";

			return View();
		}
		public ActionResult Cerca() {
			ViewBag.Message = "Pagina di ricerca";

			return View();
		}
		public ActionResult Carrello(){
			DomainModel dm = new DomainModel();
			ViewBag.prodotti= Session["products"] as List<Prodotto>;
			return View();

		}
		/*
		public ActionResult CercaOrdine1(int id) {
			ViewBag.Message = "Pagina di ricerca";
			DomainModel dm = new DomainModel();
			ViewBag.Prodotto = dm.CercaId(id);
			return View("Singolo");
		}
		*/
		 [HttpPost]
		public ActionResult Cerca(string codice ,string descr) {
			ViewBag.Message = "Pagina di ricerca";
			DomainModel dm = new DomainModel();
			int cod;
			if(int.TryParse(codice,out cod)){
				ViewBag.Products= dm.CercaId(cod);
				return View("Single");
			}else{
				ViewBag.prodotti= dm.CercaDescr(descr);
				return View("Lista");
			}
			
		}
		public ActionResult SendOrder(){
			ViewBag.Messagge="Ordine inviato!";
			DomainModel dm = new DomainModel();
			List<Prodotto> prods =  Session["products"] as List<Prodotto>;
			dm.InviaOrdine(prods);
			Session.RemoveAll();
			ViewBag.prodotti = "";
			return View("Carrello");
		}
		public ActionResult PulisciCarrello(){
			Session.RemoveAll();
			ViewBag.prodotti = "";
			return View("Carrello");
		}
		[HttpPost]
		public ActionResult AddCarrello(string codice ,string Quantita){
			//int cod = ViewBag.Products.ID;
			DomainModel dm = new DomainModel();
			Prodotto p = new Prodotto();
			p=dm.CercaId(int.Parse(codice));
			p.Quantita= int.Parse(Quantita);
			List<Prodotto> prod = Session["products"] as List<Prodotto>;

			if(prod==null){
				prod= new List<Prodotto>();
			}
			prod.Add(p);
			Session["products"]=prod;
			//dm.AggiungiCarrello(cod,Quantita);
			ViewBag.prodotti= prod;
			return View("Carrello");
		}
		public ActionResult Single(int id){
			DomainModel dm = new DomainModel();
			ViewBag.Products= dm.CercaId(id);
			return View();
		}
	}
}
