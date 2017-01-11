using FluentNHibernate.Mapping;

namespace CrudMVC_FluentNhibernate.Models
{
    public class AlunoMap : ClassMap<Aluno>
    {
        public AlunoMap()
        {
            Table("Alunos");
            Id(x => x.Id, "Id").GeneratedBy.Identity();
            Map(x => x.Nome, "Nome").Length(50).Not.Nullable();
            Map(x => x.Email, "Email").Length(100).Not.Nullable();
            Map(x => x.Curso, "Curso").Length(50).Not.Nullable();
            Map(x => x.Sexo, "Sexo").Length(50).Not.Nullable();
            Map(x => x.DataCursoInicial, "DataCursoInicial").Not.Nullable();    
        }
    }
}
