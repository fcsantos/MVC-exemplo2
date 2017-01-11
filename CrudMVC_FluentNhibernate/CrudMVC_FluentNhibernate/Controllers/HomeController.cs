using CrudMVC_FluentNhibernate.Models;
using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CrudMVC_FluentNhibernate.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.Factory.OpenSession())
            {
                var alunos = session.Query<Aluno>().ToList();
                return View(alunos);
            }
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.Factory.OpenSession())
            {
                var aluno = session.Get<Aluno>(id);
                return View(aluno);
            }
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            var model = new Aluno();
            if (model.Gender == null)
            {
                model.Gender = new SelectList(new List<SelectListItem>()
                {
                    new SelectListItem() { Text= "Masculino", Value = "Masculino" },
                    new SelectListItem() { Text= "Feminino", Value = "Masculino"}
                }, "Value", "Text");
            }
            return View(model);
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {
            try
            {
                using (ISession session = NHibernateHelper.Factory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(aluno);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.Factory.OpenSession())
            {
                var aluno = session.Get<Aluno>(id);
                if (aluno.Gender == null)
                {
                    aluno.Gender = new SelectList(new List<SelectListItem>()
                    {
                        new SelectListItem() { Text= "Masculino", Value = "Masculino" },
                        new SelectListItem() { Text= "Feminino", Value = "Feminino"}
                    }, "Value", "Text");
                }
                return View(aluno);
            }
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Aluno aluno)
        {
            try
            {
                using (ISession session = NHibernateHelper.Factory.OpenSession())
                {
                    var alunoAlterado = session.Get<Aluno>(id);

                    alunoAlterado.Sexo = aluno.Sexo;
                    alunoAlterado.Curso = aluno.Curso;
                    alunoAlterado.Email = aluno.Email;
                    alunoAlterado.Nome = aluno.Nome;
                    alunoAlterado.DataCursoInicial = aluno.DataCursoInicial;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(alunoAlterado);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.Factory.OpenSession())
            {
                var aluno = session.Get<Aluno>(id);
                return View(aluno);
            }
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Aluno aluno)
        {
            using (ISession session = NHibernateHelper.Factory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        aluno = session.Get<Aluno>(id);
                        session.Delete(aluno);
                        transaction.Commit();

                        return RedirectToAction("Index");
                    }
                    catch (System.Exception)
                    {
                        transaction.Rollback();
                        return View(aluno);
                    }
                }
            }
        }
    }
}