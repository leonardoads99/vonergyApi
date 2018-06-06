namespace vonergyWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConsumoEletrico",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Corrente = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tensao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Potencia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConsumoDiario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataRegistro = c.DateTime(nullable: false),
                        DispositivoIOT_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DispositivoIOT", t => t.DispositivoIOT_Id)
                .Index(t => t.DispositivoIOT_Id);
            
            CreateTable(
                "dbo.DispositivoIOT",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CodigoEsp = c.Long(nullable: false),
                        Descicao = c.String(maxLength: 150),
                        Modelo = c.String(maxLength: 150),
                        Ativo = c.Boolean(nullable: false),
                        Empresa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.Empresa_Id)
                .Index(t => t.Empresa_Id);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cnpj = c.String(nullable: false, maxLength: 150),
                        RazaoSocial = c.String(nullable: false, maxLength: 150),
                        NomeFantasia = c.String(nullable: false, maxLength: 150),
                        Ativo = c.String(nullable: false, maxLength: 150),
                        Logradouro = c.String(maxLength: 150),
                        Bairro = c.String(maxLength: 150),
                        Cidade = c.String(maxLength: 150),
                        Numero = c.String(maxLength: 150),
                        Referencia = c.String(maxLength: 150),
                        Cep = c.String(nullable: false, maxLength: 150),
                        Uf = c.String(maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 150),
                        Telefone = c.String(maxLength: 150),
                        Celular = c.String(maxLength: 150),
                        Site = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipamento",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NomeEquipamento = c.String(maxLength: 150),
                        Modelo = c.String(maxLength: 150),
                        PotenciaMinima = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PotenciaMaxima = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TensaoMinima = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TensaoMaximao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CorrentMinima = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CorrenteMaxima = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Empresa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.Empresa_Id)
                .Index(t => t.Empresa_Id);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Cpf = c.String(nullable: false, maxLength: 150),
                        Rg = c.String(nullable: false, maxLength: 150),
                        OrgaoExpeditor = c.Int(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        NomeMae = c.String(nullable: false, maxLength: 150),
                        NomePai = c.String(maxLength: 150),
                        Sexo = c.Int(nullable: false),
                        EstadoCivil = c.Int(nullable: false),
                        Logradouro = c.String(maxLength: 150),
                        Bairro = c.String(maxLength: 150),
                        Cidade = c.String(maxLength: 150),
                        Numero = c.String(maxLength: 150),
                        Referencia = c.String(maxLength: 150),
                        Cep = c.String(nullable: false, maxLength: 150),
                        Uf = c.String(maxLength: 150),
                        Telefone = c.String(maxLength: 150),
                        Celular = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 150),
                        Senha = c.String(maxLength: 150),
                        ResetSenha = c.Boolean(nullable: false),
                        Empresa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.Empresa_Id)
                .Index(t => t.Empresa_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionario", "Empresa_Id", "dbo.Empresa");
            DropForeignKey("dbo.Equipamento", "Empresa_Id", "dbo.Empresa");
            DropForeignKey("dbo.DispositivoIOT", "Empresa_Id", "dbo.Empresa");
            DropForeignKey("dbo.ConsumoEletrico", "DispositivoIOT_Id", "dbo.DispositivoIOT");
            DropIndex("dbo.Funcionario", new[] { "Empresa_Id" });
            DropIndex("dbo.Equipamento", new[] { "Empresa_Id" });
            DropIndex("dbo.DispositivoIOT", new[] { "Empresa_Id" });
            DropIndex("dbo.ConsumoEletrico", new[] { "DispositivoIOT_Id" });
            DropTable("dbo.Funcionario");
            DropTable("dbo.Equipamento");
            DropTable("dbo.Empresa");
            DropTable("dbo.DispositivoIOT");
            DropTable("dbo.ConsumoEletrico");
        }
    }
}
