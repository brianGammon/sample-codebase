using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTracker.API.Data;
using ProjectTracker.API.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectDbContext _context;
    private readonly JsonSerializerOptions _jsonOptions;

    public ProjectsController(ProjectDbContext context)
    {
        _context = context;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    // GET: api/projects/debug
    [HttpGet("debug")]
    public async Task<ActionResult<object>> GetDebugInfo()
    {
        var count = await _context.Projects.CountAsync();
        var projects = await _context.Projects.ToListAsync();
        var result = new { Count = count, Projects = projects };
        var json = JsonSerializer.Serialize(result, _jsonOptions);
        return Content(json, "application/json");
    }

    // GET: api/projects
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects([FromQuery] string? name, [FromQuery] ProjectStatus? status)
    {
        var query = _context.Projects.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(p => p.Name.Contains(name));
        }

        if (status.HasValue)
        {
            query = query.Where(p => p.Status == status.Value);
        }

        var projects = await query.ToListAsync();
        var json = JsonSerializer.Serialize(projects, _jsonOptions);
        return Content(json, "application/json");
    }

    // GET: api/projects/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetProject(int id)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project == null)
        {
            return NotFound();
        }

        var json = JsonSerializer.Serialize(project, _jsonOptions);
        return Content(json, "application/json");
    }

    // POST: api/projects
    [HttpPost]
    public async Task<ActionResult<Project>> CreateProject(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();

        var json = JsonSerializer.Serialize(project, _jsonOptions);
        return Content(json, "application/json");
    }

    // PUT: api/projects/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(int id, Project project)
    {
        if (id != project.Id)
        {
            return BadRequest();
        }

        _context.Entry(project).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProjectExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    private bool ProjectExists(int id)
    {
        return _context.Projects.Any(e => e.Id == id);
    }
} 