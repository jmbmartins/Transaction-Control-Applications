USE [MEI_TRAB]
GO
/****** Object:  Table [dbo].[EncLinha]    Script Date: 20/10/2023 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EncLinha](
	[EncId] [int] NOT NULL,
	[ProdutoID] [int] NOT NULL,
	[Designacao] [nvarchar](50) NOT NULL,
	[Preco] [decimal](10, 2) NOT NULL,
	[Qtd] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_EncLinha] PRIMARY KEY CLUSTERED 
(
	[EncId] ASC,
	[ProdutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encomenda]    Script Date: 20/10/2023 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encomenda](
	[EncID] [int] NOT NULL,
	[ClienteID] [int] NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Morada] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Encomenda] PRIMARY KEY CLUSTERED 
(
	[EncID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogOperations]    Script Date: 20/10/2023 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogOperations](
	[NumReg] [int] IDENTITY(1,1) NOT NULL,
	[EventType] [char](1) NULL,
	[Objecto] [varchar](30) NULL,
	[Valor] [varchar](100) NULL,
	[Referencia] [varchar](100) NULL,
	[UserID] [nvarchar](30) NOT NULL,
	[TerminalD] [nvarchar](30) NOT NULL,
	[TerminalName] [nvarchar](30) NOT NULL,
	[DCriacao] [datetime] NOT NULL,
 CONSTRAINT [PK_LogOperations] PRIMARY KEY CLUSTERED 
(
	[NumReg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EncLinha] ADD  DEFAULT ((10.0)) FOR [Preco]
GO
ALTER TABLE [dbo].[EncLinha] ADD  DEFAULT ((1.0)) FOR [Qtd]
GO
ALTER TABLE [dbo].[Encomenda] ADD  DEFAULT ('Covilhã') FOR [Morada]
GO
ALTER TABLE [dbo].[LogOperations] ADD  DEFAULT (user_name()) FOR [UserID]
GO
ALTER TABLE [dbo].[LogOperations] ADD  DEFAULT (host_id()) FOR [TerminalD]
GO
ALTER TABLE [dbo].[LogOperations] ADD  DEFAULT (host_name()) FOR [TerminalName]
GO
ALTER TABLE [dbo].[LogOperations] ADD  DEFAULT (getdate()) FOR [DCriacao]
GO
ALTER TABLE [dbo].[EncLinha]  WITH CHECK ADD  CONSTRAINT [FK_EncId] FOREIGN KEY([EncId])
REFERENCES [dbo].[Encomenda] ([EncID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[EncLinha] CHECK CONSTRAINT [FK_EncId]
GO
ALTER TABLE [dbo].[EncLinha]  WITH CHECK ADD CHECK  (([Preco]>=(0.0)))
GO
ALTER TABLE [dbo].[EncLinha]  WITH CHECK ADD CHECK  (([Qtd]>=(0.0)))
GO
ALTER TABLE [dbo].[Encomenda]  WITH CHECK ADD CHECK  (([ClienteID]>=(1)))
GO
ALTER TABLE [dbo].[Encomenda]  WITH CHECK ADD CHECK  (([EncID]>=(1)))
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_ENCOMENDA]    Script Date: 20/10/2023 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ACTUALIZAR_ENCOMENDA]
AS 
  DECLARE @EncId int
  
  DECLARE @N_Linhas int
  
  -- Obter a quantidade de encomendas
  Select @N_Linhas  = Count (*) From Encomenda
  
  DECLARE @Random INT, @Upper INT, @Lower INT
  
  -- Limites para a geração de números aleatórios
  Set @Lower = 1;   -- Menor valor
  Set @Upper = @N_Linhas; -- Maior valor
  
  -- Escolher aleatóriamente a linha a encomendar
  Set @Random = ROUND(((@Upper - @Lower -1)* RAND() + @Lower), 0);
  
  -- Obter o ID da encomenda na linha "Random"
  Select @EncId = EncId
  from ( SELECT Row_Number() Over (Order By EncId) as N_Linha, [EncID]
         FROM Encomenda) AS X
  Where N_LInha = @Random

  -- Alterar o campo Morada para o instante corrente 
  Update Encomenda 
    Set Morada = CONVERT(varchar,GETDATE(),121)
  Where EncId = @EncId
  
GO
/****** Object:  StoredProcedure [dbo].[APAGAR_ENCOMENDA]    Script Date: 20/10/2023 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Apaga uma encomenda

CREATE PROCEDURE [dbo].[APAGAR_ENCOMENDA]
AS 
  DECLARE @EncId int
  
  DECLARE @N_Linhas int
  
  -- Obter a quantidade de encomendas
  Select @N_Linhas  = Count (*) From Encomenda
  
  DECLARE @Random INT, @Upper INT, @Lower INT
  
  -- Limites para a geração de números aleatórios
  Set @Lower = 1;   -- Menor valor
  Set @Upper = @N_Linhas; -- Maior valor
  
  -- Escolher aleatóriamente a linha a apagar
  Set @Random = ROUND(((@Upper - @Lower -1)* RAND() + @Lower), 0);
  
  -- Obter o ID da encomenda na linha "Random"
  Select @EncId = EncId
  from ( SELECT Row_Number() Over (Order By EncId) as N_Linha, [EncID]
         FROM Encomenda) AS X
  Where N_LInha = @Random

  Delete From EncLinha Where EncId = @EncId
  Delete From Encomenda Where EncId = @EncId
  
GO
/****** Object:  StoredProcedure [dbo].[INSERIR_ENCOMENDA]    Script Date: 20/10/2023 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insere uma nova encomenda

CREATE PROCEDURE [dbo].[INSERIR_ENCOMENDA]
AS 
  DECLARE @EncId int
  
  DECLARE @MAX_TRY int
  DECLARE @NTry int

  SET @MAX_TRY = 20;    -- Max number of times to try

  SET @NTry = 1;     

  -- try to insert the new Encomenda
  WHILE (@NTry <= @MAX_TRY)
  BEGIN 
    Set @NTry = @NTry +1;   
     
    -- get next EncId
    Select @EncId = Max(EncId) From Encomenda;     

    IF (@EncId IS NULL)
      SET @EncId = 1;
    ELSE
      SET @EncId = @EncId +1;

    -- Inserir  encomenda
    INSERT INTO Encomenda Values (@EncId, 1000, 'Fernando Pessoa', 'Lisboa');

    IF (@@ERROR = 0)    -- Success!
	BEGIN
	  -- Inserir linhas da encomenda 
      INSERT INTO EncLinha Values (@EncId, 111, 'Mensagem', 2500, 2);
      INSERT INTO EncLinha Values (@EncId, 131, 'Livro do Desassossego', 3000, 1);
	
      BREAK  -- Sucesso, hora de sair!
	END
  END  -- Fim de ciclo
    
  IF ( @NTry > @MAX_TRY)
  BEGIN
    RAISERROR('Can''t insert the record',16,1 )
    ROLLBACK TRANSACTION
  END
GO
