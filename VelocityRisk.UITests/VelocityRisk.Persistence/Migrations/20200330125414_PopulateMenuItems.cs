using Microsoft.EntityFrameworkCore.Migrations;

namespace VelocityRisk.Persistence.Migrations
{
    public partial class PopulateMenuItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" insert into [dbo].[MenuItems] values ('Agents', 'https://velocityrisk.com/for-agents/')
                                    insert into [dbo].[MenuItems] values('Homeowners', 'https://velocityrisk.com/for-homeowners/')
                                    insert into [dbo].[MenuItems] values('Large Commercial', 'https://velocityrisk.com/for-businesses/large_business/')
                                    insert into [dbo].[MenuItems] values('Small Commercial', 'https://velocityrisk.com/small_business/')
                                    insert into [dbo].[MenuItems] values('Claims', 'https://velocityrisk.com/velocityrisk/claims')
                                    insert into [dbo].[MenuItems] values('Manage Your Policy', 'https://portal.velocityrisk.com/Login.aspx?ReturnUrl=%2f')
                                    insert into [dbo].[MenuItems] values('Make a Payment', 'https://portal.icheckgateway.com/Velocity/')
                                    insert into [dbo].[MenuItems] values('Notes and Notes', 'https://velocityrisk.com/news-and-notes/')");
        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [dbo].[MenuItems]");
        }
    }
}