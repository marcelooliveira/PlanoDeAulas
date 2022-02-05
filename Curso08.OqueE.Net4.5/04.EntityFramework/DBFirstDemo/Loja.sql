IF OBJECT_ID('dbo.pedidos') IS NOT NULL
DROP TABLE dbo.pedidos;
GO

IF OBJECT_ID('dbo.clientes') IS NOT NULL
DROP TABLE dbo.clientes;
GO

CREATE TABLE clientes (
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    nome TEXT,
    email TEXT);
GO    

INSERT INTO clientes (nome, email) VALUES ('Smeagol', 'smeagol@golum.com');
INSERT INTO clientes (nome, email) VALUES ('Harry Potter', 'harry@potter.com');
INSERT INTO clientes (nome, email) VALUES ('Thanos', 'thanos@inevitable.com');
GO

CREATE TABLE pedidos (
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    cliente_id INTEGER,
    item TEXT,
    preco REAL,
    FOREIGN KEY (cliente_id) REFERENCES clientes (id));
GO

INSERT INTO pedidos (cliente_id, item, preco)
    VALUES (1, 'Precioso', 1000.00);
INSERT INTO pedidos (cliente_id, item, preco)
    VALUES (2, 'Nimbus 2000', 40.00);
INSERT INTO pedidos (cliente_id, item, preco)
    VALUES (3, 'Joias do infinito', 1000000.00);
GO