using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CemeterySystem.Entities;

namespace CemeterySystem.EntityFrameworkCore.Seed.Data
{
    public class SeedData
    {
        public static List<Region> LoadRegions() => new()
        {
            new Region { Id = 1, NameAr = "المنطقة الشرقية", NameEn = "EAMANA", IsDeleted = false },
        };
        public static List<City> LoadCities() => new()
        {
            new City { Id = 1,NameAr = "الدمام", IsDeleted=false, RegionId = 1 },
            new City { Id = 2,NameAr = "الظهران", IsDeleted=false, RegionId = 1 },
            new City { Id = 3,NameAr = "الخبر", IsDeleted=false, RegionId = 1 },
            new City { Id = 4,NameAr = "القطيف", IsDeleted=false, RegionId = 1 },
            new City { Id = 5,NameAr = "سيهات", IsDeleted=false, RegionId = 1 },
            new City { Id = 6,NameAr = "تاروت", IsDeleted=false, RegionId = 1 },
            new City { Id = 7,NameAr = "عنك", IsDeleted=false, RegionId = 1 },
            new City { Id = 8,NameAr = "صفوى", IsDeleted=false, RegionId = 1 },
            new City { Id = 9,NameAr = "", IsDeleted=false, RegionId = 1 },
            new City { Id = 10,NameAr = "راس تنورة", IsDeleted=false, RegionId = 1 },
            new City { Id = 11,NameAr = "الجبيل", IsDeleted=false, RegionId = 1 }
        };

        public static List<District> LoadDistricts() => new()
        {
            new District { Id = 1, NameAr = "المريكبات", IsDeleted=false, CityId = 1 },
            new District { Id = 2, NameAr = "الاسكان", IsDeleted=false, CityId = 1 },
            new District { Id = 3, NameAr = "البساتين", IsDeleted=false, CityId = 1 },
            new District { Id = 4, NameAr = "الروضة", IsDeleted=false, CityId = 1 },
            new District { Id = 5, NameAr = "الريان", IsDeleted=false, CityId = 1 },
            new District { Id = 6, NameAr = "المطار", IsDeleted=false, CityId = 1 },
            new District { Id = 7, NameAr = "الصناعية الأولى", IsDeleted=false, CityId = 1 },
            new District { Id = 8, NameAr = "النزهة", IsDeleted=false, CityId = 1 },
            new District { Id = 9, NameAr = "الفيصلية", IsDeleted=false, CityId = 1 },
            new District { Id = 10,NameAr = "السيف", IsDeleted=false, CityId = 1 },
            new District { Id = 11,NameAr = "الجامعيين", IsDeleted=false, CityId = 1 },
            new District { Id = 12,NameAr = "المنار", IsDeleted=false, CityId = 1 },
            new District { Id = 13,NameAr = "الأمانة", IsDeleted=false, CityId = 1 },
            new District { Id = 14,NameAr = "النهضة", IsDeleted=false, CityId = 1 },
            new District { Id = 15,NameAr = "الفردوس", IsDeleted=false, CityId = 1 },
            new District { Id = 16,NameAr = "الندى", IsDeleted=false, CityId = 1 },
            new District { Id = 17,NameAr = "الواحة", IsDeleted=false, CityId = 1 },
            new District { Id = 18,NameAr = "المنتزة", IsDeleted=false, CityId = 1 },
            new District { Id = 19,NameAr = "الدوحة الجنوبية", IsDeleted=false, CityId = 2 },
            new District { Id = 20,NameAr = "القصور", IsDeleted=false, CityId = 2 },
            new District { Id = 21,NameAr = "القشلة", IsDeleted=false, CityId = 2 },
            new District { Id = 22,NameAr = "الدانة الشمالية", IsDeleted=false, CityId = 2 },
            new District { Id = 23,NameAr = "الدوحة الشمالية", IsDeleted=false, CityId = 2 },
            new District { Id = 24,NameAr = "الدانة الجنوبية", IsDeleted=false, CityId = 2 },
            new District { Id = 25,NameAr = "الجامعة", IsDeleted=false, CityId = 2 },
            new District { Id = 26,NameAr = "جامعة الملك فهد للبترول والمعادن", IsDeleted=false, CityId = 2 },
            new District { Id = 27,NameAr = "غرب الظهران", IsDeleted=false, CityId = 2 },
            new District { Id = 28,NameAr = "الحرس الوطني", IsDeleted=false, CityId = 2 },
        };

        public static List<Cemetery> LoadCemerties() => new()
        {
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة الثقبة", NameEn = "Thuqba Cemetery", CityId = 1},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة سيهات", NameEn = "Saihat Cemetery", CityId = 1},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة الدمام", NameEn = "Dammam Cemetery", CityId = 1},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة الدمام القديمة", NameEn = "Dammam Old Cemetery", CityId = 1},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة عنك", NameEn = "Anak Cemetery", CityId = 1},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة أم الحمام", NameEn = "Umm Al-Hamam Cemetery", CityId = 1},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة الخبَّـاقة", NameEn = "Al-Khabbaga Cemetery", CityId = 2},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة الدبابية", NameEn = "Dababiyyah Cemetery", CityId = 1},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة رشالا (القديح)", NameEn = "Rashalah Cemetery", CityId = 2},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة رأس تنورة", NameEn = "Ras Tanura Cemetery", CityId = 2},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة تاروت", NameEn = "Tarout Cemetery", CityId = 2},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة عين دار الجديدة", NameEn = "New Ain Dar Cemetery", CityId = 1},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "المقبرة الجنوبية", NameEn = "Southern Cemetery", CityId = 1},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة بقيق", NameEn = "Buqayq Cemetery", CityId = 2},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة عريعرة", NameEn = "Urayarah Cemetery", CityId = 2},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة الخفجي", NameEn = "Al Khafji Cemetery", CityId = 2},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "المقبرة الغربية", NameEn = "Western Cemetery", CityId = 2},
            new Cemetery{Id = Guid.NewGuid(), NameAr = "مقبرة بقيق الجديدة", NameEn = "New Buqayq Cemetery", CityId = 2 }
        };
    }
}
