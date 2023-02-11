using BuildApiApp.Models;
using BuildApiApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuildApiApp.Controllers
{
    // /api/Project //Get 
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IGenericRepository<Project> _projectRepository;

        public ProjectController(IGenericRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public ActionResult<List<Project>> Get()
        {
            var project = _projectRepository.GetAll();
            return project;
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public ActionResult<Project> Get(Guid id)
        {
            var project = _projectRepository.GetById(id);
            if(project == null)
            {
                return BadRequest();
            }
            return project;
        }

        // POST api/<ProjectController>
        [HttpPost]
        public ActionResult<Project> Post([FromBody] Project project)
        {
            project.Id = new Guid();
            _projectRepository.Insert(project);
            _projectRepository.Save();
            return Ok(new { message="Added Success"});
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public ActionResult<Project> Put([FromBody] Project project)
        {
            var proj = _projectRepository.GetById(project.Id);
            proj.ProjectName = project.ProjectName;
            _projectRepository.Update(proj);
            _projectRepository.Save();
            return Ok(new { message="Updated Success"});
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public ActionResult<Project> Delete(Guid id)
        {
            var project = _projectRepository.GetById(id);
            _projectRepository.Delete(project);
            _projectRepository.Save();
            return Ok(new { message = "Deleted Success" });
        }
    }
}
