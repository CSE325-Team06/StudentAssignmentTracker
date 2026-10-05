using Microsoft.AspNetCore.Identity;
using StudentAssignmentTracker.ViewModels;

namespace StudentAssignmentTracker.Interfaces;

public interface IAuthService
{
	Task<IdentityResult> RegisterAsync(RegisterViewModel model);

	Task<SignInResult> LoginAsync(LoginViewModel model);

	Task LogoutAsync();
}
