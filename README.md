# Pontos de Interesse por GPS

**O desafio:** implementar um serviço para a empresa XY Inc., especializada na produção de excelentes receptores
GPS (Global Positioning System).
A diretoria está empenhada em lançar um dispositivo inovador que promete auxiliar pessoas na localização de pontos de
interesse (POIs), e precisa muito de sua ajuda.
Você foi contratado para desenvolver a plataforma que fornecerá toda a inteligência ao dispositivo. Esta plataforma deve
ser baseada em serviços REST, para flexibilizar a integração.

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

Dado o ponto de referência (x=20, y=10) indicado pelo receptor GPS, e uma distância máxima de 10 metros, o serviço deve
retornar os seguintes POIs:

- Lanchonete
- Joalheria
- Pub
- Supermercado

</details>

<details>
<summary><strong>Funcionalidades da API</strong></summary>

---

- [x] Cadastrar pontos de interesse, com 03 atributos: nome do POI, coordenada X (inteiro não negativo) e coordenada Y (inteiro não negativo).
- [ ] Os POIs devem ser armazenados em uma base de dados.
- [x] Listar todos os POIs cadastrados.
- [ ] Buscar POI pelo seu ID.
- [ ] Listar os POIs por proximidade. Este serviço receberá uma coordenada X e uma coordenada Y, especificando um ponto de referência, bem como uma distância máxima (d-max) em metros. O serviço deverá retornar todos os POIs da base de dados que estejam a uma distância menor ou igual a d-max a partir do ponto de referência.

</details>

<details>
<summary><strong>Outros objetivos</strong></summary>

---

- [ ] Adicionar validação em todos os dados enviados pelo cliente
	- [ ] ID: Inteiro positivo.
	- [ ] Nome do ponto de interesse: Texto alfanumérico.
	- [ ] Coordenada X: Inteiro positivo.
	- [ ] Coordenada Y: Inteiro positivo.
- [ ] Criar uma seed para popular a base de dados para testes.

</details>

---

## Entradas da API

| Rota						| Função													|
|---------------------------|-----------------------------------------------------------|
| `get` /pois				| Buscar todos os pontos de interesse						|
| `get` /pois/ver/:id		| Buscar ponto de interesse pelo ID informado				|
| `get` /pois/buscar		| Buscar ponto de interesse próximos a posição informada	|
| `post` /pois				| Adiciona um novo ponto de interesse						|
| `delete` /pois			| Remove um ponto de interesse								|
