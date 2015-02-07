﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using Northwind.Core;
using Northwind.Wcf.Dtos;
using SharpArch.Wcf;

namespace Northwind.Wcf
{
    /// <summary>
    /// This inherits from <see cref="SharpArch.Wcf.ICloseableAndAbortable" /> so that it can be 
    /// interchanged with a WCF client proxy without having to worry about if you can call Close() 
    /// and Abort() on it.  In this way, you can treat everything as if it were a client proxy 
    /// which needs to be disposed with Close/Abort.
    /// </summary>
    [ServiceContract]
    public interface ITerritoriesWcfService : ICloseableAndAbortable
    {
        /// <summary>
        /// Returns all territories as DTOs.
        /// </summary>
        /// <returns>
        /// Although this returns an IList, an argument can be made for making it IEnumerable to 
        /// make the client less coupled to a specific list interface.
        /// </returns>
        [OperationContract]
        IList<TerritoryDto> GetTerritories();
    }
}
