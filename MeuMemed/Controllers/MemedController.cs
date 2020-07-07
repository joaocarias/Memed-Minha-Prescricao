using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MeuMemed.Data;
using MeuMemed.Data.IRepositorios;
using MeuMemed.Models;
using MeuMemed.Models.Json.Memed;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeuMemed.Controllers
{
    public class MemedController : Controller
    {

        private static readonly string _apiKey = "iJGiB4kjDGOLeDFPWMG3no9VnN7Abpqe3w1jEFm6olkhkZD6oSfSmYCm";
        private static readonly string _secretKey = "Xe8M5GvBGCr4FStKfxXKisRo3SfYKI7KrTMkJpCAstzu2yXVN4av5nmL";
        private static readonly string _dominio_api = "sandbox.api.memed.com.br";

        private readonly Contexto _contexto;
        private readonly IRepositorioMedico _repositorioMedico;

        public MemedController(Contexto contexto, IRepositorioMedico repositorioMedico)
        {
            _contexto = contexto;
            _repositorioMedico = repositorioMedico;
        }

        public async Task<IActionResult> CadastrarMedico(int medicoId)
        {
            var retorno = "";

            var medico = _repositorioMedico.Obter(medicoId);
            if (medico != null)
            {
                try
                {
                    var url = "https://" + _dominio_api + "/v1/sinapse-prescricao/usuarios?api-key="
                                   + _apiKey + "&secret-key=" + _secretKey;

                    HttpClient httpCliente = new HttpClient();
                    httpCliente.DefaultRequestHeaders.Add("Accept", " application/vnd.api+jsonn");
                    httpCliente.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                    httpCliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

                    var response = await httpCliente.PostAsync(url, GerarObjetoData(medico));
                    var statusCode = response.StatusCode;

                    retorno = response.Content.ReadAsStringAsync().Result;
                    if (statusCode.Equals(HttpStatusCode.Created))
                    {
                        var jsonMedicoMemed = JsonConvert.DeserializeObject<JsonRetornoCadastroMedicoMemed>(retorno);
                        if (jsonMedicoMemed != null && jsonMedicoMemed.data.attributes.token.Length > 0 && !jsonMedicoMemed.data.attributes.token.Equals(""))
                        {
                            AtualizarDadosMemed(medico, jsonMedicoMemed.data.attributes.token, Convert.ToString(jsonMedicoMemed.data.id));
                        }

                        retorno = (int)statusCode + " - " + retorno;
                    }
                    else
                    {
                        retorno = (int)statusCode + " - " + retorno;
                    }

                    httpCliente.Dispose();

                }
                catch (Exception ex)
                {
                    retorno = ex.ToString();
                }
            }

            return Ok(retorno);
        }

        public async Task<IActionResult> RecuperarTotenMedico(int medicoId)
        {
            var retorno = "";

            var medico = _repositorioMedico.Obter(medicoId);
            if (medico != null)
            {
                try
                {
                    var uri = "https://" + _dominio_api + "/v1/sinapse-prescricao/usuarios/"
                                    + medico.ExternoId + "?"
                                    + "api-key=" + _apiKey + "&secret-key=" + _secretKey;

                    HttpClient _httpCliente = new HttpClient();
                    _httpCliente.DefaultRequestHeaders.Add("Accept", " application/vnd.api+json");

                    var response = await _httpCliente.GetAsync(uri);
                    
                    retorno = response.Content.ReadAsStringAsync().Result;
                    var statusCode = response.StatusCode;

                    if (statusCode.Equals(HttpStatusCode.OK))
                    {
                        var jsonMedicoMemed = JsonConvert.DeserializeObject<JsonRecuperarMedicoMemed>(retorno);
                        AtualizarDadosMemed(medico, jsonMedicoMemed.data.attributes.token, Convert.ToString(jsonMedicoMemed.data.id));
                        
                        retorno = (int)statusCode + " - " + retorno;
                    }
                    else
                    {
                        retorno = (int)statusCode + " - " + retorno;
                    }

                    _httpCliente.Dispose();                    
                }
                catch (Exception ex)
                {
                    retorno = ex.ToString();
                }
            }

            return Ok(retorno);
        }

        public async Task<JsonResult> ObterCidades(string uf)
        {
            var url = "https://api.memed.com.br/v1/cidades?filter[uf]=" + uf;

            HttpClient _httpCliente = new HttpClient();
            var retorno = await _httpCliente.GetStringAsync(url);
            return Json(retorno);
        }

        private StringContent GerarObjetoData(Medico medico)
        {
            var parametros =
                    new
                    {
                        data = new
                        {
                            type = "usuarios",
                            attributes = new
                            {
                                external_id = medico.ExternoId,
                                nome = medico.Nome,
                                sobrenome = medico.Sobrenome,
                                // data_nascimento = medico.DataNascimento,
                                //cpf = medico.CPF,
                                //email = medico.Email,
                                uf = medico.UFCRM,
                                sexo = medico.Sexo,
                                crm = medico.CRM,
                            },
                            relationships = new
                            {
                                cidade = new
                                {
                                    data = new
                                    {
                                        type = "cidades",
                                        id = "5213"
                                    }
                                },
                                especialidade = new
                                {
                                    data = new
                                    {
                                        type = "especialidades",
                                        id = "50"
                                    }
                                },
                            },
                        }
                    };

            var json = JsonConvert.SerializeObject(parametros);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            return data;
        }

        private void AtualizarDadosMemed(Medico medico, string token, string memedId)
        {
            medico.DefinirToten(token);
            medico.DefinirMemedId(memedId);
            _contexto.Update(medico);
            _contexto.SaveChanges();
        }
    }
}
