namespace Moosareback.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class ReadingsContext : DbContext
    {
        // Your context has been configured to use a 'Measurements' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SensorApi.Models.Measurements' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Measurements' 
        // connection string in the application configuration file.
        public ReadingsContext() : base("name=Measurements")
        {
            Database.SetInitializer(new ReadingDBInitializer());
        }

        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Bmp180> Bmp180 { get; set; }

        public System.Data.Entity.DbSet<Moosareback.Models.Sht15> Sht15 { get; set; }

        public System.Data.Entity.DbSet<Moosareback.Models.Sdp610> Sdp610 { get; set; }

        public System.Data.Entity.DbSet<Moosareback.Models.CavityTemp> CavityTemps { get; set; }
    }

    public class ReadingDBInitializer : DropCreateDatabaseIfModelChanges<ReadingsContext>
    {
        protected override void Seed(ReadingsContext context)
        {
            IList<Measurement> measurements = new List<Measurement>();

            measurements.Add(new Measurement() { createdAt = "jan 1", msg = 15 });

            foreach (Measurement std in measurements)
                context.Measurements.Add(std);

            base.Seed(context);
        }
    }

    public class Datum
    {
        public double val { get; set; }
        public double time { get; set; }
    }

    public class Measurement
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int EfID { get; set; }
        [Key]
        public Guid _id { get; set; }
        public int ok { get; set; }
        public double msg { get; set; }
        public string sensor { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime time { get; set; }
        public string ip { get; set; }
        public string createdAt { get; set; }

        //public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}