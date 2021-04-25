using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Constants
{
    static class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün adi minimum 2 karakter olmalidir.";
        public static string ProductPriceInvalid = "Ürün fiyatı sıfırdan büyük olmalıdır.";
        public static string ProductDeletedSuccessfuly = "Ürün silme başarılı.";
        public static string ProductUpdatedSuccessfuly = "Ürün başarıyla güncellendi.";
        public static string CarIsNotReturned = "Araba teslim edilmemişken kiralanamaz.";
        public static string CarImageCountRangeIsExceeded = "En fazla 5 tana araba resmi eklenebilir.";
        public static string CarHasNoImage = "Arabanin resmi yok, default bir resim gosteriliyor.";
    }
}
