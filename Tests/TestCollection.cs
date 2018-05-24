using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class TestCollection: IClassFixture<DbContext>
    {
        private readonly DbContext _dbContext;
        private readonly ITestOutputHelper _outputHelper;

        public TestCollection(DbContext dbContext, ITestOutputHelper outputHelper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _outputHelper = outputHelper ?? throw new ArgumentNullException(nameof(outputHelper));
        }

        [Fact]
        public void TestSomething()
        {
            _outputHelper.WriteLine("TestSomething done.");
        }
    }

    public class DbContext : IAsyncLifetime
    {
        public Task InitializeAsync() => Task.CompletedTask;

        public Task DisposeAsync()
        {
            Console.WriteLine("Disposing some resources...");

            return Task.CompletedTask;
        }
    }
}
