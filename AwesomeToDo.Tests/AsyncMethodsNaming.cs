using System;
using System.Linq;
using System.Reflection;
using AwesomeToDo.Api.Controllers;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;
using Castle.Core.Internal;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Internal;
using Xunit;
using Xunit.Abstractions;

namespace AwesomeToDo.Tests
{
    public class AsyncMethodsNaming
    {
        private readonly ITestOutputHelper output;

        public AsyncMethodsNaming(ITestOutputHelper output)
        {
            this.output = output;
        }        

        [Theory]
        [InlineData(typeof(ApiController))]
        [InlineData(typeof(AwesomeToDoException))]
        [InlineData(typeof(Card))]
        [InlineData(typeof(ICardCommandService))]
        public void AsyncMethodsHasValidNamesIn_Api_Namespace(Type type)
        {
            // arrange
            var types = Assembly.GetAssembly(type).GetTypes();

            // act
            var result = types.GetInvalidAsyncMethods();

            //assert
            if (!result.IsNullOrEmpty())
            {
                output.WriteLine(string.Join(',', result.Select(s => s.DisplayName())));
            }
            result.Should().BeEmpty();
        }
    }
}
