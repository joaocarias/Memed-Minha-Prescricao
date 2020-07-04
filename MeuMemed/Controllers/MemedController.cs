using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeuMemed.Controllers
{
    public class MemedController : Controller
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CadastrarMedico()
        {
            var _api_key = "iJGiB4kjDGOLeDFPWMG3no9VnN7Abpqe3w1jEFm6olkhkZD6oSfSmYCm";
            var _secret_key = "Xe8M5GvBGCr4FStKfxXKisRo3SfYKI7KrTMkJpCAstzu2yXVN4av5nmL";
            var _dominio_api_memed = "sandbox.memed.com.br";
            //var url =
            //            "https://"
            //            + _dominio_api_memed +
            //            "/v1/sinapse-prescricao/usuarios?api-key="
            //            + _api_key +
            //            "&secret-key="
            //            + _secret_key;

           return View();
        }

        public async Task<JsonResult> ObterCidades()
        {
            var url = "https://api.memed.com.br/v1/cidades?filter[uf]=RN";

            var retorno = await _httpClient.GetStringAsync(url);         
            return Json(retorno);
        } 
    }
}
