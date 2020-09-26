# TicTacToeMiniMax
Implementação do algoritmo MinMax no jogo da velha.

## Teste

> Para teste do algoritimo é necessário rodar o comando **dotnet run** dentro da pasta "MinMaxTicTacToe" e abrir o html do repositorio do front do seguinte [link](https://github.com/adolfoguimaraes/tictactoe_webpage). Com isso será executada a api da aplicação web, sendo somente necessário informar no input de texto do front, o endereço http://localhost:5001(endereço default da api), seguido da rota minimax/play/(rota que informa a proxima jogada a ser realizada),portanto , será informado no input http://127.0.0.1:5001/minimax/play/. Caso não seja realizada uma jogada de forma automatica por parte da AI, será necessário trocar a porta da api no arquivo launchSettings.json localizado no diretório: **..\MinMaxTicTacToe\Properties\launchSettings.json** na linha 24. Por padrão, o endereço está http://localhost:5001. Caso seja necessário a troca do endereço, altere o valor da porta 5001 na url da linha 24 por uma outra porta livre.

## Requisitos
> Caso não consiga executar o comando **dotnet** no terminal, faça a instalação do **sdk do .net core** no link seguinte: https://dotnet.microsoft.com/download.

## Referência

> O front utilizado no projeto está localizado no repositório [tictactoe_webpage](https://github.com/adolfoguimaraes/tictactoe_webpage).
