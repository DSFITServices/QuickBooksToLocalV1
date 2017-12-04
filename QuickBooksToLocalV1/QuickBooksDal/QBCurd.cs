using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickBooksToLocalV1.Interfaces;
using QuickBooksToLocalV1.Model;
using QuickBooksToLocalV1.QuickBooksDal.Common;
using QBFC13Lib;

namespace QuickBooksToLocalV1.QuickBooksDal
{
    public class QBCustomer : QBCommon , IDbCurd<customer>
    {
        public ObservableCollection<customer> DbRead()
        {
            ObservableCollection<customer> NewCustomer = new ObservableCollection<customer>();

            

            return NewCustomer;
        }
    }
}
