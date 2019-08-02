using System.ComponentModel.DataAnnotations.Schema;

namespace Calculadora.Model.Base
{
    //Generico Para todos no Banco de dados
    public class BaseEntity
    {
        [Column("id")]
        public long? Id { get; set; }
    }
}
