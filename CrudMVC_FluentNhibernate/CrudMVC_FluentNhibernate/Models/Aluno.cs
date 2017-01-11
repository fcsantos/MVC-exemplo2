using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CrudMVC_FluentNhibernate.Models
{
    public class Aluno
    {
        public virtual int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Digite o nome do Aluno")]
        [MaxLength(50, ErrorMessage = "Nome do Aluno está muito grande, favor abreviar")]
        public virtual string Nome { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Digite o e-mail do Aluno")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [MaxLength(100, ErrorMessage = "E-mail está muito grande")]
        public virtual string Email { get; set; }

        [Display(Name = "Curso")]
        [Required(ErrorMessage = "Digite o curso do Aluno")]
        [MaxLength(50, ErrorMessage = "Nome do curso está muito grande, favor abreviar")]
        public virtual string Curso { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Escolha o sexo do Aluno")]
        public virtual string Sexo { get; set; }

        [Display(Name = "Data inicial")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Digite a data Que o Aluno irá iniciar o curso, no seguinte formato 99/99/9999")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]           
        public virtual DateTime DataCursoInicial { get; set; }

        public virtual SelectList Gender { get; set; }
    }
}
