using FluentValidation.Results;
using SerieFlix.Domain.EntitiesValidators;

namespace SerieFlix.Domain.Entities
{
    public class Serie : EntityBase
    {
        protected Serie() { }

        public Serie(Genero genero, string titulo, string descricao, int ano, bool excluido)
        {
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = excluido;
        }

        public Genero Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public bool Excluido { get; set; }

        #region [Methods]

        public void Excluir()
        {
            this.Excluido = true;
        }

        public override ValidationResult Validate() => new SerieValidators().Validate(this);


        #endregion
    }
}
