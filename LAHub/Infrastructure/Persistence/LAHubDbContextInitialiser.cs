﻿using Infrastructure.Identity;
using LAHub.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly LAHubDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, LAHubDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer() || _context.Database.IsNpgsql())
            {
                await _context.Database.MigrateAsync();
            }
            //else
            //{
            //    _context.Database.EnsureDeleted();
            //}
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        //var administratorRole = new IdentityRole("Administrator");

        //if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        //{
        //    await _roleManager.CreateAsync(administratorRole);
        //}

        //// Default users
        //var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        //if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        //{
        //    await _userManager.CreateAsync(administrator, "Administrator1!");
        //    await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
        //}

        // Default data
        // Seed, if necessary
        if (!_context.ContactMechanismTypes.Any())
        {
            List<ContactMechanismType> contactMechanismTypes = new()
            {
                new ContactMechanismType
                {
                    Id = Guid.NewGuid(),
                    Name = "Phone",
                    Description = "Phone number",
                    Created = DateTime.Now,
                    CreatedBy = "System"
                },
                new ContactMechanismType
                {
                    Id = Guid.NewGuid(),
                    Name = "Email",
                    Description = "Email address",
                    Created = DateTime.Now,
                    CreatedBy = "System"
                }
            };

            foreach (var contactMechanismType in contactMechanismTypes)
            {
                _context.ContactMechanismTypes.Add(contactMechanismType);
            }

            await _context.SaveChangesAsync();
        }

        if (!_context.ServiceOptionTypes.Any())
        {
            List<ServiceOptionType> serviceOptionTypes = new()
            {
                new ServiceOptionType
                {
                    Name = "Orgaisation",
                    Description = "Organisation providing one or more services",
                    Created = DateTime.Now,
                    CreatedBy = "System"
                },
                new ServiceOptionType
                {
                    Name = "Eligability",
                    Description = "Eligability of people who can use the service",
                    Created = DateTime.Now,
                    CreatedBy = "System"
                },
            };

            foreach (var serviceOptionType in serviceOptionTypes)
            {
                _context.ServiceOptionTypes.Add(serviceOptionType);
            }

            await _context.SaveChangesAsync();
        }
    }
}

