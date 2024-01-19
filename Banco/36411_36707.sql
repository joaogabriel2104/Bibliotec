DROP SCHEMA IF EXISTS BiblioTec;
CREATE SCHEMA BiblioTec;
USE BiblioTec;

DROP TABLE IF EXISTS editora;

CREATE TABLE editora (
    cd_editora INT,
    nm_editora VARCHAR(200),
    CONSTRAINT pk_editora PRIMARY KEY (cd_editora)
);

CREATE TABLE livro (
    cd_livro INT,
    cd_ISBN VARCHAR(200),
    nm_livro TEXT,
    aa_edicao INT,
    ds_sinopse TEXT,
    cd_editora INT,
    img_capa longblob,
    CONSTRAINT pk_livro PRIMARY KEY (cd_livro),
    CONSTRAINT fk_livro_editora1 FOREIGN KEY (cd_editora)
        REFERENCES editora (cd_editora)
);

CREATE TABLE autor (
    cd_autor INT,
    nm_autor VARCHAR(200),
    CONSTRAINT pk_autor PRIMARY KEY (cd_autor)
);

CREATE TABLE categoria (
    cd_categoria INT,
    nm_categoria VARCHAR(200),
    CONSTRAINT pk_categoria PRIMARY KEY (cd_categoria)
);

CREATE TABLE livro_categoria (
    cd_livro INT,
    cd_categoria INT,
    CONSTRAINT pk_livro_cat PRIMARY KEY (cd_livro , cd_categoria),
    CONSTRAINT fk_livro_categoria_livro1 FOREIGN KEY (cd_livro)
        REFERENCES livro (cd_livro),
    CONSTRAINT fk_livro_categoria_categoria1 FOREIGN KEY (cd_categoria)
        REFERENCES categoria (cd_categoria)
);

CREATE TABLE localizacao (
    cd_localizacao INT,
    nm_localizacao VARCHAR(255),
    CONSTRAINT pk_localizacao PRIMARY KEY (cd_localizacao)
);

CREATE TABLE exemplar (
    cd_exemplar INT,
    cd_RFID VARCHAR(300),
    cd_livro INT,
    ic_fixo TINYINT(1),
    cd_localizacao INT,
    CONSTRAINT pk_exemplar PRIMARY KEY (cd_exemplar , cd_livro),
    CONSTRAINT fk_exemplar_livro1 FOREIGN KEY (cd_livro)
        REFERENCES livro (cd_livro),
    CONSTRAINT fk_exemplar_localizacao1 FOREIGN KEY (cd_localizacao)
        REFERENCES localizacao (cd_localizacao)
);


CREATE TABLE tipo_usuario (
    cd_tipo_usuario INT,
    nm_tipo_usuario VARCHAR(45),
    CONSTRAINT pk_tipo_usuario PRIMARY KEY (cd_tipo_usuario)
);

CREATE TABLE usuario (
    nm_login VARCHAR(200),
    nm_usuario VARCHAR(255),
    nm_senha VARCHAR(64),
    ic_bloqueado TINYINT(1),
    dt_bloqueio DATE,
    cd_tipo_usuario INT,
    CONSTRAINT pk_usuario PRIMARY KEY (nm_login),
    CONSTRAINT fk_usuario_tipo_usuario1 FOREIGN KEY (cd_tipo_usuario)
        REFERENCES tipo_usuario (cd_tipo_usuario)
);

CREATE TABLE tipo_emprestimo (
    cd_tipo_emprestimo INT,
    nm_tipo_emprestimo VARCHAR(45),
    CONSTRAINT pk_tipo_emp PRIMARY KEY (cd_tipo_emprestimo)
);

CREATE TABLE emprestimo (
    nm_login VARCHAR(200),
    cd_exemplar INT,
    cd_livro INT,
    dt_emprestimo DATE,
    hr_emprestimo TIME,
    dt_devolucao_estimada DATE,
    dt_devolucao DATE,
    cd_tipo_emprestimo INT,
    CONSTRAINT pk_emp PRIMARY KEY (nm_login , cd_exemplar , cd_livro , dt_emprestimo, hr_emprestimo),
    CONSTRAINT fk_usuario_exemplar_usuario1 FOREIGN KEY (nm_login)
        REFERENCES usuario (nm_login),
    CONSTRAINT fk_usuario_exemplar_exemplar1 FOREIGN KEY (cd_exemplar , cd_livro)
        REFERENCES exemplar (cd_exemplar , cd_livro),
    CONSTRAINT fk_emprestimo_tipo_emprestimo1 FOREIGN KEY (cd_tipo_emprestimo)
        REFERENCES tipo_emprestimo (cd_tipo_emprestimo)
);

CREATE TABLE tipo_ocorrencia (
    cd_tipo_ocorrencia INT,
    nm_tipo_ocorrencia VARCHAR(45),
    CONSTRAINT pk_tipo_ocorrencia PRIMARY KEY (cd_tipo_ocorrencia)
);

CREATE TABLE ocorrencia (
    nm_login VARCHAR(200),
    cd_exemplar INT,
    cd_livro INT,
    dt_emprestimo DATE,
    cd_tipo_ocorrencia INT,
    ds_ocorrencia TEXT,
    CONSTRAINT pk_ocorrencia PRIMARY KEY (nm_login , cd_exemplar , cd_livro , dt_emprestimo , cd_tipo_ocorrencia),
    CONSTRAINT fk_emprestimo_tipo_ocorrencia_emprestimo1 FOREIGN KEY (nm_login , cd_exemplar , cd_livro , dt_emprestimo)
        REFERENCES emprestimo (nm_login , cd_exemplar , cd_livro , dt_emprestimo),
    CONSTRAINT fk_emprestimo_tipo_ocorrencia_tipo_ocorrencia1 FOREIGN KEY (cd_tipo_ocorrencia)
        REFERENCES tipo_ocorrencia (cd_tipo_ocorrencia)
);

CREATE TABLE computador (
    dt_uso_computador DATE,
    nm_login VARCHAR(200),
    CONSTRAINT pk_computador PRIMARY KEY (dt_uso_computador , nm_login),
    CONSTRAINT fk_computador_usuario1 FOREIGN KEY (nm_login)
        REFERENCES usuario (nm_login)
);

CREATE TABLE livro_autor (
    cd_livro INT,
    cd_autor INT,
    CONSTRAINT pk_livro_autor PRIMARY KEY (cd_livro , cd_autor),
    CONSTRAINT fk_livro_autor_livro1 FOREIGN KEY (cd_livro)
        REFERENCES livro (cd_livro),
    CONSTRAINT fk_livro_autor_autor1 FOREIGN KEY (cd_autor)
        REFERENCES autor (cd_autor)
);

INSERT INTO editora (cd_editora, nm_editora) VALUES (1, 'Editora FTD');
INSERT INTO editora (cd_editora, nm_editora) VALUES (2, 'Editora Seguinte');
INSERT INTO editora (cd_editora, nm_editora) VALUES (3, 'Rocco');
INSERT INTO editora (cd_editora, nm_editora) VALUES (4, 'Alt');
INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_edicao, ds_sinopse, cd_editora, img_capa) VALUES (1, '8532223796', 'Matematica - V. 3 - Geometria Analitica, Numeros Complexos E Polinomio', 2021, NULL, 1, NULL);
INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_edicao, ds_sinopse, cd_editora, img_capa) VALUES (2, '8555341612', 'Heartstopper: Dois garotos, um encontro (Vol. 1)', 2021,
'Charlie Spring e Nick Nelson não têm quase nada em comum. Charlie é um aluno dedicado e bastante inseguro por conta do bullying que sofre no colégio desde que se assumiu gay. Já Nick é superpopular, especialmente querido por ser um ótimo jogador de rúgbi. Quando os dois passam a sentar um ao lado do outro toda manhã, uma amizade intensa se desenvolve, e eles ficam cada vez mais próximos.'
, 2, NULL);
INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_edicao, ds_sinopse, cd_editora, img_capa) VALUES (3, '6555322489', 'Um ano solitário', 2022,
'Quando um site misterioso chamado Solitaire começa a pregar peças em sua escola, Tori não parece muito interessada, mesmo que Michael Holden, o garoto novo esquisito, tente convencê-la a investigar o esquema. Tori está tão presa em sua própria cabeça, tão convencida de que o mundo é horrível, que não consegue perceber os esforços que Michael e um antigo amigo de infância, Lucas, fazem para se aproximar dela.'
, 2, NULL);
INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_edicao, ds_sinopse, cd_editora, img_capa) VALUES (4, '6588131569', 'Ela fica com a garota', 2022,
'Um romance leve sobre duas meninas com vidas totalmente diferentes que se conhecem na faculdade e, sem perceber, criam uma relação de respeito e apoio mútuo'
, 4, NULL);
INSERT INTO autor (cd_autor, nm_autor) VALUES (1, 'Regina Giovanni');
INSERT INTO autor (cd_autor, nm_autor) VALUES (2, 'Jose Ruy Bonjorno');
INSERT INTO autor (cd_autor, nm_autor) VALUES (3, 'Alice Oseman');
INSERT INTO autor (cd_autor, nm_autor) VALUES (4, 'Rachael Lippincott');
INSERT INTO autor (cd_autor, nm_autor) VALUES (5, 'Alyson Derrick');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES (1, 'Literatura');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES (2, 'Biografia');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES (3, 'Educação');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES (4, 'Filosofia');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES (5, 'Química');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES (6, 'Geografia');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES (7, 'Matemática');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES (8, 'Romance');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES (9, 'Young Adult');
INSERT INTO livro_categoria (cd_livro, cd_categoria) VALUES (1, 7);
INSERT INTO livro_categoria (cd_livro, cd_categoria) VALUES (2, 8);
INSERT INTO livro_categoria (cd_livro, cd_categoria) VALUES (3, 9);
INSERT INTO livro_categoria (cd_livro, cd_categoria) VALUES (4, 8);
INSERT INTO localizacao (cd_localizacao, nm_localizacao) VALUES (1, 'E02C01P01 - Estante 02 - Coluna 01 - Prateleira 01');
INSERT INTO localizacao (cd_localizacao, nm_localizacao) VALUES (2, 'E02C01P01 - Estante 01 - Coluna 01 - Prateleira 05');
INSERT INTO localizacao (cd_localizacao, nm_localizacao) VALUES (3, 'E02C01P01 - Estante 01 - Coluna 02 - Prateleira 05');
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (1, 1, 1, 3);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (2, 1, 0, 2);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (3, 1, 0, 3);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (1, 2, 0, 1);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (2, 2, 0, 3);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (3, 2, 0, 2);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (4, 2, 1, 1);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (5, 2, 0, 3);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (6, 2, 0, 1);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (1, 3, 0, 3);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (2, 3, 0, 2);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (3, 3, 0, 1);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (4, 3, 0, 2);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (1, 4, 0, 2);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (2, 4, 1, 2);
INSERT INTO exemplar (cd_exemplar, cd_livro, ic_fixo, cd_localizacao) VALUES (3, 4, 0, 3);
INSERT INTO tipo_usuario (cd_tipo_usuario, nm_tipo_usuario) VALUES (1, 'Admin');
INSERT INTO tipo_usuario (cd_tipo_usuario, nm_tipo_usuario) VALUES (2, 'Operador');
INSERT INTO tipo_usuario (cd_tipo_usuario, nm_tipo_usuario) VALUES (3, 'Cliente');
INSERT INTO usuario (nm_login, nm_usuario, nm_senha, ic_bloqueado, dt_bloqueio, cd_tipo_usuario) VALUES ('admin', 'Administrador', '123', 0, NULL, 1);
INSERT INTO usuario (nm_login, nm_usuario, nm_senha, ic_bloqueado, dt_bloqueio, cd_tipo_usuario) VALUES ('operador', 'Operador', '123', 0, NULL, 2);
INSERT INTO usuario (nm_login, nm_usuario, nm_senha, ic_bloqueado, dt_bloqueio, cd_tipo_usuario) VALUES ('36707', 'João Gabriel', '123', 1, "2022-12-22", 3);
INSERT INTO usuario (nm_login, nm_usuario, nm_senha, ic_bloqueado, dt_bloqueio, cd_tipo_usuario) VALUES ('36411', 'Vitoria Amaral Xavier', '123', 0, NULL, 3);
INSERT INTO usuario (nm_login, nm_usuario, nm_senha, ic_bloqueado, dt_bloqueio, cd_tipo_usuario) VALUES ('12577', 'Frederico Arco e Flexa Machado Justo', '123', 0, NULL, 3);
INSERT INTO tipo_emprestimo (cd_tipo_emprestimo, nm_tipo_emprestimo) VALUES (1, 'Consulta');
INSERT INTO tipo_emprestimo (cd_tipo_emprestimo, nm_tipo_emprestimo) VALUES (2, 'Empréstimo');
INSERT INTO tipo_ocorrencia (cd_tipo_ocorrencia, nm_tipo_ocorrencia) VALUES (1, 'Devolução com leve dano');
INSERT INTO tipo_ocorrencia (cd_tipo_ocorrencia, nm_tipo_ocorrencia) VALUES (2, 'Devolução com grave dano');
INSERT INTO livro_autor (cd_livro, cd_autor) VALUES (1, 1);
INSERT INTO livro_autor (cd_livro, cd_autor) VALUES (1, 2);
INSERT INTO livro_autor (cd_livro, cd_autor) VALUES (2, 3);
INSERT INTO livro_autor (cd_livro, cd_autor) VALUES (3, 3);
INSERT INTO livro_autor (cd_livro, cd_autor) VALUES (4, 4);
INSERT INTO livro_autor (cd_livro, cd_autor) VALUES (4, 5);
INSERT INTO emprestimo (nm_login, cd_exemplar, cd_livro, dt_emprestimo, hr_emprestimo, dt_devolucao_estimada, dt_devolucao, cd_tipo_emprestimo)
VALUES ('36411', 1, 1, '20220120', '200000', date_add(dt_emprestimo, interval 14 day), NULL, 2);
INSERT INTO emprestimo (nm_login, cd_exemplar, cd_livro, dt_emprestimo, hr_emprestimo, dt_devolucao_estimada, dt_devolucao, cd_tipo_emprestimo)
VALUES ('36411', 2, 2, '20220120', '200000', date_add(dt_emprestimo, interval 14 day), NULL, 2);
INSERT INTO emprestimo (nm_login, cd_exemplar, cd_livro, dt_emprestimo, hr_emprestimo, dt_devolucao_estimada, dt_devolucao, cd_tipo_emprestimo)
VALUES ('36411', 1, 3, '20220120', '200000', date_add(dt_emprestimo, interval 14 day), NULL, 2);
INSERT INTO emprestimo (nm_login, cd_exemplar, cd_livro, dt_emprestimo, hr_emprestimo, dt_devolucao_estimada, dt_devolucao, cd_tipo_emprestimo)
VALUES ('36707', 4, 2, '20220120', '200000', date_add(dt_emprestimo, interval 14 day), '20220322', 2);