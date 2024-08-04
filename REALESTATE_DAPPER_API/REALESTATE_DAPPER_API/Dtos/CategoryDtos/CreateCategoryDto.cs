namespace REALESTATE_DAPPER_API.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName {  get; set; }
        public object? CategoryStatus { get; internal set; }
    }
}
