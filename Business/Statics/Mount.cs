using Business.DTO;
using System.Collections.Generic;

namespace Business.Statics
{
    public static class Mount
    {
        public static List<KodDTO> Mounts = new List<KodDTO>() { new KodDTO(-1,"Seçiniz"), 
                                                                 new KodDTO(1,"Ocak"),
                                                                 new KodDTO(2,"Şubat"),
                                                                 new KodDTO(3,"Mart"),
                                                                 new KodDTO(4,"Nisan"),
                                                                 new KodDTO(5,"Mayıs"),
                                                                 new KodDTO(6,"Haziran"),
                                                                 new KodDTO(7,"Temmuz"),
                                                                 new KodDTO(8,"Ağustos"),
                                                                 new KodDTO(9,"Eylül"),
                                                                 new KodDTO(10,"Ekim"),
                                                                 new KodDTO(11,"Kasım"),
                                                                 new KodDTO(12,"Aralık")
        };
    }
}
