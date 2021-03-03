using System.Collections.Generic;
using API.Dto;
using DataLayer.Model;

namespace API.DtoMapper
{
    /// <summary>
    /// Maps A Data Transfer Object to a Database Access Object and vice-versa.
    /// </summary>
    public static class SalesPersonDtoMapper
    {
        /// <summary>
        /// Map DAO object to DTO
        /// </summary>
        /// <param name="salesperson">DAO SalesPerson Object</param>
        /// <returns>Mapped DTO SalesPerson Object</returns>
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

        /// <summary>
        /// Maps a list of DAO Objects to DTO
        /// </summary>
        /// <param name="salespersons">List of DAO SalesPersons Objects</param>
        /// <returns>List of Mapped DTO SalesPersons Objects</returns>
        public static IEnumerable<SalesPersonDto> allToDto(this IEnumerable<SalesPerson> salespersons)
        {
            var salespersonsdto = new List<SalesPersonDto>();
            foreach (SalesPerson salesperson in salespersons)
            {
                salespersonsdto.Add(salesperson.toDto());
            }
            return salespersonsdto;
        }

        /// <summary>
        /// Maps a DTO Object back to a DAO.
        /// </summary>
        /// <param name="salespersondto">DTO SalesPerson Object</param>
        /// <returns>Mapped DAO SalesPerson Object</returns>
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
