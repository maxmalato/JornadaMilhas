using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemTest
{
    [Fact(DisplayName = "Validar uma oferta de viagem com sucesso")]
    public void OfertaViagem_Valida_Sucesso()
    {
        // arrange (Cenário)
        var rota = new Rota("OrigemTeste", "DestinoTeste");
        var periodo = new Periodo(new DateTime(2026, 12, 01), new DateTime(2026, 12, 02));
        var preco = 123.45;
        var validacao = true;

        // act (Ação)
        OfertaViagem ofertaViagem = new OfertaViagem(rota, periodo, preco);

        // asserts (Validação)
        Assert.Equal(validacao, ofertaViagem.EhValido);
    }

    [Fact(DisplayName = "Validar uma oferta com rota nula")]
    public void OfertaViagem_RotaNula()
    {
        // arrange
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2026, 12, 01), new DateTime(2026, 12, 02));
        var preco = 123.45;

        // act
        OfertaViagem ofertaViagem = new OfertaViagem(rota, periodo, preco);

        //asserts
        Assert.Contains("Erro: A oferta de viagem não possui uma rota válida", ofertaViagem.Erros.Sumario);
        Assert.False(ofertaViagem.EhValido);
    }

    [Fact(DisplayName = "Validar a data de início for maior que a data final")]
    public void OfertaViagem_DataInicioMaiorQueDataFinal()
    {
        // arrange
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(new DateTime(2026, 12, 02), new DateTime(2026, 12, 01));
        var preco = 123.4;

        // act
        OfertaViagem ofertaViagem = new OfertaViagem(rota, periodo, preco);

        // assert
        Assert.Contains("Erro: Data de ida não pode ser maior que a data de volta.", ofertaViagem.Erros.Sumario);
        Assert.False(ofertaViagem.EhValido);
    }
}