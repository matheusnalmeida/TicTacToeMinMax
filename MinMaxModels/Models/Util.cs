using System;
using System.Collections.Generic;
using System.Text;

namespace MinMaxModels.Models
{
    public class Util
    {
        //Ira converter o tabuleiro do jogo da velha em coordenadas x e y, baseado no tabuleiro antigo e nas novas posições em que se irá jogar
        //O parametro iaSymbol ira identificar qual o simbolo da IA. Neste caso "1" como sendo x e -1 como sendo "0".
        public static int[] ConvertMesaParaCoordenadas(int[] tabuleiro,int[] tabuleiroNovasPosicoes,int iaSymbol)
        {
            int[] coordenadas = new int[2];
            for (int i = 0; i < tabuleiro.Length; i++)
            {
                if (tabuleiroNovasPosicoes[i] == iaSymbol && tabuleiroNovasPosicoes[i] != tabuleiro[i]) {
                    if (i == 0 || i == 1 || i == 2)
                    {
                        coordenadas[0] = 0;
                        coordenadas[1] = i;
                    }
                    else if (i == 3 || i == 4 || i == 5)
                    {
                        coordenadas[0] = 1;
                        coordenadas[1] = i - 3;
                    }
                    else {
                        coordenadas[0] = 2;
                        coordenadas[1] = i - 6;
                    }
                    break;
                }
            }

            return coordenadas;
        }
    }
}
