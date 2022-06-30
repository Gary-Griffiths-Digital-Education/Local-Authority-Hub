using System.Security.Principal;

namespace WebUI.Models;

public interface IUserContext
{
    string HashedAccountId { get; set; }
    IPrincipal User { get; set; }
}
