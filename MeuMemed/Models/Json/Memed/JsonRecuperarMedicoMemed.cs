using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuMemed.Models.Json.Memed
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class AttributesDataRecuperarMedicoMemed
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string data_nascimento { get; set; }
        public string sexo { get; set; }
        public string cidade { get; set; }
        public string crm { get; set; }
        public string especialidade { get; set; }
        public string token { get; set; }
        public string uf { get; set; }
        public string user_type { get; set; }
        public int total_of_prescriptions { get; set; }
        public int total_of_prescripted_drugs { get; set; }
        public int total_of_sms_prescriptions { get; set; }
    }

    public class LinksDataRecuperarMedicoMemed
    {
        public string self { get; set; }
    }

    public class DataCidadeRelationshipsDataRecuperarMedicoMemed
    {
        public int id { get; set; }
        public string type { get; set; }
    }

    public class LinksCidadeRelationshipsDataRecuperarMedicoMemed
    {
        public string self { get; set; }
    }

    public class CidadeRelationshipsDataRecuperarMedicoMemed
    {
        public DataCidadeRelationshipsDataRecuperarMedicoMemed data { get; set; }
        public LinksCidadeRelationshipsDataRecuperarMedicoMemed links { get; set; }
    }

    public class LinksSociedadesRelationshipsDataRecuperarMedicoMemed
    {
        public string self { get; set; }
    }

    public class SociedadesRelationshipsDataRecuperarMedicoMemed
    {
        public List<object> data { get; set; }
        public LinksSociedadesRelationshipsDataRecuperarMedicoMemed links { get; set; }
    }

    public class DataEspecialidadeRelationshipsDataRecuperarMedicoMemed
    {
        public int id { get; set; }
        public string type { get; set; }
    }

    public class LinksEspecialidadeRelationshipsDataRecuperarMedicoMemed
    {
        public string self { get; set; }
    }

    public class EspecialidadeRelationshipsDataRecuperarMedicoMemed
    {
        public DataEspecialidadeRelationshipsDataRecuperarMedicoMemed data { get; set; }
        public LinksEspecialidadeRelationshipsDataRecuperarMedicoMemed links { get; set; }
    }

    public class RelationshipsDataRecuperarMedicoMemed
    {
        public CidadeRelationshipsDataRecuperarMedicoMemed cidade { get; set; }
        public SociedadesRelationshipsDataRecuperarMedicoMemed sociedades { get; set; }
        public EspecialidadeRelationshipsDataRecuperarMedicoMemed especialidade { get; set; }
    }

    public class DataRecuperarMedicoMemed
    {
        public string type { get; set; }
        public AttributesDataRecuperarMedicoMemed attributes { get; set; }
        public LinksDataRecuperarMedicoMemed links { get; set; }
        public RelationshipsDataRecuperarMedicoMemed relationships { get; set; }
        public int id { get; set; }
    }

    public class LinksRecuperarMedicoMemed
    {
        public string self { get; set; }
    }

    public class JsonRecuperarMedicoMemed
    {
        public DataRecuperarMedicoMemed data { get; set; }
        public LinksRecuperarMedicoMemed links { get; set; }
    }
}
