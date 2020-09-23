using Architecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Database
{
    public sealed class CheckHistoryConfiguration : IEntityTypeConfiguration<CheckHistory>
    {
        public void Configure(EntityTypeBuilder<CheckHistory> builder)
        {
            builder.ToTable(nameof(CheckHistory), nameof(CheckHistory));
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(c => c.CheckDate).IsRequired();
            builder.Property(c => c.IsWork).IsRequired();
            builder.Property(c => c.MessageCode).IsRequired();

            builder.HasOne(c => c.TargetApp);
        }
    }
}
