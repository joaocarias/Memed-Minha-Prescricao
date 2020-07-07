using System.Collections.Generic;

namespace MeuMemed.Models.Json.Memed
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class AttributesRetornoCadastroMedico
    {
        public string nome { get; set; }
        public string data_nascimento { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string sexo { get; set; }
        public bool terms_accepted { get; set; }
        public string status { get; set; }
        public string cidade { get; set; }
        public string clinica_ativa { get; set; }
        public object cns { get; set; }
        public string cnes { get; set; }
        public List<object> configuracoes { get; set; }
        public string crm { get; set; }
        public string endereco { get; set; }
        public string especialidade { get; set; }
        public bool estudante { get; set; }
        public bool farmacia_artesanal { get; set; }
        public bool iamspe { get; set; }
        public bool is_partner { get; set; }
        public string nome_completo { get; set; }
        public bool perola_byington { get; set; }
        public string sociedades { get; set; }
        public object telefone { get; set; }
        public string token { get; set; }
        public string uf { get; set; }
        public string universidade { get; set; }
        public string fabricante { get; set; }
        public string user_type { get; set; }
        public int total_of_prescriptions { get; set; }
        public int total_of_prescripted_drugs { get; set; }
        public int total_of_sms_prescriptions { get; set; }
        public string avatar { get; set; }
        public string ambiente { get; set; }
        public bool is_editor { get; set; }
        public bool user_name { get; set; }
        public string biografia { get; set; }
        public string imagem_capa { get; set; }
        public bool synchronized { get; set; }
        public double percentage_of_completed_profile { get; set; }
    }

    public class LinksDataRetornoCadastroMedico
    {
        public string self { get; set; }
    }

    public class DataCidadeRetornoCadastroMedico
    {
        public int id { get; set; }
        public string type { get; set; }
    }

    public class LinksCidadeRetornoCadastroMedico
    {
        public string self { get; set; }
    }

    public class CidadeRetornoCadastroMedico
    {
        public DataCidadeRetornoCadastroMedico data { get; set; }
        public LinksCidadeRetornoCadastroMedico links { get; set; }
    }

    public class LinksSociedadesRetornoCadastroMedico
    {
        public string self { get; set; }
    }

    public class SociedadesRetornoCadastroMedico
    {
        public List<object> data { get; set; }
        public LinksSociedadesRetornoCadastroMedico links { get; set; }
    }

    public class DataEspecialidadesRetornoCadastroMedico
    {
        public int id { get; set; }
        public string type { get; set; }
    }

    public class LinksEspecialidadeRetornoCadastroMedico
    {
        public string self { get; set; }
    }

    public class EspecialidadeRetornoCadastroMedico
    {
        public DataEspecialidadesRetornoCadastroMedico data { get; set; }
        public LinksEspecialidadeRetornoCadastroMedico links { get; set; }
    }

    public class RelationshipsRetornoCadastroMedico
    {
        public CidadeRetornoCadastroMedico cidade { get; set; }
        public SociedadesRetornoCadastroMedico sociedades { get; set; }
        public EspecialidadeRetornoCadastroMedico especialidade { get; set; }
        public object universidade { get; set; }
    }

    public class DataRetornoCadastroMedico
    {
        public string type { get; set; }
        public AttributesRetornoCadastroMedico attributes { get; set; }
        public LinksDataRetornoCadastroMedico links { get; set; }
        public RelationshipsRetornoCadastroMedico relationships { get; set; }
        public int id { get; set; }
    }

    public class LinksRetornoCadastroMedico
    {
        public string self { get; set; }
    }

    public class JsonRetornoCadastroMedicoMemed
    {
        public DataRetornoCadastroMedico data { get; set; }
        public LinksRetornoCadastroMedico links { get; set; }
    }
}
