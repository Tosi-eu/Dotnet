USE Filmes

SELECT nome, ano FROM Filmes;

SELECT nome, ano FROM Filmes
	ORDER BY ano ASC;
	
SELECT nome, ano, duracao FROM Filmes
	WHERE nome = 'De Volta para o Futuro';
	
SELECT * FROM Filmes
	WHERE ano=1997;

SELECT * FROM Filmes
	WHERE ano > 2000
	
SELECT * FROM Filmes
	WHERE Duracao > 100 AND Duracao  < 150
	ORDER BY Duracao ASC;
	
SELECT Ano, COUNT(*) AS Quantidade
FROM Filmes
GROUP BY Ano
ORDER BY MAX(Duracao) DESC;

SELECT PrimeiroNome, UltimoNome FROM Atores
	WHERE Genero = 'M'
	
SELECT PrimeiroNome, UltimoNome FROM Atores
	WHERE Genero = 'F'
	ORDER BY PrimeiroNome 

SELECT f.nome, g.Genero FROM Filmes f
	JOIN FilmesGenero fg ON fg.IdFilme  = f.Id
	JOIN Generos g ON fg.IdGenero  = g.Id
	
SELECT f.nome, g.Genero FROM Filmes f
	JOIN FilmesGenero fg ON fg.IdFilme  = f.Id
	JOIN Generos g ON fg.IdGenero  = g.Id
	WHERE g.Genero = 'Mistério'
	
SELECT f.nome, a.PrimeiroNome, a.UltimoNome, ef.Papel FROM Filmes f
	JOIN ElencoFilme ef ON ef.IdFilme = f.Id
	JOIN Atores a ON a.Id = ef.IdAtor 
	

