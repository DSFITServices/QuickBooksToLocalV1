using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBFC13Lib;
using QuickBooksToLocalV1.Interfaces;
using QuickBooksToLocalV1.Model;
using QuickBooksToLocalV1.QuickBooksDal.Common;

namespace QuickBooksToLocalV1.QuickBooksDal
{
    public class QBConnection : IConnection<QBSessionManager>
    {
        public bool sessionBegun = false;
        public bool connectionOpen = false;



        public QBSessionManager DbConnect(QBSessionManager sessionManager)
        {

            sessionManager.OpenConnection(@"", "QuickBooksToLocalV1");
            connectionOpen = true;
            sessionManager.BeginSession(@"", ENOpenMode.omDontCare);
            sessionBegun = true;

            return sessionManager;
        }

        public bool DbClose(QBSessionManager sessionManager)
        {
            //End the session and close the connection to QuickBooks
            if (sessionBegun && connectionOpen)
            {
                if (sessionBegun)
                {
                    sessionManager.EndSession();
                    sessionBegun = false;
                }
                if (connectionOpen)
                {
                    sessionManager.CloseConnection();
                    connectionOpen = false;
                }
            }

            return connectionOpen;
        }
    }
}
