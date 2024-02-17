using desafioRH.Context;
using desafioRH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace desafioRH.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly RecursosHumanosContext _context;
        private readonly RegistroLogContext _logContext;

        public FuncionariosController(RecursosHumanosContext context, RegistroLogContext logContext)
        {
            _context = context;
            _logContext = logContext;
        }

        public IActionResult Index()
        {
            var dados = _context.Funcionarios.ToList();            

            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult AddEmployee(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();

                var funcionarioLog = new FuncionarioLog(funcionario, EnumTipoAcao.Admissao, funcionario.Departamento, DateTimeOffset.Now);
                funcionarioLog.TipoAcao = EnumTipoAcao.Admissao;
                _logContext.FuncionarioLogs.Add(funcionarioLog);
                _logContext.SaveChanges();

                return RedirectToAction(nameof(Index), new {id = funcionario.Id});
            }

            return View(funcionario);
        }


        public IActionResult Edit(int Id)
        {
            var funcionario = _context.Funcionarios.Find(Id);

            if (funcionario == null)
                return RedirectToAction(nameof(Index));

            return View(funcionario);
        }

        [HttpPost, ActionName("Edit")]

        public IActionResult Save(Funcionario funcionario)
        {
            var editarFuncionario = _context.Funcionarios.Find(funcionario.Id);

            editarFuncionario.Nome = funcionario.Nome;
            editarFuncionario.Endereco = funcionario.Endereco;
            editarFuncionario.Salario = funcionario.Salario;
            editarFuncionario.Ramal = funcionario.Ramal;
            editarFuncionario.Departamento = funcionario.Departamento;
            editarFuncionario.EmailCorporativo = funcionario.EmailCorporativo;
           

          
            _context.SaveChanges();

            var funcionarioLog = new FuncionarioLog(funcionario, EnumTipoAcao.Alteracao, funcionario.Departamento, DateTimeOffset.Now);
            funcionarioLog.TipoAcao = EnumTipoAcao.Alteracao;
            _logContext.FuncionarioLogs.Add(funcionarioLog);
            _logContext.SaveChanges();

            return RedirectToAction(nameof(Index));
           
        }

        public IActionResult Detail(int Id)
        {
            var funcionario = _context.Funcionarios.Find(Id);

            if (funcionario == null)
                return RedirectToAction(nameof(Index));

            return View(funcionario);
        } 

        public IActionResult Delete(int Id)
        {
            var funcionario = _context.Funcionarios.Find(Id);

            if (funcionario == null)
                return RedirectToAction(nameof(Index));

            return View(funcionario);
        }

        public IActionResult DeleteEmployee(int Id)
        {
            var deletarFuncionario = _context.Funcionarios.Find(Id);

            var funcionarioLog = new FuncionarioLog(deletarFuncionario, EnumTipoAcao.Demissao, deletarFuncionario.Departamento, DateTimeOffset.Now);
            funcionarioLog.TipoAcao = EnumTipoAcao.Demissao;

            _logContext.FuncionarioLogs.Add(funcionarioLog);
            _logContext.SaveChanges();

            _context.Remove(deletarFuncionario);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }




    }
}
