namespace vonergyWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizaçãoDispositivos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DispositivoIOT", "Nome", c => c.String(maxLength: 100));
            AddColumn("dbo.Equipamento", "Marca", c => c.String(maxLength: 100));
            AddColumn("dbo.Equipamento", "TensaoMaxima", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Funcionario", "OrgaoExpeditor", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Funcionario", "Sexo", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Funcionario", "EstadoCivil", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Equipamento", "TensaoMaximao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipamento", "TensaoMaximao", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Funcionario", "EstadoCivil", c => c.Int(nullable: false));
            AlterColumn("dbo.Funcionario", "Sexo", c => c.Int(nullable: false));
            AlterColumn("dbo.Funcionario", "OrgaoExpeditor", c => c.Int(nullable: false));
            DropColumn("dbo.Equipamento", "TensaoMaxima");
            DropColumn("dbo.Equipamento", "Marca");
            DropColumn("dbo.DispositivoIOT", "Nome");
        }
    }
}
