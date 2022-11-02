using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class LabController : Controller
{
    private readonly LabManagerContext _context;

    public LabController(LabManagerContext context) {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Labs);
    }

    public IActionResult Show(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }

        return View(lab);
    }

    public IActionResult Delete(int id)
    {
        _context.Labs.Remove(_context.Labs.Find(id));
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    public IActionResult ValidacaoCadastro([FromForm] int id, [FromForm] int number, [FromForm] string name, [FromForm] string block)
    {
        if(_context.Labs.Find(id) != null)
        {
            return View(id);
        }
        else
        {
            _context.Labs.Add(new Lab(id, number, name, block));
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

    public IActionResult Atualizacao(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }

        return View(lab);
    }

    public IActionResult Update([FromForm] int id, [FromForm] int number, [FromForm] string name, [FromForm] string block)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab != null)
        {
            lab.Number = number;
            lab.Name = name;
            lab.Block = block;
            _context.Labs.Update(lab);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}