using System;
using Architecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Database
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.SeedAuths();
            builder.SeedUsers();
            builder.SeedTargetApp();
        }

        private static void SeedAuths(this ModelBuilder builder)
        {
            builder.Entity<Auth>(x =>
            {
                x.HasData(new
                {
                    Id = 1L,
                    Login = "admin",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK+u88gtSXAyPDkW+hVS+dW4AmxrnaNFZks0Zzcd5xlb12wcF/q96cc4htHFzvOH9jtN98N5EBIXSvdUVnFc9kBuRTVytATZA7gITbs//hkxvNQ3eody5U9hjdH6D+AP0vVt5unZlTZ+gInn8Ze7AC5o6mn0Y3ylGO1CBJSHU9c/BcFY9oknn+XYk9ySCoDGctMqDbvOBcvSTBkKcrCzev2KnX7xYmC3yNz1Q5oPVKgnq4mc1iuldMlCxse/IDGMJB2FRdTCLV5KNS4IZ1GB+dw3tMvcEEtmXmgT2zKN5+kUkOxhlv5g1ZLgXzWjVJeKb5uZpsn3WK5kt8T+kzMoxHd5i8HxsU2uvy9GopxAnaV0WNsBPqTGkRllSxARl4ZN3hJqUla553RT49tJxbs+N03OmkYhjq+L0aKJ1AC+7G+rdjegiAQZB+3mdE7a2Pne2kYtpMoCmNMKdm9jOOVpfXJqZMQul9ltJSlAY6LPrHFUB3mw61JBNzx+sZgYN29GfDY=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9",
                    Roles = Roles.User | Roles.Admin
                });
            });
        }
        private static void SeedTargetApp(this ModelBuilder builder)
        {
            builder.Entity<TargetApp>(x =>
            {
                x.HasData(new
                {
                    Id = 1L,
                    Title = "Google",
                    Url = "https://google.com",
                    Interval = 3,
                    CheckTime = DateTime.Now.AddMinutes(1)
                });

                x.HasData(new
                {
                    Id = 2L,
                    Title = "Not Found",
                    Url = "https://www.isimtescil.net/lkjkljlkj",
                    Interval = 3,
                    CheckTime = DateTime.Now.AddMinutes(1)
                });
            });
        }

        private static void SeedUsers(this ModelBuilder builder)
        {
            builder.Entity<User>(x =>
            {
                x.HasData(new
                {
                    Id = 1L,
                    Status = Status.Active,
                    AuthId = 1L
                });

                x.OwnsOne(y => y.Name).HasData(new
                {
                    UserId = 1L,
                    Forename = "Administrator",
                    Surname = "Administrator"
                });

                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserId = 1L,
                    Value = "administrator@administrator.com"
                });
            });
        }
    }
}
