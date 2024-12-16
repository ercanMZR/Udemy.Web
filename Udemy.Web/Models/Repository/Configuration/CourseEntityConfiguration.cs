using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Web.Models.Repository.Entities;

namespace Udemy.Web.Models.Repository.Configuration
{
    public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);//açıklama: primary key tanımlandı.
            builder.Property(x => x.Id).UseIdentityColumn();//açıklama: identity özelliği tanımlandı.
            builder.Property(x => x.Title).HasMaxLength(300).IsRequired();//açıklama: Title alanı için max uzunluk ve zorunluluk tanımlandı.
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();//açıklama: Price alanı için tip ve zorunluluk tanımlandı.
            builder.Property(x => x.ShortDescription).HasMaxLength(300).IsRequired();//açıklama: ShortDescription alanı için max uzunluk ve zorunluluk tanımlandı.
            builder.Property(x => x.LearningGoal).HasMaxLength(500).IsRequired();// açıklama: LearningGoal alanı için max uzunluk ve zorunluluk tanımlandı.
            builder.Property(x => x.Description).IsRequired();//açıklama: Description alanı için zorunluluk tanımlandı.
            builder.Property(x => x.TotalHourTime).IsRequired();//açıklama: TotalHourTime alanı için zorunluluk tanımlandı.
            builder.Property(x => x.PictureFileName).HasMaxLength(200).IsRequired();//açıklama: PictureFileName alanı için max uzunluk ve zorunluluk tanımlandı.bu alanı resim dosyasının adını tutacak.
            builder.Property(x => x.CreatedAt).IsRequired();//açıklama: CreatedAt alanı için zorunluluk tanımlandı.bu alanı oluşturulan tarihi tutacak.
            builder.Property(x => x.CreatedBy).IsRequired();//açıklama: CreatedBy alanı için zorunluluk tanımlandı.Bu alanı oluşturan kullanıcıyı tutacak.
            builder.Property(x => x.IsDeleted).IsRequired();//açıklama: IsDeleted alanı için zorunluluk tanımlandı.Bu alanı silinen kayıtları göstermek için kullanacağız.
            builder.Property(x => x.IsActive).IsRequired();//bu alanı aktif olan kayıtları göstermek için kullanacağız.
            builder.Property(x => x.CategoryId).IsRequired();//açıklama: CategoryId alanı için zorunluluk tanımlandı.Bu alanı kategoriye ait Id'yi tutacak.
            builder.HasOne(x => x.Category).WithMany(x => x.Courses).HasForeignKey(x => x.CategoryId);//açıklama: Course tablosu ile Category tablosu arasında 1-N ilişki tanımlandı.
        }
    }
}
