CREATE TABLE "Proprietario" (
    "Id" uuid primary key,
    "Nome" varchar(255),
    "CpfCnpj" varchar(255),
	"Endereco" varchar(255),
    "DataCriacao" timestamp
);

CREATE TABLE "Veiculo" (
    "Id" uuid primary key,
    "Marca" varchar(255),
    "Placa" varchar(255),
	"CpfCnpj" varchar(255),
    "DataCriacao" timestamp
);

 INSERT INTO "Proprietario" ("Id", "Nome", "CpfCnpj", "Endereco", "DataCriacao") VALUES
 ('36f53e7d-afa4-4002-adb0-0937e573de5f', 'Marca001', '134.111.111-11', 'Rua Antonio Vitor Dos Santos', '2020-10-05 07:31:10'),
 ('43027551-90f9-4278-9f91-2a02c9f5ae83','Marca002', '111.111.111-11', 'Rua Antonio Vitor Dos Santos', '2020-10-05 07:31:10'),
 ('92654b6f-83ac-4c7b-b8e5-3e997588f276', 'Marca003', '122.222.222-22', 'Rua Antonio Vitor Dos Santos', '2020-10-05 07:31:10'),
 ('8129a8f4-e7af-4e53-996c-8fd5c2daabc9', 'Marca004', '123.333.333-33', 'Rua Antonio Vitor Dos Santos', '2020-10-05 07:31:10');

 INSERT INTO "Veiculo" ("Id", "Marca", "Placa", "CpfCnpj", "DataCriacao") VALUES
 ('36f53e7d-afa4-4002-adb0-0937e573de5f', 'Marca001', 'Place001', '134.111.111-11', '2020-10-05 07:31:10'),
 ('43027551-90f9-4278-9f91-2a02c9f5ae83','Marca002', 'Place002', '111.111.111-11', '2020-10-05 07:31:10'),
 ('92654b6f-83ac-4c7b-b8e5-3e997588f276', 'Marca003', 'Place003', '122.222.222-22', '2020-10-05 07:31:10'),
 ('8129a8f4-e7af-4e53-996c-8fd5c2daabc9', 'Marca004', 'Place004', '123.333.333-33', '2020-10-05 07:31:10');