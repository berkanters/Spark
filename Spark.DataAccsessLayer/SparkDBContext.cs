using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spark.Core.Models;

namespace Spark.DataAccsessLayer
{
    public class SparkDBContext:DbContext
    {
        public SparkDBContext(DbContextOptions<SparkDBContext> options) : base(options)
        {

        }
        DbSet<User> Users { get; set; }
    }
}
