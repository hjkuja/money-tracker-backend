using FluentAssertions;
using MoneyTracker.Application.Models;
using MoneyTracker.Application.Repositories.Interfaces;
using MoneyTracker.Application.Services;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace MoneyTracker.Api.Tests.Unit;

public class UserProfileServiceTests
{
    private readonly UserProfileService _sut;
    private readonly IUserProfileRepository _userRepository = Substitute.For<IUserProfileRepository>();

    public UserProfileServiceTests()
    {
        _sut = new UserProfileService(_userRepository);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var existingUser = new UserProfile("User1")
        {
            Id = Guid.NewGuid(),
            Accounts = new List<Account>()
        };
        _userRepository.GetByIdAsync(existingUser.Id).Returns(existingUser);

        // Act
        var result = await _sut.GetByIdAsync(existingUser.Id);

        // Assert
        result.Should().BeEquivalentTo(existingUser);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenUserDoesntExist()
    {
        // Arrange
        var unexistingUserId = Guid.NewGuid();
        _userRepository.GetByIdAsync(Arg.Any<Guid>()).ReturnsNull();

        // Act
        var result = await _sut.GetByIdAsync(unexistingUserId);

        // Assert
        result.Should().BeNull();
    }

}
