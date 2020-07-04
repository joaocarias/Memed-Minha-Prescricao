using Microsoft.EntityFrameworkCore;

namespace MeuMemed.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }


    }
}
