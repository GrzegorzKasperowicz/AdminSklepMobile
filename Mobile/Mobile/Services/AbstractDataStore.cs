using AdminServiceConnection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Services
{
    public class AbstractDataStore
    {
        protected AdminServiceConnectionReference adminServiceConnectionReference ;

        public AbstractDataStore()
        {
                adminServiceConnectionReference = new AdminServiceConnectionReference("http://localhost:5226", new System.Net.Http.HttpClient());

        }
    }
}