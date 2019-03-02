using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using telephonedb.Models;
using Xunit;
using System.Linq;
using System.IO;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace Tests
{
    [TestCaseOrderer("Tests.AlphabeticalOrderer", "tests")]
    public class TelephoneDbTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture fixture;

        public TelephoneDbTests(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task A_001_Db_has_one_NumberOwner()
        {
            int thisCount = await fixture.TelephoneDb.NumberOwners.CountAsync();
            Assert.Equal(1, thisCount);
        }

        [Fact]
        public async Task A_002_Db_has_one_TelephoneNumbers()
        {
            int thisCount = await fixture.TelephoneDb.TelephoneNumber.CountAsync();
            Assert.Equal(0, thisCount);
        }

        [Fact]
        public async Task A_003_When_Number_Added_CountryCode_Is_1_By_Default()
        {
            var areaCode = (short)201;
            var lineNumber = (short)2345;
            var prefix = (short)789;
            fixture.TelephoneDb.TelephoneNumber.Add(new TelephoneNumber
            {
                Id = 3,
                AreaCode = areaCode,
                // CountryCode
                LineNumber = lineNumber,
                Prefix = prefix
            });
            fixture.TelephoneDb.SaveChanges();
            var result = fixture.TelephoneDb.TelephoneNumber.Where((t) =>
            t.AreaCode == areaCode
            && t.LineNumber == lineNumber
            && t.Prefix == prefix)
            .FirstOrDefault();
            Assert.Equal(1, result.CountryCode);
            //clean up
            fixture.TelephoneDb.Remove(result);
            fixture.TelephoneDb.SaveChanges();
            int thisCount = await fixture.TelephoneDb.TelephoneNumber.CountAsync();
            Assert.Equal(0, thisCount);
        }

        [Fact]
        public async Task A_004_When_Number_Added_IsOnNet_Is_True_By_Default()
        {
            //this test should fail
            var id = 4;
            var areaCode = (short)201;
            var lineNumber = (short)2345;
            var prefix = (short)789;
            fixture.TelephoneDb.TelephoneNumber.Add(new TelephoneNumber
            {
                Id = id,
                AreaCode = areaCode,
                LineNumber = lineNumber,
                Prefix = prefix
            });
            fixture.TelephoneDb.SaveChanges();
            var result = fixture.TelephoneDb.TelephoneNumber.Where((t) =>
            t.AreaCode == areaCode
            && t.LineNumber == lineNumber
            && t.Prefix == prefix)
            .FirstOrDefault();
            Assert.True(result.IsOnNet);
            //clean up
            fixture.TelephoneDb.Remove(result);
            fixture.TelephoneDb.SaveChanges();
            int thisCount = await fixture.TelephoneDb.TelephoneNumber.CountAsync();
            Assert.Equal(0, thisCount);
        }

        [Fact]
        public void A_005_This_Test_Deliberately_Fails()
        {
            Assert.False(true);
        }

        
        [Fact]
        public async Task A_006_When_Lite_Script_Run_There_Are_10_NumberOwners()
        {
            //clear all numbers
            var liteScript = await File.ReadAllTextAsync("telephonedb-lite-001.sql");
            var name = new SqliteParameter("@LiteScript", "Test");
            int rowsAffected = await fixture.TelephoneDb.Database.ExecuteSqlCommandAsync(liteScript, name);
            int ownerCount = await fixture.TelephoneDb.NumberOwners.CountAsync();
            Assert.Equal(1010, rowsAffected);
            Assert.Equal(11, ownerCount);
        }
    }
}