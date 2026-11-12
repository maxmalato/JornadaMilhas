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

        OfertaViagem ofertaViagem = new OfertaViagem(rota, periodo, preco);

        //asserts
        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", ofertaViagem.Erros.Sumario);
        Assert.False(ofertaViagem.EhValido);
    }
}