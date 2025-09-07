// Importa o namespace onde está o AppDbContext (a "ponte" EF ↔ Oracle).
using EFMigrationsCodeFirst.Model;
using ItensEfOracle.DBContext;

// Importa os tipos e extensões do EF Core (DbContextOptionsBuilder, Migrate, AsNoTracking, etc.).
using Microsoft.EntityFrameworkCore;

// Define a connection string do Oracle (usuário, senha e service).
// Feito aqui para simplificar a aula; em produção use appsettings/segredos/variáveis de ambiente.
var cs = "User Id=xxxx;Password=xxxx;Data Source=oracle.xxxx.com.br:1521/ORCL;";

// Monta o "pacote de opções" do EF, dizendo qual provider será usado (Oracle) e com qual conexão.
// Esse objeto 'options' será entregue ao AppDbContext, evitando construtor sem parâmetros.
var options = new DbContextOptionsBuilder<AppDbContext>().UseOracle(cs).Options;

// Cria uma instância do DbContext dentro de um 'using'.
// O 'using' garante Dispose() no final (fecha conexão, libera recursos), mesmo se der exceção.
using (var db = new AppDbContext(options))
{
    // Mensagem informativa no console.
    Console.WriteLine("Aplicando migrations...");

    // Aplica migrations pendentes no banco.
    // Motivo: em desenvolvimento, é prático garantir que o schema esteja atualizado antes de usar.
    // O EF compara o histórico de migrations com o banco e executa o 'Up()' do que estiver faltando.
    db.Database.Migrate();

    // Comentário para os alunos: "seeding" simples quando a tabela está vazia.
    // .Any() checa rapidamente se existe ao menos um registro; se não tiver, inserimos um exemplo.
    // Motivo: deixar a listagem mostrar algo na primeira execução, sem precisar digitar nada.
    if (!db.Itens.Any())
    {
        // Cria e adiciona um Item na ChangeTracker do EF (estado 'Added').
        db.Itens.Add(new Item { Nome = "Motor Elétrico 5HP", Codigo = "MT-5HP" });

        // Persiste no banco: o EF gera o SQL (INSERT) e executa na conexão Oracle.
        db.SaveChanges();
    }

    // Monta a consulta de leitura:
    // - AsNoTracking(): leitura mais leve (o EF não vai rastrear/gerenciar objetos retornados).
    // - OrderBy(i => i.Nome): ordena alfabeticamente por Nome.
    // - ToList(): executa a query e materializa os resultados na memória (lista).
    var lista = db.Itens.AsNoTracking().OrderBy(i => i.Nome).ToList();

    // Título da listagem.
    Console.WriteLine("\n=== ITENS CADASTRADOS ===");

    // Percorre e imprime cada item retornado.
    // Interpolação de string para exibir Id, Nome e Código.
    foreach (var i in lista)
        Console.WriteLine($"{i.Id}: {i.Nome} ({i.Codigo})");
}

// Fora do 'using': aqui o DbContext já foi descartado (Dispose chamado).
// Mensagem final para indicar término da execução.
Console.WriteLine("\nPronto!");