using Xunit;

namespace Tests
{
    /// <summary>
    /// When to use: when you want to create a single test context and share it 
    /// among tests in several test classes, and have it cleaned up after all 
    /// the tests in the test classes have finished.
    /// </summary>
    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}