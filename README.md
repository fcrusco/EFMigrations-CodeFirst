

---
# README

---

## 🇧🇷 Português (Brasil)

### Projeto
EFMigrationsCodeFirst

### Descrição
Exemplo simples de Entity Framework Core (Code First) com Oracle: criação da tabela `TB_ITEM` via Migrations, inserção de um registro de exemplo e listagem no console.


<img width="1816" height="421" alt="image" src="https://github.com/user-attachments/assets/777be335-f2e3-4c69-b0ee-e67db0252b3f" />


### Requisitos
- .NET 8
- Visual Studio 2022
- Acesso ao Oracle

### Pacotes NuGet
- Microsoft.EntityFrameworkCore v8.*
- Microsoft.EntityFrameworkCore.Tools v8.*
- Oracle.EntityFrameworkCore v8.21.121

### Arquivos adicionados
- **Model/Item.cs** → Classe de domínio mapeada para a tabela `TB_ITEM`
- **DBContext/AppDbContext.cs** → Contexto do EF Core, configura tipos e índice único em `CODIGO`
- **DBContext/DesignTimeDbContextFactory.cs** → Factory para rodar `Add-Migration`/`Update-Database` em projeto Console
- **Program.cs** → Configura EF, aplica migrations, insere registro de exemplo e lista dados

### Passo a passo (Migrations)
1. Criar migration inicial  
    Add-Migration InitialCreate

2. Aplicar migration no Oracle  
    Update-Database

3. Ver migrations aplicadas  
    Get-Migration

4. Executar o programa (F5)  
   - Aplica migrations (se houver pendências)  
   - Insere `Motor Elétrico 5HP` se a tabela estiver vazia  
   - Lista registros da `TB_ITEM`

5. Rollback total (voltar ao zero)  
    Update-Database 0

6. Rollback parcial (voltar a uma migration anterior)  
    Update-Database NomeDaMigrationAnterior

---

## 🇺🇸 English

### Project
EFMigrationsCodeFirst

### Description
Simple Entity Framework Core (Code First) with Oracle: creates table `TB_ITEM` via Migrations, inserts a sample row, and prints items to the console.

### Requirements
- .NET 8
- Visual Studio 2022
- Oracle instance access

### NuGet Packages
- Microsoft.EntityFrameworkCore v8.*
- Microsoft.EntityFrameworkCore.Tools v8.*
- Oracle.EntityFrameworkCore v8.21.121

### Added Files
- **Model/Item.cs** → Class mapped to `TB_ITEM`
- **DBContext/AppDbContext.cs** → EF Core context with NUMBER(19) mapping and unique index on `CODIGO`
- **DBContext/DesignTimeDbContextFactory.cs** → Design-time factory for migrations in Console projects
- **Program.cs** → Configures EF, applies migrations, seeds a sample record, lists items

### Migration Steps
1. Create initial migration  
    Add-Migration InitialCreate

2. Apply migration to Oracle  
    Update-Database

3. List applied migrations  
    Get-Migration

4. Run program (F5)  
   - Applies migrations if any  
   - Inserts `Motor Elétrico 5HP` if empty  
   - Prints `TB_ITEM` rows

5. Full rollback  
    Update-Database 0

6. Partial rollback  
    Update-Database PreviousMigrationName

---

## 🇪🇸 Español

### Proyecto
EFMigrationsCodeFirst

### Descripción
Ejemplo simple de Entity Framework Core (Code First) con Oracle: crea la tabla `TB_ITEM` mediante Migrations, inserta un registro de ejemplo y lista los ítems en consola.

### Requisitos
- .NET 8
- Visual Studio 2022
- Acceso a Oracle

### Paquetes NuGet
- Microsoft.EntityFrameworkCore v8.*
- Microsoft.EntityFrameworkCore.Tools v8.*
- Oracle.EntityFrameworkCore v8.21.121

### Archivos agregados
- **Model/Item.cs** → Clase mapeada a `TB_ITEM`
- **DBContext/AppDbContext.cs** → Contexto de EF Core con mapeo NUMBER(19) e índice único en `CODIGO`
- **DBContext/DesignTimeDbContextFactory.cs** → Factory para ejecutar migrations en proyectos Console
- **Program.cs** → Configura EF, aplica migrations, inserta un ejemplo y lista registros

### Pasos de migración
1. Crear migración inicial  
    Add-Migration InitialCreate

2. Aplicar migración en Oracle  
    Update-Database

3. Ver migraciones aplicadas  
    Get-Migration

4. Ejecutar programa (F5)  
   - Aplica migraciones si existen  
   - Inserta `Motor Elétrico 5HP` si la tabla está vacía  
   - Lista registros de `TB_ITEM`

5. Rollback total  
    Update-Database 0

6. Rollback parcial  
    Update-Database NombreDeLaMigracionAnterior
