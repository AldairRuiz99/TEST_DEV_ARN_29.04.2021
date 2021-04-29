
using FRONT_WEB.BL.Clientes;
using FRONT_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRONT_WEB.Controllers
{
    public class ClientesController : Controller
    {
        public ActionResult Index(int id)
        {
            ClienteBL BL = new ClienteBL();
            var token = BL.ObtenerToken();
            List<TESTDTO.ClienteDTO> lista = new List<TESTDTO.ClienteDTO>();
            TESTDTO.ResponseDTO r = new TESTDTO.ResponseDTO();
            r = BL.ConsultarClientes(token.Data);
            lista = r.Data;

            const int pageSize = 20;
            if (id < 1)
                id = 1;

            int recsCount = lista.Count();
            var pager = new Pages(recsCount, id, pageSize);
            int recSkip = (id - 1) * pageSize;
            var data = lista.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(data);
        }

        public ActionResult GenerarExcel()
        {
            ClienteBL BL = new ClienteBL();
            var token = BL.ObtenerToken();
            List<TESTDTO.ClienteDTO> lista = new List<TESTDTO.ClienteDTO>();
            TESTDTO.ResponseDTO r = new TESTDTO.ResponseDTO();
            r = BL.ConsultarClientes(token.Data);
            lista = r.Data;

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Clientes");
            ws.Cells["A1"].Value = "IdCliente";
            ws.Cells["B1"].Value = "FechaRegistroEmpresa";
            ws.Cells["C1"].Value = "RazonSocial";
            ws.Cells["D1"].Value = "RFC";
            ws.Cells["E1"].Value = "Sucursal";
            ws.Cells["F1"].Value = "IdEmpleado";
            ws.Cells["G1"].Value = "Nombre";
            ws.Cells["H1"].Value = "Paterno";
            ws.Cells["I1"].Value = "Materno";
            ws.Cells["J1"].Value = "IdViaje";

            int rowStart = 2;
            foreach (var c in lista)
            {
                ws.Cells["A" + rowStart].Value = c.IdCliente;
                ws.Cells["B" + rowStart].Value = c.FechaRegistroEmpresa;
                ws.Cells["C" + rowStart].Value = c.RazonSocial;
                ws.Cells["D" + rowStart].Value = c.RFC;
                ws.Cells["E" + rowStart].Value = c.Sucursal;
                ws.Cells["F" + rowStart].Value = c.IdEmpleado;
                ws.Cells["G" + rowStart].Value = c.Nombre;
                ws.Cells["H" + rowStart].Value = c.Paterno;
                ws.Cells["I" + rowStart].Value = c.Materno;
                ws.Cells["J" + rowStart].Value = c.IdViaje;
                rowStart++;
            }

            return File(pck.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Clientes.xlsx");
        }
    }
}
