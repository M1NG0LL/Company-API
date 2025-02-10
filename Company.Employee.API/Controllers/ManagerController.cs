using AutoMapper;
using Company.Employee.API.Model.DTOs.Manager;
using Company.Employee.API.Repositories;
using Company.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : BaseController<Manager, ManagerDto, CreateManagerDto,  UpdateManagerDto> 
    {
        public ManagerController(IRepository<Manager> repository, IMapper mapper) : base(repository, mapper)
        {
            
        }
    }
}
