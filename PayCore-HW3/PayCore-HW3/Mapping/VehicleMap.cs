using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PayCore_HW3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PayCore_HW3.Mapping
{
    public class VehicleMap: ClassMapping<Vehicle>
    {
        
        public VehicleMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.VehicleName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
               
            });
            Property(b => b.VehiclePlate, x =>
            {
                x.Length(14);
                x.Type(NHibernateUtil.String);
                
            });

            Table("Vehicle");

        }
    }
}
