using DBL.UOW;
using System;

namespace DBL
{
    public class BL
    {
        private UnitOfWork db;
        private string _connString;
        public BL(string connString)
        {
            this._connString = connString;
            db = new UnitOfWork(connString);
        }
    }
}
