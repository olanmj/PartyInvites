namespace PartyInvites.Migrations
{
    using PartyInvites.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PartyInvites.Models.ResponseDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PartyInvites.Models.ResponseDBContext";
        }

        protected override void Seed(PartyInvites.Models.ResponseDBContext context)
        {

            context.Responses.AddOrUpdate(
                r => r.ID,
                new GuestResponse { Name = "Party Animal", Phone = "1111111", WillAttend = true },
                new GuestResponse { Name = "Mr. Miller", Phone = "2222222", WillAttend = true },
                new GuestResponse { Name = "Sam Adams", Phone = "444444", WillAttend = true },
                new GuestResponse { Name = "Ms. Coors", Phone = "33333333", WillAttend = false }
                );
        }
    }
}
