using BE105_WEEK_8.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE105_WEEK_8.Data.EntityConfigurations
{
    public class StudentConfiguration
    {
       public void Configure(EntityTypeBuilder<Student> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.Property(p=>p.Id).ValueGeneratedOnAdd();
            builder.Property(p=>p.Firstname).IsRequired().HasMaxLength(50);
            builder.Property(p=>p.Lastname).IsRequired().HasMaxLength(50);
            builder.Property(p=>p.StudentNumber).IsRequired().HasMaxLength(50);
            builder.Property(p=>p.BirthDate).IsRequired();
            builder.Property(p=>p.CreatedAt).IsRequired();
            builder.Property(p=>p.LastUpdatedAt).IsRequired();
        }
    }
}
