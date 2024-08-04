﻿using REALESTATE_DAPPER_API.Dtos.ContactDtos;

namespace REALESTATE_DAPPER_API.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<List<Last4ContactResultDto>> GetLast4Contact();
        Task CreateContact(CreateContactDto createContactDto);
        Task DeleteContact(int id);

        Task<GetByIdContactDto> GetContact(int id);
    }
}
