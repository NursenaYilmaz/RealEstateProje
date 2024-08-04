using REALESTATE_DAPPER_API.Dtos.ToDoListDtos;

namespace REALESTATE_DAPPER_API.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoList();
        Task CreateToDoList(CreateToDoListDto ToDoListDto);
        Task DeleteToDoList(int id);

        Task UpdateToDoList(UpdateToDoListDto ToDoListDto);
        Task<GetByIdToDoListDto> GetToDoList(int id);

    }
}
