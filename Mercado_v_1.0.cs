using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_V_1._2//Novo modelo feito usando o método struct
{
    class Program
    {
        public struct Mercadorias//     Registro do Mercado
        {// Eu escolhi usar o método de registro
            public string produtos;
            public double precos;
            public int unidades;
            public int codigos;
        }
        public struct Compras//     Registro do cliente
        {
            public string produtos;
            public double preco_total;
            public int unidades;
        }
        static void Main(string[] args)
        {//Programa principal
            Mercadorias[] Estoque = new Mercadorias[15];
            Compras[] NF = new Compras[15];
            double tot = 0;
            bool fim = false;
            while (fim != true)
            {// Menuzinho basico
                Console.WriteLine("***********************************************");
                Console.WriteLine("****         Projeto UMC Mercado           ****");
                Console.WriteLine("***********************************************");
                Console.WriteLine("****      [ 1 ] Comprar produtos           ****");
                Console.WriteLine("****      [ 2 ] Emitir nota Fiscal         ****");
                Console.WriteLine("****      [ 3 ] Formas de pagamento        ****");
                Console.WriteLine("****      [ 4 ] Sair                       ****");
                Console.WriteLine("***********************************************");
                Console.Write("Opção: ");
                int escolha = int.Parse(Console.ReadLine());
                while (escolha < 1 || escolha > 5)
                {
                    Console.WriteLine("Opção inválida, digite novamente");
                    escolha = int.Parse(Console.ReadLine());
                }
                Console.Clear();
                Estoque_1(Estoque);// Todos os produtos serão cadastrador por esse procedimento
                switch (escolha)
                {
                    case 1:
                        Carrinho(Estoque, NF);
                        break;
                    case 2:
                        tot = Nota_fiscal(NF);
                        break;
                    case 3:
                        Pagamento(NF, tot);
                        break;
                    case 4:
                        fim = true;
                        break;
                }
            }
        }// Fim do programa principal
        private static void Estoque_1(Mercadorias[] estoque)//      Cadastro do estoque do mercado
        {
            //Alimentos
            estoque[0].produtos = "Arroz 5kg   ";
            estoque[0].precos = 13.90;
            estoque[0].unidades = 50;
            estoque[0].codigos = 101;

            estoque[1].produtos = "Feijão 1kg  ";
            estoque[1].precos = 3.95;
            estoque[1].unidades = 50;
            estoque[1].codigos = 102;

            estoque[2].produtos = "Macarrão 1kg";
            estoque[2].precos = 1.79;
            estoque[2].unidades = 50;
            estoque[2].codigos = 103;

            estoque[3].produtos = "Corote 300ml";
            estoque[3].precos = 4.20;
            estoque[3].unidades = 50;
            estoque[3].codigos = 104;

            estoque[4].produtos = "Café 500g   ";
            estoque[4].precos = 1.70;
            estoque[4].unidades = 50;
            estoque[4].codigos = 105;
            //Higiene pessoal
            estoque[5].produtos = "Sabonete Liq";
            estoque[5].precos = 15.80;
            estoque[5].unidades = 50;
            estoque[5].codigos = 201;

            estoque[6].produtos = "Shampoo     ";
            estoque[6].precos = 7.90;
            estoque[6].unidades = 50;
            estoque[6].codigos = 202;

            estoque[7].produtos = "Creme dental";
            estoque[7].precos = 3.54;
            estoque[7].unidades = 50;
            estoque[7].codigos = 203;

            estoque[8].produtos = "Desodorante ";
            estoque[8].precos = 17.10;
            estoque[8].unidades = 50;
            estoque[8].codigos = 204;

            estoque[9].produtos = "Fio dental  ";
            estoque[9].precos = 1.20;
            estoque[9].unidades = 50;
            estoque[9].codigos = 205;

            //Limpeza
            estoque[10].produtos = "Desinfetante";
            estoque[10].precos = 8.35;
            estoque[10].unidades = 50;
            estoque[10].codigos = 301;

            estoque[11].produtos = "Alcool 500ml";
            estoque[11].precos = 5.40;
            estoque[11].unidades = 50;
            estoque[11].codigos = 302;

            estoque[12].produtos = "Amaciante 1L";
            estoque[12].precos = 11.20;
            estoque[12].unidades = 50;
            estoque[12].codigos = 303;

            estoque[13].produtos = "Sabão em pó ";
            estoque[13].precos = 4.89;
            estoque[13].unidades = 50;
            estoque[13].codigos = 304;

            estoque[14].produtos = "Sabão liq 1L";
            estoque[14].precos = 12.70;
            estoque[14].unidades = 50;
            estoque[14].codigos = 305;
        }
        private static void Carrinho(Mercadorias[] estoque, Compras[] nota)
        {
            bool Finaliza = false;
            while (Finaliza != true)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("* COD *   Produtos   * Preços    ");
                Console.WriteLine("*********************************");
                for (int i = 0; i < estoque.Length; i++)
                {//Inicio da lista de mercadorias
                    if (i == 0)
                    {
                        Console.WriteLine("*     *   Alimentos  *");
                        Console.WriteLine("*********************************");
                    }
                    Console.WriteLine("* {0} * {1} * R$ {2}", estoque[i].codigos, estoque[i].produtos, estoque[i].precos.ToString("N2"));
                    if (i == 4)
                    {
                        Console.WriteLine("*     *              *");
                        Console.WriteLine("*     *   Higiene    *");
                        Console.WriteLine("*********************************");
                    }
                    if (i == 9)
                    {
                        Console.WriteLine("*     *              *");
                        Console.WriteLine("*     *   Limpeza    *");
                        Console.WriteLine("*********************************");
                    }
                }
                Console.WriteLine("*********************************");
                //Fim da lista de mercadorias
                Console.Write("Digite o código do produto que deseja comprar: ");// Inicio do carrinho de compras
                int codigo = int.Parse(Console.ReadLine());
                while(codigo <101 || codigo > 305)
                {
                    Console.WriteLine("Produto não cadastrado, digite novamente o código");
                    codigo = int.Parse(Console.ReadLine());
                }
                Console.Clear();
                for (int i = 0; i < estoque.Length; i++)/*  O indice dos dois registros será igual pois é mais facil fazer assim*/
                {
                    if (codigo == estoque[i].codigos)//Validação do codigo do produto
                    {
                        Console.WriteLine("Quantas unidades de {0} deseja comprar ?", estoque[i].produtos);
                        nota[i].unidades = int.Parse(Console.ReadLine());
                        while (nota[i].unidades > estoque[i].unidades)
                        {
                            Console.WriteLine("Não temos essa quantidade de {0} em estoque", estoque[i].produtos);
                            Console.WriteLine("Temos {0} unidades disponiveis", estoque[i].unidades);
                            Console.WriteLine("Digite novamente quantas unidades deseja comprar");
                            nota[i].unidades = int.Parse(Console.ReadLine());
                        }
                        nota[i].preco_total = nota[i].unidades * estoque[i].precos;//Atribuições feitas no registro do carrinho de compras
                        nota[i].produtos = estoque[i].produtos;//Nome do produto que ira constar na nota fiscal
                        estoque[i].unidades -= nota[i].unidades;//Subtraindo unidades do estoque do mercado
                        Console.WriteLine("Deseja comprar mais alguma coisa [ S ] ou [ N ] ?");
                        char Resp = char.ToUpper(char.Parse(Console.ReadLine()));
                        if (Resp == 'N')
                        {
                            Finaliza = true;
                        }
                        Console.Clear();
                    }
                }
            }
        }
        private static double Nota_fiscal(Compras[] nF)
        {
            double total = 0;
            int cont = 0;
            Console.WriteLine("Nota fiscal");
            for (int i = 0; i < nF.Length; i++)
            {
                if (nF[i].unidades > 0)
                {
                    double preco_unitario = nF[i].preco_total / nF[i].unidades;
                    Console.WriteLine("{0}  -   {1} X {2} = R$ {3}", nF[i].produtos, nF[i].unidades, preco_unitario, nF[i].preco_total);
                    total += nF[i].preco_total;
                    cont += 1;
                }
            }
            if (cont == 0)
            {
                Console.WriteLine("Nenhum produto foi comprado");
            }
            else
            {
                Console.WriteLine("Total a pagar: R$ " + total);
            }
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
            Console.Clear();
            return (total);
        }
        private static void Pagamento(Compras[] nF, double total_comprado)
        {
            bool menu_principal = false;
            while (menu_principal != true)
            {
                Console.WriteLine("****************************");
                Console.WriteLine("*    Formas de Pagamento   *");
                Console.WriteLine("****************************");
                Console.WriteLine("*  [ 1 ] Dinheiro          *");
                Console.WriteLine("*  [ 2 ] Cartão de crédito *");
                Console.WriteLine("*  [ 3 ] Cartão de débito  *");
                Console.WriteLine("*  [ 4 ] Sair              *");
                Console.WriteLine("****************************");
                Console.Write("Opção: ");
                int op = int.Parse(Console.ReadLine());
                Console.Clear();
                while (op < 1 || op > 4)
                {
                    Console.WriteLine("Opção inválida, digite novamente");
                    op = int.Parse(Console.ReadLine());
                    Console.Clear();
                }
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Pagamento a dinheiro");
                        Console.WriteLine("Total da compra R$ {0}",total_comprado);
                        double desc = total_comprado * 0.95;
                        Console.WriteLine("Total a pagar R$ {0}",desc.ToString("N2"));// Tostring("Nn") é o método para limitar o número de casa decimais
                        Console.WriteLine("Pressione ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        cartao_credito(total_comprado);
                        break;
                    case 3:
                        Console.WriteLine("Pagamento no débito");
                        Console.WriteLine("Total a pagar: R$ {0}", total_comprado);
                        Console.WriteLine("Pressione ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        menu_principal = true;
                        break;
                }
            }
        }
        private static void cartao_credito(double total)
        {
            double juros = 0;
            int parcela = 0;
            double parcela_compra = 0;
            Console.WriteLine("__________________________________________");
            Console.WriteLine("|    Pagamento no cartão de crédito      |");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("|    [ 1 ] 1X (Sem Juros)                |");
            Console.WriteLine("|    [ 2 ] 2 a 3X (10% de juros)         |");
            Console.WriteLine("|          acima de 4X (20% de juros)    |");
            Console.WriteLine("|________________________________________|");
            Console.Write("Opção: ");
            int cartao = int.Parse(Console.ReadLine());
            Console.Clear();
            while (cartao < 1 || cartao > 2)
            {
                Console.WriteLine("Opção inválida, digite novamente");
                cartao = int.Parse(Console.ReadLine());
            }
            switch (cartao)
            {
                case 1:
                    Console.WriteLine("Total a pagar: R$ {0}", total);
                    Console.WriteLine("Pressione ENTER");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 2:
                    Console.WriteLine("Em quantas vezes irá parcelar ?  \nDe 2 até 12 vezes");
                    parcela = int.Parse(Console.ReadLine());
                    while(parcela < 2 || parcela > 12)
                    {
                        Console.WriteLine("Desculpe não podemos parcelar acima de 12 vezes");
                        parcela = int.Parse(Console.ReadLine());
                    }
                    if (parcela <= 3)
                    {
                        juros = total * 1.10;
                        parcela_compra = juros / parcela;
                        Console.WriteLine("Valor total R$ " + total);
                        Console.WriteLine("Total a pagar R$ " + juros.ToString("N2"));
                        Console.WriteLine("A sua compra foi parcelada em {0} vezes de R$ {1}",parcela,parcela_compra.ToString("N2"));
                        Console.WriteLine("Pressione ENTER");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    if(parcela >= 4)
                    {
                        juros = total * 1.20;
                        parcela_compra = juros / parcela;
                        Console.WriteLine("Valor total R$ " + total);
                        Console.WriteLine("Total a pagar R$ " + juros.ToString("N2"));
                        Console.WriteLine("A sua compra foi parcelada em {0} vezes de R$ {1}", parcela, parcela_compra.ToString("N2"));
                        Console.WriteLine("Pressione ENTER");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    break;
            }
        }
    }
}
