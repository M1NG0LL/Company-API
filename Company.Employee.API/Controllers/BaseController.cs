using AutoMapper;
using ClosedXML.Excel;
using Company.Employee.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Company.Employee.API.Controllers
{
    [ApiController]
    public class BaseController<TDomain, TDto, TCreateDto, TUpdateDto> 
        : ControllerBase where TDomain : class
    {
        private readonly IRepository<TDomain> repository;
        private readonly IMapper mapper;

        public BaseController(IRepository<TDomain> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await repository.GetAllAsync();
            return Ok(mapper.Map<List<TDto>>(entities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<TDto>(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Create(TCreateDto createDto)
        {
            var entity = mapper.Map<TDomain>(createDto);
            var createdEntity = await repository.CreateAsync(entity);
            return Ok(mapper.Map<TDto>(createdEntity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TUpdateDto updateDto)
        {
            var existingEntity = await repository.GetByIdAsync(id);
            if (existingEntity == null)
                return NotFound();

            mapper.Map(updateDto, existingEntity);
            await repository.UpdateAsync(existingEntity);
            return Ok("Employee is Updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedEntity = await repository.DeleteAsync(id);
            if (deletedEntity == null)
                return NotFound();

            return Ok("Employee is deleted successfully.");
        }

    }
}
