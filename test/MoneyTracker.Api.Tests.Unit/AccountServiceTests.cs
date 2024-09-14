using FluentAssertions;
using MoneyTracker.Application.Models;
using MoneyTracker.Application.Repositories.Interfaces;
using MoneyTracker.Application.Services;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace MoneyTracker.Api.Tests.Unit;

public class AccountServiceTests
{
    private readonly AccountService _sut;
    private readonly IAccountRepository _accountRepository = Substitute.For<IAccountRepository>();

    public AccountServiceTests()
    {
        _sut = new AccountService(_accountRepository);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnAccount_WhenAccountExists()
    {
        // Arrange
        var existingAccount = new Account(Guid.NewGuid(), "TestAccount");
        _accountRepository.GetByIdAsync(existingAccount.Id).Returns(existingAccount);

        // Act
        var result = await _sut.GetByIdAsync(existingAccount.Id);

        // Assert
        result.Should().BeEquivalentTo(existingAccount);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenAccountDoesntExist()
    {
        // Arrange
        var unexistingAccountId = Guid.NewGuid();
        _accountRepository.GetByIdAsync(Arg.Any<Guid>()).ReturnsNull();

        // Act
        var result = await _sut.GetByIdAsync(unexistingAccountId);

        // Assert
        result.Should().BeNull();
    }


}
