using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBFC13Lib;
using QuickBooksToLocalV1.Model;
using QuickBooksToLocalV1.Interfaces;

namespace QuickBooksToLocalV1.QuickBooksDal.Common
{
    public class QBCommon : QBConnection
    {

        public QBSessionManager CreateSession()
        {
            return new QBSessionManager();
        }


        public IMsgSetRequest CreateRequestMessage( ref QBSessionManager sessionManager)
        {
            //Create the message set request object to hold our request
            IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest("UK", 12, 0);
            requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

            return requestMsgSet;
        }


        public IResponse GetMessageResponse(ref QBSessionManager sessionManager, ref IMsgSetRequest requestMsgSet)
        {

            // Send Request Get Responce
            //Send the request and get the response from QuickBooks
            IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
            IResponse response = responseMsgSet.ResponseList.GetAt(0);

            return response;

        }
    }
}
