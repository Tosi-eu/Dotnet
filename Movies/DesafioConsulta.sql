<<<<<<< HEAD
-- 1a consulta, retorna somente nome e ano OK
select Nome, Ano from Filmes

-- 2a consulta, retorna nome e ano ordenado por ordem crescente do ano OK
select Nome, Ano from Filmes order by Ano

-- 3a consulta, buscar pelo filme de volta para o futuro, trazendo o nome, ano e duracao OK
select * from Filmes where Nome='De Volta para o Futuro'

-- 4a consulta, buscar os filmes lancados em 1997 OK
select * from Filmes where Ano = 1997

-- 5a consulta, buscar os filmes lancados APOS o ano 2000
select * from Filmes where Ano > 2000

-- 6a consulta, buscar of filmes com duracao maior que 100 e menor que 150, em ordem crescente OK
select * from Filmes where 100 < Duracao  and Duracao < 150 order by Duracao

-- 7a consulta buscar a quantidade de filmes lancadas no ano, agrupando por ano e ordenando em ordem decrescente OK
SELECT Ano, COUNT(*) AS Quantidade
FROM Filmes
GROUP BY Ano
ORDER BY MAX(Duracao) DESC;

-- 8a consulta buscar os atores do genero masculino, retornando PrimeiroNome e UltimoNome OK
select * from Atores where Genero = 'M'

-- 9a consulta buscar os atores do genero feminino, retornando PrimeiroNome e UltimoNome OK
select * from Atores where Genero = 'F'

-- 10a consulta buscar nome do filme e genero OK

SELECT Filmes.Nome AS NomeFilme, Generos.Genero AS Genero
FROM Filmes
JOIN FilmesGenero ON Filmes.Id = FilmesGenero.IdFilme
JOIN Generos ON Generos.Id = FilmesGenero.IdGenero;

--11a Buscar o nome do filme e o genero do tipo misterio OK

SELECT Filmes.Nome AS NomeFilme, Generos.Genero AS Genero
FROM Filmes
JOIN FilmesGenero ON Filmes.Id = FilmesGenero.IdFilme
JOIN Generos ON Generos.Id = FilmesGenero.IdGenero
WHERE Generos.Genero = 'Mistério';

--12a Buscar o nome do filme e os atores, trazendo o PrimeiroNome, UltimoNome e seu Papel

SELECT Filmes.Nome AS NomeFilme, Atores.PrimeiroNome, Atores.UltimoNome, ElencoFilme.Papel
FROM Filmes
JOIN ElencoFilme ON Filmes.Id = ElencoFilme.IdFilme
=======
-- 1a consulta, retorna somente nome e ano OK
select Nome, Ano from Filmes

-- 2a consulta, retorna nome e ano ordenado por ordem crescente do ano OK
select Nome, Ano from Filmes order by Ano

-- 3a consulta, buscar pelo filme de volta para o futuro, trazendo o nome, ano e duracao OK
select * from Filmes where Nome='De Volta para o Futuro'

-- 4a consulta, buscar os filmes lancados em 1997 OK
select * from Filmes where Ano = 1997

-- 5a consulta, buscar os filmes lancados APOS o ano 2000
select * from Filmes where Ano > 2000

-- 6a consulta, buscar of filmes com duracao maior que 100 e menor que 150, em ordem crescente OK
select * from Filmes where 100 < Duracao  and Duracao < 150 order by Duracao

-- 7a consulta buscar a quantidade de filmes lancadas no ano, agrupando por ano e ordenando em ordem decrescente OK
SELECT Ano, COUNT(*) AS Quantidade
FROM Filmes
GROUP BY Ano
ORDER BY MAX(Duracao) DESC;

-- 8a consulta buscar os atores do genero masculino, retornando PrimeiroNome e UltimoNome OK
select * from Atores where Genero = 'M'

-- 9a consulta buscar os atores do genero feminino, retornando PrimeiroNome e UltimoNome OK
select * from Atores where Genero = 'F'

-- 10a consulta buscar nome do filme e genero OK

SELECT Filmes.Nome AS NomeFilme, Generos.Genero AS Genero
FROM Filmes
JOIN FilmesGenero ON Filmes.Id = FilmesGenero.IdFilme
JOIN Generos ON Generos.Id = FilmesGenero.IdGenero;

--11a Buscar o nome do filme e o genero do tipo misterio OK

SELECT Filmes.Nome AS NomeFilme, Generos.Genero AS Genero
FROM Filmes
JOIN FilmesGenero ON Filmes.Id = FilmesGenero.IdFilme
JOIN Generos ON Generos.Id = FilmesGenero.IdGenero
WHERE Generos.Genero = 'Mistério';

--12a Buscar o nome do filme e os atores, trazendo o PrimeiroNome, UltimoNome e seu Papel

SELECT Filmes.Nome AS NomeFilme, Atores.PrimeiroNome, Atores.UltimoNome, ElencoFilme.Papel
FROM Filmes
JOIN ElencoFilme ON Filmes.Id = ElencoFilme.IdFilme
>>>>>>> 09e6cbb77432af796941f1945dabde1e8826bbc2
JOIN Atores ON Atores.Id = ElencoFilme.IdAtor;