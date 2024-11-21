# Pontos de Interesse por GPS

**O desafio:** implementar um servi�o para a empresa XY Inc., especializada na produ��o de excelentes receptores
GPS (Global Positioning System).
A diretoria est� empenhada em lan�ar um dispositivo inovador que promete auxiliar pessoas na localiza��o de pontos de
interesse (POIs), e precisa muito de sua ajuda.
Voc� foi contratado para desenvolver a plataforma que fornecer� toda a intelig�ncia ao dispositivo. Esta plataforma deve
ser baseada em servi�os REST, para flexibilizar a integra��o.

<details>
<summary><strong>Exemplo</strong></summary>

---

Considere a seguinte base de dados de POIs:

- 'Lanchonete' (x=27, y=12)
- 'Posto' (x=31, y=18)
- 'Joalheria' (x=15, y=12)
- 'Floricultura' (x=19, y=21)
- 'Pub' (x=12, y=8)
- 'Supermercado' (x=23, y=6)
- 'Churrascaria' (x=28, y=2)

Dado o ponto de refer�ncia (x=20, y=10) indicado pelo receptor GPS, e uma dist�ncia m�xima de 10 metros, o servi�o deve
retornar os seguintes POIs:

- Lanchonete
- Joalheria
- Pub
- Supermercado

</details>

<details>
<summary><strong>Funcionalidades da API</strong></summary>

---

- [ ] Cadastrar pontos de interesse, com 03 atributos: nome do POI, coordenada X (inteiro n�o negativo) e coordenada Y (inteiro n�o negativo).
- [ ] Os POIs devem ser armazenados em uma base de dados.
- [ ] Listar todos os POIs cadastrados.
- [ ] Listar os POIs por proximidade. Este servi�o receber� uma coordenada X e uma coordenada Y, especificando um ponto de refer�ncia, bem como uma dist�ncia m�xima (d-max) em metros. O servi�o dever� retornar todos os POIs da base de dados que estejam a uma dist�ncia menor ou igual a d-max a partir do ponto de refer�ncia.

</details>

---

## Entradas da API

| Rota					| Fun��o													|
|-----------------------|-----------------------------------------------------------|
| `get` /pois			| Buscar todos os pontos de interesse						|
| `get` /pois/buscar	| Buscar ponto de interesse pr�ximos a posi��o informada	|
| `post` /pois			| Adiciona um novo ponto de interesse						|
| `delete` /pois		| Remove um ponto de interesse								|
