using Core.Infrastructure.Models;
using Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(o =>
    o.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Core.Presentation"))); 

var app = builder.Build();

app.MapGet("/test-db", async (AppDbContext db) =>
{
    Guid userId = Guid.CreateVersion7();
    Guid accountId = Guid.CreateVersion7();
    Guid profileId = Guid.CreateVersion7();
    Guid shoppingCartId = Guid.CreateVersion7();
    Guid holdAccountId = Guid.CreateVersion7();
    Guid userAuthId = Guid.CreateVersion7();

    var user = new User
    {
        Id = userId,
        Name = $"user-{userId}"
    };

    var userAccount = new UserAccount
    {
        Id = accountId,
        UserId = userId,
        Balance = 100, 
        Currency = Core.Domain.Currency.RUB,
    };

    var userProfile = new UserProfile
    {
        Id = profileId,
        UserId = userId  
    };

    var userHoldAccount = new HoldAccount
    {
        Id = holdAccountId,
        BaseAccountId = accountId,
        Balance = 0,
        Currency = Core.Domain.Currency.RUB,
    };

    var userShoppingCart = new ShoppingCart
    {
        Id = shoppingCartId,
        UserId = userId,  
    };

    var userAuth = new UserAuth
    {
        Id = userAuthId,
        UserId = userId,  
        Credentials = "credentials",
    };

    db.Users.Add(user);
    db.UserAuthentications.Add(userAuth);
    db.Accounts.Add(userAccount);
    db.Accounts.Add(userHoldAccount);
    db.ShoppingCarts.Add(userShoppingCart);

    await db.SaveChangesAsync(); 

    var u = await db.Users
        .FirstAsync();
    var userAuthentications = u.AuthProviders;
    var userAuthenticationsSecondWay = await db.UserAuthentications
        .Where(ua => ua.UserId == u.Id)
        .ToListAsync();
    var ua = await db.UserAccounts.FirstAsync(a => a.UserId == u.Id);
    var uaSecondWay = await db.Accounts.FirstAsync(a => a.Type == Core.Domain.AccountType.User);

    return Results.Ok(new
    {
        user = u, 
        userAuth1 = userAuthentications,
        userAuth2 = userAuthenticationsSecondWay,
        ua = ua, 
        ua2 = uaSecondWay,
    });
});


app.Run();
