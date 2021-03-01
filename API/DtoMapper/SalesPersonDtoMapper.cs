using System.Collections.Generic;
using API.Dto;
using DataLayer.Model;

namespace API.DtoMapper
{
    public static class SalesPersonDtoMapper
    {
        public static SalesPersonDto toDto(this SalesPerson salesperson)
        {
            if (salesperson != null)
            {
                return new SalesPersonDto()
                {
                    ID = salesperson.ID,
                    Name = salesperson.Name,
                    Surname = salesperson.Surname
                };
            }
            return null;
        }

        public static IEnumerable<SalesPersonDto> allToDto(this IEnumerable<SalesPerson> salespersons)
        {
            var salespersonsdto = new List<SalesPersonDto>();
            foreach (SalesPerson salesperson in salespersons)
            {
                salespersonsdto.Add(salesperson.toDto());
            }
            return salespersonsdto;
        }

        public static SalesPerson toDao(this SalesPersonDto salespersondto)
        {
            if (salespersondto != null)
            {
                return new SalesPerson()
                {
                    ID = salespersondto.ID,
                    Name = salespersondto.Name,
                    Surname = salespersondto.Surname
                };
            }
            return null;
        }
    }
}
