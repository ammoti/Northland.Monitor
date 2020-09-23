using Architecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Database
{
    public sealed class TargetAppConfiguration : IEntityTypeConfiguration<TargetApp>
    {
        public void Configure(EntityTypeBuilder<TargetApp> builder)
        {
            builder.ToTable(nameof(TargetApp), nameof(TargetApp));
            builder.HasKey(targetApp => targetApp.Id);
            builder.Property(targetApp => targetApp.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(targetApp => targetApp.Title).IsRequired();
            builder.Property(targetApp => targetApp.Url).IsRequired();
            builder.Property(targetApp => targetApp.Interval).IsRequired();
        }
    }
}
