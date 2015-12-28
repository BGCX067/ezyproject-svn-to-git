using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace FrameworkDemo
{
    public class City
    {
        public virtual int Id { get; protected set; }
        public virtual long Population { get; set; }
        public virtual string Name { get; set; }
        public virtual Municipality Municipality { get; set; }
    }

    public class Municipality
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public ISet<City> Cities { get; set; }
    }


    public class CityMap : ClassMapping<City>
    {
        public CityMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Population);
            Property(x => x.Name, m => m.Length(SqlClientDriver.MaxSizeForLengthLimitedString + 1));
            ManyToOne(x => x.Municipality, m => { m.Cascade(Cascade.All); m.NotNullable(true); });
        }
    }

}
