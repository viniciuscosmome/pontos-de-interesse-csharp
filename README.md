# Pontos de Interesse por GPS

***[@viniciuscosmome](https://github.com/viniciuscosmome)***

**O desafio:** implementar um serviço para a empresa XY Inc., especializada na produção de excelentes receptores
GPS (Global Positioning System).
A diretoria está empenhada em lançar um dispositivo inovador que promete auxiliar pessoas na localização de pontos de
interesse (POIs), e precisa muito de sua ajuda.
Você foi contratado para desenvolver a plataforma que fornecerá toda a inteligência ao dispositivo. Esta plataforma deve
ser baseada em serviços REST, para flexibilizar a integração.

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

Dado o ponto de referência ` (x=20, y=10) ` indicado pelo receptor GPS, e uma distância máxima de ` 10 metros `, o serviço
deve retornar os seguintes POIs:

| Local			|
|---------------|
| Lanchonete	|
| Joalheria		|
| Pub			|
| Supermercado	|

> [!tip]\
> Você pode encontrar mais desafios como esse em:\
> ***[@backend-br](https://github.com/backend-br/desafios)***

## API

### Entradas da API

| Rota							| Função													|
|-------------------------------|-----------------------------------------------------------|
| `get` /pois					| Buscar todos os pontos de interesse						|
| `get` /pois/ver/:id			| Buscar ponto de interesse pelo ID informado				|
| `get` /pois/buscar?d=&x=&y=	| Buscar ponto de interesse próximos a posição informada	|
| `post` /pois					| Adiciona um novo ponto de interesse						|

### lista de objetivos

<details>
<summary><strong>Ver lista de objetivos</strong></summary>

- [x] Cadastrar pontos de interesse, com 03 atributos: nome do POI, coordenada X (inteiro não negativo) e coordenada Y (inteiro não negativo).
- [x] Os POIs devem ser armazenados em uma base de dados.
- [x] Listar todos os POIs cadastrados.
- [x] Buscar POI pelo seu ID.
- [x] Listar os POIs por proximidade. Este serviço receberá uma coordenada X e uma coordenada Y, especificando um ponto de referência, bem como uma distância máxima (d-max) em metros. O serviço deverá retornar todos os POIs da base de dados que estejam a uma distância menor ou igual a d-max a partir do ponto de referência.
- [x] Permitir a atualização de um POI
- [x] Permitir a exclusão de um POI
- [ ] Adicionar validação em todos os dados enviados pelo cliente
	- [ ] ID: Inteiro positivo.
	- [ ] Nome do ponto de interesse: Texto alfanumérico.
	- [ ] Coordenada X: Inteiro positivo.
	- [ ] Coordenada Y: Inteiro positivo.
- [x] Criar uma seed para popular a base de dados para testes.

</details>

---
