using DataManager;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaJohan.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index(string identidad)
        {
            List<ClienteModel> cliente = new List<ClienteModel>();
            DataCliente dataCliente = new DataCliente();
            ClienteModel objClienteEmpUno = dataCliente.ObtieneClientePorIdEmpresaUno(identidad);
            ClienteModel objClienteEmpDos = dataCliente.ObtieneClientePorIdEmpresaDos(identidad);

            if (objClienteEmpUno.Identidad != null)
                cliente.Add(objClienteEmpUno);
            if (objClienteEmpDos.Identidad != null)
                cliente.Add(objClienteEmpDos);
            return View(cliente);
        }

        public ActionResult Actualizar(string empresa, int cantidadCompras, string fechaCompra)
        {
            List<ClienteModel> cliente = new List<ClienteModel>();
            DataCliente dataCliente = new DataCliente();

            if(empresa == "1")
            {
                // actualiza en bd 1
            }
            else if (empresa == "2")
            {
                // actualiza en bd 2
            }

            return RedirectToAction("Index");
        }
    }
}
