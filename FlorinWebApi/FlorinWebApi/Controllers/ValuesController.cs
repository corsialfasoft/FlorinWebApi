using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlorinWebApi.Models;

namespace FlorinWebApi.Controllers {
	public class ValuesController : ApiController {
		// GET api/values
		DomainModel dm = new DomainModel();
		public IEnumerable<Prodotto> Get() {
			return dm.CercaDescr("").ToArray();
		}

		// GET api/values/5
		public Prodotto Get(int id) {
			return dm.CercaId(id);
		}

		// POST api/values
		public void Post([FromBody]string value) {
		}

		// PUT api/values/5
		public void Put(int id,[FromBody]string value) {
		}

		// DELETE api/values/5
		public void Delete(int id) {
		}
	}
}
