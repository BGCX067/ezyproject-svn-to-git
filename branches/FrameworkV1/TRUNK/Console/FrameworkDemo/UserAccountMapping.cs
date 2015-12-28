using System;
using FluentNHibernate.Mapping;

namespace FrameworkDemo
{
    [Serializable]
    public class UserAccountMapping
        : ClassMap<UserAccount>
    {
        public UserAccountMapping()
        {
            Table("UserAccounts");

            Id(p => p.Id).GeneratedBy.Identity().Not.Nullable();

            Map(p => p.Username)
                .Not.Nullable();
                //.Unique();
            Map(p => p.Email)
                .Not.Nullable();
                //.Unique();
            Map(p => p.Password)
                .Not.Nullable();
            References(x => x.Department).Column("IdDepartment").Cascade.All();
        }
    }

    [Serializable]
    public class DepartmentMapping : ClassMap<Department>
    {
        public DepartmentMapping()
        {
            Table("Department");

            Id(t => t.Id).GeneratedBy.Identity().Not.Nullable();

            Map(t => t.DepartmentName).Not.Nullable();
            
        }
    }
}