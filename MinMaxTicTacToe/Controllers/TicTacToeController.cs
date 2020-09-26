using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MinMaxModels.Models;
using Newtonsoft.Json;

namespace MinMaxTicTacToe.Controllers
{
    [Route("minimax")]
    public class TicTacToeController : Controller
    {
        private readonly TicTacToeMinMax mapperTicTac;

        public TicTacToeController(TicTacToeMinMax ticTacToe)
        {
            this.mapperTicTac = ticTacToe;
        }

        [HttpPost("play")]
        public string ProximoMovimento([FromBody] Tabuleiro data)
        {
            try
            {
                var coordenadas = mapperTicTac.proximoEstagioIA(data.game.ToArray());
                return JsonConvert.SerializeObject(new ResponseSucess  { move = new List<int>(coordenadas) });
            }
            catch (Exception ex) {
                return JsonConvert.SerializeObject(new ResponseFailed() { msg = ex.Message });
            }

        }

        public class Tabuleiro
        {
            public List<int> game { get; set; }
        }

        public class ResponseSucess {
            public HttpStatusCode status = HttpStatusCode.OK;
            //Posições x e y do tabuleiro onde será marcada a jogada
            public List<int> move { get; set; }
        }

        public class ResponseFailed
        {
            public HttpStatusCode status = HttpStatusCode.InternalServerError;
            //Posições x e y do tabuleiro onde será marcada a jogada
            public string msg { get; set; }
        }
    }
}
