using backend_app.Data;
using backend_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly ILogger<EmpresasController> _logger;
        private readonly DataContext _context;

        public EmpresasController(ILogger<EmpresasController> logger, DataContext context){
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetEmpresas")]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas(){
            return await _context.Empresas.ToListAsync();
        }

        [HttpGet("{id:int}", Name = "GetEmpresa")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id){
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa==null)
            {
                return NotFound();
            }
            return empresa;
        }
        
        /* metodo de tipo empresa */
        [HttpGet("{rfc}", Name = "ExisteEmpresa")]
        public async Task<ActionResult<Empresa>> ExisteEmpresa(String rfc){
            
            var empresa = await _context.Empresas.Where(e => e.Rfc == rfc).FirstOrDefaultAsync<Empresa>();
            if (empresa==null)
            {
                return NotFound();
            }
            return empresa;
        }

        [HttpPost]
        public async Task<ActionResult<Empresa>> Post(Empresa empresa){
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetEmpresa", new {id = empresa.Id}, empresa);
        }

        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, Empresa empresa){
            if (id != empresa.Id)
            {
                return BadRequest();
            }
            _context.Entry(empresa).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Empresa>> Delete(int id){
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa==null)
            {
                return NotFound();
            }
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return empresa;
        }
    }
}