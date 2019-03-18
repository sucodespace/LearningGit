﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;
    using System.Configuration;
    public partial class HotelDBEntities : DbContext
    {
        public HotelDBEntities()
            //: base("name=HotelDBEntities")
           :base(GetConnString())
        {
            
        }

        private static string GetConnString()
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["HotelDBEntities"].ConnectionString;
            //如果对字符串做了加密,在下面解密...
            return connString;
        }
        //public HotelDBEntities()
        //{
        //    // base.Database.Connection.ConnectionString = "Server=.;DataBase=HotelDB;Uid=sa;Pwd=password01!";
        //    //如果加密的话，在这里应该是加密后的字符串
        //    var connString = System.Configuration.ConfigurationManager.ConnectionStrings["efDbConnection"].ConnectionString;

        //    //解密：connString（此处省略）
        //    base.Database.Connection.ConnectionString = connString;
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dishes> Dishes { get; set; }
        public virtual DbSet<DishesBook> DishesBook { get; set; }
        public virtual DbSet<DishesCategory> DishesCategory { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsCategory> NewsCategory { get; set; }
        public virtual DbSet<Recruitment> Recruitment { get; set; }
        public virtual DbSet<Suggestion> Suggestion { get; set; }
        public virtual DbSet<SysAdmins> SysAdmins { get; set; }
    }
}