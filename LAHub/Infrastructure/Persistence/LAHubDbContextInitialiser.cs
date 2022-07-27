using Infrastructure.Identity;
using LAHub.Domain.Entities;
using LAHub.Domain.OpenReferralEnities;
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

    public void InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer() || _context.Database.IsNpgsql())
            {
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();
                //await _context.Database.MigrateAsync();
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
        if (_context.Classifications.Any())
            return;

        // Default roles
        var administratorRole = new IdentityRole("Administrator");

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };
       
        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
        }
        


        // Default data
        // Seed, if necessary
        List<Classification> classifications = new()
        {
            new Classification("Autism", "Autism" ),
            new Classification("Brest Feeding", "Brest Feeding Support" ),
        };

        var organisationSeedData = new Infrastructure.Persistence.SeedData.Organisations.OrganisationSeedData(classifications);
        

        _context.Classifications.AddRange(classifications);

        await _context.SaveChangesAsync();

        IReadOnlyCollection<Organisation> organisations = organisationSeedData.SeedOrganistions();

        foreach (var organisation in organisations)
        {
            _context.Organisations.Add(organisation);
        }

        await _context.SaveChangesAsync();

        var openReferralOrganisationSeedData = new Infrastructure.Persistence.SeedData.Organisations.OpenReferralOrganisationSeedData();

        IReadOnlyCollection<OpenReferralOrganisation> openReferralOrganisations = openReferralOrganisationSeedData.SeedOpenReferralOrganistions();

        foreach (var openReferralOrganisation in openReferralOrganisations)
        {
            _context.OpenReferralOrganisations.Add(openReferralOrganisation);
        }

        await _context.SaveChangesAsync();

    }
}

