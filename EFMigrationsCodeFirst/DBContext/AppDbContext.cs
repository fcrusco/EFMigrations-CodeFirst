// Importa o namespace onde está a classe Item (o Model)
using EFMigrationsCodeFirst.Model;

// Importa os recursos principais do Entity Framework Core
using Microsoft.EntityFrameworkCore;

// Define o namespace onde está o DbContext (boa prática de organização)
namespace ItensEfOracle.DBContext;

// Define a classe AppDbContext, que herda de DbContext (classe base do EF Core)
// Essa classe representa a "ponte" entre o C# e o Banco de Dados
public class AppDbContext : DbContext
{
    // Cria a DbSet<Item>, que é o "espelho" da tabela TB_ITEM no banco
    // Com ela conseguimos fazer consultas LINQ como db.Itens.ToList()
    public DbSet<Item> Itens => Set<Item>();

    // Construtor da classe AppDbContext
    // Recebe opções de configuração (connection string, provider etc.)
    // e repassa para a classe base (DbContext)
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Método chamado pelo EF Core quando o modelo está sendo criado
    // É aqui que configuramos detalhes extras das entidades (tabelas)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configura a entidade Item:
        // - Propriedade Id será mapeada como NUMBER(19) no Oracle
        // - Será auto-incrementada (ValueGeneratedOnAdd)
        modelBuilder.Entity<Item>()
            .Property(i => i.Id)
            .HasColumnType("NUMBER(19)")
            .ValueGeneratedOnAdd();

        // Configura a entidade Item:
        // - Cria um índice único para a coluna Codigo
        //   (garante que não existam dois itens com o mesmo código)
        modelBuilder.Entity<Item>()
            .HasIndex(i => i.Codigo)
            .IsUnique();
    }
}