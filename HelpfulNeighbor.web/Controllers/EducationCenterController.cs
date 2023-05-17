using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelpfulNeighbor.web.Features.Centers;
using HelpfulNeighbor.web.Common;
using HelpfulNeighbor.web.Data;

namespace HelpfulNeighbor.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationCenterController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public EducationCenterController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var educationCenter = _dataContext
                .EducationCenter
                .Select(educationCEnter => new EducationCenterGetDto
                {
                    Id = educationCEnter.Id,
                    Name = educationCEnter.Name,
                    Location = educationCEnter.Location,
                    HoursOfOperation = educationCenter.HoursOfOperation,
                    TypeId = educationCEnter.TypeId,
                })
                .ToList();
            response.Data = educationCenter;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();
            var educationCenterToReturn = _dataContext.EducationCenter.Select(educationCenter => new EducationCenterGetDto
            {
                Id = educationCenter.Id,
                Name = educationCenter.Name,
                Location = educationCenter.Location,
                HoursOfOperation = educationCenter.HoursOfOperation,
                TypeId = educationCenter.TypeId,
            })
                .FirstOrDefault(educationCenter => educationCenter.Id == id);

            if (educationCenterToReturn == null)
            {
                response.AddError("id", "Education Center Could Not Be Found.");
                return BadRequest(response);
            }

            response.Data = educationCenterToReturn;
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EducationCenterCreateDto educationCenterCreateDto)
        {
            var response = new Response();
            if (string.IsNullOrEmpty(educationCenterCreateDto.Name))
            {
                response.AddError("name", "Education Center Name Cannot Be Empty.");
            }
            if (response.HasErrors)
            {
                return BadRequest(Response);
            }

            var educationCenterToAdd = new EducationCenter
            {
                Name = educationCenterCreateDto.Name,
                Location = educationCenterCreateDto.Location,
                HoursOfOperation = educationCenterCreateDto.HoursOfOperation,
                TypeId = educationCenterCreateDto.TypeId,
            };

            _dataContext.EducationCenter.Add(educationCenterToAdd);
            _dataContext.SaveChanges();

            var educationCenterToReturn = new EducationCenterGetDto
            {
                Name = educationCenterToAdd.Name,
                Location = educationCenterToAdd.Location,
                HoursOfOperation = educationCenterToAdd.HoursOfOperation,
                TypeId = educationCenterToAdd.TypeId,
            };

            response.Data = educationCenterToReturn;
            return Created("", Response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] EducationCenterUpdateDto educationCenterUpdateDto)
        {
            var response = new Response();

            var educationCenterToUpdate = _dataContext.EducationCenter.FirstOrDefault(educationCenter => educationCenter.Id == id);
            if (educationCenterToUpdate == null)
            {
                response.AddError("id", "Education Center Could Not Be Found.");
                return BadRequest(response);
            }

            educationCenterToUpdate.Name
        }


    }
}
