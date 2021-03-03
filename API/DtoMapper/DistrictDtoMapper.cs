using System.Collections.Generic;
using API.Dto;
using DataLayer.Model;

namespace API.DtoMapper
{
    public static class DistrictDtoMapper
    {
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

        public static IEnumerable<DistrictDto> allToDto(this IEnumerable<District> districts)
        {
            var districtsdto = new List<DistrictDto>();
            foreach (District district in districts)
            {
                districtsdto.Add(district.toDto());
            }
            return districtsdto;
        }

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
