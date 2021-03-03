using System.Collections.Generic;
using API.Dto;
using DataLayer.Model;

namespace API.DtoMapper
{
    /// <summary>
    /// Maps A Data Transfer Object to a Database Access Object and vice-versa.
    /// </summary>
    public static class StoreDtoMapper
    {
        /// <summary>
        /// Map DAO object to DTO
        /// </summary>
        /// <param name="store">DAO Store Object</param>
        /// <returns>Mapped DTO Store Object</returns>
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

        /// <summary>
        /// Maps a list of DAO Objects to DTO
        /// </summary>
        /// <param name="stores">List of DAO Store Objects</param>
        /// <returns>List of Mapped DTO Store Objects</returns>
        public static IEnumerable<StoreDto> allToDto(this IEnumerable<Store> stores)
        {
            var storesdto = new List<StoreDto>();
            foreach(Store store in stores)
            {
                storesdto.Add(store.toDto());
            }
            return storesdto;
        }

        /// <summary>
        /// Maps a DTO Object back to a DAO.
        /// </summary>
        /// <param name="storedto">DTO Store Object</param>
        /// <returns>Mapped DAO Store Object</returns>
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
