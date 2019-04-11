using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WahooDespesa.DataContext;
using WahooDespesa.Model;
namespace WahooDespesa
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FornecedorController : Controller
    {
        private WahooDbContext _context;
        public FornecedorController(WahooDbContext context)
        {
            _context = context;

            if (_context.Fornecedores.Count() == 0)
            {
                _context.Fornecedores.Add(new Fornecedor { CNPJ = "099290919000911", NomeFantasia = "People Fit", RazaoSocial = "People Fit" });
                _context.SaveChanges();
            }

        }

        /// <summary>
        /// API responsável por retornar a lista com todos os fornecedores
        /// </summary>
        /// <returns>A Lista de todos os fornecedores</returns>
        [HttpGet]
        public IEnumerable<Fornecedor> GetAll() {
            return _context.Fornecedores.AsNoTracking().ToList();
        }
        [HttpGet("{id}",Name ="GetFornecedor")]
        public IActionResult GeyById(long id)
        {
            var fornecedor = _context.Fornecedores.FirstOrDefault(f => f.FornecedorId == id);
            if(fornecedor == null)
            {
                return NotFound(); //404
                /*
                 * 200 series -ok
                 * 300 changed
                 * 400 problably your fault
                 * 500 problably my fault
                 */
            }
            return new ObjectResult(fornecedor); //200
        }

        /// <summary>
        /// API responsável pela criação de um novo fornecedor
        /// </summary>
        /// <param name="fornecedor"></param>
        /// <returns>Um novo fornecedor criado</returns>
        /// <response code="201">Retorno o novo fornecedor criado</response>
        /// <response code="400">O objeto passado como parametro não existia (is null)</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody]Fornecedor fornecedor){
           
            if (fornecedor == null){
                return BadRequest(); //400
            }
            _context.Fornecedores.Add(fornecedor);
            _context.SaveChanges();

            return CreatedAtRoute("GetFornecedor", new { id = fornecedor.FornecedorId }, fornecedor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Fornecedor fornecedor) {

            if (fornecedor == null || fornecedor.FornecedorId != id){
                return BadRequest(); //400
            }

            var _fornecedor = _context.Fornecedores.FirstOrDefault(f => f.FornecedorId == id);
            if (_fornecedor == null){
                return NotFound(); //404
            }

            _fornecedor.CNPJ = fornecedor.CNPJ;
            _fornecedor.NomeFantasia = fornecedor.NomeFantasia;
            _fornecedor.RazaoSocial = fornecedor.RazaoSocial;

            _context.Fornecedores.Update(_fornecedor);
            _context.SaveChanges();

            return new NoContentResult();

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id){
            var _fornecedor = _context.Fornecedores.FirstOrDefault(f => f.FornecedorId == id);

            if (_fornecedor == null)
            {
                return NotFound(); //404
            }

            _context.Fornecedores.Remove(_fornecedor);
            _context.SaveChanges();

            return new NoContentResult();

        }
    }
}
