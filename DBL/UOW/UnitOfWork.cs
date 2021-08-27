using DBL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private string connString;
        private bool _disposed;

        private ISecurityRepository securityRepository;
        private IProductcategoryRepository productcategoryRepository;
        private ProductattributesRepository productattributesRepository;


        public UnitOfWork(string connectionString)
        {
            connString = connectionString;
        }
        public ISecurityRepository SecurityRepository
        {
            get { return securityRepository ?? (securityRepository = new SecurityRepository(connString)); }
        }
        public IProductcategoryRepository ProductcategoryRepository
        {
            get { return productcategoryRepository ?? (productcategoryRepository = new ProductcategoryRepository(connString)); }
        }
        public IProductattributesRepository ProductattributesRepository
        {
            get { return productattributesRepository ?? (productattributesRepository = new ProductattributesRepository(connString)); }
        }
        public void Reset()
        {
            securityRepository = null;
            productcategoryRepository = null;
            productattributesRepository = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
