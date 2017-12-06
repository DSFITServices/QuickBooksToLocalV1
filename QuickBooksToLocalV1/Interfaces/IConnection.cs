using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBooksToLocalV1.Interfaces
{
    public interface IConnection<T>
    {
        /// <summary>
        /// Connect to Dataservice
        /// IE   Database Web Ect
        /// </summary>
        /// <returns>session</returns>
        T DbConnect(T obj);

        /// <summary>
        /// Closes Data Service
        /// </summary>
        /// <param name="obj">session</param>
        /// <returns>True or False</returns>
        bool DbClose(T obj);
        
    }
}
