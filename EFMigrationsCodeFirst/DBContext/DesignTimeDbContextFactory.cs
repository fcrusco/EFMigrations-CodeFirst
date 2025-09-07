//Essa classe não roda no programa, ela é usada apenas quando você executa comandos do EF Core no Visual Studio/CLI.
// Importa os recursos do Entity Framework Core
using Microsoft.EntityFrameworkCore;
// Importa a interface IDesignTimeDbContextFactory usada para criar DbContext em tempo de design (migrations, scaffold)
using Microsoft.EntityFrameworkCore.Design;
// Define o namespace do projeto, organizando as classes relacionadas ao DbContext
namespace ItensEfOracle.DBContext;
// Classe que implementa IDesignTimeDbContextFactory<AppDbContext>
// Essa factory é usada pelo EF Core quando precisamos rodar comandos no Visual Studio
// (como Add-Migration ou Update-Database) e ele não sabe como instanciar o DbContext
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    // Método obrigatório da interface: cria uma instância de AppDbContext em tempo de design
    // O parâmetro string[] args pode receber argumentos, mas normalmente não usamos
    public AppDbContext CreateDbContext(string[] args)
    {
        // Define a string de conexão com o banco Oracle
        // Aqui devem ser preenchidos: usuário, senha e Data Source (host:porta/service)
        var cs = "User Id=xxxx;Password=xxxx;Data Source=oracle.xxxx.com.br:1521/ORCL;";

        // Cria o objeto de configuração de opções para o AppDbContext
        // - Usa o provider Oracle (UseOracle)
        // - Associa a connection string definida acima
        var opts = new DbContextOptionsBuilder<AppDbContext>().UseOracle(cs).Options;

        // Retorna uma nova instância de AppDbContext já configurada
        // O EF Core vai usar essa instância para rodar migrations e outros comandos
        return new AppDbContext(opts);
    }
}