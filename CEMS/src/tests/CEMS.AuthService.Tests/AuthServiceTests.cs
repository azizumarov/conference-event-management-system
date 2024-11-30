using CEMS.Core.Entities;
using CEMS.Core.Interfaces;
using CEMS.Core.RepositoryInterfaces.DalRepositories;
using Moq;

namespace CEMS.AuthService.Tests
{
    public class AuthServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IRoleRepository> _mockRoleRepository;
        private readonly Mock<IPasswordHasher> _mockPasswordHasher;
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockRoleRepository = new Mock<IRoleRepository>();
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _authService = new AuthService(
                _mockUserRepository.Object,
                _mockRoleRepository.Object,
                _mockPasswordHasher.Object);
        }

        [Fact]
        public async Task AssignRoleToUserAsync_ShouldReturnTrue_WhenSuccessful()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var roleId = Guid.NewGuid();
            _mockUserRepository.Setup(repo => repo.AddRoleToUserAsync(userId, roleId)).ReturnsAsync(true);

            // Act
            var result = await _authService.AssignRoleToUserAsync(userId, roleId);

            // Assert
            Assert.True(result);
            _mockUserRepository.Verify(repo => repo.AddRoleToUserAsync(userId, roleId), Times.Once);
        }

        [Fact]
        public async Task AuthenticateUserAsync_ShouldReturnAuthenticated_WhenCredentialsAreValid()
        {
            // Arrange
            var login = "testUser";
            var password = "testPassword";
            var user = new User { Login = login, PasswordHash = "hashedPassword" };

            _mockUserRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<User> { user });
            _mockPasswordHasher.Setup(hasher => hasher.VerifyPassword(password, user.PasswordHash)).Returns(true);

            // Act
            var result = await _authService.AuthenticateUserAsync(login, password);

            // Assert
            Assert.Equal("Authenticated", result);
        }

        [Fact]
        public async Task AuthenticateUserAsync_ShouldThrowException_WhenUserNotFound()
        {
            // Arrange
            var login = "unknownUser";
            var password = "testPassword";

            _mockUserRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<User>());

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _authService.AuthenticateUserAsync(login, password));
        }

        [Fact]
        public async Task GetUserRolesAsync_ShouldReturnRoles_WhenCalled()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var roles = new List<Role> { new Role { Id = Guid.NewGuid(), Name = "Admin" } };

            _mockRoleRepository.Setup(repo => repo.GetUserRolesAsync(userId)).ReturnsAsync(roles);

            // Act
            var result = await _authService.GetUserRolesAsync(userId);

            // Assert
            Assert.Equal(roles, result);
        }

        [Fact]
        public async Task RegisterUserAsync_ShouldReturnTrue_WhenSuccessful()
        {
            // Arrange
            var user = new User { Login = "newUser", PasswordHash = "plainPassword" };
            _mockUserRepository.Setup(repo => repo.AddAsync(user)).ReturnsAsync(user);
            _mockPasswordHasher.Setup(hasher => hasher.HashPassword(user.PasswordHash)).Returns("hashedPassword");

            // Act
            var result = await _authService.RegisterUserAsync(user);

            // Assert
            Assert.True(result);
            _mockUserRepository.Verify(repo => repo.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task RegisterUserAsync_ShouldReturnFalse_WhenExceptionThrown()
        {
            // Arrange
            var user = new User { Login = "newUser", PasswordHash = "plainPassword" };
            _mockUserRepository.Setup(repo => repo.AddAsync(user)).ThrowsAsync(new Exception());

            // Act
            var result = await _authService.RegisterUserAsync(user);

            // Assert
            Assert.False(result);
        }
    }
 
}