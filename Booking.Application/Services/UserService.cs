using AutoMapper;
using Booking.Application.DTO;
using Booking.Application.Errors;
using Booking.Application.Interfaces.Privacy;
using Booking.Domain.Models;
using Booking.Application.Interfaces.Repositories;

namespace Booking.Application.Services;

public class UserService(IRoleRepository roleRepository, IPasswordHasher passwordHasher, IUserRepository userRepository, IMapper mapper, IJwtGenerator jwtGenerator)
{
  private readonly IPasswordHasher _hasher = passwordHasher;
  private readonly IUserRepository _userRepository = userRepository;
  private readonly IJwtGenerator _jwtGenerator = jwtGenerator;
  private readonly IRoleRepository _roleRepository = roleRepository;
  private readonly IMapper _mapper = mapper;

  public async Task<Result<bool>> Register(UserRegistration user)
  {
    string hashedPassword = _hasher.Generate(user.Password);
    Role? role = await _roleRepository.GetByTitle(user.RoleTitle);
    if (role == null) return Result<bool>.Fail(new RegistrationError("Cannot find role")); 
    User newUser = new()
    {
      Username = user.Username,  
      PasswordHash = hashedPassword,
      Role = role,
      RoleId = role.Id, 
    };
    return await _userRepository.Add(newUser) ? 
      Result<bool>.Ok(true) : 
      Result<bool>.Fail(new RegistrationError("Error registration"));
  }
  
  public async Task<Result<string>> Login(UserLogin user)
  {
    User? newUser = await _userRepository.GetByUsername(user.Username);
    if (newUser == null) return Result<string>.Fail(new ValidationError("Username not found", "username"));
    return _hasher.Compare(user.Password, newUser.PasswordHash) ? 
     Result<string>.Ok(_jwtGenerator.GenerateJwtToken(newUser)):
     Result<string>.Fail(new ValidationError("Password doesn't match", "password"));
  }

  public async Task<ICollection<User>> GetAll()
  {
    return await _userRepository.GetAll();  
  }
}