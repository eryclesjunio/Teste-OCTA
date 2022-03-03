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
 ('36f53e7d-afa4-4002-adb0-0937e573de5f', 'Cora Lobo Olaio', '134.111.111-11', '423 Reynold Hills', '2022-02-05 07:31:10'),
 ('43027551-90f9-4278-9f91-2a02c9f5ae83','Diego Belmonte Mata', '111.111.111-11', '02937 Heaney Trail', '2022-02-05 07:31:10'),
 ('92654b6f-83ac-4c7b-b8e5-3e997588f276', 'Nicolae Marques Cartaxo', '122.222.222-22', '644 Hackett Curve', '2022-02-05 07:31:10'),
 ('8129a8f4-e7af-4e53-996c-8fd5c2daabc9', 'Mara Feitosa Quadros', '123.333.333-33', '61256 VonRueden Streets', '2022-02-05 07:31:10');

 INSERT INTO "Veiculo" ("Id", "Marca", "Placa", "CpfCnpj", "DataCriacao") VALUES
 ('20566bbb-7476-4924-92c9-2c98598d20ed', 'Marca001', 'Place001', '134.111.111-11', '2022-02-05 07:31:10'),
 ('ebd999d7-7652-4241-9e6e-b906337bc577','Marca002', 'Place002', '111.111.111-11', '2022-02-05 07:31:10'),
 ('058f20f7-d490-496f-9eff-7a5c2c6d70e4', 'Marca003', 'Place003', '122.222.222-22', '2022-02-05 07:31:10'),
 ('a94f6297-03a3-48dd-8a14-3077afe65ad3', 'Marca004', 'Place004', '123.333.333-33', '2022-02-05 07:31:10');