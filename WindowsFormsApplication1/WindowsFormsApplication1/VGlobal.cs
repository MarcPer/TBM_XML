using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//meus
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Variáveis globais
    /// </summary>
    public static class VGlobal
    {
        #region Variaveis Globais
        //Variáveis Globais

        #region Estruturas versao 4.01
        //Estruturas versao 4.01
        public class stHeaderCarteira401
        {
            public string cnpjcpf; //CNPJ ou CPF do Titular –CNPJ ou CPF do titular da carteira. 
            public string codcart; //Código Carteira –O objetivo deste campo é identificar diferentes carteiras do mesmo investidor (mesmo CNPJ / CPF). Este é o código interno da carteira no sistema do informante. 
            public string dtposicao; //“Data Posição” –Data da apuração do valor do PL (Patrimônio Líquido) da carteira. Os ativos informados neste layout devem ter seus valores apurados para esta mesma data. 
            public string nome; //Nome da Carteira –Nome do titular da carteira conforme cadastro no CNPJ / CPF.
            public string tpcli; //Tipo de Pessoa –Identifica se é Pessoa Física ou Pessoa Jurídica em consonância com a informação prestada no campo “CNPJ / CPF”. Preencher com: “F”- Pessoa Física “J”– Pessoa Jurídica 
            public string codcntcor; //Código da Conta Corrente –Código para identificação da Carteira (Código do Banco + Código da Agência sem o Dígito + Número da Conta Corrente semo Dígito Verificador) 
            public string nomegestor; //Nome do Gestor/Administrador –Nome do gestor do fundo na “Data Posição” conformecadastro no CNPJ.
            public string cnpjgestor; //CNPJ do Gestor -CNPJ do gestor do fundo na “Data Posição” conformecadastro na Receita Federal. O campo deverá ser preenchido apenas com números.
            public string nomecustodiante; //Nome do Custodiante -Nome do custodiante do fundo na “Data Posição” conforme cadastro no CNPJ.
            public string cnpjcustodiante; //CNPJ do Custodiante -CNPJ do custodiante do fundo na “Data Posição” conforme cadastro na Receita Federal. O campo deverá ser preenchido apenas com números. 
            public string patliq; //PL da Carteira –Patrimônio Líquido de fechamento da Carteira na “Data Posição” (líquido de tributos) PL = Valor dos Ativos + Valores a Receber – Valores a Pagar Caso a Carteira seja de Investimentos Coletivo (Clubes de Investimentos por exemplo), deve seguir o mesmo critério do PL do Fundo. 
            public string tributos; //Valor de Tributos –Valor total dos tributos provisionados (IR + IOF +PIS + COFINS) na “Data Posição”.
            public string valorativos; //Valor dos Ativos - Valor dos ativos acrescidos dos ajustes Mercado Futuro / Net Swap / Prêmio de Opções e demais derivativos na “Data Posição”.
            public string valorreceber; //Valores a Receber -Valores a receber exceto os ajustes Mercado Futuro/ Net Swap / Prêmio de Opções e demais derivativos na “Data Posição”, já considerados em “Valor dos Ativos”
            public string valorpagar;//Valores a Pagar -Valores a pagar exceto os ajustes Mercado Futuro /Net Swap / Prêmio de Opções e demais derivativos na “Data Posição”, já considerados em “Valor dos Ativos”
        };
        public class stHeaderFundo401
        {
            public string isin; //Código para identificação do fundo, fornecido pela BVMF, cujos ativos estejam sendo informados no presente layout.
            public string cnpj; //CNPJ do Fundo –CNPJ do fundo conforme cadastro na Receita Federal. O campo deverá ser preenchido apenas com números.
            public string nome; //Nome do Fundo –Nome do Fundo cadastrado na Receita Federal / CVM  ou nome Fantasia do Fundo.
            public string dtposicao; //Data Posição –Data de apuração do valor da cota do fundo. Os ativos informados neste layout devem ter seus valores apurados para esta mesma data. 
            public string nomeadm; //Nome do Adm. –Nome do administrador do fundo na “Data Posição”, conforme cadastro no CNPJ. 
            public string cnpjadm; //CNPJ do Adm. – CNPJ do administrador do fundo na “Data Posição” conforme cadastro na Receita Federal. O campo deverá ser preenchido apenas com números. 
            public string nomegestor; //Nome do Gestor –Nome do gestor do fundo na “Data Posição” conformecadastro no CNPJ. 
            public string cnpjgestor; //CNPJ do Gestor –CNPJ do gestor do fundo na “Data Posição” conforme cadastro na Receita Federal. O campo deverá ser preenchido apenas com números. 
            public string nomecustodiante; //Nome do Custodiante –Nome do custodiante do fundo na “Data Posição” conforme cadastro no CNPJ.
            public string cnpjcustodiante; //CNPJ do Custodiante –  CNPJ do custodiante do fundo na “Data Posição” conforme cadastro na Receita Federal. O campo deverá ser preenchido apenas com números. 
            public string valorcota; // Valor da Quota –Valor da cota do fundo apurado na “Data Posição”. 
            public string quantidade; //Quantidade –Valor numérico com o estoque de cotas na “Data Posição”.
            public string patliq; //PL do Fundo –  Valor financeiro do PL (Patrimônio Líquido) de fechamento do fundo na “Data Posição”. Os valores são dados em modulo PL = Valor dos Ativos + Valores a Receber – Valoresa Pagar – Cotas a Emitir – Cotas a Resgatar PL = Quantidade de Cotas X Valor das Cotas. Obs:O validador aceitará uma diferença de até R$500,00no valor do somatório do PL do fundo.
            public string valorativos;//Valor dos Ativos –Valor dos ativos acrescidos dos ajustes Mercado Futuro / Net Swap / Prêmio de Opções e demais derivativos na “Data Posição”. Obs:Ativos classificados como “Vendido (V)”, devem terseu “Valor Financeiro ” deduzido do “Valor dos Ativos”. Ativos classificados como “Comprado” (C) devem ter seu “Valor Financeiro” considerados em “Valor dos Ativos” do Header Ativos classificados como “Doado” (D), deverão ter seu “Valor Financeiro” somado para composição do “Valor dos Ativos” do Header. 
            public string valorreceber;//Valores a Receber – Valores a receber exceto os ajustes Mercado Futuro / Net Swap / Prêmio de Opções e demais derivativos, já considerados em “Valor dos Ativos” 
            public string valorpagar; //Valores a Pagar -Valores a pagar exceto os ajustes Mercado Futuro /Net Swap / Prêmio de Opções e demais derivativos, já considerados em “Valor dos Ativos” 
            public string vlcotasemitir; //Cotas a Emitir –Valores em aberto referentes às aplicações no fundo cuja conversão de cotas não ocorreu até a “Data Posição”.
            public string vlcotasresgatar; //Cotas a Resgatar –  Valores em aberto referentes aos resgates de cotistas do fundo e cuja conversão de cotas ocorreu até a “Data Posição”, porém não liquidada financeiramente.
            public string codanbid; //Código ANBIMA –Código do fundo cadastrado na ANBIMA, conforme disponibilizado no sistema SI-ANBIMA. 
            public string tipofundo;//Tipo de Fundo –Código de classificação do Tipo de Fundo da ANBIMA, conforme disponibilizado ao sistema SI ANBIMA. Caso o fundo não seja cadastrado na ANBIMA, ele deverá se cadastrar de acordo com as regras publicadas no site da ANBIMA na seção Fundos de Investimentos opção Classificação http://www.ANBIMA.com.br/Pub/Custodia/Area_Documentos/outros_documentos/Tipo_fundos_ANBIMA.zip 
            public string nivelrsc; //Nível de Risco – Nível de risco segundo estabelecido na RES CMN 3121de 25/09/2003. O campo deverá ser preenchido somente quando o fundo em questão se tratar de FIDC e FICFIDC. Código de Risco dos Ativos:BB – Baixo MM– Médio AA– Alto MA– Médio Alto             
        };
        public class stpartplanprev401
        {
            public string cnpb; //Código CNPB –Código para identificação do Plano de Benefício docotista do fundo ou titular da carteira informado no arquivo de posição. É fornecido pela SPC. Obs:O campo “Código CNPB” não deverá ser preenchido com código superior a 10 dígitos.
            public string percpart; //% de Participação –Percentual da participação do Plano de Benefício no Patrimônio Líquido do Fundo / Carteira informado no Arquivo de Posição. Este campo deverá ser preenchido apenas com números.
        };
        public class sttitpublico401
        {
            //Seção
            public string isin; //Código ISIN-  Código para identificação do Ativo, fornecido pela  BVMF, ou pela Agência de numeração do país que emitiu o papel.
            public string codativo; //Código do Ativo – Código para identificação do tipo de título público, fornecido pelo SELIC ou pelo ambiente de negociação, quando o título for emitidono exterior. 
            public string cusip; //Código CUSIP – Código para identificação do ativo. É fornecido pelo CUSIP ( Service Bureau U. S. and Canadian Companies) 
            public string dtemissao; //Data da Emissão –  Data da emissão do ativo conforme cadastro no SELIC, não podendo ser utilizada a “Data Base”. A “Data de Emissão” é sempre posterior ou igual a “Data Base”. Obs:Data Base é a data de criação do Título pelo emissor (BACEN; Tesouro Nacional).
            public string dtoperacao; //Data da Operação / Compra –  Data em que foi realizada a compra definitiva do papel pelo fundo ou data em que foi realizada a operação compromissada. 
            public string dtvencimento; //Data do Vencimento / Liquidação –  Data do vencimento do ativo (ou do lastro, no caso  de operação compromissada) conforme cadastro no SELIC.
            public string qtdisponivel; //Quantidade Disponível – Quantidade disponível para negociação na “Data Posição”. 
            public string qtgarantia; //Quantidade em Garantia –  Quantidade bloqueada para negociação em margem de garantia de operações (BVMF) na “Data Posição”. 
            public string depgar; //Depositário das Garantias –  Identifica a câmara de liquidação em favor da qual  a garantia está depositada, conforme tabela auxiliar “Depositário das Garantias”. O campo deve ser preenchido se a “Quantidade em Garantia” for diferente de zero.
            public string pucompra; //PU Compra – “Valor Financeiro” pago na aquisição do ativo dividido pela quantidade comprada 
            public string puvencimento; //PU Vencimento –Conforme cadastro no SELIC ou no ambiente de negociação, caso for emitido no exterior. 
            public string puposicao; //PU Posição -. É o valor que está sendo contabilizado no Fundo/Carteira na ““Data Posição””.
            public string puemissao; //PU Emissão – Valor presente do “PU de Vencimento” na data de emissão do papel. Obs: Para casos de títulos pré fixado, o campo “PU de Emissão” deverá ser preenchido com o mesmo valor do campo “PU de Compra” 
            public string principal; //Principal – “PU de Compra” X “Quantidade Total”
            public string tributos; //Valor de Tributos – Valor total dos tributos provisionados (IR + IOF) 
            public string valorfindisp; //Valor Financeiro Disponível –“PU de Posição” X “Quantidade Disponível” 
            public string valorfinemgar; //Valor Financeiro em Garantia – “PU de Posição” X “Quantidade em Garantia” 
            public string coupom; //Cupom -Taxa de compra negociada. Este campo deverá ser preenchido apenas com números. 
            public string indexador; //Indexador –Código do indexador conforme cadastro na Tabela daBVMF. Para consulta de códigos acesse o site: http://www.bmfbovespa.com.br/pt-br/regulacao/horarios-de-negociacao/derivativos.aspx?Idioma=pt-br
            public string percindex; //% do Indexador –  Este percentual refere-se ao indexador da operação.No caso de Títulos pré fixados, preencher 100. Este campo deverá ser preenchido apenas com números. 
            public string caracteristica; //Característica do Titulo –Identificar se o título poderá ser negociado a qualquer momento, ou deverá ser mantido até o seu vencimento. Preencher com: “N”– Negociação “V”– Vencimento 
            public string percprovcred; //% Provisão de Credito – Provisão de perda percentual sobre o valor financeiro bruto disponível na “Data Posição”. Este campo deverá ser preenchido apenas com números. Obs: Os valores preenchidos nos campos “Valor FinanceiroDisponível” e o “Valor Financeiro em Garantia” já são líquidos de provisão de crédito.
            public string classeoperacao; //Classe da Operação - .Identificar a classe da operação. Preencher com: “C”– Comprado “D”– Doado “T”– Tomado “V” - Vendido 
            public string idinternoativo; //Identificador Interno do Ativo – Código interno do ativo conforme cadastro no sistema de origem. 
            public string nivelrsc; //Nível de Risco – Nível de risco segundo estabelecido na RES CMN 3121de 25/09/2003. Códigos de Risco do Ativo: “BB” – Baixo “MM”– Médio “AA”– Alto “MA”– Médio Alto
            //Subseção Compromisso
            public string dtretorno; //Data de Retorno –Data do retorno da operação compromissada.
            public string puretorno; //PU de Retorno –Valor corrigido da operação compromissada divididopela “Quantidade Disponível”. 
            public string indexadorcomp;//Indexador - Código do indexador conforme cadastro na Tabela da BVMF. Para consultar os referidos códigos acesse o site: http://www.bmfbovespa.com.br/pt-br/regulacao/horarios-de-negociacao/derivativos.aspx?Idioma=pt-br
            public string perindexcomp;//Percentual do Indexador -Este percentual refere-se ao indexador da operaçãocompromissada. Este campo deverá ser preenchido apenas com números. 
            public string txoperacao;//Taxa da Operação –Taxa da Operação Compromissada, ao ano. Este campodeverá ser preenchido apenas com números. 
            public string classecomp; //Classe da Compromissada – Identificar a classe da operação compromissada. Preencher com: “C”– Compra com Revenda “V”– Venda com recompra 
            //Subseção Aluguel
            public string dtvencalug;//Data do Vencimento do Aluguel –  Data registrada no depositário como término do aluguel do ativo. Este campo deve ser informado pelas pontas Doadora e Tomadora. 
            public string txalug;//Taxa de Aluguel –Custo, em valor percentual ao ano, a ser pago peloTomador e Doador do ativo. Este campo deverá ser preenchido apenas com números. 
            public string indexadoralug; //Indexador – Código do indexador conforme cadastro na Tabela da BVMF. Para consultar os referidos códigos acesse o site: http://www.bmfbovespa.com.br/pt-br/regulacao/horarios-de-negociacao/derivativos.aspx?Idioma=pt-br
            public string percalug;// Percentual do Indexador do Aluguel –  Este Percentual refere-se ao indexador que se aplica no aluguel. Este campo deverá ser preenchido apenas com números. 

        };
        public class sttitprivado401
        {
            //Seção
            public string isin; //Código ISIN-  Código para identificação do Ativo, fornecido pela  BVMF, ou pela Agência de numeração do país que emitiu o papel.
            public string codativo; //Código do Ativo – Código para identificação do tipo de título público, fornecido pelo SELIC ou pelo ambiente de negociação, quando o título for emitidono exterior. 
            public string cusip; //Código CUSIP – Código para identificação do ativo. É fornecido pelo CUSIP ( Service Bureau U. S. and Canadian Companies) 
            public string dtemissao; //Data da Emissão –  Data da emissão do ativo conforme cadastro no SELIC, não podendo ser utilizada a “Data Base”. A “Data de Emissão” é sempre posterior ou igual a “Data Base”. Obs:Data Base é a data de criação do Título pelo emissor (BACEN; Tesouro Nacional).
            public string dtoperacao; //Data da Operação / Compra –  Data em que foi realizada a compra definitiva do papel pelo fundo ou data em que foi realizada a operação compromissada. 
            public string dtvencimento; //Data do Vencimento / Liquidação –  Data do vencimento do ativo (ou do lastro, no caso  de operação compromissada) conforme cadastro no SELIC.
            public string cnpjemissor; //CNPJ do Emissor -  CNPJ do emissor do título privado na “Data Posição”, conforme cadastro na Receita Federal 
            public string qtdisponivel; //Quantidade Disponível – Quantidade disponível para negociação na “Data Posição”. 
            public string qtgarantia; //Quantidade em Garantia –  Quantidade bloqueada para negociação em margem de garantia de operações (BVMF) na “Data Posição”. 
            public string depgar; //Depositário das Garantias –  Identifica a câmara de liquidação em favor da qual  a garantia está depositada, conforme tabela auxiliar “Depositário das Garantias”. O campo deve ser preenchido se a “Quantidade em Garantia” for diferente de zero.
            public string pucompra; //PU Compra – “Valor Financeiro” pago na aquisição do ativo dividido pela quantidade comprada 
            public string puvencimento; //PU Vencimento –Conforme cadastro no SELIC ou no ambiente de negociação, caso for emitido no exterior. 
            public string puposicao; //PU Posição -. É o valor que está sendo contabilizado no Fundo/Carteira na ““Data Posição””.
            public string puemissao; //PU Emissão – Valor presente do “PU de Vencimento” na data de emissão do papel. Obs: Para casos de títulos pré fixado, o campo “PU de Emissão” deverá ser preenchido com o mesmo valor do campo “PU de Compra” 
            public string principal; //Principal – “PU de Compra” X “Quantidade Total”
            public string tributos; //Valor de Tributos – Valor total dos tributos provisionados (IR + IOF) 
            public string valorfindisp; //Valor Financeiro Disponível –“PU de Posição” X “Quantidade Disponível” 
            public string valorfinemgar; //Valor Financeiro em Garantia – “PU de Posição” X “Quantidade em Garantia” 
            public string coupom; //Cupom -Taxa de compra negociada. Este campo deverá ser preenchido apenas com números. 
            public string indexador; //Indexador –Código do indexador conforme cadastro na Tabela daBVMF. Para consulta de códigos acesse o site: http://www.bmfbovespa.com.br/pt-br/regulacao/horarios-de-negociacao/derivativos.aspx?Idioma=pt-br
            public string percindex; //% do Indexador –  Este percentual refere-se ao indexador da operação.No caso de Títulos pré fixados, preencher 100. Este campo deverá ser preenchido apenas com números. 
            public string caracteristica; //Característica do Titulo –Identificar se o título poderá ser negociado a qualquer momento, ou deverá ser mantido até o seu vencimento. Preencher com: “N”– Negociação “V”– Vencimento 
            public string percprovcred; //% Provisão de Credito – Provisão de perda percentual sobre o valor financeiro bruto disponível na “Data Posição”. Este campo deverá ser preenchido apenas com números. Obs: Os valores preenchidos nos campos “Valor FinanceiroDisponível” e o “Valor Financeiro em Garantia” já são líquidos de provisão de crédito.
            public string classeoperacao; //Classe da Operação - .Identificar a classe da operação. Preencher com: “C”– Comprado “D”– Doado “T”– Tomado “V” - Vendido 
            public string idinternoativo; //Identificador Interno do Ativo – Código interno do ativo conforme cadastro no sistema de origem. 
            public string nivelrsc; //Nível de Risco – Nível de risco segundo estabelecido na RES CMN 3121de 25/09/2003. Códigos de Risco do Ativo: “BB” – Baixo “MM”– Médio “AA”– Alto “MA”– Médio Alto
            //Subseção Compromisso
            public string dtretorno; //Data de Retorno –Data do retorno da operação compromissada.
            public string puretorno; //PU de Retorno –Valor corrigido da operação compromissada divididopela “Quantidade Disponível”. 
            public string indexadorcomp;//Indexador - Código do indexador conforme cadastro na Tabela da BVMF. Para consultar os referidos códigos acesse o site: http://www.bmfbovespa.com.br/pt-br/regulacao/horarios-de-negociacao/derivativos.aspx?Idioma=pt-br
            public string perindexcomp;//Percentual do Indexador -Este percentual refere-se ao indexador da operaçãocompromissada. Este campo deverá ser preenchido apenas com números. 
            public string txoperacao;//Taxa da Operação –Taxa da Operação Compromissada, ao ano. Este campodeverá ser preenchido apenas com números. 
            public string classecomp; //Classe da Compromissada – Identificar a classe da operação compromissada. Preencher com: “C”– Compra com Revenda “V”– Venda com recompra 
            //Subseção Aluguel
            public string dtvencalug;//Data do Vencimento do Aluguel –  Data registrada no depositário como término do aluguel do ativo. Este campo deve ser informado pelas pontas Doadora e Tomadora. 
            public string txalug;//Taxa de Aluguel –Custo, em valor percentual ao ano, a ser pago peloTomador e Doador do ativo. Este campo deverá ser preenchido apenas com números. 
            public string indexadoralug; //Indexador – Código do indexador conforme cadastro na Tabela da BVMF. Para consultar os referidos códigos acesse o site: http://www.bmfbovespa.com.br/pt-br/regulacao/horarios-de-negociacao/derivativos.aspx?Idioma=pt-br
            public string percalug;// Percentual do Indexador do Aluguel –  Este Percentual refere-se ao indexador que se aplica no aluguel. Este campo deverá ser preenchido apenas com números. 
        };
        public class stdebenture401
        {
            public string isin;
            public string coddeb;
            public string debconv;
            public string debpartlucro;
            public string SPE;
            public string cusip;
            public string dtemissao;
            public string dtoperacao;
            public string dtvencimento;
            public string cnpjemissor;
            public string qtdisponivel;
            public string qtgarantia;
            public string depgar;
            public string pucompra;
            public string puvencimento;
            public string puposicao;
            public string puemissao;
            public string principal;
            public string tributos;
            public string valorfindisp;
            public string valorfinemgar;
            public string coupom;
            public string indexador;
            public string percindex;
            public string caracteristica;
            public string percprovcred;
            public string classeoperacao;
            public string idinternoativo;
            public string nivelrsc;
        };
        public class stcaixa401
        {
            public string isininstituicao;
            public string tpconta;
            public string saldo;
            public string nivelrsc;
        };
        public class stcotas401
        {
            public string isin;
            public string cnpjfundo;
            public string qtdisponivel;
            public string qtgarantia;
            public string puposicao;
            public string tributos;
            public string nivelrsc;
        };
        public class stdespesas401
        {
            public string txadm;
            public string tributos;
            public string perctaxaadm;
            public string txperf;
            public string vltxperf;
            public string perctxperf;
            public string percindex;
            public string outtax;
            public string indexador;
        };
        public class stacoes401
        {
            public string isin;
            public string cusip;
            public string codativo;
            public string qtdisponivel;
            public string lote;
            public string qtgarantia;
            public string valorfindisp;
            public string valorfinemgar;
            public string tributos;
            public string puposicao;
            public string percprovcred;
            public string tpconta;
            public string classeoperacao;
            public string dtvencalug;
            public string txalug;
            public string cnpjinter;
        };
        public class stprovisao401
        {
            public string codprov;
            public string credeb;
            public string dt;
            public string valor;
        };
        public class stcorretagem401
        {
            public string cnpjcorretora;
            public string tpcorretora;
            public string numope;
            public string vlbov;
            public string vlrepassebov;
            public string vlbmf;
            public string vlrepassebmf;
            public string vloutbolsas;
            public string vlrepasseoutbol;
        };
        #endregion

        #region Tela
        //Tela
        public static string CaminhoXML;
        public static RichTextBox rtLOG;
        #endregion

        #region Tamanho dos indices dos arquivos
        //Tamanho dos indices dos arquivos 
        public static int[] TamArquivoposicao_4_01;
        public static int[] TamCarteira;
        public static int[] TamFundo;
        public static int[] TamHeader;
        public static int[] TamPartplanprev;
        public static int[] TamTitprivado;
        public static int[] TamTitpublico;
        public static int[] TamDebenture;
        public static int[] TamCaixa;
        public static int[] TamCotas;
        public static int[] TamDespesas;
        public static int[] TamAcoes;
        public static int[] TamProvisao;
        public static int[] TamCorretagem;
        public static int TamTotArquivoposicao_4_01;
        public static int TamTotCarteira;
        public static int TamTotFundo;
        public static int TamTotHeader;
        public static int TamTotPartplanprev;
        public static int TamTotTitprivado;
        public static int TamTotTitpublico;
        public static int TamTotDebenture;
        public static int TamTotCaixa;
        public static int TamTotCotas;
        public static int TamTotDespesas;
        public static int TamTotAcoes;
        public static int TamTotProvisao;
        public static int TamTotCorretagem;
        #endregion

        #region Variáveis de relatorio
        //Variáveis de relatorio
        //Informações do cabeçalho
        public class stInformacoesGerais
        {
            public string DataPosicao;
            public string Item;
            public string Nome;
            public string PatrimonioLiquido;
        }

        //Posição da Carteira
        public class stFundosInvestimento
        {
            public string Classe;
            public string NomeFundo;
            public string ISIN;
            public string QuantidadeCota;
            public string QuantidadeCotaBloqueada;
            public string ValorCota;
            public string ValorBruto;
            public string Imposto;
            public string ValorLiquido;
        }

        //Ativos da Carteira
        public class stCreditoPrivado
        {
            public string CodigoAtivo;
            public string ISIN;
            public string Emissor;
            public string Indexador;
            public string Spread;
            public string DataEmissao;
            public string DataCompra;
            public string DataVencimento;
            public string QuantidadeDisponivel;
            public string QuantidadeGarantia;
            public string PUPosicao;
            public string ValorBruto;
            public string Impostos;
            public string ValorLiquido;
            public string Disponivel;
        }
        public class stTituloPublico
        {
            public string CodigoAtivo;
            public string ISIN;
            public string Indexador;
            public string Spread;
            public string DataEmissao;
            public string DataCompra;
            public string DataVencimento;
            public string QuantidadeDisponivel;
            public string QuantidadeGarantia;
            public string PUPosicao;
            public string ValorBruto;
            public string Impostos;
            public string ValorLiquido;
            public string Disponivel;
        }
        public class stAcoes
        {
        }

        //Exposições e Enquadramentos
        public class stPorSeguimento
        {
        }
        public class stPorEmissor
        {
        }
        #endregion

        #region Globais Gerais
        //Variáveis Globais Gerais
        public static FileInfo[] ListaArquivos;
        public static XmlNodeList xmlnode;

        #endregion

        #endregion
    }
    /*public struct VRelatorio
    {
        VGlobal.stInformacoesGerais[] rlInformacoesGerais = new VGlobal.stInformacoesGerais[VGlobal.TamTotHeader];
        VGlobal.stCreditoPrivado[] rlCreditoPrivado = new VGlobal.stCreditoPrivado[VGlobal.TamTotHeader];
        VGlobal.stTituloPublico[] rlTituloPublico = new VGlobal.stTituloPublico[VGlobal.TamTotHeader];
        VGlobal.stAcoes[] rlAcoes = new VGlobal.stAcoes[VGlobal.TamTotHeader];
        VGlobal.stPorSeguimento[] rlPorSeguimento = new VGlobal.stPorSeguimento[VGlobal.TamTotHeader];
        VGlobal.stPorEmissor[] rlPorEmissor = new VGlobal.stPorEmissor[VGlobal.TamTotHeader];

    
    }*/

}
