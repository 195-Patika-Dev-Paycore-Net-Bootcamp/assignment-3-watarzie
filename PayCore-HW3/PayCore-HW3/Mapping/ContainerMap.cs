﻿using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PayCore_HW3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCore_HW3.Mapping
{
    public class ContainerMap:ClassMapping<Container>
    {
        public ContainerMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });
            Property(b => b.ContainerName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);

            });
            Property(b => b.VehicleId, x =>
            {
                x.Type(NHibernateUtil.Int64);

            });
            Property(b => b.Latitude, x =>
            {
                x.Precision(10);
                x.Scale(6);
                x.Type(NHibernateUtil.Double);
            });
            Property(b => b.Longitude, x =>
            {
                x.Precision(10);
                x.Scale(6);
                x.Type(NHibernateUtil.Double);
            });
            Table("Container");
        }
    }
}
