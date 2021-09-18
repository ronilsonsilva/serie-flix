using SerieFlix.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SerieFlix.Tests.MockData
{
    /// <summary>
    /// Série com anos inválidos. Considerado anos inválidos:
    ///  - Valor menor ou igual a zero.
    ///  - Valor maior que ano corrente.
    /// </summary>
    public class SerieComAnoInvalidosMock : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] 
            {
                new Serie(genero: Genero.Comedia, titulo: "Auto da Compadecida", descricao: "Comédia no sertão nordestino.", ano: -1, excluido: false),
            };
            yield return new object[] 
            {
                new Serie(genero: Genero.Comedia, titulo: "Auto da Compadecida", descricao: "Comédia no sertão nordestino.", ano: DateTime.Now.Year + 1, excluido: false)
            };
            yield return new object[] 
            {
                new Serie(genero: Genero.Comedia, titulo: "Auto da Compadecida", descricao: "Comédia no sertão nordestino.", ano: 0, excluido: false),
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// Dados de séries com títulos inválidos. Considerado inválidos os seguintes títulos:
    ///  - Vazio
    ///  - null
    ///  - Com tamanho maior que 512 caracteres.
    /// </summary>
    public class SerieComTituloInvalidoMock : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Serie(genero: Genero.Comedia, titulo: string.Empty, descricao: "Comédia no sertão nordestino.", ano: 2004, excluido: false)
            };
            yield return new object[]
            {
                new Serie(genero: Genero.Comedia, titulo: null, descricao: "Comédia no sertão nordestino.", ano: 2004, excluido: false)
            };
            yield return new object[]
            {
                new Serie(genero: Genero.Comedia, titulo: Utils.RandomString(513), descricao: "Comédia no sertão nordestino.", ano: 2004, excluido: false)
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// Objeto séries, deve ser aceito pelo domínio.
    /// </summary>
    public class SerieObjetoValidoMock : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Serie(genero: Genero.Comedia, titulo: "Auto da Compadecida", descricao: "Comédia no sertão nordestino.", ano: 2000, excluido: false)
            };
            yield return new object[]
            {
                new Serie(genero: Genero.Comedia, titulo: Utils.RandomString(1), descricao: Utils.RandomString(356), ano: 2004, excluido: false)
            };
            yield return new object[]
            {
                new Serie(genero: Genero.Comedia, titulo: Utils.RandomString(512), descricao: Utils.RandomString(120), ano: 2012, excluido: false)
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
