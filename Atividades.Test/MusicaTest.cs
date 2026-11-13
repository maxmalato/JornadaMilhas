namespace Atividades.Test;

public class MusicaTest
{
    [Fact(DisplayName = "Valida se uma música é criada com nome")]
    public void Musica_Com_Nome_Valido()
    {
        // arrange
        var nomeMusica = "Nome da música";

        // act
        var musica = new Musica(nomeMusica);

        // assert
        Assert.Equal(nomeMusica, musica.Nome);
    }

    [Fact(DisplayName = "Valida o identificador da música iniciado corretamente")]
    public void Musica_Identificador_Valido()
    {
        // arrange
        var nomeMusica = "Nome da música para teste";
        var identificadorMusica = 10;

        // act
        var musica = new Musica(nomeMusica) { Id = identificadorMusica };

        // assert
        Assert.Equal(identificadorMusica, musica.Id);
    }

    [Fact(DisplayName = "Valida a saída do método ToString")]
    public void Musica_ToString_Valido()
    {
        // arrange
        var nomeMusica = "Nome da música com método ToString";
        var identificadorMusica = 13;

        var musica = new Musica(nomeMusica)
        {
            Id = identificadorMusica
        };

        var toStringEsperado = $@"Id: {identificadorMusica} Nome: {nomeMusica}";

        // act
        var resultado = musica.ToString();

        // assert
        Assert.Equal(toStringEsperado, resultado);
    }
}