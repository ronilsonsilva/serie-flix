namespace SerieFlix.WebApp.Core.Models
{

    public class SerieViewModel 
    {
        public SerieViewModel() {}
        public int Id { get; set; }
        public Genero Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public bool Excluido { get; set; }
    }

	public enum Genero
	{
		Acao = 1,
		Aventura = 2,
		Comedia = 3,
		Documentario = 4,
		Drama = 5,
		Espionagem = 6,
		Faroeste = 7,
		Fantasia = 8,
		Ficcao_Cientifica = 9,
		Musical = 10,
		Romance = 11,
		Suspense = 12,
		Terror = 13
	}
}
