namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'0707dc1c-eaf1-42fb-9baa-7559aaf87ba2', N'admin@Vidly.com', 0, N'ADXbFvAqYhiLnxPOuxv9SgzC6Viy4mbqHV0J5PEn1Rtx2WcDmOnW28vr6d/1IulBVQ==', N'b6cbd5e5-6d42-4804-a2cf-93059d432125', NULL, 0, 0, NULL, 1, 0, N'admin@Vidly.com', N'123456789', N'041667735')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'2287bcc1-3ef2-48b4-8c4e-43fd74ec350f', N'guest@Vidly.com', 0, N'AAJlJuoV8KUZyruSEvzEOR27Z9dIeTkLxyUp0nFUkSgMcBa2B5RcmMLKVmNI8UQ+QQ==', N'ed7987fb-1b40-463a-a200-200f51eb4018', NULL, 0, 0, NULL, 1, 0, N'guest@Vidly.com', N'123456', N'07961612300')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ce6d80b8-0772-46b3-bc90-e10cc4be2a9a', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0707dc1c-eaf1-42fb-9baa-7559aaf87ba2', N'ce6d80b8-0772-46b3-bc90-e10cc4be2a9a')



");

        }
        
        public override void Down()
        {
        }
    }
}
