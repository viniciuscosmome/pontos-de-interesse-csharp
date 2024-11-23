# Pontos de Interesse por GPS

***[@viniciuscosmome](https://github.com/viniciuscosmome)***

**O desafio:** implementar um servi�o para a empresa XY Inc., especializada na produ��o de excelentes receptores
GPS (Global Positioning System).
A diretoria est� empenhada em lan�ar um dispositivo inovador que promete auxiliar pessoas na localiza��o de pontos de
interesse (POIs), e precisa muito de sua ajuda.
Voc� foi contratado para desenvolver a plataforma que fornecer� toda a intelig�ncia ao dispositivo. Esta plataforma deve
ser baseada em servi�os REST, para flexibilizar a integra��o.

## Exemplo:

Considere a seguinte base de dados de POIs:

| Local			| Pos X	| Pos Y	|
|---------------|-------|-------|
| Lanchonete	| 27	| 12	|
| Posto			| 31	| 18	|
| Joalheria		| 15	| 12	|
| Floricultura	| 19	| 21	|
| Pub			| 12	| 8		|
| Supermercado	| 23	| 6		|
| Churrascaria	| 28	| 2		|

Dado o ponto de refer�ncia ` (x=20, y=10) ` indicado pelo receptor GPS, e uma dist�ncia m�xima de ` 10 metros `, o servi�o
deve retornar os seguintes POIs:

| Local			|
|---------------|
| Lanchonete	|
| Joalheria		|
| Pub			|
| Supermercado	|

> [!tip]\
> Voc� pode encontrar mais desafios como esse em:\
> ***[@backend-br](https://github.com/backend-br/desafios)***

## API

### Entradas da API

| Rota							| Fun��o													|
|-------------------------------|-----------------------------------------------------------|
| `get` /pois					| Buscar todos os pontos de interesse						|
| `get` /pois/ver/:id			| Buscar ponto de interesse pelo ID informado				|
| `get` /pois/buscar?d=&x=&y=	| Buscar ponto de interesse pr�ximos a posi��o informada	|
| `post` /pois					| Adiciona um novo ponto de interesse						|

### lista de objetivos

<details>
<summary><strong>Ver lista de objetivos</strong></summary>

- [x] Cadastrar pontos de interesse, com 03 atributos: nome do POI, coordenada X (inteiro n�o negativo) e coordenada Y (inteiro n�o negativo).
- [x] Os POIs devem ser armazenados em uma base de dados.
- [x] Listar todos os POIs cadastrados.
- [x] Buscar POI pelo seu ID.
- [x] Listar os POIs por proximidade. Este servi�o receber� uma coordenada X e uma coordenada Y, especificando um ponto de refer�ncia, bem como uma dist�ncia m�xima (d-max) em metros. O servi�o dever� retornar todos os POIs da base de dados que estejam a uma dist�ncia menor ou igual a d-max a partir do ponto de refer�ncia.
- [x] Permitir a atualiza��o de um POI
- [x] Permitir a exclus�o de um POI
- [ ] Adicionar valida��o em todos os dados enviados pelo cliente
	- [ ] ID: Inteiro positivo.
	- [ ] Nome do ponto de interesse: Texto alfanum�rico.
	- [ ] Coordenada X: Inteiro positivo.
	- [ ] Coordenada Y: Inteiro positivo.
- [x] Criar uma seed para popular a base de dados para testes.

</details>

---
