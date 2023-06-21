using AutoBogus;
using BasicBank.Domain.Entities;
using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBank.Domain.Test.Tests
{
    public class AccountTests
    {
        [Theory]
        [InlineData(15000)]
        [InlineData(20000)]
        public void Account_Deposit_SingleTran_Over_Error(decimal overAmount)
        {
            // Arrange
            User user = AutoFaker.Generate<User>();
            Account acc = new(user);

            // Act
            Action act = () => acc.Deposit(overAmount);

            // Assert
            act.Should().Throw<BusinessException>().WithMessage($"The provided amount ({overAmount}) must be between 1 and *.");
        }

        [Fact]
        public void Account_Deposit_MultTran_Over_Success()
        {
            // Arrange
            User user = AutoFaker.Generate<User>();
            Account acc = new(user);

            // Act
            acc.Deposit(9000);
            decimal balance = acc.Deposit(9000);

            // Assert
            Assert.Equal(18000, balance);
            Assert.Equal(18000, acc.Balance);
        }

        [Fact]
        public void Account_Withdraw_Less100_Error()
        {
            // Arrange
            User user = AutoFaker.Generate<User>();
            Account acc = new(user);

            // Act
            decimal balance = acc.Deposit(300);
            Assert.Equal(300, balance);
            Action act = () => acc.Withdraw(250);

            // Assert
            act.Should().Throw<BusinessException>().WithMessage($"You can not have less than*");
        }

        [Fact]
        public void Account_Withdraw_Negative_Error()
        {
            // Arrange
            User user = AutoFaker.Generate<User>();
            Account acc = new(user);

            // Act
            decimal balance = acc.Deposit(300);
            Assert.Equal(300, balance);
            Action act = () => acc.Withdraw(-1);

            // Assert
            act.Should().Throw<BusinessException>().WithMessage("Invalid provided amount to withdraw.");
        }

        [Fact]
        public void Account_Withdraw_Percent_Error()
        {
            // Arrange
            User user = AutoFaker.Generate<User>();
            Account acc = new(user);

            // Act
            decimal balance = acc.Deposit(10000);
            Assert.Equal(10000, balance);
            Action act = () => acc.Withdraw(9200);

            // Assert
            act.Should().Throw<BusinessException>().WithMessage("Max withraw value allowed:*");
        }

    }
}
