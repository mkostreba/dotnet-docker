using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using telephonedb.Models;

namespace Tests
{
    public class DatabaseFixture : IDisposable
    {
        public SqliteConnection Db { get; private set; }
        public telephonedbchangesContext TelephoneDb { get; private set; }

        public DatabaseFixture()
        {
            var Db = new SqliteConnection("DataSource=:memory:");
            Db.Open();

            try
            {
                var options = new DbContextOptionsBuilder<telephonedbchangesContext>()
                    .UseSqlite(Db)
                    .Options;

                // Create the schema in the database
                var context = new telephonedbchangesContext(options);
                context.Database.EnsureCreated();
                // add a NumberOwner
                context.NumberOwners.Add(new NumberOwners
                {
                    Id = 0,
                    Name = "TestCompany"
                });
                context.SaveChanges();
                this.TelephoneDb = context;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if(this.TelephoneDb != null) this.TelephoneDb.Dispose();
                    if (this.Db != null)
                    {
                        this.Db.Close();
                        this.Db.Dispose();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DatabaseFixture() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}