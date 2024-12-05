﻿using ClinicSystem.models;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem
{
    public class AppDbcontext:DbContext
    {

        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {

        }
         
        public DbSet<Clinic> clinics { get; set; }
        public DbSet<Patient> patients { get; set; }

        public DbSet<booking> bookings { get; set; }


    }
}
