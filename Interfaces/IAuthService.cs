using Microsoft.AspNetCore.Identity;
using StudentAssignmentTracker.ViewModels;

namespace StudentAssignmentTracker.Interfaces;

/// <summary>
/// Defines the account registration, sign-in, and sign-out operations used by the UI.
/// </summary>
public interface IAuthService
{
	/// <summary>
	/// Creates an account from the validated registration details.
	/// </summary>
	Task<IdentityResult> RegisterAsync(RegisterViewModel model);

	/// <summary>
	/// Attempts to sign in with the supplied credentials.
	/// </summary>
	Task<SignInResult> LoginAsync(LoginViewModel model);

	/// <summary>
	/// Ends the current user's authenticated session.
	/// </summary>
	Task LogoutAsync();
}
