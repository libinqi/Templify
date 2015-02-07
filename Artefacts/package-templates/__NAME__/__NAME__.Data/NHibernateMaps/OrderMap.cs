﻿using FluentNHibernate.Automapping;
using Northwind.Core;
using FluentNHibernate.Automapping.Alterations;

namespace Northwind.Data.NHibernateMappings
{
    public class OrderMap : IAutoMappingOverride<Order>
    {
        public void Override(AutoMapping<Order> mapping) {
            mapping.Id(x => x.Id, "OrderID")
                .UnsavedValue(0)
                .GeneratedBy.Identity();

            mapping.Map(x => x.ShipToName, "ShipName");

            mapping.References(x => x.OrderedBy, "CustomerID").Not.Nullable();
        }
    }
}
