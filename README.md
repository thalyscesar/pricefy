# pricefy
Se os pacotes não forem baixados  executar comando 
Update-Package -ProjectName Api.Pricefy
Update-Package -ProjectName ImportacaoExcel

os arquivos de excel se encontra na pasta debug e tambem na pasta lotes 
caso não esteja com o caminho correto setar o caminho da pasta lotes que encontra na raiz do projeto.

1 ImportacaoExcel
Leitura do Excel 
e um  consumo da api.Pricefy executando o metodo post para inserir o lote de produto

2 Api.Pricefy
Metodos Get e post para insercao e obtenção do lote 
usando uma conexao MongoDb
Deve ser instalado Robo 3T 1.4.1
e criar a conexao que a connectionstring esta no  appsettings;
e apos criar a conexao conforme a connections string  adicionar a collection lotes

estrategia: não desnormalizei objeto que insere o lote eu acredito que o lote e uma agregacao e os itens do lote não existem sem o lote; 
