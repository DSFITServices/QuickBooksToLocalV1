using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBFC13Lib;
using QuickBooksToLocalV1.Model;

namespace QuickBooksToLocalV1.Interfaces
{
    interface IDbCurd<T>
    {
        /// <summary>
        /// Create a new Obj
        /// Creates a new Obj to save to Dataservice
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>T object</returns>
        //T DbCreate(T obj);
        
        /// <summary>
        /// Update itemn in Dataservice
        /// </summary>
        /// <param name="obj">Data to de Updated</param>
        /// <returns>Data</returns>
        T DbUpdate(T obj);

        /// <summary>
        /// Reads All or some of the Data
        /// From Data Service
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //ObservableCollection<T> DbRead(T obj);

        /// <summary>
        /// Delete data From Dataservice
        /// </summary>
        /// <param name="dbID">ID of Data to be deleted</param>
        /// <returns></returns>
        //string DbDelete(string dbID;


    }
}
