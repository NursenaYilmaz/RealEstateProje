using REALESTATE_DAPPER_API.Models.dappercontext;
using REALESTATE_DAPPER_API.Repositories.AppUserRepositories;
using REALESTATE_DAPPER_API.Repositories.BottomGridRepositories;
using REALESTATE_DAPPER_API.Repositories.CategoryRepository;
using REALESTATE_DAPPER_API.Repositories.ContactRepositories;
using REALESTATE_DAPPER_API.Repositories.EmployeeRepositories;
using REALESTATE_DAPPER_API.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;
using REALESTATE_DAPPER_API.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;
using REALESTATE_DAPPER_API.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using REALESTATE_DAPPER_API.Repositories.MessageRepositories;
using REALESTATE_DAPPER_API.Repositories.PopularLocationRepositories;
using REALESTATE_DAPPER_API.Repositories.ProductImageRepositories;
using REALESTATE_DAPPER_API.Repositories.ProductRepository;
using REALESTATE_DAPPER_API.Repositories.PropertyAmenityRepositories;
using REALESTATE_DAPPER_API.Repositories.ServiceRepository;
using REALESTATE_DAPPER_API.Repositories.StatisticsRepositories;
using REALESTATE_DAPPER_API.Repositories.SubFeatureRepositories;
using REALESTATE_DAPPER_API.Repositories.TestimonailRepositories;
using REALESTATE_DAPPER_API.Repositories.ToDoListRepositories;
using REALESTATE_DAPPER_API.Repositories.WhoWeAreRepository;

namespace REALESTATE_DAPPER_API.Containers
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddTransient<Context>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IBottomGridRepository, BottomGridRepository>();
            services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
            services.AddTransient<ITestimonialRepository, TestimonialRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IToDoListRepository, ToDoListRepository>();
            services.AddTransient<IStatisticRepository, StatisticRepository>();
            services.AddTransient<IChartRepository, ChartRepository>();
            services.AddTransient<ILastProductsRepository, LastProductsRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<IAppUserRepository, AppUserRepository>();
            services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
            services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();
        }
    }
}
