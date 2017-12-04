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
        bool sessionBegun = false;
        bool connectionOpen = false;



        public QBSessionManager DbConnect()
        {

            return new QBSessionManager();
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
