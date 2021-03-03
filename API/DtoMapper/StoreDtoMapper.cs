using System.Collections.Generic;
using API.Dto;
using DataLayer.Model;

namespace API.DtoMapper
{
    public static class StoreDtoMapper
    {
        public static StoreDto toDto(this Store store)
        {
            if(store != null)
            {
                return new StoreDto()
                {
                    ID = store.ID,
                    Name = store.Name,
                    Info = store.Info,
                    DistrictID = store.DistrictID,
                    DistrictName = store.DistrictName
                };
            }
            return null;
        }

        public static IEnumerable<StoreDto> allToDto(this IEnumerable<Store> stores)
        {
            var storesdto = new List<StoreDto>();
            foreach(Store store in stores)
            {
                storesdto.Add(store.toDto());
            }
            return storesdto;
        }

        public static Store toDao(this StoreDto storedto)
        {
            if (storedto != null)
            {
                return new Store()
                {
                    ID = storedto.ID,
                    Name = storedto.Name,
                    Info = storedto.Info,
                    DistrictID = storedto.DistrictID,
                    DistrictName = storedto.DistrictName
                };
            }
            return null;
        }
    }
}
