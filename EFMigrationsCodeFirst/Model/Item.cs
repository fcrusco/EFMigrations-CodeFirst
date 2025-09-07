// Importa os atributos de validação (ex.: [Key], [Required], [MaxLength])
using System.ComponentModel.DataAnnotations;

// Importa os atributos de mapeamento para o banco (ex.: [Table], [Column], [DatabaseGenerated])
using System.ComponentModel.DataAnnotations.Schema;


namespace EFMigrationsCodeFirst.Model
{

    // Define o namespace onde ficam as classes de modelo (organização do projeto)

    // Informa ao EF Core que esta classe mapeia a tabela Oracle chamada "TB_ITEM"
    [Table("TB_ITEM")]
    public class Item
    {
        // Marca a propriedade como chave primária (Primary Key) da tabela
        [Key]
        // Mapeia esta propriedade para a coluna "ID_ITEM" no Oracle
        [Column("ID_ITEM")]
        // Indica que o valor é gerado pelo banco (IDENTITY no Oracle); o EF não envia valor no INSERT
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Propriedade da PK no código C#; usamos long para combinar com NUMBER(19) no Oracle
        public long Id { get; set; } // NUMBER(19)

        // Torna o campo obrigatório (NOT NULL) e limita o tamanho máximo a 120 caracteres
        [Required, MaxLength(120)]
        // Mapeia para a coluna "NOME" no Oracle
        [Column("NOME")]
        // Propriedade do nome; inicia com string vazia para evitar null em referência não anulável
        public string Nome { get; set; } = string.Empty;

        // Campo obrigatório (NOT NULL) com tamanho máximo de 40 caracteres (útil para códigos/catalogação)
        [Required, MaxLength(40)]
        // Mapeia para a coluna "CODIGO" no Oracle
        [Column("CODIGO")]
        // Propriedade do código; inicia com string vazia por segurança (nullable reference types)
        public string Codigo { get; set; } = string.Empty;
    }

}
