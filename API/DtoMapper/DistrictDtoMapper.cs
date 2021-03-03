using System.Collections.Generic;
using API.Dto;
using DataLayer.Model;

namespace API.DtoMapper
{
    /// <summary>
    /// Maps A Data Transfer Object to a Database Access Object and vice-versa.
    /// </summary>
    public static class DistrictDtoMapper
    {
        /// <summary>
        /// Map DAO object to DTO
        /// </summary>
        /// <param name="district">DAO District Object</param>
        /// <returns>Mapped DTO District Object</returns>
        public static DistrictDto toDto(this District district)
        {
            if (district != null)
            {
                return new DistrictDto()
                {
                    ID = district.ID,
                    Name = district.Name,
                    PSPID = district.PSPID,
                    PSPName = district.PSPName,
                    SSPCount = district.SSPCount
                };
            }
            return null;
        }

        /// <summary>
        /// Maps a list of DAO Objects to DTO
        /// </summary>
        /// <param name="districts">List of DAO District Objects</param>
        /// <returns>List of Mapped DTO Districts Objects</returns>
        public static IEnumerable<DistrictDto> allToDto(this IEnumerable<District> districts)
        {
            var districtsdto = new List<DistrictDto>();
            foreach (District district in districts)
            {
                districtsdto.Add(district.toDto());
            }
            return districtsdto;
        }

        /// <summary>
        /// Maps a DTO Object back to a DAO.
        /// </summary>
        /// <param name="districtdto">DTO District Object</param>
        /// <returns>Mapped DAO District Object</returns>
        public static District toDao(this DistrictDto districtdto)
        {
            if (districtdto != null)
            {
                return new District()
                {
                    ID = districtdto.ID,
                    Name = districtdto.Name,
                    PSPID = districtdto.PSPID,
                    PSPName = districtdto.PSPName,
                    SSPCount = districtdto.SSPCount
                };
            }
            return null;
        }


    }
}
