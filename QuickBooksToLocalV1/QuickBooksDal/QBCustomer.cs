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
    public class QBCustomer : QBCommon, IDbCurd<customer>
    {

        private List<string> IDlist;

        private int ActiveState;
        private DateTime CreateStartDT;
        private DateTime CreateEndDT;
        private DateTime ModifiedStartDT;
        private DateTime ModifiedEndDT;




        public ObservableCollection<customer> DbRead()
        {
            ObservableCollection<customer> Customers = new ObservableCollection<customer>();

            QBSessionManager sessionManager = CreateSession();
            IMsgSetRequest requestMsgSet = CreateRequestMessage(ref sessionManager);
            sessionManager = DbConnect(sessionManager);

            // Setup requestquery
            ICustomerQuery customerQueryReq = requestMsgSet.AppendCustomerQueryRq();
            customerQueryReq = SetCustomerQuery(ref requestMsgSet, 0, ref customerQueryReq);



            IResponse response = GetMessageResponse(ref sessionManager, ref requestMsgSet);
            ICustomerRetList customerRetList = (ICustomerRetList)response.Detail;


            if (customerRetList != null)
            {
                for (int i = 0; i < customerRetList.Count; i++)
                {
                    ICustomerRet customerRet = customerRetList.GetAt(i);
                    customer Customer = FillCustomer(customerRet);

                    Customers.Add(Customer);

                }
            }
            return Customers;
        }


        ICustomerQuery SetCustomerQuery(ref IMsgSetRequest requestMsgSet, int MetaType, ref ICustomerQuery customerQueryReq)
        {


            switch (MetaType)
            {
                // Returns Count only No Data returned;
                case 1:
                    customerQueryReq.metaData.SetValue(ENmetaData.mdMetaDataOnly);
                    break;
                case 2:
                    //Returns Both Count and Data
                    customerQueryReq.metaData.SetValue(ENmetaData.mdMetaDataAndResponseData);
                    break;
                default:
                    customerQueryReq.metaData.SetValue(ENmetaData.mdNoMetaData);
                    break;
            }

            // Check to see if IDList is not null
            // loop through list adding them to query

            //customerQueryReq.ORCustomerListQuery.ListIDList.Add("");


            switch (ActiveState)
            {
                case 1:
                    customerQueryReq.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asInactiveOnly);
                    break;
                case 2:
                    customerQueryReq.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asAll);
                    break;
                default:
                    customerQueryReq.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                    break;
            }

            return customerQueryReq;
        }


        customer FillCustomer(ICustomerRet customerRet)
        {
            var customerdal = new customer
            {

                //Go through all the elements of ICustomerRetList
                //Get value of ListID
                ID = (string)customerRet.ListID.GetValue(),
                //Get value of TimeCreated
                TimeCreated = (DateTime)customerRet.TimeCreated.GetValue(),
                //Get value of TimeModified
                TimeModified = (DateTime)customerRet.TimeModified.GetValue(),
                //Get value of EditSequence
                EditSequence = (string)customerRet.EditSequence.GetValue(),
                //Get value of Name
                Name = (string)customerRet.Name.GetValue(),
                //Get value of FullName
                FullName = (string)customerRet.FullName.GetValue()
            };
            //Get value of IsActive
            if (customerRet.IsActive != null)
            {
                customerdal.IsActive = (bool)customerRet.IsActive.GetValue();
            }
            if (customerRet.ClassRef != null)
            {
                //Get value of ListID
                if (customerRet.ClassRef.ListID != null)
                {
                    customerdal.ClassId = (string)customerRet.ClassRef.ListID.GetValue();
                }
                //Get value of FullName
                if (customerRet.ClassRef.FullName != null)
                {
                    customerdal.ClassName = (string)customerRet.ClassRef.FullName.GetValue();
                }
            }
            if (customerRet.ParentRef != null)
            {
                //Get value of ListID
                if (customerRet.ParentRef.ListID != null)
                {
                    customerdal.ParentId = (string)customerRet.ParentRef.ListID.GetValue();
                }
                //Get value of FullName
                if (customerRet.ParentRef.FullName != null)
                {
                    customerdal.ParentName = (string)customerRet.ParentRef.FullName.GetValue();
                }
            }
            //Get value of Sublevel
            customerdal.Sublevel = (int)customerRet.Sublevel.GetValue();
            //Get value of CompanyName
            if (customerRet.CompanyName != null)
            {
                customerdal.Company = (string)customerRet.CompanyName.GetValue();
            }
            //Get value of Salutation
            if (customerRet.Salutation != null)
            {
                customerdal.Salutation = (string)customerRet.Salutation.GetValue();
            }
            //Get value of FirstName
            if (customerRet.FirstName != null)
            {
                customerdal.FirstName = (string)customerRet.FirstName.GetValue();
            }
            //Get value of MiddleName
            if (customerRet.MiddleName != null)
            {
                customerdal.MiddleInitial = (string)customerRet.MiddleName.GetValue();
            }
            //Get value of LastName
            if (customerRet.LastName != null)
            {
                customerdal.LastName = (string)customerRet.LastName.GetValue();
            }
            ////Get value of JobTitle
            //if (customerRet.JobTitle != null)
            //{
            //    customerdal.JobTitle = (string)customerRet.JobTitle.GetValue();
            //}
            if (customerRet.BillAddress != null)
            {
                //Get value of Addr1
                if (customerRet.BillAddress.Addr1 != null)
                {
                    customerdal.BillingLine1 = (string)customerRet.BillAddress.Addr1.GetValue();
                }
                //Get value of Addr2
                if (customerRet.BillAddress.Addr2 != null)
                {
                    customerdal.BillingLine2 = (string)customerRet.BillAddress.Addr2.GetValue();
                }
                //Get value of Addr3
                if (customerRet.BillAddress.Addr3 != null)
                {
                    customerdal.BillingLine3 = (string)customerRet.BillAddress.Addr3.GetValue();
                }
                //Get value of Addr4
                if (customerRet.BillAddress.Addr4 != null)
                {
                    customerdal.BillingLine4 = (string)customerRet.BillAddress.Addr4.GetValue();
                }
                //Get value of Addr5
                if (customerRet.BillAddress.Addr5 != null)
                {
                    customerdal.BillingLine5 = (string)customerRet.BillAddress.Addr5.GetValue();
                }
                //Get value of City
                if (customerRet.BillAddress.City != null)
                {
                    customerdal.BillingCity = (string)customerRet.BillAddress.City.GetValue();
                }
                //Get value of State
                if (customerRet.BillAddress.State != null)
                {
                    customerdal.BillingState = (string)customerRet.BillAddress.State.GetValue();
                }
                //Get value of PostalCode
                if (customerRet.BillAddress.PostalCode != null)
                {
                    customerdal.BillingPostalCode = (string)customerRet.BillAddress.PostalCode.GetValue();
                }
                //Get value of Country
                if (customerRet.BillAddress.Country != null)
                {
                    customerdal.BillingCountry = (string)customerRet.BillAddress.Country.GetValue();
                }
                //Get value of Note
                if (customerRet.BillAddress.Note != null)
                {
                    customerdal.BillingNote = (string)customerRet.BillAddress.Note.GetValue();
                }
            }
            //if (customerRet.BillAddressBlock != null)
            //{
            //    //Get value of Addr1
            //    if (customerRet.BillAddressBlock.Addr1 != null)
            //    {
            //        customerdal.Addr1 = (string)customerRet.BillAddressBlock.Addr1.GetValue();
            //    }
            //    //Get value of Addr2
            //    if (customerRet.BillAddressBlock.Addr2 != null)
            //    {
            //        customerdal.Addr2 = (string)customerRet.BillAddressBlock.Addr2.GetValue();
            //    }
            //    //Get value of Addr3
            //    if (customerRet.BillAddressBlock.Addr3 != null)
            //    {
            //        customerdal.Addr3 = (string)customerRet.BillAddressBlock.Addr3.GetValue();
            //    }
            //    //Get value of Addr4
            //    if (customerRet.BillAddressBlock.Addr4 != null)
            //    {
            //        customerdal.Addr4 = (string)customerRet.BillAddressBlock.Addr4.GetValue();
            //    }
            //    //Get value of Addr5
            //    if (customerRet.BillAddressBlock.Addr5 != null)
            //    {
            //        customerdal.Addr5 = (string)customerRet.BillAddressBlock.Addr5.GetValue();
            //    }
            //}
            if (customerRet.ShipAddress != null)
            {
                //Get value of Addr1
                if (customerRet.ShipAddress.Addr1 != null)
                {
                    customerdal.ShippingLine1 = (string)customerRet.ShipAddress.Addr1.GetValue();
                }
                //Get value of Addr2
                if (customerRet.ShipAddress.Addr2 != null)
                {
                    customerdal.ShippingLine2 = (string)customerRet.ShipAddress.Addr2.GetValue();
                }
                //Get value of Addr3
                if (customerRet.ShipAddress.Addr3 != null)
                {
                    customerdal.ShippingLine3 = (string)customerRet.ShipAddress.Addr3.GetValue();
                }
                //Get value of Addr4
                if (customerRet.ShipAddress.Addr4 != null)
                {
                    customerdal.ShippingLine4 = (string)customerRet.ShipAddress.Addr4.GetValue();
                }
                //Get value of Addr5
                if (customerRet.ShipAddress.Addr5 != null)
                {
                    customerdal.ShippingLine5 = (string)customerRet.ShipAddress.Addr5.GetValue();
                }
                //Get value of City
                if (customerRet.ShipAddress.City != null)
                {
                    customerdal.ShippingCity = (string)customerRet.ShipAddress.City.GetValue();
                }
                //Get value of State
                if (customerRet.ShipAddress.State != null)
                {
                    customerdal.ShippingState = (string)customerRet.ShipAddress.State.GetValue();
                }
                //Get value of PostalCode
                if (customerRet.ShipAddress.PostalCode != null)
                {
                    customerdal.ShippingPostalCode = (string)customerRet.ShipAddress.PostalCode.GetValue();
                }
                //Get value of Country
                if (customerRet.ShipAddress.Country != null)
                {
                    customerdal.ShippingCountry = (string)customerRet.ShipAddress.Country.GetValue();
                }
                //Get value of Note
                if (customerRet.ShipAddress.Note != null)
                {
                    customerdal.ShippingNote = (string)customerRet.ShipAddress.Note.GetValue();
                }
            }
            //if (customerRet.ShipAddressBlock != null)
            //{
            //    //Get value of Addr1
            //    if (customerRet.ShipAddressBlock.Addr1 != null)
            //    {
            //        customerdal.Addr1 = (string)customerRet.ShipAddressBlock.Addr1.GetValue();
            //    }
            //    //Get value of Addr2
            //    if (customerRet.ShipAddressBlock.Addr2 != null)
            //    {
            //        customerdal.Addr2 = (string)customerRet.ShipAddressBlock.Addr2.GetValue();
            //    }
            //    //Get value of Addr3
            //    if (customerRet.ShipAddressBlock.Addr3 != null)
            //    {
            //        customerdal.Addr3 = (string)customerRet.ShipAddressBlock.Addr3.GetValue();
            //    }
            //    //Get value of Addr4
            //    if (customerRet.ShipAddressBlock.Addr4 != null)
            //    {
            //        customerdal.Addr4 = (string)customerRet.ShipAddressBlock.Addr4.GetValue();
            //    }
            //    //Get value of Addr5
            //    if (customerRet.ShipAddressBlock.Addr5 != null)
            //    {
            //        customerdal.Addr5 = (string)customerRet.ShipAddressBlock.Addr5.GetValue();
            //    }
            //}
            //if (customerRet.ShipToAddressList != null)
            //{
            //    for (int i = 0; i < customerRet.ShipToAddressList.Count; i++)
            //    {
            //        IShipToAddress ShipToAddress = customerRet.ShipToAddressList.GetAt(i);
            //        //Get value of Name
            //        customerdal.Name = (string)ShipToAddress.Name.GetValue();
            //        //Get value of Addr1
            //        if (ShipToAddress.Addr1 != null)
            //        {
            //            customerdal.ShippingLine1 = (string)ShipToAddress.Addr1.GetValue();
            //        }
            //        //Get value of Addr2
            //        if (ShipToAddress.Addr2 != null)
            //        {
            //            customerdal.ShippingLine2 = (string)ShipToAddress.Addr2.GetValue();
            //        }
            //        //Get value of Addr3
            //        if (ShipToAddress.Addr3 != null)
            //        {
            //            customerdal.ShippingLine3 = (string)ShipToAddress.Addr3.GetValue();
            //        }
            //        //Get value of Addr4
            //        if (ShipToAddress.Addr4 != null)
            //        {
            //            customerdal.ShippingLine4 = (string)ShipToAddress.Addr4.GetValue();
            //        }
            //        //Get value of Addr5
            //        if (ShipToAddress.Addr5 != null)
            //        {
            //            customerdal.ShippingLine5 = (string)ShipToAddress.Addr5.GetValue();
            //        }
            //        //Get value of City
            //        if (ShipToAddress.City != null)
            //        {
            //            customerdal.ShippingCity = (string)ShipToAddress.City.GetValue();
            //        }
            //        //Get value of State
            //        if (ShipToAddress.State != null)
            //        {
            //            customerdal.ShippingState = (string)ShipToAddress.State.GetValue();
            //        }
            //        //Get value of PostalCode
            //        if (ShipToAddress.PostalCode != null)
            //        {
            //            customerdal.ShippingPostalCode = (string)ShipToAddress.PostalCode.GetValue();
            //        }
            //        //Get value of Country
            //        if (ShipToAddress.Country != null)
            //        {
            //            customerdal.Country = (string)ShipToAddress.Country.GetValue();
            //        }
            //        //Get value of Note
            //        if (ShipToAddress.Note != null)
            //        {
            //            customerdal.ShippingNote = (string)ShipToAddress.Note.GetValue();
            //        }
            ////Get value of DefaultShipTo
            //if (ShipToAddress.DefaultShipTo != null)
            //{
            //    customerdal.DefaultShipTo = (bool)ShipToAddress.DefaultShipTo.GetValue();
            //}
            //}
            //}
            //Get value of Phone
            if (customerRet.Phone != null)
            {
                customerdal.Phone = (string)customerRet.Phone.GetValue();
            }
            //Get value of AltPhone
            if (customerRet.AltPhone != null)
            {
                customerdal.AlternatePhone = (string)customerRet.AltPhone.GetValue();
            }
            //Get value of Fax
            if (customerRet.Fax != null)
            {
                customerdal.Fax = (string)customerRet.Fax.GetValue();
            }
            //Get value of Email
            if (customerRet.Email != null)
            {
                customerdal.Email = (string)customerRet.Email.GetValue();
            }
            //Get value of Cc
            if (customerRet.Cc != null)
            {
                customerdal.Cc = (string)customerRet.Cc.GetValue();
            }
            //Get value of Contact
            if (customerRet.Contact != null)
            {
                customerdal.Contact = (string)customerRet.Contact.GetValue();
            }
            //Get value of AltContact
            if (customerRet.AltContact != null)
            {
                customerdal.AlternateContact = (string)customerRet.AltContact.GetValue();
            }
            //if (customerRet.AdditionalContactRefList != null)
            //{
            //    for (int i = 0; i < customerRet.AdditionalContactRefList.Count; i++)
            //    {
            //        IQBBaseRef QBBaseRef = customerRet.AdditionalContactRefList.GetAt(i);
            //        //Get value of ContactName
            //        customerdal.ContactName = (string)QBBaseRef.ContactName.GetValue();
            //        //Get value of ContactValue
            //        customerdal.ContactValue = (string)QBBaseRef.ContactValue.GetValue();
            //    }
            //}
            //if (customerRet.ContactsRetList != null)
            //{
            //    for (int i = 0; i < customerRet.ContactsRetList.Count; i++)
            //    {
            //        IContactsRet ContactsRet = customerRet.ContactsRetList.GetAt(i);
            //        //Get value of ListID
            //        customerdal.ListID = (string)ContactsRet.ListID.GetValue();
            //        //Get value of TimeCreated
            //        customerdal.TimeCreated = (DateTime)ContactsRet.TimeCreated.GetValue();
            //        //Get value of TimeModified
            //        customerdal.TimeModified = (DateTime)ContactsRet.TimeModified.GetValue();
            //        //Get value of EditSequence
            //        customerdal.EditSequence = (string)ContactsRet.EditSequence.GetValue();
            //        //Get value of Contact
            //        if (ContactsRet.Contact != null)
            //        {
            //            customerdal.Contact = (string)ContactsRet.Contact.GetValue();
            //        }
            //        //Get value of Salutation
            //        if (ContactsRet.Salutation != null)
            //        {
            //            customerdal.Salutation = (string)ContactsRet.Salutation.GetValue();
            //        }
            //        //Get value of FirstName
            //        customerdal.FirstName = (string)ContactsRet.FirstName.GetValue();
            //        //Get value of MiddleName
            //        if (ContactsRet.MiddleName != null)
            //        {
            //            customerdal.MiddleName = (string)ContactsRet.MiddleName.GetValue();
            //        }
            //        //Get value of LastName
            //        if (ContactsRet.LastName != null)
            //        {
            //            customerdal.LastName = (string)ContactsRet.LastName.GetValue();
            //        }
            //        ////Get value of JobTitle
            //        //if (ContactsRet.JobTitle != null)
            //        //{
            //        //    customerdal.JobTitle = (string)ContactsRet.JobTitle.GetValue();
            //        //}
            //        if (ContactsRet.AdditionalContactRefList != null)
            //        {
            //            for (int i = 0; i < ContactsRet.AdditionalContactRefList.Count; i++)
            //            {
            //                IQBBaseRef QBBaseRef = ContactsRet.AdditionalContactRefList.GetAt(i);
            //                //Get value of ContactName
            //                customerdal.ContactName = (string)QBBaseRef.ContactName.GetValue();
            //                //Get value of ContactValue
            //                customerdal.ContactValue = (string)QBBaseRef.ContactValue.GetValue();
            //            }
            //        }
            //    }
            //}
            if (customerRet.CustomerTypeRef != null)
            {
                //Get value of ListID
                if (customerRet.CustomerTypeRef.ListID != null)
                {
                    customerdal.TypeId = (string)customerRet.CustomerTypeRef.ListID.GetValue();
                }
                //Get value of FullName
                if (customerRet.CustomerTypeRef.FullName != null)
                {
                    customerdal.Type = (string)customerRet.CustomerTypeRef.FullName.GetValue();
                }
            }
            if (customerRet.TermsRef != null)
            {
                //Get value of ListID
                if (customerRet.TermsRef.ListID != null)
                {
                    customerdal.TermsId = (string)customerRet.TermsRef.ListID.GetValue();
                }
                //Get value of FullName
                if (customerRet.TermsRef.FullName != null)
                {
                    customerdal.Terms = (string)customerRet.TermsRef.FullName.GetValue();
                }
            }
            if (customerRet.SalesRepRef != null)
            {
                //Get value of ListID
                if (customerRet.SalesRepRef.ListID != null)
                {
                    customerdal.SalesRepId = (string)customerRet.SalesRepRef.ListID.GetValue();
                }
                //Get value of FullName
                if (customerRet.SalesRepRef.FullName != null)
                {
                    customerdal.SalesRep = (string)customerRet.SalesRepRef.FullName.GetValue();
                }
            }
            //Get value of Balance
            if (customerRet.Balance != null)
            {
                customerdal.Balance = (double)customerRet.Balance.GetValue();
            }
            //Get value of TotalBalance
            //if (customerRet.TotalBalance != null)
            //{
            //    customerdal.TotalBalance = (double)customerRet.TotalBalance.GetValue();
            //}
            if (customerRet.SalesTaxCodeRef != null)
            {
                //Get value of ListID
                if (customerRet.SalesTaxCodeRef.ListID != null)
                {
                    customerdal.TaxCodeId = (string)customerRet.SalesTaxCodeRef.ListID.GetValue();
                }
                //Get value of FullName
                if (customerRet.SalesTaxCodeRef.FullName != null)
                {
                    customerdal.TaxCode = (string)customerRet.SalesTaxCodeRef.FullName.GetValue();
                }
            }
            if (customerRet.ItemSalesTaxRef != null)
            {
                //Get value of ListID
                if (customerRet.ItemSalesTaxRef.ListID != null)
                {
                    customerdal.TaxItemId = (string)customerRet.ItemSalesTaxRef.ListID.GetValue();
                }
                //Get value of FullName
                if (customerRet.ItemSalesTaxRef.FullName != null)
                {
                    customerdal.TaxItem = (string)customerRet.ItemSalesTaxRef.FullName.GetValue();
                }
            }
            //Get value of ResaleNumber
            if (customerRet.ResaleNumber != null)
            {
                customerdal.ResaleNumber = (string)customerRet.ResaleNumber.GetValue();
            }
            //Get value of AccountNumber
            if (customerRet.AccountNumber != null)
            {
                customerdal.AccountNumber = (string)customerRet.AccountNumber.GetValue();
            }
            //Get value of CreditLimit
            if (customerRet.CreditLimit != null)
            {
                customerdal.CreditLimit = (double)customerRet.CreditLimit.GetValue();
            }
            if (customerRet.PreferredPaymentMethodRef != null)
            {
                //Get value of ListID
                if (customerRet.PreferredPaymentMethodRef.ListID != null)
                {
                    customerdal.PreferredPaymentMethodId = (string)customerRet.PreferredPaymentMethodRef.ListID.GetValue();
                }
                //Get value of FullName
                if (customerRet.PreferredPaymentMethodRef.FullName != null)
                {
                    customerdal.PreferredPaymentMethodName = (string)customerRet.PreferredPaymentMethodRef.FullName.GetValue();
                }
            }
            if (customerRet.CreditCardInfo != null)
            {
                //Get value of CreditCardNumber
                if (customerRet.CreditCardInfo.CreditCardNumber != null)
                {
                    customerdal.CreditCardNumber = (string)customerRet.CreditCardInfo.CreditCardNumber.GetValue();
                }
                //Get value of ExpirationMonth
                if (customerRet.CreditCardInfo.ExpirationMonth != null)
                {
                    customerdal.CreditCardExpMonth = (int)customerRet.CreditCardInfo.ExpirationMonth.GetValue();
                }
                //Get value of ExpirationYear
                if (customerRet.CreditCardInfo.ExpirationYear != null)
                {
                    customerdal.CreditCardExpYear = (int)customerRet.CreditCardInfo.ExpirationYear.GetValue();
                }
                //Get value of NameOnCard
                if (customerRet.CreditCardInfo.NameOnCard != null)
                {
                    customerdal.CreditCardNameOnCard = (string)customerRet.CreditCardInfo.NameOnCard.GetValue();
                }
                //Get value of CreditCardAddress
                if (customerRet.CreditCardInfo.CreditCardAddress != null)
                {
                    customerdal.CreditCardAddress = (string)customerRet.CreditCardInfo.CreditCardAddress.GetValue();
                }
                //Get value of CreditCardPostalCode
                if (customerRet.CreditCardInfo.CreditCardPostalCode != null)
                {
                    customerdal.CreditCardPostalCode = (string)customerRet.CreditCardInfo.CreditCardPostalCode.GetValue();
                }
            }
            //Get value of JobStatus
            if (customerRet.JobStatus != null)
            {
                ENJobStatus JobStatus = (ENJobStatus)customerRet.JobStatus.GetValue();
            }
            //Get value of JobStartDate
            if (customerRet.JobStartDate != null)
            {
                customerdal.JobStartDate = (DateTime)customerRet.JobStartDate.GetValue();
            }
            //Get value of JobProjectedEndDate
            if (customerRet.JobProjectedEndDate != null)
            {
                customerdal.JobProjectedEndDate = (DateTime)customerRet.JobProjectedEndDate.GetValue();
            }
            //Get value of JobEndDate
            if (customerRet.JobEndDate != null)
            {
                customerdal.JobEndDate = (DateTime)customerRet.JobEndDate.GetValue();
            }
            //Get value of JobDesc
            if (customerRet.JobDesc != null)
            {
                customerdal.JobDescription = (string)customerRet.JobDesc.GetValue();
            }
            if (customerRet.JobTypeRef != null)
            {
                //Get value of ListID
                if (customerRet.JobTypeRef.ListID != null)
                {
                    customerdal.JobTypeId = (string)customerRet.JobTypeRef.ListID.GetValue();
                }
                //Get value of FullName
                if (customerRet.JobTypeRef.FullName != null)
                {
                    customerdal.JobType = (string)customerRet.JobTypeRef.FullName.GetValue();
                }
            }
            //Get value of Notes
            if (customerRet.Notes != null)
            {
                customerdal.Notes = (string)customerRet.Notes.GetValue();
            }
            //if (customerRet.AdditionalNotesRetList != null)
            //{
            //    for (int i = 0; i < customerRet.AdditionalNotesRetList.Count; i++)
            //    {
            //        IAdditionalNotesRet AdditionalNotesRet = customerRet.AdditionalNotesRetList.GetAt(i121);
            //        //Get value of NoteID
            //        customerdal.NoteID = (int)AdditionalNotesRet.NoteID.GetValue();
            //        //Get value of Date
            //        customerdal.Date = (DateTime)AdditionalNotesRet.Date.GetValue();
            //        //Get value of Note
            //        customerdal.Note = (string)AdditionalNotesRet.Note.GetValue();
            //    }
            //}
            //Get value of PreferredDeliveryMethod
            if (customerRet.PreferredDeliveryMethod != null)
            {
                customerdal.PreferredDeliveryMethod = customerRet.PreferredDeliveryMethod.ToString();
            }
            if (customerRet.PriceLevelRef != null)
            {
                //Get value of ListID
                if (customerRet.PriceLevelRef.ListID != null)
                {
                    customerdal.PriceLevelId = (string)customerRet.PriceLevelRef.ListID.GetValue();
                }
                //Get value of FullName
                if (customerRet.PriceLevelRef.FullName != null)
                {
                    customerdal.PriceLevel = (string)customerRet.PriceLevelRef.FullName.GetValue();
                }
            }
            ////Get value of ExternalGUID
            //if (customerRet.ExternalGUID != null)
            //{
            //    customerdal.ExternalGUID = (string)customerRet.ExternalGUID.GetValue();
            //}
            if (customerRet.CurrencyRef != null)
            {
                //Get value of ListID
                if (customerRet.CurrencyRef.ListID != null)
                {
                    customerdal.CurrencyId = (string)customerRet.CurrencyRef.ListID.GetValue();
                }
                //Get value of FullName
                if (customerRet.CurrencyRef.FullName != null)
                {
                    customerdal.CurrencyName = (string)customerRet.CurrencyRef.FullName.GetValue();
                }
            }
            //if (customerRet.DataExtRetList != null)
            //{
            //    for (int i = 0; i < customerRet.DataExtRetList.Count; i++)
            //    {
            //        IDataExtRet DataExtRet = customerRet.DataExtRetList.GetAt(i131);
            //        //Get value of OwnerID
            //        if (DataExtRet.OwnerID != null)
            //        {
            //            customerdal.OwnerID = (string)DataExtRet.OwnerID.GetValue();
            //        }
            //        //Get value of DataExtName
            //        customerdal.DataExtName = (string)DataExtRet.DataExtName.GetValue();
            //        //Get value of DataExtType
            //        ENDataExtType DataExtType = (ENDataExtType)DataExtRet.DataExtType.GetValue();
            //        //Get value of DataExtValue
            //        customerdal.DataExtValue = (string)DataExtRet.DataExtValue.GetValue();
            //    }
            //}

            return customerdal;
        }
    }
}
