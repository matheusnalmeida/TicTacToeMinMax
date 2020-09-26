using MinMaxModels.Models.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinMaxModels.Models
{
    //Marcando como 1 o X que representam a AI
    //Marcando como 2 as bolas(0) que representam os jogadores
    //Marcando como 0 os espaços em branco
    public class TicTacToeMinMax
    {
        private static int IA_SYMBOL = 1;
        private static int PLAYER_SYMBOL = 2;

        public TicTacToeMinMax() { }

        //Metodo responsavel por dada uma situação da mesa, retornar a proxima melhor situação
        public int[] proximoEstagioIA(int[] mesa)
        {
            //Arvore começa do estagio atual da mesa
            Tree<int[]> arvoreAtual = new Tree<int[]>();
            arvoreAtual.Add(null, mesa, null);
            var noInicio = arvoreAtual.Root;
            MinMax(arvoreAtual, noInicio, true);
            var melhorNo = retornaMinMaxFilho(noInicio, true);
            int[] coordenadas = Util.ConvertMesaParaCoordenadas(mesa, melhorNo.Element, 1);
            return coordenadas;
        }

        public void MinMax(Tree<int[]> tree, Node<int[]> paiAtual, bool ehMaximiza)
        {
            var situacaoJogo = ChecarSituacaoJogo(paiAtual.Element);
            if (situacaoJogo != null)
            {
                paiAtual.id = situacaoJogo.Value;
            }
            else if (ehMaximiza)
            {
                for (int i = 0; i < 9; i++)
                {
                    var situacaoJogoAtualCopia = (int[])paiAtual.Element.Clone();
                    //Se a posição estiver livre, marque a posição e gere o min max para a posição
                    if (situacaoJogoAtualCopia[i] == 0)
                    {
                        situacaoJogoAtualCopia[i] = IA_SYMBOL;
                        var noAtual = new Node<int[]>(null, paiAtual, new List<Node<int[]>>(), situacaoJogoAtualCopia);
                        tree.Add(noAtual);
                        MinMax(tree, noAtual, false);
                        var idNew = retornaMinMaxFilhoId(paiAtual, true);
                        if (idNew != 20 && idNew != -20)
                        {
                            paiAtual.id = idNew;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    var situacaoJogoAtualCopia = (int[])paiAtual.Element.Clone();
                    //Se a posição estiver livre, marque a posição e gere o min max para a posição
                    if (situacaoJogoAtualCopia[i] == 0)
                    {
                        situacaoJogoAtualCopia[i] = PLAYER_SYMBOL;
                        var noAtual = new Node<int[]>(null, paiAtual, new List<Node<int[]>>(), situacaoJogoAtualCopia);
                        tree.Add(noAtual);
                        MinMax(tree, noAtual, true);
                        var idNew = retornaMinMaxFilhoId(paiAtual, false);
                        if (idNew != 20 && idNew != -20)
                        {
                            paiAtual.id = idNew;
                        }
                    }
                }
            }
        }

        // 10 = AI ganha | 0 = Empate | -10 = AI perde
        public int? ChecarSituacaoJogo(int[] table)
        {
            //Checando horizontal
            for (int i = 0; i < 9; i += 3)
            {
                if (table[i] == PLAYER_SYMBOL && table[i + 1] == PLAYER_SYMBOL && table[i + 2] == PLAYER_SYMBOL)
                {
                    return -10;
                }
                if (table[i] == IA_SYMBOL && table[i + 1] == IA_SYMBOL && table[i + 2] == IA_SYMBOL)
                {
                    return 10;
                }
            }
            //Checando vertical
            for (int i = 0; i < 3; i++)
            {
                if (table[i] == PLAYER_SYMBOL && table[i + 3] == PLAYER_SYMBOL && table[i + 6] == PLAYER_SYMBOL)
                {
                    return -10;
                }
                else if (table[i] == IA_SYMBOL && table[i + 3] == IA_SYMBOL && table[i + 6] == IA_SYMBOL)
                {
                    return 10;
                }
            }
            //Checando diagonais
            if (table[0] == PLAYER_SYMBOL && table[4] == PLAYER_SYMBOL && table[8] == PLAYER_SYMBOL)
            {
                return -10;
            }
            if (table[0] == IA_SYMBOL && table[4] == IA_SYMBOL && table[8] == IA_SYMBOL)
            {
                return 10;
            }
            if (table[2] == PLAYER_SYMBOL && table[4] == PLAYER_SYMBOL && table[6] == PLAYER_SYMBOL)
            {
                return -10;
            }
            if (table[2] == IA_SYMBOL && table[4] == IA_SYMBOL && table[6] == IA_SYMBOL)
            {
                return 10;
            }

            //Checando se é empate
            if (numeroDeEspacosEmBranco(table) == 0)
            {
                return 0;
            }

            return null;
        }

        //Checa o numero de espacos em branco no tabuleiro
        public int numeroDeEspacosEmBranco(int[] table)
        {
            int numeroDeEspacosEmBranco = 0;
            foreach (var position in table)
            {
                if (position == 0)
                {
                    numeroDeEspacosEmBranco++;
                }
            }
            return numeroDeEspacosEmBranco;
        }

        //Retornar o menor ou maior no filho do no atual de acordo com o parametro ehMaximo
        public Node<int[]> retornaMinMaxFilho(Node<int[]> stage, bool ehMaximo)
        {
            Node<int[]> no = null;
            int valor = ehMaximo ? -20 : 20;
            foreach (var child in stage.Childs)
            {
                if (ehMaximo)
                {
                    if (child.id > valor)
                    {
                        valor = child.id.Value;
                        no = child;
                    }
                }
                else
                {
                    if (child.id < valor)
                    {
                        valor = child.id.Value;
                        no = child;
                    }
                }
            }
            return no;
        }

        //Retornar o menor ou maior id do filho do no atual de acordo com o parametro ehMaximo
        public int retornaMinMaxFilhoId(Node<int[]> stage, bool ehMaximo)
        {
            int valor = ehMaximo ? -20 : 20;
            foreach (var child in stage.Childs)
            {
                if (ehMaximo)
                {
                    if (child.id > valor)
                    {
                        valor = child.id.Value;
                    }
                }
                else
                {
                    if (child.id < valor)
                    {
                        valor = child.id.Value;
                    }
                }
            }
            return valor;
        }
    }
}
