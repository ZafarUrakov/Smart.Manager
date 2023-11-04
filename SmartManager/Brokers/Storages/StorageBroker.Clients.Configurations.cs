//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using Microsoft.EntityFrameworkCore;
using SmartManager.Models.Students;

namespace SmartManager.Brokers.Storages
{
    public partial class StorageBroker
    {
        //private static void AddStudentConfigurations(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>()
        //        .HasKey(student =>
        //        new { student.GroupId });

        //    modelBuilder.Entity<Student>()
        //        .HasOne(student => student)
        //        .WithMany(group => group.Students)
        //        .HasForeignKey(student => student.GroupId)
        //        .OnDelete(DeleteBehavior.NoAction);
    }
}
