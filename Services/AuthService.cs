using Microsoft.AspNetCore.Identity;
using StudentAssignmentTracker.Interfaces;
using StudentAssignmentTracker.Models;
using StudentAssignmentTracker.ViewModels;

namespace StudentAssignmentTracker.Services;

public class AuthService : IAuthService
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly SignInManager<ApplicationUser> _signInManager;

	public AuthService(
		UserManager<ApplicationUser> userManager,
		SignInManager<ApplicationUser> signInManager)
	{
		_userManager = userManager;
		_signInManager = signInManager;
	}

	public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
	{
		var user = new ApplicationUser
		{
			FirstName = model.FirstName,
			LastName = model.LastName,
			Email = model.Email,
			UserName = model.Email
		};

		return await _userManager.CreateAsync(user, model.Password);
	}

	public Task<SignInResult> LoginAsync(LoginViewModel model)
	{
		return _signInManager.PasswordSignInAsync(
			model.Email,
			model.Password,
			model.RememberMe,
			lockoutOnFailure: true);
	}

	public Task LogoutAsync()
	{
		return _signInManager.SignOutAsync();
	}
}
